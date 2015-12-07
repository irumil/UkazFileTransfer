using System;
using System.IO;

namespace FileService
{
    public class FileTransferService: IFileTransferService
    {
        // куда будем помещать принятый файл
        private readonly string _directoryUpload = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadUkazFile");

        public void LogWrite(string info)
        {
            Console.WriteLine("[{0}] {1}", DateTime.Now, info);
        }

        public FileTransferService ()
        {
            CreateUploadFolderIfNeed();
        }

        private void CreateUploadFolderIfNeed()
        {
            // создаем папку для входящего файла
            if (!Directory.Exists(_directoryUpload))
            {
                LogWrite(string.Format("Создаем папку для сохранения полученных файлов {0}", _directoryUpload));
                Directory.CreateDirectory(_directoryUpload);
            }
        }

        private void CreateDestinationFolder(string moveDirectory)
        {
            //создаем папку для перемещения
            if (!Directory.Exists(moveDirectory))
            {
                LogWrite(string.Format("Создаем папку для перемещения файла {0}", moveDirectory));
                Directory.CreateDirectory(moveDirectory);
            }
        }

        public void SendFile(UkazFileInfo ukazFileInfo)
        {
            //проверка пароля
            if (!IsValidPassword(ukazFileInfo.Password)) return;

            CreateUploadFolderIfNeed();
            CreateDestinationFolder(ukazFileInfo.FileMovePath); 

            // Получаем информацию о входящем файле
            LogWrite(string.Format("Старт загрузки {0} Размер файла {1}", ukazFileInfo.FileName,ukazFileInfo.Length));

            string filePath = Path.Combine(_directoryUpload, ukazFileInfo.FileName);

            // удаляем если такой уже есть
            if (File.Exists(filePath)) File.Delete(filePath);

            const int chunkSize = 2048;
            byte[] buffer = new byte[chunkSize];

            using (var writeStream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
            {
                do
                {
                    // читаем байты из потока
                    int bytesRead = ukazFileInfo.FileByteStream.Read(buffer, 0, chunkSize);
                    if (bytesRead == 0) break;

                    // пишем байты в файл
                    writeStream.Write(buffer, 0, bytesRead);
                } while (true);

                LogWrite("Получен!");
                writeStream.Close();
            }
            
            if (moveFile(filePath, Path.Combine(ukazFileInfo.FileMovePath, ukazFileInfo.FileName)))
            {
                LogWrite(string.Format("Перемещен в папку назначения {0}",Path.Combine(ukazFileInfo.FileMovePath, ukazFileInfo.FileName)));
            }
        }

        public bool IsFileProcessed(string fileName)
        {
            //проверяем прошел ли файл обработки и удален
            if (!File.Exists(fileName)) return true;
            return false;
        }

        private bool moveFile(string sourceFileName, string destinationFileName)
        {
            // если такой есть то удаляем
            if (File.Exists(destinationFileName)) File.Delete(destinationFileName);
            // перемещаем файл
            File.Move(sourceFileName, destinationFileName);
            //быстро проверяем есть ли он там
            if (File.Exists(destinationFileName)) return true;
            return false;
        }
       
        private string ReadPassword()
        {
            return "380318++";
        }

        public UkazFileInfo DownloadFile(UkazFileInfo request)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPassword(string password)
        {
            return ReadPassword() == password;
        }
    }
}
