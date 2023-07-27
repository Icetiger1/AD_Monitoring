namespace AD_Monitoring
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remoteControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCCMConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whoOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sentMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.reportOnSharedNetworkResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportOnLocalAdminsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(219, 62);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(914, 485);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.Text = "Name";
            this.ColumnHeader.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Location";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "OS";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Company";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "IP";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "User";
            this.columnHeader5.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteControlToolStripMenuItem,
            this.computerManagementToolStripMenuItem,
            this.sCCMConnectionToolStripMenuItem,
            this.whoOnlineToolStripMenuItem,
            this.discCToolStripMenuItem,
            this.shareFolderToolStripMenuItem,
            this.powerManagementToolStripMenuItem,
            this.pingToolStripMenuItem,
            this.printersToolStripMenuItem,
            this.localAdminToolStripMenuItem,
            this.sentMessageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.OwnerItem = this.toolStripButton3;
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 268);
            // 
            // remoteControlToolStripMenuItem
            // 
            this.remoteControlToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources._32officeicons_31_89708;
            this.remoteControlToolStripMenuItem.Name = "remoteControlToolStripMenuItem";
            this.remoteControlToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.remoteControlToolStripMenuItem.Text = "Remote control";
            this.remoteControlToolStripMenuItem.Click += new System.EventHandler(this.remoteControlToolStripMenuItem_Click);
            // 
            // computerManagementToolStripMenuItem
            // 
            this.computerManagementToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources.rocket_startup_monitor_screen_computer_icon_124621;
            this.computerManagementToolStripMenuItem.Name = "computerManagementToolStripMenuItem";
            this.computerManagementToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.computerManagementToolStripMenuItem.Text = "Computer Management";
            this.computerManagementToolStripMenuItem.Click += new System.EventHandler(this.computerManagementToolStripMenuItem_Click);
            // 
            // sCCMConnectionToolStripMenuItem
            // 
            this.sCCMConnectionToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources.cable_connect_connection_computer_hardware_icon_141983;
            this.sCCMConnectionToolStripMenuItem.Name = "sCCMConnectionToolStripMenuItem";
            this.sCCMConnectionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.sCCMConnectionToolStripMenuItem.Text = "SCCM connection";
            this.sCCMConnectionToolStripMenuItem.Click += new System.EventHandler(this.sCCMConnectionToolStripMenuItem_Click);
            // 
            // whoOnlineToolStripMenuItem
            // 
            this.whoOnlineToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources.question_emoticon_5618;
            this.whoOnlineToolStripMenuItem.Name = "whoOnlineToolStripMenuItem";
            this.whoOnlineToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.whoOnlineToolStripMenuItem.Text = "Who online?";
            this.whoOnlineToolStripMenuItem.Click += new System.EventHandler(this.whoOnlineToolStripMenuItem_Click);
            // 
            // discCToolStripMenuItem
            // 
            this.discCToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources.documents_folder_18875;
            this.discCToolStripMenuItem.Name = "discCToolStripMenuItem";
            this.discCToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.discCToolStripMenuItem.Text = "Disc C:\\";
            this.discCToolStripMenuItem.Click += new System.EventHandler(this.discCToolStripMenuItem_Click);
            // 
            // shareFolderToolStripMenuItem
            // 
            this.shareFolderToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources.OneDrive_Folder_23362;
            this.shareFolderToolStripMenuItem.Name = "shareFolderToolStripMenuItem";
            this.shareFolderToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.shareFolderToolStripMenuItem.Text = "Share folder";
            this.shareFolderToolStripMenuItem.Click += new System.EventHandler(this.shareFolderToolStripMenuItem_Click);
            // 
            // powerManagementToolStripMenuItem
            // 
            this.powerManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shutdownToolStripMenuItem,
            this.rebootToolStripMenuItem});
            this.powerManagementToolStripMenuItem.Name = "powerManagementToolStripMenuItem";
            this.powerManagementToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.powerManagementToolStripMenuItem.Text = "Power management";
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.rebootToolStripMenuItem.Text = "Reboot";
            this.rebootToolStripMenuItem.Click += new System.EventHandler(this.rebootToolStripMenuItem_Click);
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources.ping_big_logo_icon_icons_com_68373;
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.pingToolStripMenuItem.Text = "Ping";
            this.pingToolStripMenuItem.Click += new System.EventHandler(this.pingToolStripMenuItem_Click);
            // 
            // printersToolStripMenuItem
            // 
            this.printersToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources.printer;
            this.printersToolStripMenuItem.Name = "printersToolStripMenuItem";
            this.printersToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.printersToolStripMenuItem.Text = "Printers";
            this.printersToolStripMenuItem.Click += new System.EventHandler(this.printersToolStripMenuItem_Click);
            // 
            // localAdminToolStripMenuItem
            // 
            this.localAdminToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources.image_07_10_22_12_14_2;
            this.localAdminToolStripMenuItem.Name = "localAdminToolStripMenuItem";
            this.localAdminToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.localAdminToolStripMenuItem.Text = "Local admin";
            this.localAdminToolStripMenuItem.Click += new System.EventHandler(this.localAdminToolStripMenuItem_Click);
            // 
            // sentMessageToolStripMenuItem
            // 
            this.sentMessageToolStripMenuItem.Image = global::AD_Monitoring.Properties.Resources.student_work_office_desk_work_space_computer_working_support_icon_191191;
            this.sentMessageToolStripMenuItem.Name = "sentMessageToolStripMenuItem";
            this.sentMessageToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.sentMessageToolStripMenuItem.Text = "Sent message";
            this.sentMessageToolStripMenuItem.Click += new System.EventHandler(this.sentMessageToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folderorangecd_93301.png");
            this.imageList1.Images.SetKeyName(1, "folderorangewifi_93453.png");
            this.imageList1.Images.SetKeyName(2, "folderyellow_92963.png");
            this.imageList1.Images.SetKeyName(3, "like-icon_31852.png");
            this.imageList1.Images.SetKeyName(4, "dislike-icon_31856.png");
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.DropDown = this.contextMenuStrip1;
            this.toolStripButton3.Image = global::AD_Monitoring.Properties.Resources.computer_77914;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(66, 56);
            this.toolStripButton3.Text = "Modes";
            this.toolStripButton3.ToolTipText = "Modes";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripSplitButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripSeparator3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1145, 59);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 59);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 59);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportOnSharedNetworkResourcesToolStripMenuItem,
            this.reportOnLocalAdminsToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::AD_Monitoring.Properties.Resources.writing_77881;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(66, 56);
            this.toolStripSplitButton1.Text = "Reports";
            this.toolStripSplitButton1.ToolTipText = "Reports";
            // 
            // reportOnSharedNetworkResourcesToolStripMenuItem
            // 
            this.reportOnSharedNetworkResourcesToolStripMenuItem.Name = "reportOnSharedNetworkResourcesToolStripMenuItem";
            this.reportOnSharedNetworkResourcesToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.reportOnSharedNetworkResourcesToolStripMenuItem.Text = "Report on shared network resources";
            // 
            // reportOnLocalAdminsToolStripMenuItem
            // 
            this.reportOnLocalAdminsToolStripMenuItem.Name = "reportOnLocalAdminsToolStripMenuItem";
            this.reportOnLocalAdminsToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.reportOnLocalAdminsToolStripMenuItem.Text = "Report on local admins";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::AD_Monitoring.Properties.Resources.microsoft_excel_alt_macos_bigsur_icon_189979;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(56, 56);
            this.toolStripButton2.Text = "Excel";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 59);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 59);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::AD_Monitoring.Properties.Resources.iconfinder_technologymachineelectronicdevice39_4026421_113339;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(54, 56);
            this.toolStripButton1.Text = "Scan computers";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 553);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1121, 68);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(631, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "               ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(12, 62);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(201, 485);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1002, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1145, 633);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AD Monitoring";
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolStrip toolStrip1;
        private ColumnHeader ColumnHeader;
        public ListView listView1;
        private RichTextBox richTextBox1;
        private Label label1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton2;
        private TreeView treeView1;
        private ImageList imageList1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator3;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Label label2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem remoteControlToolStripMenuItem;
        private ToolStripMenuItem computerManagementToolStripMenuItem;
        private ToolStripMenuItem sCCMConnectionToolStripMenuItem;
        private ToolStripMenuItem discCToolStripMenuItem;
        private ToolStripSplitButton toolStripButton3;
        private ToolStripMenuItem shareFolderToolStripMenuItem;
        private ToolStripMenuItem powerManagementToolStripMenuItem;
        private ToolStripMenuItem shutdownToolStripMenuItem;
        private ToolStripMenuItem rebootToolStripMenuItem;
        private ToolStripMenuItem pingToolStripMenuItem;
        private ToolStripMenuItem printersToolStripMenuItem;
        private ToolStripMenuItem localAdminToolStripMenuItem;
        private ToolStripMenuItem sentMessageToolStripMenuItem;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem reportOnSharedNetworkResourcesToolStripMenuItem;
        private ToolStripMenuItem reportOnLocalAdminsToolStripMenuItem;
        private ToolStripMenuItem whoOnlineToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
    }
}