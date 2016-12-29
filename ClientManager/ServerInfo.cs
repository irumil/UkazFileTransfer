using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ClientManager.FileTransferServiceReference;

namespace ClientManager
{
    public enum ServerStatus
    {
        CheckServerState,       // проверка статуса сервера
        ServerAvailable,        // сервер доступен
        ServerNotAvailable,     // сервер не доступен
        FileStatusEmpty,        // пусто
        FileTransferStart,      // старт передачи файла
        FileTransfered,         // файл передан
        FileError,              // ошибка пердачи файла 
        FileCheckProcessing,    // старт проверки обработки файла
        FileProcessed,          // файл обработан
        FileNotProcessed,       // файл ещё не обработан  
        ServiceError            // ошибка пердачи файла 
    }

    [Serializable]
    public class ServerInfo: INotifyPropertyChanged
    {
        #region Private Fields
        private bool _needCopy;
        private string _ipAdress;
        private string _description;
        private string _movePath;
        private string _info;
        private string _fileName;
        private int _errorCount;
        private long _length;
        private string _errorText;
        private Image _iconStatus = Properties.Resources.empty;
        private string _percentComplete;
        private readonly Dictionary<ServerStatus, Action> _serverStatusCollection;

        private const string Password = "380318++";
        #endregion Private Fileds  

        
        public ServerInfo()
        {
            _serverStatusCollection = new Dictionary<ServerStatus, Action>();
            _serverStatusCollection.Add(ServerStatus.FileStatusEmpty, () =>
            {
                _iconStatus = Properties.Resources.empty;
                _info = string.Empty;
            });
            _serverStatusCollection.Add(ServerStatus.CheckServerState, () =>
            {
                _iconStatus = Properties.Resources.search_server;
                _info = "Проверка сервера...";
            });
            _serverStatusCollection.Add(ServerStatus.ServerAvailable, () =>
            {
                _iconStatus = Properties.Resources.serverAvailable;
                _info = "Cервер доступен";
            });
            _serverStatusCollection.Add(ServerStatus.ServerNotAvailable, () =>
            {
                _iconStatus = Properties.Resources.serverNotAvailable;
                _info = "Сервер НЕ доступен!!!";
            });
            _serverStatusCollection.Add(ServerStatus.FileTransferStart, () =>
            {
                _iconStatus = Properties.Resources.start;
                _info = string.Format("Старт передачи файла {0}... попытка {1}", _fileName, _errorCount);
            });
            _serverStatusCollection.Add(ServerStatus.FileTransfered, () =>
            {
                _iconStatus = Properties.Resources.save_ok;
                _info = string.Format("Файл {0} передан и скопирован куда надо!", _fileName);
                PercentComplete = string.Empty;
            });
            _serverStatusCollection.Add(ServerStatus.FileCheckProcessing, () =>
            {
                _iconStatus = Properties.Resources.processing;
                _info = string.Format("Проверка обработки файла {0}...", _fileName);
            });
            _serverStatusCollection.Add(ServerStatus.FileProcessed, () =>
            {
                _iconStatus = Properties.Resources.success;
                _info = string.Format("Файл '{0}' подключен", _fileName);
            });
            _serverStatusCollection.Add(ServerStatus.FileNotProcessed, () =>
            {
                _iconStatus = Properties.Resources.alert;
                _info = string.Format("Файл '{0}' Ещё не подключен", _fileName);
            });
            _serverStatusCollection.Add(ServerStatus.ServiceError, () =>
            {
                _iconStatus = Properties.Resources.error;
                _info = string.Format("Ошибка: {0}", _errorText);
            });
        }
        

        [DisplayName(@"Копировать")]
        public bool NeedCopy
        {
            get{return _needCopy;}
            set 
            { 
                _needCopy = value; 
                OnPropertyChanged("NeedCopy");
            }
        }

        [DisplayName(@"IP Адрес")]
        public string IpAdress
        {
            get { return _ipAdress; }
            set
            {
                _ipAdress = value;
                OnPropertyChanged("IpAdress");
            }
        }

        [DisplayName(@"Описание")]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        [DisplayName(@"Путь для перемещения")]
        public string MovePath
        {
            get { return _movePath; }
            set
            {
                _movePath = value;
                OnPropertyChanged("MovePath");
            }
        }

        [XmlIgnore]
        [Browsable(false)]
        public ServerStatus ServerStatus
        {
            set
            {
                _serverStatusCollection[value].Invoke();
                //говорим подписчику свойсва что изменился статус
                OnPropertyChanged("IconStatus");
                OnPropertyChanged("StatusInfo");
            }
        }

