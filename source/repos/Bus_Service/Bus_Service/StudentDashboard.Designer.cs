namespace Bus_Service
{
    partial class StudentDashboard
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            lblName = new Label();
            lblDept = new Label();
            lblType = new Label();
            lblSeat = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblSeat);
            groupBox1.Controls.Add(lblType);
            groupBox1.Controls.Add(lblDept);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(21, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(749, 125);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "BOOKING DETAILS";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 36);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Name : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(421, 36);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 1;
            label2.Text = "Department : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 83);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 2;
            label3.Text = "Booking Type :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(414, 83);
            label4.Name = "label4";
            label4.Size = new Size(107, 20);
            label4.TabIndex = 3;
            label4.Text = "Seat Number : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(194, 184);
            label5.Name = "label5";
            label5.Size = new Size(112, 20);
            label5.TabIndex = 4;
            label5.Text = "Current Status : ";
            // 
            // button1
            // 
            button1.Location = new Point(129, 243);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "View Status";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(327, 243);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Cancel Booking";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(515, 243);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 7;
            button3.Text = "Logout";
            button3.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(202, 36);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 20);
            lblName.TabIndex = 4;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(567, 36);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(0, 20);
            lblDept.TabIndex = 5;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(202, 92);
            lblType.Name = "lblType";
            lblType.Size = new Size(0, 20);
            lblType.TabIndex = 6;
            // 
            // lblSeat
            // 
            lblSeat.AutoSize = true;
            lblSeat.Location = new Point(567, 83);
            lblSeat.Name = "lblSeat";
            lblSeat.Size = new Size(0, 20);
            lblSeat.TabIndex = 7;
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(groupBox1);
            Name = "StudentDashboard";
            Text = "StudentDashboard";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label lblSeat;
        private Label lblType;
        private Label lblDept;
        private Label lblName;
    }
}