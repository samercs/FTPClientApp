using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClientApp
{
    public partial class Connect : Form
    {
        private readonly string _ftpUrl;
        private readonly string _ftpUserName ;
        private readonly string _ftpPassword;
        public Connect()
        {
            _ftpUrl = "ftp://waws-prod-sn1-003.ftp.azurewebsites.windows.net/site/wwwroot";
            _ftpUserName = "NCSS\\$NCSS";
            _ftpPassword = "ATc5izubLjtcACpctjlg3J7MlCDcR9zoFe6sgDnmsJaNJbMNa41JAAEbYRSE";

            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EnableDisableForm(bool status)
        {
            textBox1.Enabled = status;
            textBox2.Enabled = status;
            textBox3.Enabled = status;
            btnClose.Enabled = status;
            button1.Enabled = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisableForm(false);
                Ftp ftp = new Ftp(textBox1.Text, textBox2.Text, textBox3.Text);
                var result = ftp.directoryListSimple("/");
                if (!result.Any())
                {
                    EnableDisableForm(true);
                    MessageBox.Show(this, "Can't connect to ftp server", "Error Ftp Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
                EnableDisableForm(true);
                var mainForm = new Form1(textBox1.Text, textBox2.Text, textBox3.Text);
                mainForm.Show();
                this.Hide();
            }
            catch
            {
                EnableDisableForm(true);
                MessageBox.Show(this, "Can't connect to ftp server", "Error Ftp Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            textBox1.Text = _ftpUrl;
            textBox2.Text = _ftpUserName;
            textBox3.Text = _ftpPassword;
        }
    }
}
