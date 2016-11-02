namespace FTPClientApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("File 1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("File 2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Folder 1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("File 1");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("File 2");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Folder 2", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node6");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("File 1");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("File 2");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Folder 1", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("File 1");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("File 2");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Folder 2", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Node6");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 672);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote Files";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.treeView2);
            this.groupBox2.Location = new System.Drawing.Point(703, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(697, 672);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local Files";
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(6, 19);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 2;
            treeNode1.Name = "Node2";
            treeNode1.SelectedImageKey = "image.png";
            treeNode1.Text = "File 1";
            treeNode2.ImageIndex = 4;
            treeNode2.Name = "Node3";
            treeNode2.SelectedImageKey = "word.png";
            treeNode2.Text = "File 2";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Folder 1";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "Node4";
            treeNode4.SelectedImageKey = "file.png";
            treeNode4.Text = "File 1";
            treeNode5.ImageIndex = 4;
            treeNode5.Name = "Node5";
            treeNode5.SelectedImageKey = "word.png";
            treeNode5.Text = "File 2";
            treeNode6.Name = "Node1";
            treeNode6.Text = "Folder 2";
            treeNode7.ImageIndex = 3;
            treeNode7.Name = "Node6";
            treeNode7.SelectedImageKey = "pdf.png";
            treeNode7.Text = "Node6";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode7});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(673, 647);
            this.treeView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1478080389_Folder.png");
            this.imageList1.Images.SetKeyName(1, "file.png");
            this.imageList1.Images.SetKeyName(2, "image.png");
            this.imageList1.Images.SetKeyName(3, "pdf.png");
            this.imageList1.Images.SetKeyName(4, "word.png");
            // 
            // treeView2
            // 
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.imageList1;
            this.treeView2.Location = new System.Drawing.Point(17, 19);
            this.treeView2.Name = "treeView2";
            treeNode8.ImageIndex = 2;
            treeNode8.Name = "Node2";
            treeNode8.SelectedImageKey = "image.png";
            treeNode8.Text = "File 1";
            treeNode9.ImageIndex = 4;
            treeNode9.Name = "Node3";
            treeNode9.SelectedImageKey = "word.png";
            treeNode9.Text = "File 2";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Folder 1";
            treeNode11.ImageIndex = 1;
            treeNode11.Name = "Node4";
            treeNode11.SelectedImageKey = "file.png";
            treeNode11.Text = "File 1";
            treeNode12.ImageIndex = 4;
            treeNode12.Name = "Node5";
            treeNode12.SelectedImageKey = "word.png";
            treeNode12.Text = "File 2";
            treeNode13.Name = "Node1";
            treeNode13.Text = "Folder 2";
            treeNode14.ImageIndex = 3;
            treeNode14.Name = "Node6";
            treeNode14.SelectedImageKey = "pdf.png";
            treeNode14.Text = "Node6";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode13,
            treeNode14});
            this.treeView2.SelectedImageIndex = 0;
            this.treeView2.Size = new System.Drawing.Size(668, 647);
            this.treeView2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList2;
            this.button1.Location = new System.Drawing.Point(12, 687);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "Download File";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "download.png");
            this.imageList2.Images.SetKeyName(1, "upload.png");
            this.imageList2.Images.SetKeyName(2, "rename.png");
            this.imageList2.Images.SetKeyName(3, "1478081027_file_delete.png");
            // 
            // button2
            // 
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImageIndex = 1;
            this.button2.ImageList = this.imageList2;
            this.button2.Location = new System.Drawing.Point(703, 687);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 55);
            this.button2.TabIndex = 3;
            this.button2.Text = "Upload File";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 2;
            this.button3.ImageList = this.imageList2;
            this.button3.Location = new System.Drawing.Point(184, 687);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 55);
            this.button3.TabIndex = 4;
            this.button3.Text = "Rename";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageIndex = 3;
            this.button4.ImageList = this.imageList2;
            this.button4.Location = new System.Drawing.Point(354, 687);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 55);
            this.button4.TabIndex = 5;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 758);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

