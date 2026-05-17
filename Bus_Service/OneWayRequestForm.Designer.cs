namespace Bus_Service
{
    partial class OneWayRequestForm
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
            this.groupBoxSubmitRequest = new System.Windows.Forms.GroupBox();
            this.buttonSubmitRequest = new System.Windows.Forms.Button();
            this.dateTimePickerRequestDate = new System.Windows.Forms.DateTimePicker();
            this.labelRequestDate = new System.Windows.Forms.Label();
            this.comboBoxRoute = new System.Windows.Forms.ComboBox();
            this.labelRoute = new System.Windows.Forms.Label();
            this.textBoxReason = new System.Windows.Forms.TextBox();
            this.labelReason = new System.Windows.Forms.Label();
            this.groupBoxPreviousRequests = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxSubmitRequest.SuspendLayout();
            this.groupBoxPreviousRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSubmitRequest
            // 
            this.groupBoxSubmitRequest.Controls.Add(this.buttonSubmitRequest);
            this.groupBoxSubmitRequest.Controls.Add(this.dateTimePickerRequestDate);
            this.groupBoxSubmitRequest.Controls.Add(this.labelRequestDate);
            this.groupBoxSubmitRequest.Controls.Add(this.comboBoxRoute);
            this.groupBoxSubmitRequest.Controls.Add(this.labelRoute);
            this.groupBoxSubmitRequest.Controls.Add(this.textBoxReason);
            this.groupBoxSubmitRequest.Controls.Add(this.labelReason);
            this.groupBoxSubmitRequest.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSubmitRequest.Name = "groupBoxSubmitRequest";
            this.groupBoxSubmitRequest.Size = new System.Drawing.Size(760, 180);
            this.groupBoxSubmitRequest.TabIndex = 0;
            this.groupBoxSubmitRequest.TabStop = false;
            this.groupBoxSubmitRequest.Text = "Submit One-Way Request";
            // 
            // buttonSubmitRequest
            // 
            this.buttonSubmitRequest.BackColor = System.Drawing.Color.Green;
            this.buttonSubmitRequest.ForeColor = System.Drawing.Color.White;
            this.buttonSubmitRequest.Location = new System.Drawing.Point(640, 140);
            this.buttonSubmitRequest.Name = "buttonSubmitRequest";
            this.buttonSubmitRequest.Size = new System.Drawing.Size(100, 30);
            this.buttonSubmitRequest.TabIndex = 6;
            this.buttonSubmitRequest.Text = "Submit";
            this.buttonSubmitRequest.UseVisualStyleBackColor = false;
            this.buttonSubmitRequest.Click += new System.EventHandler(this.buttonSubmitRequest_Click);
            // 
            // dateTimePickerRequestDate
            // 
            this.dateTimePickerRequestDate.Location = new System.Drawing.Point(550, 100);
            this.dateTimePickerRequestDate.Name = "dateTimePickerRequestDate";
            this.dateTimePickerRequestDate.Size = new System.Drawing.Size(190, 20);
            this.dateTimePickerRequestDate.TabIndex = 5;
            // 
            // labelRequestDate
            // 
            this.labelRequestDate.AutoSize = true;
            this.labelRequestDate.Location = new System.Drawing.Point(480, 100);
            this.labelRequestDate.Name = "labelRequestDate";
            this.labelRequestDate.Size = new System.Drawing.Size(35, 13);
            this.labelRequestDate.TabIndex = 4;
            this.labelRequestDate.Text = "Date:";
            // 
            // comboBoxRoute
            // 
            this.comboBoxRoute.FormattingEnabled = true;
            this.comboBoxRoute.Location = new System.Drawing.Point(550, 60);
            this.comboBoxRoute.Name = "comboBoxRoute";
            this.comboBoxRoute.Size = new System.Drawing.Size(190, 21);
            this.comboBoxRoute.TabIndex = 3;
            // 
            // labelRoute
            // 
            this.labelRoute.AutoSize = true;
            this.labelRoute.Location = new System.Drawing.Point(480, 60);
            this.labelRoute.Name = "labelRoute";
            this.labelRoute.Size = new System.Drawing.Size(41, 13);
            this.labelRoute.TabIndex = 2;
            this.labelRoute.Text = "Route:";
            // 
            // textBoxReason
            // 
            this.textBoxReason.Location = new System.Drawing.Point(100, 30);
            this.textBoxReason.Multiline = true;
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(640, 60);
            this.textBoxReason.TabIndex = 1;
            // 
            // labelReason
            // 
            this.labelReason.AutoSize = true;
            this.labelReason.Location = new System.Drawing.Point(20, 30);
            this.labelReason.Name = "labelReason";
            this.labelReason.Size = new System.Drawing.Size(47, 13);
            this.labelReason.TabIndex = 0;
            this.labelReason.Text = "Reason:";
            // 
            // groupBoxPreviousRequests
            // 
            this.groupBoxPreviousRequests.Controls.Add(this.buttonRefresh);
            this.groupBoxPreviousRequests.Controls.Add(this.dataGridViewRequests);
            this.groupBoxPreviousRequests.Location = new System.Drawing.Point(12, 200);
            this.groupBoxPreviousRequests.Name = "groupBoxPreviousRequests";
            this.groupBoxPreviousRequests.Size = new System.Drawing.Size(760, 250);
            this.groupBoxPreviousRequests.TabIndex = 1;
            this.groupBoxPreviousRequests.TabStop = false;
            this.groupBoxPreviousRequests.Text = "Your One-Way Requests";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(640, 220);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 23);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // dataGridViewRequests
            // 
            this.dataGridViewRequests.AllowUserToAddRows = false;
            this.dataGridViewRequests.AllowUserToDeleteRows = false;
            this.dataGridViewRequests.AllowUserToOrderColumns = true;
            this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequests.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewRequests.Name = "dataGridViewRequests";
            this.dataGridViewRequests.ReadOnly = true;
            this.dataGridViewRequests.Size = new System.Drawing.Size(720, 190);
            this.dataGridViewRequests.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(640, 460);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 30);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // OneWayRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 500);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxPreviousRequests);
            this.Controls.Add(this.groupBoxSubmitRequest);
            this.Name = "OneWayRequestForm";
            this.Text = "One-Way Request";
            this.Load += new System.EventHandler(this.OneWayRequestForm_Load);
            this.groupBoxSubmitRequest.ResumeLayout(false);
            this.groupBoxSubmitRequest.PerformLayout();
            this.groupBoxPreviousRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBoxSubmitRequest;
        private System.Windows.Forms.Button buttonSubmitRequest;
        private System.Windows.Forms.DateTimePicker dateTimePickerRequestDate;
        private System.Windows.Forms.Label labelRequestDate;
        private System.Windows.Forms.ComboBox comboBoxRoute;
        private System.Windows.Forms.Label labelRoute;
        private System.Windows.Forms.TextBox textBoxReason;
        private System.Windows.Forms.Label labelReason;
        private System.Windows.Forms.GroupBox groupBoxPreviousRequests;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.Button buttonClose;
    }
}
