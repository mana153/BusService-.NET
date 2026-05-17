namespace Bus_Service
{
    partial class AdminForm
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
            label1 = new Label();
            dtpTravelDate = new DateTimePicker();
            label2 = new Label();
            cbBusNumber = new ComboBox();
            label3 = new Label();
            txtRoute = new TextBox();
            label4 = new Label();
            nudSeatCapacity = new NumericUpDown();
            btnAddTravel = new Button();
            btnUpdateTravel = new Button();
            btnDeleteTravel = new Button();
            btnClear = new Button();
            btnBack = new Button();
            dataGridViewTravels = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)nudSeatCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTravels).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 27);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 0;
            label1.Text = "Travel Date:";
            // 
            // dtpTravelDate
            // 
            dtpTravelDate.Location = new Point(114, 27);
            dtpTravelDate.Margin = new Padding(3, 4, 3, 4);
            dtpTravelDate.Name = "dtpTravelDate";
            dtpTravelDate.Size = new Size(171, 27);
            dtpTravelDate.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 67);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 2;
            label2.Text = "Bus Number:";
            // 
            // cbBusNumber
            // 
            cbBusNumber.FormattingEnabled = true;
            cbBusNumber.Items.AddRange(new object[] { "BUS001", "BUS002", "BUS003", "BUS004", "BUS005" });
            cbBusNumber.Location = new Point(114, 67);
            cbBusNumber.Margin = new Padding(3, 4, 3, 4);
            cbBusNumber.Name = "cbBusNumber";
            cbBusNumber.Size = new Size(171, 28);
            cbBusNumber.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 107);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 4;
            label3.Text = "Route:";
            // 
            // txtRoute
            // 
            txtRoute.Location = new Point(114, 107);
            txtRoute.Margin = new Padding(3, 4, 3, 4);
            txtRoute.Name = "txtRoute";
            txtRoute.Size = new Size(171, 27);
            txtRoute.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 147);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 6;
            label4.Text = "Seat Capacity:";
            // 
            // nudSeatCapacity
            // 
            nudSeatCapacity.Location = new Point(114, 147);
            nudSeatCapacity.Margin = new Padding(3, 4, 3, 4);
            nudSeatCapacity.Name = "nudSeatCapacity";
            nudSeatCapacity.Size = new Size(171, 27);
            nudSeatCapacity.TabIndex = 7;
            // 
            // btnAddTravel
            // 
            btnAddTravel.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            btnAddTravel.ForeColor = System.Drawing.Color.White;
            btnAddTravel.Location = new Point(11, 27);
            btnAddTravel.Margin = new Padding(3, 4, 3, 4);
            btnAddTravel.Name = "btnAddTravel";
            btnAddTravel.Size = new Size(91, 40);
            btnAddTravel.TabIndex = 8;
            btnAddTravel.Text = "Add Travel";
            btnAddTravel.UseVisualStyleBackColor = false;
            btnAddTravel.Click += btnAddTravel_Click;
            // 
            // btnUpdateTravel
            // 
            btnUpdateTravel.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            btnUpdateTravel.ForeColor = System.Drawing.Color.White;
            btnUpdateTravel.Location = new Point(114, 27);
            btnUpdateTravel.Margin = new Padding(3, 4, 3, 4);
            btnUpdateTravel.Name = "btnUpdateTravel";
            btnUpdateTravel.Size = new Size(91, 40);
            btnUpdateTravel.TabIndex = 9;
            btnUpdateTravel.Text = "Update Travel";
            btnUpdateTravel.UseVisualStyleBackColor = false;
            btnUpdateTravel.Click += btnUpdateTravel_Click;
            // 
            // btnDeleteTravel
            // 
            btnDeleteTravel.BackColor = System.Drawing.Color.FromArgb(204, 0, 0);
            btnDeleteTravel.ForeColor = System.Drawing.Color.White;
            btnDeleteTravel.Location = new Point(217, 27);
            btnDeleteTravel.Margin = new Padding(3, 4, 3, 4);
            btnDeleteTravel.Name = "btnDeleteTravel";
            btnDeleteTravel.Size = new Size(91, 40);
            btnDeleteTravel.TabIndex = 10;
            btnDeleteTravel.Text = "Delete Travel";
            btnDeleteTravel.UseVisualStyleBackColor = false;
            btnDeleteTravel.Click += btnDeleteTravel_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            btnClear.Location = new Point(320, 27);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(91, 40);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            btnBack.ForeColor = System.Drawing.Color.White;
            btnBack.Location = new Point(625, 27);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(91, 40);
            btnBack.TabIndex = 15;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // dataGridViewTravels
            // 
            dataGridViewTravels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTravels.Dock = DockStyle.Fill;
            dataGridViewTravels.Location = new Point(0, 293);
            dataGridViewTravels.Margin = new Padding(3, 4, 3, 4);
            dataGridViewTravels.Name = "dataGridViewTravels";
            dataGridViewTravels.RowHeadersWidth = 51;
            dataGridViewTravels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTravels.Size = new Size(747, 374);
            dataGridViewTravels.TabIndex = 12;
            dataGridViewTravels.CellClick += dataGridViewTravels_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtpTravelDate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbBusNumber);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtRoute);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(nudSeatCapacity);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(747, 200);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Travel Details";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAddTravel);
            groupBox2.Controls.Add(btnUpdateTravel);
            groupBox2.Controls.Add(btnDeleteTravel);
            groupBox2.Controls.Add(btnClear);
            groupBox2.Controls.Add(btnBack);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 200);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(747, 93);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Actions";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new Size(747, 667);
            Controls.Add(dataGridViewTravels);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminForm";
            Text = "Admin - Travel Management";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudSeatCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTravels).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTravelDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBusNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSeatCapacity;
        private System.Windows.Forms.Button btnAddTravel;
        private System.Windows.Forms.Button btnUpdateTravel;
        private System.Windows.Forms.Button btnDeleteTravel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dataGridViewTravels;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
