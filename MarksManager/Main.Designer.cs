namespace MarksManager
{
   partial class Main
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
      this.grp1 = new System.Windows.Forms.GroupBox();
      this.BtnLoad = new System.Windows.Forms.Button();
      this.LbPath = new System.Windows.Forms.Label();
      this.TxtPathIni = new System.Windows.Forms.TextBox();
      this.BtnPathIni = new System.Windows.Forms.Button();
      this.SelFileDlg = new System.Windows.Forms.OpenFileDialog();
      this.TxtMsgBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.ListBMarks = new System.Windows.Forms.ListBox();
      this.lstLines = new System.Windows.Forms.ListView();
      this.colLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label3 = new System.Windows.Forms.Label();
      this.CBFilter = new System.Windows.Forms.ComboBox();
      this.BtSave = new System.Windows.Forms.Button();
      this.LstMarks = new System.Windows.Forms.ListView();
      this.Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Lng1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Lng2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.BtAddMark = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.checkMarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.btnEditMark = new System.Windows.Forms.Button();
      this.btnDelMark = new System.Windows.Forms.Button();
      this.btnMarkRevised = new System.Windows.Forms.Button();
      this.btnClearRevised = new System.Windows.Forms.Button();
      this.btnUpdateFromFile = new System.Windows.Forms.Button();
      this.chkShowDes = new System.Windows.Forms.CheckBox();
      this.grp1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // grp1
      // 
      this.grp1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grp1.Controls.Add(this.BtnLoad);
      this.grp1.Controls.Add(this.LbPath);
      this.grp1.Controls.Add(this.TxtPathIni);
      this.grp1.Controls.Add(this.BtnPathIni);
      this.grp1.Location = new System.Drawing.Point(11, 30);
      this.grp1.Name = "grp1";
      this.grp1.Size = new System.Drawing.Size(1009, 74);
      this.grp1.TabIndex = 2;
      this.grp1.TabStop = false;
      this.grp1.Text = "Analyse Dictionary: ";
      // 
      // BtnLoad
      // 
      this.BtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BtnLoad.Location = new System.Drawing.Point(926, 25);
      this.BtnLoad.Name = "BtnLoad";
      this.BtnLoad.Size = new System.Drawing.Size(77, 31);
      this.BtnLoad.TabIndex = 4;
      this.BtnLoad.TabStop = false;
      this.BtnLoad.Text = "Load";
      this.BtnLoad.UseVisualStyleBackColor = true;
      this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
      // 
      // LbPath
      // 
      this.LbPath.AutoSize = true;
      this.LbPath.Location = new System.Drawing.Point(7, 28);
      this.LbPath.Name = "LbPath";
      this.LbPath.Size = new System.Drawing.Size(42, 18);
      this.LbPath.TabIndex = 0;
      this.LbPath.Text = "Path:";
      // 
      // TxtPathIni
      // 
      this.TxtPathIni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TxtPathIni.Location = new System.Drawing.Point(49, 26);
      this.TxtPathIni.Name = "TxtPathIni";
      this.TxtPathIni.Size = new System.Drawing.Size(827, 23);
      this.TxtPathIni.TabIndex = 1;
      this.TxtPathIni.TabStop = false;
      // 
      // BtnPathIni
      // 
      this.BtnPathIni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BtnPathIni.Location = new System.Drawing.Point(885, 25);
      this.BtnPathIni.Name = "BtnPathIni";
      this.BtnPathIni.Size = new System.Drawing.Size(33, 31);
      this.BtnPathIni.TabIndex = 2;
      this.BtnPathIni.TabStop = false;
      this.BtnPathIni.Text = "...";
      this.BtnPathIni.UseVisualStyleBackColor = true;
      this.BtnPathIni.Click += new System.EventHandler(this.BtnPathIni_Click);
      // 
      // SelFileDlg
      // 
      this.SelFileDlg.FileName = "openFileDialog1";
      // 
      // TxtMsgBox
      // 
      this.TxtMsgBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TxtMsgBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TxtMsgBox.Location = new System.Drawing.Point(8, 563);
      this.TxtMsgBox.Multiline = true;
      this.TxtMsgBox.Name = "TxtMsgBox";
      this.TxtMsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.TxtMsgBox.Size = new System.Drawing.Size(1236, 70);
      this.TxtMsgBox.TabIndex = 8;
      this.TxtMsgBox.TabStop = false;
      this.TxtMsgBox.TextChanged += new System.EventHandler(this.TxtMsgBox_TextChanged);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(749, 122);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(109, 18);
      this.label1.TabIndex = 11;
      this.label1.Text = "Change Marks:";
      // 
      // ListBMarks
      // 
      this.ListBMarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ListBMarks.FormattingEnabled = true;
      this.ListBMarks.ItemHeight = 17;
      this.ListBMarks.Location = new System.Drawing.Point(745, 141);
      this.ListBMarks.Name = "ListBMarks";
      this.ListBMarks.ScrollAlwaysVisible = true;
      this.ListBMarks.Size = new System.Drawing.Size(279, 276);
      this.ListBMarks.TabIndex = 1;
      this.ListBMarks.SelectedIndexChanged += new System.EventHandler(this.ListBMarks_SelectedIndexChanged);
      // 
      // lstLines
      // 
      this.lstLines.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.lstLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLine});
      this.lstLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lstLines.FullRowSelect = true;
      this.lstLines.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.lstLines.HideSelection = false;
      this.lstLines.Location = new System.Drawing.Point(9, 140);
      this.lstLines.MultiSelect = false;
      this.lstLines.Name = "lstLines";
      this.lstLines.Size = new System.Drawing.Size(728, 416);
      this.lstLines.TabIndex = 0;
      this.lstLines.UseCompatibleStateImageBehavior = false;
      this.lstLines.View = System.Windows.Forms.View.Details;
      this.lstLines.VirtualMode = true;
      this.lstLines.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lstLines_RetrieveVirtualItem);
      this.lstLines.SelectedIndexChanged += new System.EventHandler(this.lstLines_SelectedIndexChanged);
      this.lstLines.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLines_KeyPress);
      // 
      // colLine
      // 
      this.colLine.Text = "Lines:";
      this.colLine.Width = 703;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 114);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(44, 18);
      this.label3.TabIndex = 12;
      this.label3.Text = "Filter:";
      // 
      // CBFilter
      // 
      this.CBFilter.FormattingEnabled = true;
      this.CBFilter.Items.AddRange(new object[] {
            "No Filter",
            "Checked",
            "Unchecked"});
      this.CBFilter.Location = new System.Drawing.Point(63, 111);
      this.CBFilter.Name = "CBFilter";
      this.CBFilter.Size = new System.Drawing.Size(201, 25);
      this.CBFilter.TabIndex = 0;
      this.CBFilter.TabStop = false;
      this.CBFilter.SelectedValueChanged += new System.EventHandler(this.CBFilter_SelectedValueChanged);
      // 
      // BtSave
      // 
      this.BtSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BtSave.Location = new System.Drawing.Point(628, 109);
      this.BtSave.Name = "BtSave";
      this.BtSave.Size = new System.Drawing.Size(109, 25);
      this.BtSave.TabIndex = 14;
      this.BtSave.TabStop = false;
      this.BtSave.Text = "Save";
      this.BtSave.UseVisualStyleBackColor = true;
      this.BtSave.Click += new System.EventHandler(this.BtSave_Click);
      // 
      // LstMarks
      // 
      this.LstMarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LstMarks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Code,
            this.Desc,
            this.Lng1,
            this.Lng2});
      this.LstMarks.FullRowSelect = true;
      this.LstMarks.HideSelection = false;
      this.LstMarks.Location = new System.Drawing.Point(745, 422);
      this.LstMarks.MultiSelect = false;
      this.LstMarks.Name = "LstMarks";
      this.LstMarks.Size = new System.Drawing.Size(499, 136);
      this.LstMarks.TabIndex = 3;
      this.LstMarks.UseCompatibleStateImageBehavior = false;
      this.LstMarks.View = System.Windows.Forms.View.Details;
      this.LstMarks.DoubleClick += new System.EventHandler(this.LstMarks_DoubleClick);
      this.LstMarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstMarks_KeyPress);
      // 
      // Code
      // 
      this.Code.Text = "Code";
      // 
      // Desc
      // 
      this.Desc.Text = "Description";
      this.Desc.Width = 120;
      // 
      // Lng1
      // 
      this.Lng1.Text = "Lng1";
      this.Lng1.Width = 120;
      // 
      // Lng2
      // 
      this.Lng2.Text = "Lng2";
      this.Lng2.Width = 89;
      // 
      // BtAddMark
      // 
      this.BtAddMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BtAddMark.Location = new System.Drawing.Point(1031, 385);
      this.BtAddMark.Name = "BtAddMark";
      this.BtAddMark.Size = new System.Drawing.Size(59, 31);
      this.BtAddMark.TabIndex = 16;
      this.BtAddMark.TabStop = false;
      this.BtAddMark.Text = "Add";
      this.BtAddMark.UseVisualStyleBackColor = true;
      this.BtAddMark.Click += new System.EventHandler(this.BtAddMark_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(1251, 28);
      this.menuStrip1.TabIndex = 17;
      this.menuStrip1.Text = "Tools";
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkMarksToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
      this.toolsToolStripMenuItem.Text = "Tools";
      // 
      // checkMarksToolStripMenuItem
      // 
      this.checkMarksToolStripMenuItem.Name = "checkMarksToolStripMenuItem";
      this.checkMarksToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
      this.checkMarksToolStripMenuItem.Text = "Check Marks";
      this.checkMarksToolStripMenuItem.Click += new System.EventHandler(this.checkMarksToolStripMenuItem_Click);
      // 
      // btnEditMark
      // 
      this.btnEditMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEditMark.Location = new System.Drawing.Point(1095, 385);
      this.btnEditMark.Name = "btnEditMark";
      this.btnEditMark.Size = new System.Drawing.Size(56, 31);
      this.btnEditMark.TabIndex = 16;
      this.btnEditMark.TabStop = false;
      this.btnEditMark.Text = "Edit";
      this.btnEditMark.UseVisualStyleBackColor = true;
      this.btnEditMark.Click += new System.EventHandler(this.btnEditMark_Click);
      // 
      // btnDelMark
      // 
      this.btnDelMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelMark.Location = new System.Drawing.Point(1187, 385);
      this.btnDelMark.Name = "btnDelMark";
      this.btnDelMark.Size = new System.Drawing.Size(56, 31);
      this.btnDelMark.TabIndex = 16;
      this.btnDelMark.TabStop = false;
      this.btnDelMark.Text = "Del";
      this.btnDelMark.UseVisualStyleBackColor = true;
      this.btnDelMark.Click += new System.EventHandler(this.btnDelMark_Click);
      // 
      // btnMarkRevised
      // 
      this.btnMarkRevised.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMarkRevised.Location = new System.Drawing.Point(1031, 274);
      this.btnMarkRevised.Name = "btnMarkRevised";
      this.btnMarkRevised.Size = new System.Drawing.Size(72, 31);
      this.btnMarkRevised.TabIndex = 16;
      this.btnMarkRevised.TabStop = false;
      this.btnMarkRevised.Text = "Revised";
      this.btnMarkRevised.UseVisualStyleBackColor = true;
      this.btnMarkRevised.Click += new System.EventHandler(this.btnMarkRevised_Click);
      // 
      // btnClearRevised
      // 
      this.btnClearRevised.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClearRevised.Location = new System.Drawing.Point(1125, 274);
      this.btnClearRevised.Name = "btnClearRevised";
      this.btnClearRevised.Size = new System.Drawing.Size(119, 31);
      this.btnClearRevised.TabIndex = 16;
      this.btnClearRevised.TabStop = false;
      this.btnClearRevised.Text = "Clear Revised";
      this.btnClearRevised.UseVisualStyleBackColor = true;
      this.btnClearRevised.Click += new System.EventHandler(this.btnClearRevised_Click);
      // 
      // btnUpdateFromFile
      // 
      this.btnUpdateFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnUpdateFromFile.Location = new System.Drawing.Point(1033, 348);
      this.btnUpdateFromFile.Name = "btnUpdateFromFile";
      this.btnUpdateFromFile.Size = new System.Drawing.Size(209, 31);
      this.btnUpdateFromFile.TabIndex = 16;
      this.btnUpdateFromFile.TabStop = false;
      this.btnUpdateFromFile.Text = "Update Marks from File";
      this.btnUpdateFromFile.UseVisualStyleBackColor = true;
      this.btnUpdateFromFile.Click += new System.EventHandler(this.btnUpdateFromFile_Click);
      // 
      // chkShowDes
      // 
      this.chkShowDes.AutoSize = true;
      this.chkShowDes.Location = new System.Drawing.Point(288, 114);
      this.chkShowDes.Name = "chkShowDes";
      this.chkShowDes.Size = new System.Drawing.Size(182, 22);
      this.chkShowDes.TabIndex = 18;
      this.chkShowDes.Text = "Mostrar idioma destino";
      this.chkShowDes.UseVisualStyleBackColor = true;
      this.chkShowDes.CheckedChanged += new System.EventHandler(this.chkShowDes_CheckedChanged);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1251, 642);
      this.Controls.Add(this.chkShowDes);
      this.Controls.Add(this.btnDelMark);
      this.Controls.Add(this.btnEditMark);
      this.Controls.Add(this.btnUpdateFromFile);
      this.Controls.Add(this.btnClearRevised);
      this.Controls.Add(this.btnMarkRevised);
      this.Controls.Add(this.BtAddMark);
      this.Controls.Add(this.LstMarks);
      this.Controls.Add(this.BtSave);
      this.Controls.Add(this.CBFilter);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.lstLines);
      this.Controls.Add(this.ListBMarks);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.TxtMsgBox);
      this.Controls.Add(this.grp1);
      this.Controls.Add(this.menuStrip1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Manage Marks";
      this.grp1.ResumeLayout(false);
      this.grp1.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox grp1;
      private System.Windows.Forms.Button BtnLoad;
      private System.Windows.Forms.Label LbPath;
      private System.Windows.Forms.TextBox TxtPathIni;
      private System.Windows.Forms.Button BtnPathIni;
      private System.Windows.Forms.OpenFileDialog SelFileDlg;
      private System.Windows.Forms.TextBox TxtMsgBox;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ListBox ListBMarks;
      private System.Windows.Forms.ListView lstLines;
      private System.Windows.Forms.ColumnHeader colLine;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox CBFilter;
      private System.Windows.Forms.Button BtSave;
      private System.Windows.Forms.ListView LstMarks;
      private System.Windows.Forms.ColumnHeader Code;
      private System.Windows.Forms.ColumnHeader Lng2;
      private System.Windows.Forms.ColumnHeader Desc;
      private System.Windows.Forms.ColumnHeader Lng1;
      private System.Windows.Forms.Button BtAddMark;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem checkMarksToolStripMenuItem;
    private System.Windows.Forms.Button btnEditMark;
    private System.Windows.Forms.Button btnDelMark;
    private System.Windows.Forms.Button btnMarkRevised;
    private System.Windows.Forms.Button btnClearRevised;
    private System.Windows.Forms.Button btnUpdateFromFile;
    private System.Windows.Forms.CheckBox chkShowDes;
    }
}

