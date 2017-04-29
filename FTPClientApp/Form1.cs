using System;
using System.IO;
using System.Windows.Forms;

namespace FTPClientApp
{
    //this is the main ftp from
    //in this form you can do many ftp operation like upload file, download file .....
    public partial class Form1 : Form
    {
        //this is ftp server info from previous form
        private readonly string ftpUrl;
        private readonly string ftpUserName;
        private readonly string ftpPassword;

        private string selectedRemoteFile = "";//selected remote file that user need to work on it
        private string currentLocalFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");//local folder path that user use to interactive with server
        private string currentRemoteFolder = "/";// remote folder 

        //load ftp info from previous form and display current screen.
        public Form1(string url, string username, string password)
        {
            ftpUrl = url;
            ftpUserName = username;
            ftpPassword = password;
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //when from load display current loacal folder files & remote folder files
            LoadLocalFiles();

            LoadServerFile();

        }

        private void LoadServerFile()
        {
            //get remote files and refresh the tree for ftp files
            treeView1.Nodes.Clear();
            var serverNode = new TreeNode("Server Files");
            GetServerFiles(this.currentRemoteFolder, ref serverNode);
            treeView1.Nodes.Add(serverNode);
            treeView1.ExpandAll();
        }

        private void LoadLocalFiles()
        {
            //load local file and refresh the local files tree
            treeView2.Nodes.Clear();
            var node = new TreeNode("Local Files");
            GetFiles(this.currentLocalFolder, ref node);
            treeView2.Nodes.Add(node);
            treeView2.ExpandAll();
        }

        private void GetFiles(string path, ref TreeNode node)
        {
            //read folder content and display folder & files
            DirectoryInfo d = new DirectoryInfo(path);
            foreach (var dir in d.GetDirectories())
            {
                var dirNode = new TreeNode(dir.Name);
                GetFiles(dir.FullName, ref dirNode);
                node.Nodes.Add(dirNode);
            }
            foreach (var file in d.GetFiles())
            {
                int imgIndex = GetImgIndex(file.Name);
                node.Nodes.Add(file.FullName, file.Name, imgIndex);
            }

        }

        private void GetServerFiles(string path, ref TreeNode node)
        {
            //read server files & folders and display this content in the tree
            var ftpClient = new Ftp(ftpUrl, ftpUserName, ftpPassword);
            var serverDirectories = ftpClient.directoryListDetailed(path);
            foreach (var dir in serverDirectories)
            {
                int imgIndex = 0;
                if (!string.IsNullOrEmpty(dir))
                {

                    var serverFile = ServerFile.Create(dir);

                    if (serverFile.FileType == FileType.File)
                    {
                        imgIndex = GetImgIndex(serverFile.Name);
                        node.Nodes.Add(dir, $"{serverFile.Name,-30} : ({serverFile.Size} byte)", imgIndex);
                    }
                    else
                    {
                        node.Nodes.Add(dir, serverFile.Name, imgIndex);
                    }

                }

            }
        }

