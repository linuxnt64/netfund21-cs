namespace _01_WinForms_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lbActivities.Items.Add(tbActivity.Text);
            tbActivity.Text = "";
        }
    }
}