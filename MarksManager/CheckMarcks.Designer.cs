namespace MarksManager
{
   partial class CheckMarcks
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
      this.LbPath = new System.Windows.Forms.Label();
      this.TxtPathIni1 = new System.Windows.Forms.TextBox();
      this.BtnPathIni = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.TxtPathIni2 = new System.Windows.Forms.TextBox();
      this.button2 = new System.Windows.Forms.Button();
      this.AnalizeBT = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtBLine1 = new System.Windows.Forms.TextBox();
      this.txtBLine2 = new System.Windows.Forms.TextBox();
      this.LBCurrLine = new System.Windows.Forms.Label();
      this.BTCont = new System.Windows.Forms.Button();
      this.SelFileDlg = new System.Windows.Forms.OpenFileDialog();
      this.BTSave = new System.Windows.Forms.Button();
      this.chkMarkText = new System.Windows.Forms.CheckBox();
      this.btnHome = new System.Windows.Forms.Button();
      this.btnMarksInfo = new System.Windows.Forms.Button();
      this.btnSetAutoOk = new System.Windows.Forms.Button();
      this.grp1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // grp1
      // 
      this.grp1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grp1.Controls.Add(this.LbPath);
      this.grp1.Controls.Add(this.TxtPathIni1);
      this.grp1.Controls.Add(this.BtnPathIni);
      this.grp1.Location = new System.Drawing.Point(13, 10);
      this.grp1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.grp1.Name = "grp1";
      this.grp1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.grp1.Size = new System.Drawing.Size(1018, 67);
      this.grp1.TabIndex = 3;
      this.grp1.TabStop = false;
      this.grp1.Text = "Analyse Dictionary: ";
      // 
      // LbPath
      // 
      this.LbPath.AutoSize = true;
      this.LbPath.Location = new System.Drawing.Point(6, 29);
      this.LbPath.Name = "LbPath";
      this.LbPath.Size = new System.Drawing.Size(42, 18);
      this.LbPath.TabIndex = 0;
      this.LbPath.Text = "Path:";
      // 
      // TxtPathIni1
      // 
      this.TxtPathIni1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TxtPathIni1.Location = new System.Drawing.Point(50, 27);
      this.TxtPathIni1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.TxtPathIni1.Name = "TxtPathIni1";
      this.TxtPathIni1.Size = new System.Drawing.Size(919, 23);
      this.TxtPathIni1.TabIndex = 1;
      this.TxtPathIni1.TabStop = false;
      // 
      // BtnPathIni
      // 
      this.BtnPathIni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BtnPathIni.Location = new System.Drawing.Point(976, 22);
      this.BtnPathIni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.BtnPathIni.Name = "BtnPathIni";
      this.BtnPathIni.Size = new System.Drawing.Size(34, 30);
      this.BtnPathIni.TabIndex = 2;
      this.BtnPathIni.TabStop = false;
      this.BtnPathIni.Text = "...";
      this.BtnPathIni.UseVisualStyleBackColor = true;
      this.BtnPathIni.Click += new System.EventHandler(this.BtnPathIni_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.TxtPathIni2);
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Location = new System.Drawing.Point(13, 76);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Size = new System.Drawing.Size(1018, 64);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Against Dictionary: ";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(42, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "Path:";
      // 
      // TxtPathIni2
      // 
      this.TxtPathIni2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TxtPathIni2.Location = new System.Drawing.Point(50, 27);
      this.TxtPathIni2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.TxtPathIni2.Name = "TxtPathIni2";
      this.TxtPathIni2.Size = new System.Drawing.Size(919, 23);
      this.TxtPathIni2.TabIndex = 1;
      this.TxtPathIni2.TabStop = false;
      // 
      // button2
      // 
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button2.Location = new System.Drawing.Point(976, 22);
      this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(34, 30);
      this.button2.TabIndex = 2;
      this.button2.TabStop = false;
      this.button2.Text = "...";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // AnalizeBT
      // 
      this.AnalizeBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.AnalizeBT.Location = new System.Drawing.Point(476, 146);
      this.AnalizeBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.AnalizeBT.Name = "AnalizeBT";
      this.AnalizeBT.Size = new System.Drawing.Size(155, 34);
      this.AnalizeBT.TabIndex = 5;
      this.AnalizeBT.Text = "Cargar";
      this.AnalizeBT.UseVisualStyleBackColor = true;
      this.AnalizeBT.Click += new System.EventHandler(this.AnalizeBT_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(22, 228);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 18);
      this.label2.TabIndex = 6;
      this.label2.Text = "Line :";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(19, 279);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 18);
      this.label3.TabIndex = 6;
      this.label3.Text = "Line 2:";
      // 
      // txtBLine1
      // 
      this.txtBLine1.AcceptsReturn = true;
      this.txtBLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtBLine1.Location = new System.Drawing.Point(21, 251);
      this.txtBLine1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.txtBLine1.Name = "txtBLine1";
      this.txtBLine1.Size = new System.Drawing.Size(999, 23);
      this.txtBLine1.TabIndex = 7;
      this.txtBLine1.TextChanged += new System.EventHandler(this.txtBLine1_TextChanged);
      // 
      // txtBLine2
      // 
      this.txtBLine2.AcceptsReturn = true;
      this.txtBLine2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtBLine2.Location = new System.Drawing.Point(22, 301);
      this.txtBLine2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.txtBLine2.Multiline = true;
      this.txtBLine2.Name = "txtBLine2";
      this.txtBLine2.Size = new System.Drawing.Size(999, 113);
      this.txtBLine2.TabIndex = 7;
      this.txtBLine2.TextChanged += new System.EventHandler(this.txtBLine2_TextChanged);
      // 
      // LBCurrLine
      // 
      this.LBCurrLine.AutoSize = true;
      this.LBCurrLine.Location = new System.Drawing.Point(67, 228);
      this.LBCurrLine.Name = "LBCurrLine";
      this.LBCurrLine.Size = new System.Drawing.Size(0, 18);
      this.LBCurrLine.TabIndex = 8;
      // 
      // BTCont
      // 
      this.BTCont.Location = new System.Drawing.Point(267, 213);
      this.BTCont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.BTCont.Name = "BTCont";
      this.BTCont.Size = new System.Drawing.Size(46, 34);
      this.BTCont.TabIndex = 9;
      this.BTCont.Text = ">>";
      this.BTCont.UseVisualStyleBackColor = true;
      this.BTCont.Click += new System.EventHandler(this.BTCont_Click);
      // 
      // SelFileDlg
      // 
      this.SelFileDlg.FileName = "openFileDialog1";
      // 
      // BTSave
      // 
      this.BTSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.BTSave.Location = new System.Drawing.Point(475, 430);
      this.BTSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.BTSave.Name = "BTSave";
      this.BTSave.Size = new System.Drawing.Size(83, 27);
      this.BTSave.TabIndex = 9;
      this.BTSave.Text = "Save";
      this.BTSave.UseVisualStyleBackColor = true;
      this.BTSave.Click += new System.EventHandler(this.BTSave_Click);
      // 
      // chkMarkText
      // 
      this.chkMarkText.AutoSize = true;
      this.chkMarkText.Checked = true;
      this.chkMarkText.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkMarkText.Location = new System.Drawing.Point(322, 219);
      this.chkMarkText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.chkMarkText.Name = "chkMarkText";
      this.chkMarkText.Size = new System.Drawing.Size(232, 22);
      this.chkMarkText.TabIndex = 10;
      this.chkMarkText.Text = "Muestra el texto de las marcas";
      this.chkMarkText.UseVisualStyleBackColor = true;
      this.chkMarkText.CheckedChanged += new System.EventHandler(this.chkMarkText_CheckedChanged);
      // 
      // btnHome
      // 
      this.btnHome.Location = new System.Drawing.Point(190, 213);
      this.btnHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnHome.Name = "btnHome";
      this.btnHome.Size = new System.Drawing.Size(70, 34);
      this.btnHome.TabIndex = 5;
      this.btnHome.Text = "Inicio";
      this.btnHome.UseVisualStyleBackColor = true;
      this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
      // 
      // btnMarksInfo
      // 
      this.btnMarksInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMarksInfo.Location = new System.Drawing.Point(862, 430);
      this.btnMarksInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnMarksInfo.Name = "btnMarksInfo";
      this.btnMarksInfo.Size = new System.Drawing.Size(154, 27);
      this.btnMarksInfo.TabIndex = 9;
      this.btnMarksInfo.Text = "Actualiza Marcas";
      this.btnMarksInfo.UseVisualStyleBackColor = true;
      this.btnMarksInfo.Click += new System.EventHandler(this.btnMarksInfo_Click);
      // 
      // btnSetAutoOk
      // 
      this.btnSetAutoOk.Location = new System.Drawing.Point(604, 217);
      this.btnSetAutoOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnSetAutoOk.Name = "btnSetAutoOk";
      this.btnSetAutoOk.Size = new System.Drawing.Size(408, 26);
      this.btnSetAutoOk.TabIndex = 5;
      this.btnSetAutoOk.Text = "Poner como revidada la ya lo este en el otro diccionario";
      this.btnSetAutoOk.UseVisualStyleBackColor = true;
      this.btnSetAutoOk.Click += new System.EventHandler(this.btnSetAutoOk_Click);
      // 
      // CheckMarcks
      // 
      this.AcceptButton = this.AnalizeBT;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1043, 469);
      this.Controls.Add(this.chkMarkText);
      this.Controls.Add(this.btnMarksInfo);
      this.Controls.Add(this.BTSave);
      this.Controls.Add(this.BTCont);
      this.Controls.Add(this.LBCurrLine);
      this.Controls.Add(this.txtBLine2);
      this.Controls.Add(this.txtBLine1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnSetAutoOk);
      this.Controls.Add(this.btnHome);
      this.Controls.Add(this.AnalizeBT);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.grp1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CheckMarcks";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "CheckMarcks";
      this.Load += new System.EventHandler(this.CheckMarcks_Load);
      this.grp1.ResumeLayout(false);
      this.grp1.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox grp1;
      private System.Windows.Forms.Label LbPath;
      private System.Windows.Forms.TextBox TxtPathIni1;
      private System.Windows.Forms.Button BtnPathIni;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox TxtPathIni2;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button AnalizeBT;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox txtBLine1;
      private System.Windows.Forms.TextBox txtBLine2;
      private System.Windows.Forms.Label LBCurrLine;
      private System.Windows.Forms.Button BTCont;
      private System.Windows.Forms.OpenFileDialog SelFileDlg;
      private System.Windows.Forms.Button BTSave;
    private System.Windows.Forms.CheckBox chkMarkText;
    private System.Windows.Forms.Button btnHome;
    private System.Windows.Forms.Button btnMarksInfo;
    private System.Windows.Forms.Button btnSetAutoOk;
    }
}