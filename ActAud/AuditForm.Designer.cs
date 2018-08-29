namespace ActAud
{
    partial class AuditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditForm));
			this.tPgAuditSystemEvents = new System.Windows.Forms.TabPage();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.gbCurrentLog = new System.Windows.Forms.GroupBox();
			this.CurrentLogDataGrid = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.gbFilter = new System.Windows.Forms.GroupBox();
			this.rbByComputer = new System.Windows.Forms.RadioButton();
			this.rbByDate = new System.Windows.Forms.RadioButton();
			this.rbByMessageType = new System.Windows.Forms.RadioButton();
			this.rbByID = new System.Windows.Forms.RadioButton();
			this.EventTypeFilterComboBox = new System.Windows.Forms.ComboBox();
			this.RefreshCurrentLogButton = new System.Windows.Forms.Button();
			this.ToFilterDatePicker = new System.Windows.Forms.DateTimePicker();
			this.RefreshCurrentLogWithFilterButton = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.EraseCurrentLogButton = new System.Windows.Forms.Button();
			this.FromFilterDatePicker = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.InstanceIdFilterTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.MachineNameFilterTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.rtbMonitoredEvents = new System.Windows.Forms.RichTextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.StartEventMonitoringButton = new System.Windows.Forms.Button();
			this.gbSystemEventsList = new System.Windows.Forms.GroupBox();
			this.EventLogsTreeView = new System.Windows.Forms.TreeView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.RefreshEventLogsButton = new System.Windows.Forms.ToolStripButton();
			this.tcAuditFileSystem = new System.Windows.Forms.TabControl();
			this.tPgAuditFileSystem = new System.Windows.Forms.TabPage();
			this.gbInformation = new System.Windows.Forms.GroupBox();
			this.rtbInformation = new System.Windows.Forms.RichTextBox();
			this.pnElements = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.FileCatalogTextBox = new System.Windows.Forms.TextBox();
			this.clbActions = new System.Windows.Forms.CheckedListBox();
			this.StopFileWatcherButton = new System.Windows.Forms.Button();
			this.ClearFileWatcherLog = new System.Windows.Forms.Button();
			this.StartFileWatcherButton = new System.Windows.Forms.Button();
			this.tbPgAuditDevices = new System.Windows.Forms.TabPage();
			this.lsbAuditDevices = new System.Windows.Forms.ListBox();
			this.tPgAuditSystemEvents.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.gbCurrentLog.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CurrentLogDataGrid)).BeginInit();
			this.panel1.SuspendLayout();
			this.gbFilter.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.panel2.SuspendLayout();
			this.gbSystemEventsList.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tcAuditFileSystem.SuspendLayout();
			this.tPgAuditFileSystem.SuspendLayout();
			this.gbInformation.SuspendLayout();
			this.pnElements.SuspendLayout();
			this.tbPgAuditDevices.SuspendLayout();
			this.SuspendLayout();
			// 
			// tPgAuditSystemEvents
			// 
			this.tPgAuditSystemEvents.Controls.Add(this.splitter1);
			this.tPgAuditSystemEvents.Controls.Add(this.tabControl3);
			this.tPgAuditSystemEvents.Controls.Add(this.gbSystemEventsList);
			this.tPgAuditSystemEvents.Location = new System.Drawing.Point(4, 22);
			this.tPgAuditSystemEvents.Name = "tPgAuditSystemEvents";
			this.tPgAuditSystemEvents.Padding = new System.Windows.Forms.Padding(3);
			this.tPgAuditSystemEvents.Size = new System.Drawing.Size(1422, 543);
			this.tPgAuditSystemEvents.TabIndex = 1;
			this.tPgAuditSystemEvents.Text = "Мониторинг системных событий";
			this.tPgAuditSystemEvents.UseVisualStyleBackColor = true;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(323, 3);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(5, 537);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// tabControl3
			// 
			this.tabControl3.Controls.Add(this.tabPage5);
			this.tabControl3.Controls.Add(this.tabPage6);
			this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl3.Location = new System.Drawing.Point(323, 3);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(1096, 537);
			this.tabControl3.TabIndex = 2;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.gbCurrentLog);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(1088, 511);
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "Просмотр журналов событий";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// gbCurrentLog
			// 
			this.gbCurrentLog.Controls.Add(this.CurrentLogDataGrid);
			this.gbCurrentLog.Controls.Add(this.panel1);
			this.gbCurrentLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbCurrentLog.Location = new System.Drawing.Point(3, 3);
			this.gbCurrentLog.Name = "gbCurrentLog";
			this.gbCurrentLog.Size = new System.Drawing.Size(1082, 505);
			this.gbCurrentLog.TabIndex = 1;
			this.gbCurrentLog.TabStop = false;
			this.gbCurrentLog.Text = "Выбранный журнал";
			// 
			// CurrentLogDataGrid
			// 
			this.CurrentLogDataGrid.AllowUserToAddRows = false;
			this.CurrentLogDataGrid.AllowUserToDeleteRows = false;
			this.CurrentLogDataGrid.AllowUserToResizeRows = false;
			this.CurrentLogDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.CurrentLogDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.CurrentLogDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
			this.CurrentLogDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CurrentLogDataGrid.Location = new System.Drawing.Point(3, 16);
			this.CurrentLogDataGrid.Name = "CurrentLogDataGrid";
			this.CurrentLogDataGrid.RowHeadersVisible = false;
			this.CurrentLogDataGrid.RowHeadersWidth = 71;
			this.CurrentLogDataGrid.Size = new System.Drawing.Size(1076, 322);
			this.CurrentLogDataGrid.TabIndex = 0;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Идентификатор";
			this.Column1.Name = "Column1";
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Тип сообщения";
			this.Column2.Name = "Column2";
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Дата";
			this.Column3.Name = "Column3";
			// 
			// Column4
			// 
			this.Column4.HeaderText = "Компьютер";
			this.Column4.Name = "Column4";
			// 
			// Column5
			// 
			this.Column5.HeaderText = "Сообщение";
			this.Column5.Name = "Column5";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.gbFilter);
			this.panel1.Controls.Add(this.EventTypeFilterComboBox);
			this.panel1.Controls.Add(this.RefreshCurrentLogButton);
			this.panel1.Controls.Add(this.ToFilterDatePicker);
			this.panel1.Controls.Add(this.RefreshCurrentLogWithFilterButton);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.EraseCurrentLogButton);
			this.panel1.Controls.Add(this.FromFilterDatePicker);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.InstanceIdFilterTextBox);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.MachineNameFilterTextBox);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 338);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1076, 164);
			this.panel1.TabIndex = 17;
			// 
			// gbFilter
			// 
			this.gbFilter.Controls.Add(this.rbByComputer);
			this.gbFilter.Controls.Add(this.rbByDate);
			this.gbFilter.Controls.Add(this.rbByMessageType);
			this.gbFilter.Controls.Add(this.rbByID);
			this.gbFilter.Location = new System.Drawing.Point(386, 14);
			this.gbFilter.Name = "gbFilter";
			this.gbFilter.Size = new System.Drawing.Size(146, 123);
			this.gbFilter.TabIndex = 4;
			this.gbFilter.TabStop = false;
			this.gbFilter.Text = "Фильтрация";
			// 
			// rbByComputer
			// 
			this.rbByComputer.AutoSize = true;
			this.rbByComputer.Location = new System.Drawing.Point(11, 93);
			this.rbByComputer.Name = "rbByComputer";
			this.rbByComputer.Size = new System.Drawing.Size(104, 17);
			this.rbByComputer.TabIndex = 3;
			this.rbByComputer.TabStop = true;
			this.rbByComputer.Text = "По компьютеру";
			this.rbByComputer.UseVisualStyleBackColor = true;
			// 
			// rbByDate
			// 
			this.rbByDate.AutoSize = true;
			this.rbByDate.Location = new System.Drawing.Point(11, 70);
			this.rbByDate.Name = "rbByDate";
			this.rbByDate.Size = new System.Drawing.Size(65, 17);
			this.rbByDate.TabIndex = 2;
			this.rbByDate.TabStop = true;
			this.rbByDate.Text = "По дате";
			this.rbByDate.UseVisualStyleBackColor = true;
			// 
			// rbByMessageType
			// 
			this.rbByMessageType.AutoSize = true;
			this.rbByMessageType.Location = new System.Drawing.Point(11, 47);
			this.rbByMessageType.Name = "rbByMessageType";
			this.rbByMessageType.Size = new System.Drawing.Size(124, 17);
			this.rbByMessageType.TabIndex = 1;
			this.rbByMessageType.TabStop = true;
			this.rbByMessageType.Text = "По типу сообщения";
			this.rbByMessageType.UseVisualStyleBackColor = true;
			// 
			// rbByID
			// 
			this.rbByID.AutoSize = true;
			this.rbByID.Location = new System.Drawing.Point(11, 24);
			this.rbByID.Name = "rbByID";
			this.rbByID.Size = new System.Drawing.Size(125, 17);
			this.rbByID.TabIndex = 0;
			this.rbByID.TabStop = true;
			this.rbByID.Text = "По идентификатору";
			this.rbByID.UseVisualStyleBackColor = true;
			// 
			// EventTypeFilterComboBox
			// 
			this.EventTypeFilterComboBox.FormattingEnabled = true;
			this.EventTypeFilterComboBox.Location = new System.Drawing.Point(254, 41);
			this.EventTypeFilterComboBox.Name = "EventTypeFilterComboBox";
			this.EventTypeFilterComboBox.Size = new System.Drawing.Size(108, 21);
			this.EventTypeFilterComboBox.TabIndex = 16;
			// 
			// RefreshCurrentLogButton
			// 
			this.RefreshCurrentLogButton.Location = new System.Drawing.Point(14, 14);
			this.RefreshCurrentLogButton.Name = "RefreshCurrentLogButton";
			this.RefreshCurrentLogButton.Size = new System.Drawing.Size(140, 37);
			this.RefreshCurrentLogButton.TabIndex = 1;
			this.RefreshCurrentLogButton.Text = "Просмотр выбранного журнала";
			this.RefreshCurrentLogButton.UseVisualStyleBackColor = true;
			this.RefreshCurrentLogButton.Click += new System.EventHandler(this.OnRefreshCurrentLogButtonClick);
			// 
			// ToFilterDatePicker
			// 
			this.ToFilterDatePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
			this.ToFilterDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.ToFilterDatePicker.Location = new System.Drawing.Point(191, 132);
			this.ToFilterDatePicker.Name = "ToFilterDatePicker";
			this.ToFilterDatePicker.ShowCheckBox = true;
			this.ToFilterDatePicker.Size = new System.Drawing.Size(171, 20);
			this.ToFilterDatePicker.TabIndex = 15;
			// 
			// RefreshCurrentLogWithFilterButton
			// 
			this.RefreshCurrentLogWithFilterButton.Location = new System.Drawing.Point(14, 59);
			this.RefreshCurrentLogWithFilterButton.Name = "RefreshCurrentLogWithFilterButton";
			this.RefreshCurrentLogWithFilterButton.Size = new System.Drawing.Size(140, 43);
			this.RefreshCurrentLogWithFilterButton.TabIndex = 2;
			this.RefreshCurrentLogWithFilterButton.Text = "Просмотр выбранного журнала с фильтрацией";
			this.RefreshCurrentLogWithFilterButton.UseVisualStyleBackColor = true;
			this.RefreshCurrentLogWithFilterButton.Click += new System.EventHandler(this.OnRefreshCurrentLogWithFilterButtonClick);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(164, 131);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(19, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "до";
			// 
			// EraseCurrentLogButton
			// 
			this.EraseCurrentLogButton.Location = new System.Drawing.Point(14, 108);
			this.EraseCurrentLogButton.Name = "EraseCurrentLogButton";
			this.EraseCurrentLogButton.Size = new System.Drawing.Size(140, 36);
			this.EraseCurrentLogButton.TabIndex = 3;
			this.EraseCurrentLogButton.Text = "Очистить выбранный журнал";
			this.EraseCurrentLogButton.UseVisualStyleBackColor = true;
			this.EraseCurrentLogButton.Click += new System.EventHandler(this.OnEraseCurrentLogButtonClick);
			// 
			// FromFilterDatePicker
			// 
			this.FromFilterDatePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
			this.FromFilterDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.FromFilterDatePicker.Location = new System.Drawing.Point(191, 106);
			this.FromFilterDatePicker.Name = "FromFilterDatePicker";
			this.FromFilterDatePicker.ShowCheckBox = true;
			this.FromFilterDatePicker.Size = new System.Drawing.Size(171, 20);
			this.FromFilterDatePicker.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(160, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Идентификатор";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(164, 108);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(18, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "от";
			// 
			// InstanceIdFilterTextBox
			// 
			this.InstanceIdFilterTextBox.Location = new System.Drawing.Point(254, 14);
			this.InstanceIdFilterTextBox.Name = "InstanceIdFilterTextBox";
			this.InstanceIdFilterTextBox.Size = new System.Drawing.Size(108, 20);
			this.InstanceIdFilterTextBox.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(164, 89);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(33, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Дата";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(161, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Тип сообщения";
			// 
			// MachineNameFilterTextBox
			// 
			this.MachineNameFilterTextBox.Location = new System.Drawing.Point(254, 65);
			this.MachineNameFilterTextBox.Name = "MachineNameFilterTextBox";
			this.MachineNameFilterTextBox.Size = new System.Drawing.Size(108, 20);
			this.MachineNameFilterTextBox.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(164, 66);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Компьютер";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.rtbMonitoredEvents);
			this.tabPage6.Controls.Add(this.panel2);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(1088, 511);
			this.tabPage6.TabIndex = 1;
			this.tabPage6.Text = "Мониторинг событий";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// rtbMonitoredEvents
			// 
			this.rtbMonitoredEvents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbMonitoredEvents.Location = new System.Drawing.Point(0, 52);
			this.rtbMonitoredEvents.Name = "rtbMonitoredEvents";
			this.rtbMonitoredEvents.Size = new System.Drawing.Size(1088, 459);
			this.rtbMonitoredEvents.TabIndex = 0;
			this.rtbMonitoredEvents.Text = "";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.StartEventMonitoringButton);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1088, 52);
			this.panel2.TabIndex = 9;
			// 
			// StartEventMonitoringButton
			// 
			this.StartEventMonitoringButton.Location = new System.Drawing.Point(7, 3);
			this.StartEventMonitoringButton.Name = "StartEventMonitoringButton";
			this.StartEventMonitoringButton.Size = new System.Drawing.Size(267, 44);
			this.StartEventMonitoringButton.TabIndex = 6;
			this.StartEventMonitoringButton.Text = "Начать мониторинг событий";
			this.StartEventMonitoringButton.UseVisualStyleBackColor = true;
			this.StartEventMonitoringButton.Click += new System.EventHandler(this.OnStartEventMonitoringButtonClick);
			// 
			// gbSystemEventsList
			// 
			this.gbSystemEventsList.Controls.Add(this.EventLogsTreeView);
			this.gbSystemEventsList.Controls.Add(this.toolStrip1);
			this.gbSystemEventsList.Dock = System.Windows.Forms.DockStyle.Left;
			this.gbSystemEventsList.Location = new System.Drawing.Point(3, 3);
			this.gbSystemEventsList.Name = "gbSystemEventsList";
			this.gbSystemEventsList.Size = new System.Drawing.Size(320, 537);
			this.gbSystemEventsList.TabIndex = 0;
			this.gbSystemEventsList.TabStop = false;
			this.gbSystemEventsList.Text = "Список системных журналов";
			// 
			// EventLogsTreeView
			// 
			this.EventLogsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EventLogsTreeView.Location = new System.Drawing.Point(3, 41);
			this.EventLogsTreeView.Name = "EventLogsTreeView";
			this.EventLogsTreeView.Size = new System.Drawing.Size(314, 493);
			this.EventLogsTreeView.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshEventLogsButton});
			this.toolStrip1.Location = new System.Drawing.Point(3, 16);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(314, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// RefreshEventLogsButton
			// 
			this.RefreshEventLogsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RefreshEventLogsButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshEventLogsButton.Image")));
			this.RefreshEventLogsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RefreshEventLogsButton.Name = "RefreshEventLogsButton";
			this.RefreshEventLogsButton.Size = new System.Drawing.Size(65, 22);
			this.RefreshEventLogsButton.Text = "Обновить";
			this.RefreshEventLogsButton.Click += new System.EventHandler(this.OnRefreshEventLogsButtonClick);
			// 
			// tcAuditFileSystem
			// 
			this.tcAuditFileSystem.Controls.Add(this.tPgAuditSystemEvents);
			this.tcAuditFileSystem.Controls.Add(this.tPgAuditFileSystem);
			this.tcAuditFileSystem.Controls.Add(this.tbPgAuditDevices);
			this.tcAuditFileSystem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcAuditFileSystem.Location = new System.Drawing.Point(0, 0);
			this.tcAuditFileSystem.Name = "tcAuditFileSystem";
			this.tcAuditFileSystem.SelectedIndex = 0;
			this.tcAuditFileSystem.Size = new System.Drawing.Size(1430, 569);
			this.tcAuditFileSystem.TabIndex = 1;
			// 
			// tPgAuditFileSystem
			// 
			this.tPgAuditFileSystem.Controls.Add(this.gbInformation);
			this.tPgAuditFileSystem.Controls.Add(this.pnElements);
			this.tPgAuditFileSystem.Location = new System.Drawing.Point(4, 22);
			this.tPgAuditFileSystem.Name = "tPgAuditFileSystem";
			this.tPgAuditFileSystem.Size = new System.Drawing.Size(1422, 543);
			this.tPgAuditFileSystem.TabIndex = 2;
			this.tPgAuditFileSystem.Text = "Мониторинг событий файловой системы";
			this.tPgAuditFileSystem.UseVisualStyleBackColor = true;
			// 
			// gbInformation
			// 
			this.gbInformation.Controls.Add(this.rtbInformation);
			this.gbInformation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbInformation.Location = new System.Drawing.Point(227, 0);
			this.gbInformation.Name = "gbInformation";
			this.gbInformation.Size = new System.Drawing.Size(1195, 543);
			this.gbInformation.TabIndex = 21;
			this.gbInformation.TabStop = false;
			this.gbInformation.Text = "Информация об изменениях файловой системы";
			// 
			// rtbInformation
			// 
			this.rtbInformation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbInformation.Location = new System.Drawing.Point(3, 16);
			this.rtbInformation.Name = "rtbInformation";
			this.rtbInformation.Size = new System.Drawing.Size(1189, 524);
			this.rtbInformation.TabIndex = 0;
			this.rtbInformation.Text = "";
			// 
			// pnElements
			// 
			this.pnElements.Controls.Add(this.label1);
			this.pnElements.Controls.Add(this.FileCatalogTextBox);
			this.pnElements.Controls.Add(this.clbActions);
			this.pnElements.Controls.Add(this.StopFileWatcherButton);
			this.pnElements.Controls.Add(this.ClearFileWatcherLog);
			this.pnElements.Controls.Add(this.StartFileWatcherButton);
			this.pnElements.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnElements.Location = new System.Drawing.Point(0, 0);
			this.pnElements.Name = "pnElements";
			this.pnElements.Size = new System.Drawing.Size(227, 543);
			this.pnElements.TabIndex = 22;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Введите путь к каталогу";
			// 
			// FileCatalogTextBox
			// 
			this.FileCatalogTextBox.Location = new System.Drawing.Point(4, 31);
			this.FileCatalogTextBox.Name = "FileCatalogTextBox";
			this.FileCatalogTextBox.Size = new System.Drawing.Size(220, 20);
			this.FileCatalogTextBox.TabIndex = 21;
			// 
			// clbActions
			// 
			this.clbActions.CheckOnClick = true;
			this.clbActions.FormattingEnabled = true;
			this.clbActions.Items.AddRange(new object[] {
            "Изменение файловой системы",
            "Создание файлов и папок",
            "Удаление файлов и папок",
            "Переименование файлов и папок"});
			this.clbActions.Location = new System.Drawing.Point(4, 74);
			this.clbActions.Name = "clbActions";
			this.clbActions.Size = new System.Drawing.Size(220, 64);
			this.clbActions.TabIndex = 13;
			// 
			// StopFileWatcherButton
			// 
			this.StopFileWatcherButton.Enabled = false;
			this.StopFileWatcherButton.Location = new System.Drawing.Point(3, 189);
			this.StopFileWatcherButton.Name = "StopFileWatcherButton";
			this.StopFileWatcherButton.Size = new System.Drawing.Size(220, 35);
			this.StopFileWatcherButton.TabIndex = 20;
			this.StopFileWatcherButton.Text = "Остановить";
			this.StopFileWatcherButton.UseVisualStyleBackColor = true;
			this.StopFileWatcherButton.Click += new System.EventHandler(this.OnStopFileWatcherButtonClick);
			// 
			// ClearFileWatcherLog
			// 
			this.ClearFileWatcherLog.Location = new System.Drawing.Point(4, 230);
			this.ClearFileWatcherLog.Name = "ClearFileWatcherLog";
			this.ClearFileWatcherLog.Size = new System.Drawing.Size(221, 41);
			this.ClearFileWatcherLog.TabIndex = 18;
			this.ClearFileWatcherLog.Text = "Очистить поле вывода информации";
			this.ClearFileWatcherLog.UseVisualStyleBackColor = true;
			this.ClearFileWatcherLog.Click += new System.EventHandler(this.OnClearFileWatcherButtonClick);
			// 
			// StartFileWatcherButton
			// 
			this.StartFileWatcherButton.Location = new System.Drawing.Point(4, 144);
			this.StartFileWatcherButton.Name = "StartFileWatcherButton";
			this.StartFileWatcherButton.Size = new System.Drawing.Size(220, 39);
			this.StartFileWatcherButton.TabIndex = 19;
			this.StartFileWatcherButton.Text = "Начать мониторинг событий файловой системы";
			this.StartFileWatcherButton.UseVisualStyleBackColor = true;
			this.StartFileWatcherButton.Click += new System.EventHandler(this.OnStartFileWatcherButtonClick);
			// 
			// tbPgAuditDevices
			// 
			this.tbPgAuditDevices.Controls.Add(this.lsbAuditDevices);
			this.tbPgAuditDevices.Location = new System.Drawing.Point(4, 22);
			this.tbPgAuditDevices.Name = "tbPgAuditDevices";
			this.tbPgAuditDevices.Size = new System.Drawing.Size(1422, 543);
			this.tbPgAuditDevices.TabIndex = 3;
			this.tbPgAuditDevices.Text = "Мониториг аппаратных изменений";
			this.tbPgAuditDevices.UseVisualStyleBackColor = true;
			// 
			// lsbAuditDevices
			// 
			this.lsbAuditDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsbAuditDevices.Location = new System.Drawing.Point(0, 0);
			this.lsbAuditDevices.Name = "lsbAuditDevices";
			this.lsbAuditDevices.Size = new System.Drawing.Size(1422, 543);
			this.lsbAuditDevices.TabIndex = 2;
			// 
			// AuditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1430, 569);
			this.Controls.Add(this.tcAuditFileSystem);
			this.Name = "AuditForm";
			this.Text = "AuditForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnAuditFormFormClosed);
			this.Load += new System.EventHandler(this.OnAuditFormLoad);
			this.tPgAuditSystemEvents.ResumeLayout(false);
			this.tabControl3.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.gbCurrentLog.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.CurrentLogDataGrid)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.gbFilter.ResumeLayout(false);
			this.gbFilter.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.gbSystemEventsList.ResumeLayout(false);
			this.gbSystemEventsList.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tcAuditFileSystem.ResumeLayout(false);
			this.tPgAuditFileSystem.ResumeLayout(false);
			this.gbInformation.ResumeLayout(false);
			this.pnElements.ResumeLayout(false);
			this.pnElements.PerformLayout();
			this.tbPgAuditDevices.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.TabPage tPgAuditSystemEvents;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox gbCurrentLog;
        private System.Windows.Forms.DateTimePicker ToFilterDatePicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker FromFilterDatePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MachineNameFilterTextBox;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox InstanceIdFilterTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.RadioButton rbByComputer;
        private System.Windows.Forms.RadioButton rbByDate;
        private System.Windows.Forms.RadioButton rbByMessageType;
        private System.Windows.Forms.RadioButton rbByID;
        private System.Windows.Forms.Button EraseCurrentLogButton;
        private System.Windows.Forms.Button RefreshCurrentLogWithFilterButton;
        private System.Windows.Forms.Button RefreshCurrentLogButton;
        private System.Windows.Forms.DataGridView CurrentLogDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button StartEventMonitoringButton;
        private System.Windows.Forms.RichTextBox rtbMonitoredEvents;
        private System.Windows.Forms.GroupBox gbSystemEventsList;
        private System.Windows.Forms.TreeView EventLogsTreeView;
        private System.Windows.Forms.TabControl tcAuditFileSystem;
        private System.Windows.Forms.TabPage tPgAuditFileSystem;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.RichTextBox rtbInformation;
        private System.Windows.Forms.Button StopFileWatcherButton;
        private System.Windows.Forms.CheckedListBox clbActions;
		private System.Windows.Forms.Button StartFileWatcherButton;
		private System.Windows.Forms.Button ClearFileWatcherLog;
		private System.Windows.Forms.TabPage tbPgAuditDevices;
        private System.Windows.Forms.ListBox lsbAuditDevices;
        private System.Windows.Forms.Panel pnElements;
		private System.Windows.Forms.ComboBox EventTypeFilterComboBox;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton RefreshEventLogsButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox FileCatalogTextBox;
    }
}