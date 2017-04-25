using System;
using System.IO;
using System.Windows.Forms;

namespace FTPClientApp
{
    public partial class Form1 : Form
    {

        private readonly string ftpUrl;
        private readonly string ftpUserName;
        private readonly string ftpPassword;

        private string selectedRemoteFile = "";
        private string currentLocalFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        private string currentRemoteFolder = "/";

        public Form1(string url, string username, string password)
        {
            ftpUrl = url;
            ftpUserName = username;
            ftpPassword = password;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLocalFiles();

            LoadServerFile();

        }

        private void LoadServerFile()
        {
            //get ftp files
            treeView1.Nodes.Clear();
            var serverNode = new TreeNode("Server Files");
            GetServerFiles(this.currentRemoteFolder, ref serverNode);
            treeView1.Nodes.Add(serverNode);
            treeView1.ExpandAll();
        }

        private void LoadLocalFiles()
        {
            treeView2.Nodes.Clear();
            var node = new TreeNode("Local Files");
            GetFiles(this.currentLocalFolder, ref node);
            treeView2.Nodes.Add(node);
            treeView2.ExpandAll();
        }

        private void GetFiles(string path, ref TreeNode node)
        {
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
                        node.Nodes.Add(dir, $"{serverFile.Name.Trim(),-30} : ({serverFile.Size} byte)", imgIndex);
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(treeView2.SelectedNode.Name))
            {
                var uploadFilePath = Path.Combine(this.currentRemoteFolder, Path.GetFileName(treeView2.SelectedNode.Name));
                Ftp ftp = new Ftp(ftpUrl, ftpUserName, ftpPassword);
                var result = ftp.upload(uploadFilePath, treeView2.SelectedNode.Name);
                if (result)
                {
                    MessageBox.Show($"File {Path.GetFileName(treeView2.SelectedNode.Name)} has been upload successfully to {uploadFilePath}");
                    LoadServerFile();
                    treeView1.ExpandAll();
                }
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Node.Name))
            {
                btnUpload.Enabled = true;
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Ftp ftp = new Ftp(ftpUrl, ftpUserName, ftpPassword);
            var remoteFileServer = ServerFile.Create(this.selectedRemoteFile);
            var result = ftp.download(Path.Combine(this.currentRemoteFolder, remoteFileServer.Name), Path.Combine(this.currentLocalFolder, Path.GetFileName(remoteFileServer.Name)));
            if (result)
            {
                MessageBox.Show("File has been downloaded successfully.");
                LoadLocalFiles();
                treeView2.ExpandAll();
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            ServerFile s = ServerFile.Create(this.selectedRemoteFile);

            var renameDialog = new RenameDialog();
            renameDialog.NewFileName = s.Name;
            if (renameDialog.ShowDialog(this) == DialogResult.OK)
            {
                Ftp ftp = new Ftp(ftpUrl, ftpUserName, ftpPassword);
                var result = ftp.rename(this.currentRemoteFolder + "/" + Path.GetFileName(s.Name), renameDialog.NewFileName);
                renameDialog.Dispose();
                LoadServerFile();
                treeView1.ExpandAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(this, "Are you want to delete this file from server?", "Delete", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                ServerFile s = ServerFile.Create(this.selectedRemoteFile);
                Ftp ftp = new Ftp(ftpUrl, ftpUserName, ftpPassword);
                var result = ftp.delete(Path.Combine(this.currentRemoteFolder, s.Name));
                if (result)
                {
                    MessageBox.Show($"Files {s.Name} has been deleted successfully.");
                    LoadServerFile();
                    treeView1.ExpandAll();
                }

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
