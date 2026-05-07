using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bus_Service
{
    public partial class StudentDashboard : Form
    {
        
            int userID;

            public StudentDashboard()
            {
                InitializeComponent();
            }

            public StudentDashboard(int UserID)
            {
                InitializeComponent();
                userID = UserID;
            }
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
