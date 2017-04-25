using System;
using System.Windows.Forms;

namespace FTPClientApp
{
    public partial class RenameDialog : Form
    {
        public string NewFileName { get; set; }

        public RenameDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewFileName = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            
        }

        private void RenameDialog_Load(object sender, EventArgs e)
        {
            textBox1.Text = NewFileName;
        }
    }
}