        private int GetImgIndex(string name)
        {
            //use this method to get file icon (in our tree each file type has diffrent icon like pdf files, images files...)
            int imgIndex = 1;
            var fileName = name.ToLower();
            if (fileName.EndsWith(".doc") || fileName.EndsWith(".docx"))
            {
                imgIndex = 4;
            }
            if (fileName.EndsWith(".pdf"))
            {
                imgIndex = 3;
            }
            if (fileName.EndsWith(".jpg") || fileName.EndsWith(".jepg") || fileName.EndsWith(".png") ||
                fileName.EndsWith(".gif"))
            {
                imgIndex = 2;
            }
            if (fileName.EndsWith(".ppt") || fileName.EndsWith(".pptx"))
            {
                imgIndex = 5;
            }
            if (fileName.EndsWith(".xls") || fileName.EndsWith(".xlsx"))
            {
                imgIndex = 6;
            }
            if (fileName.EndsWith(".exe"))
            {
                imgIndex = 7;
            }
            if (fileName.EndsWith(".php"))
            {
                imgIndex = 8;
            }
            if (fileName.EndsWith(".aspx"))
            {
                imgIndex = 9;
            }
            if (fileName.EndsWith(".css") || fileName.EndsWith(".less") || fileName.EndsWith(".sass") || fileName.EndsWith(".scss"))
            {
                imgIndex = 10;
            }
            if (fileName.EndsWith(".html") || fileName.EndsWith(".htm"))
            {
                imgIndex = 11;
            }
            if (fileName.EndsWith(".cs"))
            {
                imgIndex = 12;
            }

            return imgIndex;
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        //hande uploaf file button click
        private void btnUpload_Click(object sender, EventArgs e)
        {
            //check first that user serlect file to upload to server
            if (!string.IsNullOrEmpty(treeView2.SelectedNode.Name))
            {
                var uploadFilePath = Path.Combine(this.currentRemoteFolder, Path.GetFileName(treeView2.SelectedNode.Name));//get full file path
                Ftp ftp = new Ftp(ftpUrl, ftpUserName, ftpPassword);//create new ftp object to use for file upload
                var result = ftp.upload(uploadFilePath, treeView2.SelectedNode.Name);//upload file to server
                if (result)//if success display message that the upload has been complete
                {
                    MessageBox.Show($"File {Path.GetFileName(treeView2.SelectedNode.Name)} has been upload successfully to {uploadFilePath}");
                    LoadServerFile();//refresh server files
                    treeView1.ExpandAll();//expand the server file tree
                }
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // if user select local file. then enable the upload button. by default the upload button is disabled
            if (!string.IsNullOrEmpty(e.Node.Name))
            {
                btnUpload.Enabled = true;
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // if user select remote file (file not folder). enable download button and rename button and delete buttons
            if (!string.IsNullOrEmpty(e.Node.Name))
            {
                ServerFile s = ServerFile.Create(e.Node.Name);
                if (s.FileType == FileType.Folder)
                {
                    this.btnDownload.Enabled = false;
                    this.btnRename.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
                else
                {
                    this.selectedRemoteFile = e.Node.Name;
                    this.btnDownload.Enabled = true;
                    this.btnRename.Enabled = true;
                    this.btnDelete.Enabled = true;

                }
            }
        }


        //handel download button click
        private void btnDownload_Click(object sender, EventArgs e)
        {
            Ftp ftp = new Ftp(ftpUrl, ftpUserName, ftpPassword);//create new ftp object to use for file download
            var remoteFileServer = ServerFile.Create(this.selectedRemoteFile);//create new remote file object
            //try to download the file from server to current local folder
            var result = ftp.download(Path.Combine(this.currentRemoteFolder, remoteFileServer.Name), Path.Combine(this.currentLocalFolder, Path.GetFileName(remoteFileServer.Name)));
            if (result)//if success. display mesasge box that file download complete
            {
                MessageBox.Show("File has been downloaded successfully.");
                LoadLocalFiles();
                treeView2.ExpandAll();
            }
        }

        //handel rename button click
        private void btnRename_Click(object sender, EventArgs e)
        {
            //crete new server file object
            ServerFile s = ServerFile.Create(this.selectedRemoteFile);

            //create new rename dialog object
            var renameDialog = new RenameDialog();
            //set rename dialog file name
            renameDialog.NewFileName = s.Name;
            if (renameDialog.ShowDialog(this) == DialogResult.OK)//display the rename file dialog. then if user click the rename button on rename dialog
            {
                Ftp ftp = new Ftp(ftpUrl, ftpUserName, ftpPassword);//create new ftp object
                var result = ftp.rename(this.currentRemoteFolder + "/" + Path.GetFileName(s.Name), renameDialog.NewFileName);//try to rename server file.
                renameDialog.Dispose();//hidden rename dialog
                LoadServerFile();//refresh server file tree
                treeView1.ExpandAll();//expand server files tree
            }
        }


        //handel delete file button click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //fisrt display confirmation message to user.
            if (
                MessageBox.Show(this, "Are you want to delete this file from server?", "Delete", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            //if user click yes on the confirmation message
            {
                ServerFile s = ServerFile.Create(this.selectedRemoteFile);// create new file server object
                Ftp ftp = new Ftp(ftpUrl, ftpUserName, ftpPassword);//create new ftp object
                var result = ftp.delete(Path.Combine(this.currentRemoteFolder, s.Name));//delete the server file
                if (result)//if delete success
                {
                    //display message box to user that delete has complete
                    MessageBox.Show($"Files {s.Name} has been deleted successfully.");
                    LoadServerFile();//refresh server files tree
                    treeView1.ExpandAll();//expand server file tree
                }

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//shutdown application
        }
    }
}