        [XmlIgnore]
        [DisplayName(@"Статус Инфо")]
        public string StatusInfo
        {
            get { return _info; }
        }

        [XmlIgnore]
        [DisplayName(@"%")]
        public string PercentComplete
        {
            get { return _percentComplete; }
            set
            {
                _percentComplete = value;
                OnPropertyChanged("PercentComplete");
            } 
        }

        [XmlIgnore]
        public Image IconStatus
        {
            get{ return _iconStatus;}
        }
        
        [XmlIgnore]
        [Browsable(false)]
        public long Length { get; set; }

        [XmlIgnore]
        [Browsable(false)]
        public string ErrorText { get; set; }

        [XmlIgnore]
        [Browsable(false)]
        public string FileName{ get; set ; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(name));
        }
        
        private FileTransferServiceClient GetClient()
        {
            var client = new FileTransferServiceClient();

            client.Endpoint.Address =
                new EndpointAddress(string.Format("http://{0}:8733/FileService/mex", _ipAdress));

            var externalBinding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = 10067108864,
                TransferMode = TransferMode.Streamed,
                MessageEncoding = WSMessageEncoding.Mtom
            };

            client.Endpoint.Binding = externalBinding;

            return client;
        }

        public async void CheckServiceAsync()
        {
            ServerStatus = ServerStatus.CheckServerState;
           
            try
            {
                var mexClient = new MetadataExchangeClient(new Uri(string.Format("http://{0}:8733/FileService", _ipAdress)),
                        MetadataExchangeClientMode.HttpGet);

                MetadataSet metadata = await mexClient.GetMetadataAsync();
                
                ServerStatus = ServerStatus.ServerAvailable;
            }
            catch (Exception ex)
            {
                SetExceptionStatus(ex);
            }
        }

        public async void SendFileToServiceAsync(string fileName)
        {
            if ((fileName == string.Empty) && (_movePath == string.Empty)) 
                throw new Exception("Не указан файл для отправки или директория для перемещения");

            var transferOk = false;
            _errorCount=1;

            while (!transferOk && _errorCount!=4)
            {
                var client = GetClient();

                try
                {
                    var fileInfo = new FileInfo(fileName);
                    _fileName = fileInfo.Name;
                    _length = fileInfo.Length;

                    ServerStatus = ServerStatus.FileTransferStart;

                    using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var uploadStreamWithProgress = new StreamWithProgress(stream))
                        {
                            uploadStreamWithProgress.ProgressChanged += uploadStreamWithProgress_ProgressChanged;
                            await client.SendFileAsync(_movePath, _fileName, _length, Password, uploadStreamWithProgress);
                            ServerStatus = ServerStatus.FileTransfered;

                            transferOk = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //счетчик
                    _errorCount++;
                    SetExceptionStatus(ex);
                    Thread.Sleep(3000);
                }
                finally
                {
                    client.Close();
                }
            }
        }

        private void uploadStreamWithProgress_ProgressChanged(object sender, StreamWithProgress.ProgressChangedEventArgs e)
        {
            if (e.Length != 0)
            {
                PercentComplete = (e.BytesRead * 100 / e.Length) + "%";
            }
        }

        public async void CheckStatusFileOnServerAsync(string fileName)
        {
            var client = GetClient();

            try
            {
                ServerStatus = ServerStatus.FileCheckProcessing;

                var file = new FileInfo(fileName);
                _fileName = file.Name;

                bool result = await client.IsFileProcessedAsync(Path.Combine(_fileName, _movePath, _fileName));

                ServerStatus serverStatus = result ? ServerStatus.FileProcessed : ServerStatus.FileNotProcessed;
                ServerStatus = serverStatus;
            }
            catch (Exception ex)
            {
                SetExceptionStatus(ex);
            }
            finally
            {
                client.Close();
            }
        }

        private void SetExceptionStatus(Exception ex)
        {
            _errorText = ex.Message;

            

            if (ex.InnerException != null)
            {
                _errorText = ex.InnerException.Message;
            }

            ServerStatus = ServerStatus.ServiceError;
        }

        private void SetExceptionStatus(Exception ex, int errorCnt)
        {
            _errorText = ex.Message + " "+errorCnt;
            

            if (ex.InnerException != null)
            {
                _errorText = ex.InnerException.Message+" "+errorCnt;
            }

            ServerStatus = ServerStatus.ServiceError;
        }
    }
}
