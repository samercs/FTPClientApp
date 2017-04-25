using System;
using System.Windows.Forms;

namespace FTPClientApp
{
    //this form use to rename ftp files.
    //We use this file as dilago to display to user when he need to rename any ftp file name.
    public partial class RenameDialog : Form
    {

        //FTP file name
        public string NewFileName { get; set; }

        public RenameDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //on rename button click. get the new name from textbox and hidden the form
            this.NewFileName = textBox1.Text;
            this.DialogResult = DialogResult.OK;

        }

        private void RenameDialog_Load(object sender, EventArgs e)
        {
            //on load form load old file name in the text box.
            textBox1.Text = NewFileName;
        }
    }
}
