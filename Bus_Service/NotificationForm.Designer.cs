namespace Bus_Service
{
    partial class NotificationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewNotifications = new System.Windows.Forms.DataGridView();
            this.buttonMarkAsRead = new System.Windows.Forms.Button();
            this.buttonMarkAllAsRead = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelUnreadCount = new System.Windows.Forms.Label();
            this.groupBoxNotifications = new System.Windows.Forms.GroupBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotifications)).BeginInit();
            this.groupBoxNotifications.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewNotifications
            // 
            this.dataGridViewNotifications.AllowUserToAddRows = false;
            this.dataGridViewNotifications.AllowUserToDeleteRows = false;
            this.dataGridViewNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewNotifications.Location = new System.Drawing.Point(3, 50);
            this.dataGridViewNotifications.Name = "dataGridViewNotifications";
            this.dataGridViewNotifications.ReadOnly = true;
            this.dataGridViewNotifications.Size = new System.Drawing.Size(794, 300);
            this.dataGridViewNotifications.TabIndex = 0;
            // 
            // buttonMarkAsRead
            // 
            this.buttonMarkAsRead.Location = new System.Drawing.Point(20, 20);
            this.buttonMarkAsRead.Name = "buttonMarkAsRead";
            this.buttonMarkAsRead.Size = new System.Drawing.Size(120, 30);
            this.buttonMarkAsRead.TabIndex = 1;
            this.buttonMarkAsRead.Text = "Mark as Read";
            this.buttonMarkAsRead.UseVisualStyleBackColor = true;
            this.buttonMarkAsRead.Click += new System.EventHandler(this.buttonMarkAsRead_Click);
            // 
            // buttonMarkAllAsRead
            // 
            this.buttonMarkAllAsRead.Location = new System.Drawing.Point(160, 20);
            this.buttonMarkAllAsRead.Name = "buttonMarkAllAsRead";
            this.buttonMarkAllAsRead.Size = new System.Drawing.Size(150, 30);
            this.buttonMarkAllAsRead.TabIndex = 2;
            this.buttonMarkAllAsRead.Text = "Mark All as Read";
            this.buttonMarkAllAsRead.UseVisualStyleBackColor = true;
            this.buttonMarkAllAsRead.Click += new System.EventHandler(this.buttonMarkAllAsRead_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(650, 20);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 30);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(760, 20);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 30);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelUnreadCount
            // 
            this.labelUnreadCount.AutoSize = true;
            this.labelUnreadCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelUnreadCount.Location = new System.Drawing.Point(20, 20);
            this.labelUnreadCount.Name = "labelUnreadCount";
            this.labelUnreadCount.Size = new System.Drawing.Size(80, 17);
            this.labelUnreadCount.TabIndex = 5;
            this.labelUnreadCount.Text = "Unread: 0";
            // 
            // groupBoxNotifications
            // 
            this.groupBoxNotifications.Controls.Add(this.labelUnreadCount);
            this.groupBoxNotifications.Controls.Add(this.dataGridViewNotifications);
            this.groupBoxNotifications.Location = new System.Drawing.Point(12, 12);
            this.groupBoxNotifications.Name = "groupBoxNotifications";
            this.groupBoxNotifications.Size = new System.Drawing.Size(800, 360);
            this.groupBoxNotifications.TabIndex = 6;
            this.groupBoxNotifications.TabStop = false;
            this.groupBoxNotifications.Text = "Notifications";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.buttonMarkAsRead);
            this.groupBoxActions.Controls.Add(this.buttonMarkAllAsRead);
            this.groupBoxActions.Controls.Add(this.buttonRefresh);
            this.groupBoxActions.Controls.Add(this.buttonClose);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 378);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(800, 70);
            this.groupBoxActions.TabIndex = 7;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 461);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxNotifications);
            this.Name = "NotificationForm";
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotifications)).EndInit();
            this.groupBoxNotifications.ResumeLayout(false);
            this.groupBoxNotifications.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dataGridViewNotifications;
        private System.Windows.Forms.Button buttonMarkAsRead;
        private System.Windows.Forms.Button buttonMarkAllAsRead;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelUnreadCount;
        private System.Windows.Forms.GroupBox groupBoxNotifications;
        private System.Windows.Forms.GroupBox groupBoxActions;
    }
}
