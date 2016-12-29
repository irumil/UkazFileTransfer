namespace Client
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.serverInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkServiceButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.saveListButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.sendUkazButton = new System.Windows.Forms.Button();
            this.NeedCopy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IpAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentComplete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iconStatus = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LogListBox
            // 
            this.LogListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.IntegralHeight = false;
            this.LogListBox.Location = new System.Drawing.Point(5, 335);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(836, 197);
            this.LogListBox.TabIndex = 16;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Location = new System.Drawing.Point(766, 10);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 15;
            this.BrowseButton.Text = "Открыть";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FileTextBox
            // 
            this.FileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTextBox.Location = new System.Drawing.Point(94, 12);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.Size = new System.Drawing.Size(666, 20);
            this.FileTextBox.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // serverInfoDataGridView
            // 
            this.serverInfoDataGridView.AllowUserToAddRows = false;
            this.serverInfoDataGridView.AllowUserToDeleteRows = false;
            this.serverInfoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverInfoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.serverInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serverInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NeedCopy,
            this.IpAdress,
            this.Description,
            this.MovePath,
            this.status,
            this.PercentComplete,
            this.iconStatus});
            this.serverInfoDataGridView.Location = new System.Drawing.Point(5, 82);
            this.serverInfoDataGridView.Name = "serverInfoDataGridView";
            this.serverInfoDataGridView.RowHeadersWidth = 25;
            this.serverInfoDataGridView.Size = new System.Drawing.Size(836, 247);
            this.serverInfoDataGridView.TabIndex = 26;
            this.serverInfoDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.serverInfoDataGridView_DataError);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Файл массива:";
            // 
            // checkServiceButton
            // 
            this.checkServiceButton.Image = global::Client.Properties.Resources.search_server_icon32;
            this.checkServiceButton.Location = new System.Drawing.Point(5, 36);
            this.checkServiceButton.Name = "checkServiceButton";
            this.checkServiceButton.Size = new System.Drawing.Size(40, 40);
            this.checkServiceButton.TabIndex = 35;
            this.toolTip1.SetToolTip(this.checkServiceButton, "Проверка доступности серверов");
            this.checkServiceButton.UseVisualStyleBackColor = true;
            this.checkServiceButton.Click += new System.EventHandler(this.checkServiceButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.Image = global::Client.Properties.Resources.information_3114;
            this.aboutButton.Location = new System.Drawing.Point(801, 36);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(40, 40);
            this.aboutButton.TabIndex = 34;
            this.toolTip1.SetToolTip(this.aboutButton, "О программе");
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // saveListButton
            // 
            this.saveListButton.Image = global::Client.Properties.Resources.server_icon_save;
            this.saveListButton.Location = new System.Drawing.Point(284, 36);
            this.saveListButton.Name = "saveListButton";
            this.saveListButton.Size = new System.Drawing.Size(40, 40);
            this.saveListButton.TabIndex = 33;
            this.toolTip1.SetToolTip(this.saveListButton, "Сохранить изменения списка");
            this.saveListButton.UseVisualStyleBackColor = true;
            this.saveListButton.Click += new System.EventHandler(this.saveListButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::Client.Properties.Resources.desable_server_icon;
            this.deleteButton.Location = new System.Drawing.Point(242, 36);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(40, 40);
            this.deleteButton.TabIndex = 32;
            this.toolTip1.SetToolTip(this.deleteButton, "Удалить сервер");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = global::Client.Properties.Resources.add_server_icon__1_;
            this.addButton.Location = new System.Drawing.Point(200, 36);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(40, 40);
            this.addButton.TabIndex = 31;
            this.toolTip1.SetToolTip(this.addButton, "Добавить новый сервер");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Image = global::Client.Properties.Resources.client22;
            this.checkButton.Location = new System.Drawing.Point(119, 36);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(62, 40);
            this.checkButton.TabIndex = 29;
            this.toolTip1.SetToolTip(this.checkButton, "Проверка подключения массива");
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // sendUkazButton
            // 
            this.sendUkazButton.Enabled = false;
            this.sendUkazButton.Image = global::Client.Properties.Resources.Untitled_92;
            this.sendUkazButton.Location = new System.Drawing.Point(48, 36);
            this.sendUkazButton.Name = "sendUkazButton";
            this.sendUkazButton.Size = new System.Drawing.Size(68, 40);
            this.sendUkazButton.TabIndex = 28;
            this.toolTip1.SetToolTip(this.sendUkazButton, "Старт передачи файла массива");
            this.sendUkazButton.UseVisualStyleBackColor = true;
            this.sendUkazButton.Click += new System.EventHandler(this.sendUkazButton_Click);
            // 
            // NeedCopy
            // 
            this.NeedCopy.DataPropertyName = "NeedCopy";
            this.NeedCopy.HeaderText = "Копировать";
            this.NeedCopy.Name = "NeedCopy";
            this.NeedCopy.Width = 70;
            // 
            // IpAdress
            // 
            this.IpAdress.DataPropertyName = "IpAdress";
            this.IpAdress.HeaderText = "Ip Адрес";
            this.IpAdress.Name = "IpAdress";
            this.IpAdress.Width = 80;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Описание";
            this.Description.Name = "Description";
            this.Description.Width = 120;
            // 
            // MovePath
            // 
            this.MovePath.DataPropertyName = "MovePath";
            this.MovePath.HeaderText = "Путь для перемещения";
            this.MovePath.Name = "MovePath";
            // 
            // status
            // 
            this.status.DataPropertyName = "StatusInfo";
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 350;
            // 
            // PercentComplete
            // 
            this.PercentComplete.DataPropertyName = "PercentComplete";
            this.PercentComplete.HeaderText = "%";
            this.PercentComplete.Name = "PercentComplete";
            this.PercentComplete.ReadOnly = true;
            this.PercentComplete.Width = 45;
            // 
            // iconStatus
            // 
            this.iconStatus.DataPropertyName = "IconStatus";
            this.iconStatus.HeaderText = "";
            this.iconStatus.Name = "iconStatus";
            this.iconStatus.ReadOnly = true;
            this.iconStatus.Width = 30;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 540);
            this.Controls.Add(this.checkServiceButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.saveListButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.sendUkazButton);
            this.Controls.Add(this.serverInfoDataGridView);
            this.Controls.Add(this.LogListBox);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.FileTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(773, 578);
            this.Name = "ClientForm";
            this.Text = "Подключение массива";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox FileTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView serverInfoDataGridView;
        private System.Windows.Forms.Button sendUkazButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveListButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button checkServiceButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NeedCopy;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentComplete;
        private System.Windows.Forms.DataGridViewImageColumn iconStatus;
    }
}

