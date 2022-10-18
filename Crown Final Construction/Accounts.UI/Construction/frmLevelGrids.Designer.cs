namespace Accounts.UI
{
    partial class frmLevelGrids
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
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveLevel = new MetroFramework.Controls.MetroTile();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbxLevels = new MetroFramework.Controls.MetroComboBox();
            this.cbxBlocks = new MetroFramework.Controls.MetroComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtFileName = new MetroFramework.Controls.MetroTextBox();
            this.btnReadFile = new MetroFramework.Controls.MetroButton();
            this.grdGrids = new Accounts.UI.CustomDataGrid();
            this.colIdGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGridDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnClearGrid = new MetroFramework.Controls.MetroTile();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrids)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.btnReadFile);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.grdGrids);
            this.groupBox1.Controls.Add(this.btnClearGrid);
            this.groupBox1.Controls.Add(this.btnSaveLevel);
            this.groupBox1.Location = new System.Drawing.Point(427, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 494);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level Girds";
            // 
            // btnSaveLevel
            // 
            this.btnSaveLevel.ActiveControl = null;
            this.btnSaveLevel.Location = new System.Drawing.Point(344, 453);
            this.btnSaveLevel.Name = "btnSaveLevel";
            this.btnSaveLevel.Size = new System.Drawing.Size(201, 38);
            this.btnSaveLevel.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSaveLevel.TabIndex = 0;
            this.btnSaveLevel.Text = "Save Grid";
            this.btnSaveLevel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveLevel.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveLevel.UseSelectable = true;
            this.btnSaveLevel.UseTileImage = true;
            this.btnSaveLevel.Click += new System.EventHandler(this.btnSaveLevel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.metroLabel2);
            this.groupBox2.Controls.Add(this.metroLabel1);
            this.groupBox2.Controls.Add(this.cbxLevels);
            this.groupBox2.Controls.Add(this.cbxBlocks);
            this.groupBox2.Location = new System.Drawing.Point(22, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 495);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Levels Info";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(12, 55);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Levels :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(12, 22);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(68, 25);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Blocks :";
            // 
            // cbxLevels
            // 
            this.cbxLevels.FormattingEnabled = true;
            this.cbxLevels.ItemHeight = 23;
            this.cbxLevels.Location = new System.Drawing.Point(100, 56);
            this.cbxLevels.Name = "cbxLevels";
            this.cbxLevels.Size = new System.Drawing.Size(291, 29);
            this.cbxLevels.TabIndex = 0;
            this.cbxLevels.UseSelectable = true;
            this.cbxLevels.SelectedIndexChanged += new System.EventHandler(this.cbxLevels_SelectedIndexChanged);
            // 
            // cbxBlocks
            // 
            this.cbxBlocks.FormattingEnabled = true;
            this.cbxBlocks.ItemHeight = 23;
            this.cbxBlocks.Location = new System.Drawing.Point(100, 21);
            this.cbxBlocks.Name = "cbxBlocks";
            this.cbxBlocks.Size = new System.Drawing.Size(291, 29);
            this.cbxBlocks.TabIndex = 0;
            this.cbxBlocks.UseSelectable = true;
            this.cbxBlocks.SelectedIndexChanged += new System.EventHandler(this.cbxBlocks_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(8, 24);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(70, 19);
            this.metroLabel3.TabIndex = 1;
            this.metroLabel3.Text = "Load File :";
            // 
            // txtFileName
            // 
            // 
            // 
            // 
            this.txtFileName.CustomButton.Image = null;
            this.txtFileName.CustomButton.Location = new System.Drawing.Point(351, 1);
            this.txtFileName.CustomButton.Name = "";
            this.txtFileName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFileName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFileName.CustomButton.TabIndex = 1;
            this.txtFileName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFileName.CustomButton.UseSelectable = true;
            this.txtFileName.Lines = new string[0];
            this.txtFileName.Location = new System.Drawing.Point(84, 24);
            this.txtFileName.MaxLength = 32767;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PasswordChar = '\0';
            this.txtFileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFileName.SelectedText = "";
            this.txtFileName.SelectionLength = 0;
            this.txtFileName.SelectionStart = 0;
            this.txtFileName.ShortcutsEnabled = true;
            this.txtFileName.ShowButton = true;
            this.txtFileName.Size = new System.Drawing.Size(373, 23);
            this.txtFileName.TabIndex = 2;
            this.txtFileName.UseSelectable = true;
            this.txtFileName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFileName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFileName.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtFileName_ButtonClick);
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(463, 23);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(75, 23);
            this.btnReadFile.TabIndex = 3;
            this.btnReadFile.Text = "Read File";
            this.btnReadFile.UseSelectable = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // grdGrids
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdGrids.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdGrids.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGrids.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdGrids.ColumnHeadersHeight = 25;
            this.grdGrids.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdGrid,
            this.colGridCode,
            this.colGridName,
            this.colGridDiscription,
            this.colDel});
            this.grdGrids.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdGrids.EnableHeadersVisualStyles = false;
            this.grdGrids.Location = new System.Drawing.Point(8, 54);
            this.grdGrids.MultiSelect = false;
            this.grdGrids.Name = "grdGrids";
            this.grdGrids.RowHeadersVisible = false;
            this.grdGrids.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdGrids.Size = new System.Drawing.Size(538, 398);
            this.grdGrids.TabIndex = 0;
            this.grdGrids.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLevels_CellClick);
            this.grdGrids.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdLevels_CellFormatting);
            // 
            // colIdGrid
            // 
            this.colIdGrid.DataPropertyName = "IdGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colIdGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIdGrid.HeaderText = "IdGrid";
            this.colIdGrid.Name = "colIdGrid";
            this.colIdGrid.Visible = false;
            // 
            // colGridCode
            // 
            this.colGridCode.DataPropertyName = "GridCode";
            this.colGridCode.HeaderText = "Grid Code";
            this.colGridCode.Name = "colGridCode";
            this.colGridCode.Width = 120;
            // 
            // colGridName
            // 
            this.colGridName.DataPropertyName = "GridName";
            this.colGridName.HeaderText = "Grid Title";
            this.colGridName.Name = "colGridName";
            this.colGridName.Width = 200;
            // 
            // colGridDiscription
            // 
            this.colGridDiscription.DataPropertyName = "Discription";
            this.colGridDiscription.HeaderText = "Discription";
            this.colGridDiscription.Name = "colGridDiscription";
            this.colGridDiscription.Width = 150;
            // 
            // colDel
            // 
            this.colDel.HeaderText = "...";
            this.colDel.Name = "colDel";
            this.colDel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDel.Width = 50;
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.ActiveControl = null;
            this.btnClearGrid.Location = new System.Drawing.Point(142, 453);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(201, 38);
            this.btnClearGrid.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnClearGrid.TabIndex = 0;
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClearGrid.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClearGrid.UseSelectable = true;
            this.btnClearGrid.UseTileImage = true;
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // frmLevelGrids
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(984, 588);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmLevelGrids";
            this.Text = "Grids Setup";
            this.Load += new System.EventHandler(this.frmLevelGrids_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrids)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel4;
        private CustomDataGrid grdGrids;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTile btnSaveLevel;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbxLevels;
        private MetroFramework.Controls.MetroComboBox cbxBlocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGridDiscription;
        private System.Windows.Forms.DataGridViewButtonColumn colDel;
        private MetroFramework.Controls.MetroButton btnReadFile;
        private MetroFramework.Controls.MetroTextBox txtFileName;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroTile btnClearGrid;
    }
}