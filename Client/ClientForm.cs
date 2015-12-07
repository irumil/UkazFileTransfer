using System;
using System.Text;
using System.Windows.Forms;
using ClientManager;

namespace Client
{
    public partial class ClientForm : Form
    {
        private ServerInfoManager _serverInfoManager;
        
        public ClientForm()
        {
            InitializeComponent(); 
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = FileTextBox.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            _serverInfoManager = new ServerInfoManager();

            _serverInfoManager.UpdateLog += AppendLogToListBox;
            serverInfoDataGridView.DataSource = _serverInfoManager.GetServerList();
        }

        private void AppendLogToListBox(string info)
        {
            LogListBox.Items.Add(info);
            LogListBox.SelectedIndex = LogListBox.Items.Count-1;
        }

        private void checkServiceButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            checkServiceButton.Enabled = false;
            try
            {
                _serverInfoManager.StartCkeckService();
                sendUkazButton.Enabled = true;
            }
            catch
            {
                sendUkazButton.Enabled = false;
            }
            finally
            {
                Cursor = Cursors.Default;
                checkServiceButton.Enabled = true;
            }
        }

        private void sendUkazButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Начинаем отправку фала на сервера?", @"Подтвердить",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;
            
            Cursor = Cursors.WaitCursor;
            sendUkazButton.Enabled = false;
            try
            {
                _serverInfoManager.StartTransferFiles(FileTextBox.Text);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            checkButton.Enabled = false;
            try
            {
                _serverInfoManager.StartCheckStatusFiles(FileTextBox.Text);
            }
            finally
            {
                Cursor = Cursors.Default;
                checkButton.Enabled = true;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _serverInfoManager.AddServer();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(@"Удалить", @"Подтвердить",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if ((result == DialogResult.Yes) && (serverInfoDataGridView.CurrentRow != null))
                {
                    _serverInfoManager.DeleteServer(serverInfoDataGridView.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Ошибка "+ ex.Message+ ex.InnerException.Message);
            }
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            _serverInfoManager.SaveServerList();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_serverInfoManager.IsServerListChanged) return;

            var result = MessageBox.Show( @"Список серверов был изменен, сохранить изменения?",@"Подтвердить",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) 
            {
                _serverInfoManager.SaveServerList();
            }
            
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("Программа разработана для подключения массива М122 систем АСУ УЗЕЛ, АСУ СТ");
            info.AppendLine("В инструкции есть подробное описание работы с программой");
            info.AppendLine("ЛОИС Семей 2015г");
            MessageBox.Show(info.ToString());
        }

        private void serverInfoDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //
        }
    }
}
