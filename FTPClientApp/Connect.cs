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
    //this is the connect from.
    //in this form you enter ftp server info(url, username & password) to access the ftp server.
    public partial class Connect : Form
    {
        private readonly string _ftpUrl; // Ftp Url To Connect
        private readonly string _ftpUserName; // FTP User Name
        private readonly string _ftpPassword; // FTP Password
        public Connect()
        {
            //Add Demo Init FTP info
            _ftpUrl = "ftp://waws-prod-sn1-003.ftp.azurewebsites.windows.net/site/wwwroot";
            _ftpUserName = @"samercs\$samercs";
            _ftpPassword = "DfM0PduaA6ZhpgfqZaad2BuK9X0ENlsQhbux35dh9Tl3EsAvMMdT1RnDmJip";
            //Default Componenct init form methods
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Shutdown current application
            Application.Exit();
        }

        //This method use to enable or desable form elements (button & text box).
        private void EnableDisableForm(bool status)
        {
            textBox1.Enabled = status;
            textBox2.Enabled = status;
            textBox3.Enabled = status;
            btnClose.Enabled = status;
            button1.Enabled = status;
        }

        //Handel connect button click event
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisableForm(false);//Disable form elements to prevent user cahnge ftp login info after click connect button
                Ftp ftp = new Ftp(textBox1.Text, textBox2.Text, textBox3.Text);//create new Ftp object to connect.
                var result = ftp.directoryListSimple("/");//try to connect to this ftp
                if (!result.Any())//if connect not success. re enable form elements and display error message box
                {
                    EnableDisableForm(true);
                    MessageBox.Show(this, "Can't connect to ftp server", "Error Ftp Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
                //connect success. then we should open second form.
                EnableDisableForm(true);
                var mainForm = new Form1(textBox1.Text, textBox2.Text, textBox3.Text);
                mainForm.Show();
                this.Hide();
            }
            catch
            {
                //if any exception happen when user try to connect to ftp server. display error message box
                EnableDisableForm(true);
                MessageBox.Show(this, "Can't connect to ftp server", "Error Ftp Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void Connect_Load(object sender, EventArgs e)
        {
            //form load event.
            //When form load fill text box with demo ftp server info
            textBox1.Text = _ftpUrl;
            textBox2.Text = _ftpUserName;
            textBox3.Text = _ftpPassword;
        }
    }
}
