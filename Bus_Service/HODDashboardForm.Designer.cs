namespace Bus_Service
{
    partial class HODDashboardForm
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
            this.dataGridViewPendingRequests = new System.Windows.Forms.DataGridView();
            this.textBoxRequestDetails = new System.Windows.Forms.TextBox();
            this.buttonApprove = new System.Windows.Forms.Button();
            this.buttonReject = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelPendingCount = new System.Windows.Forms.Label();
            this.groupBoxRequests = new System.Windows.Forms.GroupBox();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingRequests)).BeginInit();
            this.groupBoxRequests.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPendingRequests
            // 
            this.dataGridViewPendingRequests.AllowUserToAddRows = false;
            this.dataGridViewPendingRequests.AllowUserToDeleteRows = false;
            this.dataGridViewPendingRequests.AllowUserToOrderColumns = true;
            this.dataGridViewPendingRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPendingRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPendingRequests.Location = new System.Drawing.Point(3, 50);
            this.dataGridViewPendingRequests.Name = "dataGridViewPendingRequests";
            this.dataGridViewPendingRequests.ReadOnly = true;
            this.dataGridViewPendingRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPendingRequests.Size = new System.Drawing.Size(800, 180);
            this.dataGridViewPendingRequests.TabIndex = 0;
            this.dataGridViewPendingRequests.SelectionChanged += new System.EventHandler(this.dataGridViewPendingRequests_SelectionChanged);
            // 
            // textBoxRequestDetails
            // 
            this.textBoxRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRequestDetails.Location = new System.Drawing.Point(3, 16);
            this.textBoxRequestDetails.Multiline = true;
            this.textBoxRequestDetails.Name = "textBoxRequestDetails";
            this.textBoxRequestDetails.ReadOnly = true;
            this.textBoxRequestDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRequestDetails.Size = new System.Drawing.Size(800, 150);
            this.textBoxRequestDetails.TabIndex = 1;
            // 
            // buttonApprove
            // 
            this.buttonApprove.BackColor = System.Drawing.Color.Green;
            this.buttonApprove.Enabled = false;
            this.buttonApprove.ForeColor = System.Drawing.Color.White;
            this.buttonApprove.Location = new System.Drawing.Point(20, 30);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(100, 30);
            this.buttonApprove.TabIndex = 2;
            this.buttonApprove.Text = "Approve";
            this.buttonApprove.UseVisualStyleBackColor = false;
            this.buttonApprove.Click += new System.EventHandler(this.buttonApprove_Click);
            // 
            // buttonReject
            // 
            this.buttonReject.BackColor = System.Drawing.Color.Red;
            this.buttonReject.Enabled = false;
            this.buttonReject.ForeColor = System.Drawing.Color.White;
            this.buttonReject.Location = new System.Drawing.Point(140, 30);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(100, 30);
            this.buttonReject.TabIndex = 3;
            this.buttonReject.Text = "Reject";
            this.buttonReject.UseVisualStyleBackColor = false;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(700, 30);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 30);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(700, 80);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 30);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelPendingCount
            // 
            this.labelPendingCount.AutoSize = true;
            this.labelPendingCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelPendingCount.Location = new System.Drawing.Point(20, 20);
            this.labelPendingCount.Name = "labelPendingCount";
            this.labelPendingCount.Size = new System.Drawing.Size(150, 17);
            this.labelPendingCount.TabIndex = 6;
            this.labelPendingCount.Text = "Pending Requests: 0";
            // 
            // groupBoxRequests
            // 
            this.groupBoxRequests.Controls.Add(this.labelPendingCount);
            this.groupBoxRequests.Controls.Add(this.dataGridViewPendingRequests);
            this.groupBoxRequests.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRequests.Name = "groupBoxRequests";
            this.groupBoxRequests.Size = new System.Drawing.Size(806, 240);
            this.groupBoxRequests.TabIndex = 7;
            this.groupBoxRequests.TabStop = false;
            this.groupBoxRequests.Text = "Pending One-Way Requests";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.textBoxRequestDetails);
            this.groupBoxDetails.Location = new System.Drawing.Point(12, 258);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(806, 172);
            this.groupBoxDetails.TabIndex = 8;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Request Details";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.buttonApprove);
            this.groupBoxActions.Controls.Add(this.buttonReject);
            this.groupBoxActions.Controls.Add(this.buttonRefresh);
            this.groupBoxActions.Controls.Add(this.buttonClose);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 436);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(806, 120);
            this.groupBoxActions.TabIndex = 9;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // HODDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 568);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.groupBoxRequests);
            this.Name = "HODDashboardForm";
            this.Text = "HOD Dashboard - One-Way Request Approval";
            this.Load += new System.EventHandler(this.HODDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPendingRequests)).EndInit();
            this.groupBoxRequests.ResumeLayout(false);
            this.groupBoxRequests.PerformLayout();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dataGridViewPendingRequests;
        private System.Windows.Forms.TextBox textBoxRequestDetails;
        private System.Windows.Forms.Button buttonApprove;
        private System.Windows.Forms.Button buttonReject;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelPendingCount;
        private System.Windows.Forms.GroupBox groupBoxRequests;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.GroupBox groupBoxActions;
    }
}
