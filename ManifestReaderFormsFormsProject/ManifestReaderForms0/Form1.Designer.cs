namespace ManifestReaderForms0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblPathTitle = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.cmdChooseFolder = new System.Windows.Forms.Button();
            this.lblFilesFoundTitle = new System.Windows.Forms.Label();
            this.lblFilesFound = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblFile = new System.Windows.Forms.Label();
            this.cmdGetFile = new System.Windows.Forms.Button();
            this.lblFakeFile = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblFileTitle = new System.Windows.Forms.Label();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdClean = new System.Windows.Forms.Button();
            this.tblFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPathTitle
            // 
            this.lblPathTitle.AutoSize = true;
            this.lblPathTitle.Location = new System.Drawing.Point(12, 5);
            this.lblPathTitle.Name = "lblPathTitle";
            this.lblPathTitle.Size = new System.Drawing.Size(41, 17);
            this.lblPathTitle.TabIndex = 0;
            this.lblPathTitle.Text = "Path:";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(13, 25);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(18, 17);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "--";
            // 
            // cmdChooseFolder
            // 
            this.cmdChooseFolder.BackColor = System.Drawing.SystemColors.Control;
            this.cmdChooseFolder.Location = new System.Drawing.Point(16, 111);
            this.cmdChooseFolder.Name = "cmdChooseFolder";
            this.cmdChooseFolder.Size = new System.Drawing.Size(80, 45);
            this.cmdChooseFolder.TabIndex = 2;
            this.cmdChooseFolder.Text = "Choose folder";
            this.cmdChooseFolder.UseVisualStyleBackColor = false;
            this.cmdChooseFolder.Click += new System.EventHandler(this.cmdChooseFolder_Click);
            // 
            // lblFilesFoundTitle
            // 
            this.lblFilesFoundTitle.AutoSize = true;
            this.lblFilesFoundTitle.Location = new System.Drawing.Point(11, 46);
            this.lblFilesFoundTitle.Name = "lblFilesFoundTitle";
            this.lblFilesFoundTitle.Size = new System.Drawing.Size(81, 17);
            this.lblFilesFoundTitle.TabIndex = 3;
            this.lblFilesFoundTitle.Text = "Files found:";
            // 
            // lblFilesFound
            // 
            this.lblFilesFound.AutoSize = true;
            this.lblFilesFound.Location = new System.Drawing.Point(12, 70);
            this.lblFilesFound.Name = "lblFilesFound";
            this.lblFilesFound.Size = new System.Drawing.Size(18, 17);
            this.lblFilesFound.TabIndex = 4;
            this.lblFilesFound.Text = "--";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tblname,
            this.tblFile});
            this.dataGridView1.Location = new System.Drawing.Point(16, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(550, 192);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(462, 369);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(110, 17);
            this.lblFile.TabIndex = 6;
            this.lblFile.Text = "File to download";
            this.lblFile.Visible = false;
            // 
            // cmdGetFile
            // 
            this.cmdGetFile.Enabled = false;
            this.cmdGetFile.Location = new System.Drawing.Point(412, 389);
            this.cmdGetFile.Name = "cmdGetFile";
            this.cmdGetFile.Size = new System.Drawing.Size(75, 30);
            this.cmdGetFile.TabIndex = 7;
            this.cmdGetFile.Text = "Open file";
            this.cmdGetFile.UseVisualStyleBackColor = true;
            this.cmdGetFile.Click += new System.EventHandler(this.cmdGetFile_Click);
            // 
            // lblFakeFile
            // 
            this.lblFakeFile.AutoSize = true;
            this.lblFakeFile.Location = new System.Drawing.Point(101, 371);
            this.lblFakeFile.Name = "lblFakeFile";
            this.lblFakeFile.Size = new System.Drawing.Size(18, 17);
            this.lblFakeFile.TabIndex = 8;
            this.lblFakeFile.Text = "--";
            // 
            // cmdSave
            // 
            this.cmdSave.Enabled = false;
            this.cmdSave.Location = new System.Drawing.Point(491, 389);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 30);
            this.cmdSave.TabIndex = 9;
            this.cmdSave.Text = "Save file";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblFileTitle
            // 
            this.lblFileTitle.AutoSize = true;
            this.lblFileTitle.Location = new System.Drawing.Point(13, 371);
            this.lblFileTitle.Name = "lblFileTitle";
            this.lblFileTitle.Size = new System.Drawing.Size(91, 17);
            this.lblFileTitle.TabIndex = 10;
            this.lblFileTitle.Text = "File selected:";
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Location = new System.Drawing.Point(199, 134);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(57, 17);
            this.lblSearchTitle.TabIndex = 11;
            this.lblSearchTitle.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(262, 134);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(144, 22);
            this.txtSearch.TabIndex = 12;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Enabled = false;
            this.cmdSearch.Location = new System.Drawing.Point(412, 109);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 47);
            this.cmdSearch.TabIndex = 13;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdClean
            // 
            this.cmdClean.Enabled = false;
            this.cmdClean.Location = new System.Drawing.Point(491, 109);
            this.cmdClean.Name = "cmdClean";
            this.cmdClean.Size = new System.Drawing.Size(75, 47);
            this.cmdClean.TabIndex = 14;
            this.cmdClean.Text = "Clean search";
            this.cmdClean.UseVisualStyleBackColor = true;
            this.cmdClean.Click += new System.EventHandler(this.cmdClean_Click);
            // 
            // tblFile
            // 
            this.tblFile.HeaderText = "File";
            this.tblFile.Name = "tblFile";
            this.tblFile.ReadOnly = true;
            // 
            // tblname
            // 
            this.tblname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tblname.FillWeight = 500F;
            this.tblname.HeaderText = "Name";
            this.tblname.Name = "tblname";
            this.tblname.ReadOnly = true;
            this.tblname.Visible = false;
            this.tblname.Width = 74;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 431);
            this.Controls.Add(this.cmdClean);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearchTitle);
            this.Controls.Add(this.lblFileTitle);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lblFakeFile);
            this.Controls.Add(this.cmdGetFile);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblFilesFound);
            this.Controls.Add(this.lblFilesFoundTitle);
            this.Controls.Add(this.cmdChooseFolder);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblPathTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Manifest Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblPathTitle;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button cmdChooseFolder;
        private System.Windows.Forms.Label lblFilesFoundTitle;
        protected System.Windows.Forms.Label lblFilesFound;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button cmdGetFile;
        private System.Windows.Forms.Label lblFakeFile;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblFileTitle;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdClean;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblFile;
    }
}

