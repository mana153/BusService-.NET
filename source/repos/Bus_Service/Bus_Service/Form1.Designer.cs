namespace Bus_Service
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
            Title = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label9 = new Label();
            button1 = new Button();
            button2 = new Button();
            label6 = new Label();
            groupBox1 = new GroupBox();
            button3 = new Button();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label8 = new Label();
            textBox3 = new TextBox();
            comboBox2 = new ComboBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Title.Location = new Point(226, 374);
            Title.Name = "Title";
            Title.Size = new Size(184, 20);
            Title.TabIndex = 0;
            Title.Text = "Volunteer Veriification";
            Title.Click += Title_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(807, 510);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(308, 157);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 2;
            label1.Text = "Role: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label3.Location = new Point(308, 209);
            label3.Name = "label3";
            label3.Size = new Size(111, 23);
            label3.TabIndex = 3;
            label3.Text = "UserName: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label4.Location = new Point(308, 256);
            label4.Name = "label4";
            label4.Size = new Size(102, 23);
            label4.TabIndex = 4;
            label4.Text = "Password: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label5.Location = new Point(308, 311);
            label5.Name = "label5";
            label5.Size = new Size(118, 23);
            label5.TabIndex = 5;
            label5.Text = "Department:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(495, 414);
            label7.Name = "label7";
            label7.Size = new Size(51, 23);
            label7.TabIndex = 7;
            label7.Text = "OTP";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(603, 223);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 9;
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            button1.Location = new Point(245, 411);
            button1.Name = "button1";
            button1.Size = new Size(124, 35);
            button1.TabIndex = 10;
            button1.Text = "Generate OPT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            button2.Location = new Point(384, 478);
            button2.Name = "button2";
            button2.Size = new Size(97, 32);
            button2.TabIndex = 11;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(384, 82);
            label6.Name = "label6";
            label6.Size = new Size(292, 25);
            label6.TabIndex = 12;
            label6.Text = "Create User Registration     ";
            label6.Click += label6_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(Title);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1017, 579);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "User Registeration";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button3
            // 
            button3.BackColor = Color.Gainsboro;
            button3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            button3.Location = new Point(522, 478);
            button3.Name = "button3";
            button3.Size = new Size(97, 32);
            button3.TabIndex = 23;
            button3.Text = "Login";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(170, 507);
            label13.Name = "label13";
            label13.Size = new Size(710, 23);
            label13.TabIndex = 22;
            label13.Text = "----------------------------------------------------------------------------------------------------";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(170, 452);
            label12.Name = "label12";
            label12.Size = new Size(710, 23);
            label12.TabIndex = 21;
            label12.Text = "----------------------------------------------------------------------------------------------------";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(170, 56);
            label11.Name = "label11";
            label11.Size = new Size(710, 23);
            label11.TabIndex = 20;
            label11.Text = "----------------------------------------------------------------------------------------------------";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(170, 107);
            label10.Name = "label10";
            label10.Size = new Size(710, 23);
            label10.TabIndex = 19;
            label10.Text = "----------------------------------------------------------------------------------------------------";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(170, 351);
            label8.Name = "label8";
            label8.Size = new Size(710, 23);
            label8.TabIndex = 18;
            label8.Text = "----------------------------------------------------------------------------------------------------";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Times New Roman", 12F);
            textBox3.Location = new Point(563, 411);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 30);
            textBox3.TabIndex = 17;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Times New Roman", 12F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "SCIENCE", "BBA", "B.COM", "LAW", "MBA", "MSC - DS" });
            comboBox2.Location = new Point(591, 309);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 30);
            comboBox2.TabIndex = 16;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Times New Roman", 12F);
            textBox2.Location = new Point(591, 254);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 30);
            textBox2.TabIndex = 15;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 12F);
            textBox1.Location = new Point(591, 207);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 30);
            textBox1.TabIndex = 14;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Times New Roman", 12F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Student", "Volunteer", "Admin" });
            comboBox1.Location = new Point(591, 155);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 30);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 603);
            Controls.Add(groupBox1);
            Controls.Add(label9);
            Controls.Add(label2);
            Name = "Form1";
            Text = "REGISTRATION";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label9;
        private Button button1;
        private Button button2;
        private Label label6;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label8;
        private Button button3;
    }
}
