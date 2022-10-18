namespace Accounts.UI
{
    partial class frmBlocks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBlockName = new MetroFramework.Controls.MetroTextBox();
            this.txtBlockCode = new MetroFramework.Controls.MetroTextBox();
            this.lblProductDiscription = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.DtBlock = new System.Windows.Forms.DateTimePicker();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkActive = new MetroFramework.Controls.MetroCheckBox();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.txtBlockDicription = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdLevels = new Accounts.UI.CustomDataGrid();
            this.colIdLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevelCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevelDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSaveLevel = new MetroFramework.Controls.MetroTile();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdBlocks = new Accounts.UI.CustomDataGrid();
            this.colIdBlock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlockTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlockEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLevels)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBlocks)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBlockName
            // 
            // 
            // 
            // 
            this.txtBlockName.CustomButton.Image = null;
            this.txtBlockName.CustomButton.Location = new System.Drawing.Point(246, 1);
            this.txtBlockName.CustomButton.Name = "";
            this.txtBlockName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBlockName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBlockName.CustomButton.TabIndex = 1;
            this.txtBlockName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBlockName.CustomButton.UseSelectable = true;
            this.txtBlockName.CustomButton.Visible = false;
            this.txtBlockName.Lines = new string[0];
            this.txtBlockName.Location = new System.Drawing.Point(147, 112);
            this.txtBlockName.MaxLength = 32767;
            this.txtBlockName.Name = "txtBlockName";
            this.txtBlockName.PasswordChar = '\0';
            this.txtBlockName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBlockName.SelectedText = "";
            this.txtBlockName.SelectionLength = 0;
            this.txtBlockName.SelectionStart = 0;
            this.txtBlockName.ShortcutsEnabled = true;
            this.txtBlockName.Size = new System.Drawing.Size(268, 23);
            this.txtBlockName.TabIndex = 1;
            this.txtBlockName.UseSelectable = true;
            this.txtBlockName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBlockName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBlockCode
            // 
            // 
            // 
            // 
            this.txtBlockCode.CustomButton.Image = null;
            this.txtBlockCode.CustomButton.Location = new System.Drawing.Point(147, 1);
            this.txtBlockCode.CustomButton.Name = "";
            this.txtBlockCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBlockCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBlockCode.CustomButton.TabIndex = 1;
            this.txtBlockCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBlockCode.CustomButton.UseSelectable = true;
            this.txtBlockCode.CustomButton.Visible = false;
            this.txtBlockCode.Lines = new string[0];
            this.txtBlockCode.Location = new System.Drawing.Point(147, 87);
            this.txtBlockCode.MaxLength = 32767;
            this.txtBlockCode.Name = "txtBlockCode";
            this.txtBlockCode.PasswordChar = '\0';
            this.txtBlockCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBlockCode.SelectedText = "";
            this.txtBlockCode.SelectionLength = 0;
            this.txtBlockCode.SelectionStart = 0;
            this.txtBlockCode.ShortcutsEnabled = true;
            this.txtBlockCode.Size = new System.Drawing.Size(169, 23);
            this.txtBlockCode.TabIndex = 0;
            this.txtBlockCode.UseSelectable = true;
            this.txtBlockCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBlockCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblProductDiscription
            // 
            this.lblProductDiscription.AutoSize = true;
            this.lblProductDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblProductDiscription.Location = new System.Drawing.Point(25, 111);
            this.lblProductDiscription.Name = "lblProductDiscription";
            this.lblProductDiscription.Size = new System.Drawing.Size(77, 19);
            this.lblProductDiscription.TabIndex = 3;
            this.lblProductDiscription.Text = "Block Title :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(25, 87);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Block Code :";
            // 
            // DtBlock
            // 
            this.DtBlock.Location = new System.Drawing.Point(147, 222);
            this.DtBlock.Name = "DtBlock";
            this.DtBlock.Size = new System.Drawing.Size(268, 20);
            this.DtBlock.TabIndex = 3;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(23, 215);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(87, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Created On :";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(148, 245);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(66, 15);
            this.chkActive.TabIndex = 4;
            this.chkActive.Text = "InActive";
            this.chkActive.UseSelectable = true;
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.Location = new System.Drawing.Point(253, 264);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 38);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.UseTileImage = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(147, 264);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 38);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseTileImage = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBlockDicription
            // 
            // 
            // 
            // 
            this.txtBlockDicription.CustomButton.Image = null;
            this.txtBlockDicription.CustomButton.Location = new System.Drawing.Point(188, 2);
            this.txtBlockDicription.CustomButton.Name = "";
            this.txtBlockDicription.CustomButton.Size = new System.Drawing.Size(77, 77);
            this.txtBlockDicription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBlockDicription.CustomButton.TabIndex = 1;
            this.txtBlockDicription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBlockDicription.CustomButton.UseSelectable = true;
            this.txtBlockDicription.CustomButton.Visible = false;
            this.txtBlockDicription.Lines = new string[0];
            this.txtBlockDicription.Location = new System.Drawing.Point(147, 138);
            this.txtBlockDicription.MaxLength = 32767;
            this.txtBlockDicription.Multiline = true;
            this.txtBlockDicription.Name = "txtBlockDicription";
            this.txtBlockDicription.PasswordChar = '\0';
            this.txtBlockDicription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBlockDicription.SelectedText = "";
            this.txtBlockDicription.SelectionLength = 0;
            this.txtBlockDicription.SelectionStart = 0;
            this.txtBlockDicription.ShortcutsEnabled = true;
            this.txtBlockDicription.Size = new System.Drawing.Size(268, 82);
            this.txtBlockDicription.TabIndex = 2;
            this.txtBlockDicription.UseSelectable = true;
            this.txtBlockDicription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBlockDicription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(25, 141);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(117, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Block Discription :";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(22, 52);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(951, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------------------------------------";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdLevels);
            this.groupBox1.Controls.Add(this.btnSaveLevel);
            this.groupBox1.Location = new System.Drawing.Point(427, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 494);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blocks Level";
            // 
            // grdLevels
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdLevels.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLevels.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLevels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdLevels.ColumnHeadersHeight = 25;
            this.grdLevels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdLevel,
            this.colLevelCode,
            this.colLevelName,
            this.colLevelDiscription,
            this.colDel});
            this.grdLevels.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdLevels.EnableHeadersVisualStyles = false;
            this.grdLevels.Location = new System.Drawing.Point(8, 16);
            this.grdLevels.MultiSelect = false;
            this.grdLevels.Name = "grdLevels";
            this.grdLevels.RowHeadersVisible = false;
            this.grdLevels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdLevels.Size = new System.Drawing.Size(538, 436);
            this.grdLevels.TabIndex = 0;
            this.grdLevels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLevels_CellClick);
            this.grdLevels.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdLevels_CellFormatting);
            // 
            // colIdLevel
            // 
            this.colIdLevel.DataPropertyName = "IdLevel";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colIdLevel.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIdLevel.HeaderText = "IdLevel";
            this.colIdLevel.Name = "colIdLevel";
            this.colIdLevel.Visible = false;
            // 
            // colLevelCode
            // 
            this.colLevelCode.DataPropertyName = "LevelCode";
            this.colLevelCode.HeaderText = "Level Code";
            this.colLevelCode.Name = "colLevelCode";
            this.colLevelCode.Width = 120;
            // 
            // colLevelName
            // 
            this.colLevelName.DataPropertyName = "AccountName";
            this.colLevelName.HeaderText = "Level Title";
            this.colLevelName.Name = "colLevelName";
            this.colLevelName.Width = 200;
            // 
            // colLevelDiscription
            // 
            this.colLevelDiscription.DataPropertyName = "Discription";
            this.colLevelDiscription.HeaderText = "Discription";
            this.colLevelDiscription.Name = "colLevelDiscription";
            this.colLevelDiscription.Width = 150;
            // 
            // colDel
            // 
            this.colDel.HeaderText = "...";
            this.colDel.Name = "colDel";
            this.colDel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDel.Width = 50;
            // 
            // btnSaveLevel
            // 
            this.btnSaveLevel.ActiveControl = null;
            this.btnSaveLevel.Location = new System.Drawing.Point(344, 453);
            this.btnSaveLevel.Name = "btnSaveLevel";
            this.btnSaveLevel.Size = new System.Drawing.Size(201, 38);
            this.btnSaveLevel.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSaveLevel.TabIndex = 0;
            this.btnSaveLevel.Text = "Save Block Level";
            this.btnSaveLevel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveLevel.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveLevel.UseSelectable = true;
            this.btnSaveLevel.UseTileImage = true;
            this.btnSaveLevel.Click += new System.EventHandler(this.btnSaveLevel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdBlocks);
            this.groupBox2.Location = new System.Drawing.Point(22, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 495);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Blocks Info";
            // 
            // grdBlocks
            // 
            this.grdBlocks.AllowUserToAddRows = false;
            this.grdBlocks.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdBlocks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdBlocks.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBlocks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdBlocks.ColumnHeadersHeight = 25;
            this.grdBlocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdBlock,
            this.colBlockCode,
            this.colBlockTitle,
            this.colBlockEdit});
            this.grdBlocks.EnableHeadersVisualStyles = false;
            this.grdBlocks.Location = new System.Drawing.Point(6, 236);
            this.grdBlocks.MultiSelect = false;
            this.grdBlocks.Name = "grdBlocks";
            this.grdBlocks.ReadOnly = true;
            this.grdBlocks.RowHeadersVisible = false;
            this.grdBlocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBlocks.Size = new System.Drawing.Size(387, 217);
            this.grdBlocks.TabIndex = 0;
            this.grdBlocks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBlocks_CellClick);
            this.grdBlocks.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdBlocks_CellFormatting);
            // 
            // colIdBlock
            // 
            this.colIdBlock.DataPropertyName = "IdBlock";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colIdBlock.DefaultCellStyle = dataGridViewCellStyle6;
            this.colIdBlock.HeaderText = "IdBlock";
            this.colIdBlock.Name = "colIdBlock";
            this.colIdBlock.ReadOnly = true;
            this.colIdBlock.Visible = false;
            // 
            // colBlockCode
            // 
            this.colBlockCode.DataPropertyName = "BlockCode";
            this.colBlockCode.HeaderText = "Block Code";
            this.colBlockCode.Name = "colBlockCode";
            this.colBlockCode.ReadOnly = true;
            // 
            // colBlockTitle
            // 
            this.colBlockTitle.DataPropertyName = "BlockName";
            this.colBlockTitle.HeaderText = "Block Title";
            this.colBlockTitle.Name = "colBlockTitle";
            this.colBlockTitle.ReadOnly = true;
            this.colBlockTitle.Width = 220;
            // 
            // colBlockEdit
            // 
            this.colBlockEdit.HeaderText = "...";
            this.colBlockEdit.Name = "colBlockEdit";
            this.colBlockEdit.ReadOnly = true;
            this.colBlockEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBlockEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBlockEdit.Width = 60;
            // 
            // frmBlocks
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(984, 588);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.DtBlock);
            this.Controls.Add(this.txtBlockDicription);
            this.Controls.Add(this.txtBlockName);
            this.Controls.Add(this.txtBlockCode);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.lblProductDiscription);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmBlocks";
            this.Text = "Blocks Setup";
            this.Load += new System.EventHandler(this.frmBlocks_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLevels)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBlocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtBlockName;
        private MetroFramework.Controls.MetroTextBox txtBlockCode;
        private MetroFramework.Controls.MetroLabel lblProductDiscription;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DateTimePicker DtBlock;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox chkActive;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTextBox txtBlockDicription;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private CustomDataGrid grdLevels;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTile btnSaveLevel;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomDataGrid grdBlocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdBlock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlockCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlockTitle;
        private System.Windows.Forms.DataGridViewButtonColumn colBlockEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevelCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevelDiscription;
        private System.Windows.Forms.DataGridViewButtonColumn colDel;
    }
}