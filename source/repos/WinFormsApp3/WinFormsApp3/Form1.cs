namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string language = "";

            foreach (var item in checkedListBox1.CheckedItems)
            {
                language += item.ToString() + ", ";
            }

            MessageBox.Show(
                "Name: " + textBox1.Text +
                "\nAge: " + textBox2.Text +
                "\nKnows Language: " + language
            );
        }

    }
}
