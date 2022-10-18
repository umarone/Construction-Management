namespace Accounts.UI
{
    partial class frmInventoryIssuanceLocation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.chkAllProducts = new System.Windows.Forms.CheckBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.PEditBox = new MetroFramework.Controls.MetroTextBox();
            this.btnProductReport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.grdMaterials = new Accounts.UI.TabDataGrid();
            this.colItemName = new Accounts.UI.DataGridViewProductWaterMarkColumn();
            this.colDepartments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlocks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 50);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1149, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "-----------------------------";
            // 
            // chkAllProducts
            // 
            this.chkAllProducts.AutoSize = true;
            this.chkAllProducts.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkAllProducts.Location = new System.Drawing.Point(481, 76);
            this.chkAllProducts.Name = "chkAllProducts";
            this.chkAllProducts.Size = new System.Drawing.Size(109, 17);
            this.chkAllProducts.TabIndex = 35;
            this.chkAllProducts.Text = "Load All Materials";
            this.chkAllProducts.UseVisualStyleBackColor = true;
            this.chkAllProducts.CheckedChanged += new System.EventHandler(this.chkAllProducts_CheckedChanged);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(24, 72);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(62, 19);
            this.metroLabel10.TabIndex = 33;
            this.metroLabel10.Text = "Product :";
            // 
            // PEditBox
            // 
            // 
            // 
            // 
            this.PEditBox.CustomButton.Image = null;
            this.PEditBox.CustomButton.Location = new System.Drawing.Point(363, 1);
            this.PEditBox.CustomButton.Name = "";
            this.PEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PEditBox.CustomButton.TabIndex = 1;
            this.PEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PEditBox.CustomButton.UseSelectable = true;
            this.PEditBox.Lines = new string[0];
            this.PEditBox.Location = new System.Drawing.Point(90, 72);
            this.PEditBox.MaxLength = 32767;
            this.PEditBox.Name = "PEditBox";
            this.PEditBox.PasswordChar = '\0';
            this.PEditBox.PromptText = "Product Here";
            this.PEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PEditBox.SelectedText = "";
            this.PEditBox.SelectionLength = 0;
            this.PEditBox.SelectionStart = 0;
            this.PEditBox.ShortcutsEnabled = true;
            this.PEditBox.ShowButton = true;
            this.PEditBox.Size = new System.Drawing.Size(385, 23);
            this.PEditBox.TabIndex = 32;
            this.PEditBox.UseSelectable = true;
            this.PEditBox.WaterMark = "Product Here";
            this.PEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.PEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.PEditBox_ButtonClick);
            this.PEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PEditBox_KeyPress);
            // 
            // btnProductReport
            // 
            this.btnProductReport.BackColor = System.Drawing.Color.MistyRose;
            this.btnProductReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductReport.ForeColor = System.Drawing.Color.Black;
            this.btnProductReport.Location = new System.Drawing.Point(619, 73);
            this.btnProductReport.Name = "btnProductReport";
            this.btnProductReport.Size = new System.Drawing.Size(101, 25);
            this.btnProductReport.TabIndex = 34;
            this.btnProductReport.Text = "Load Report";
            this.btnProductReport.UseVisualStyleBackColor = false;
            this.btnProductReport.Click += new System.EventHandler(this.btnProductReport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.MistyRose;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(722, 73);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(101, 25);
            this.btnExport.TabIndex = 34;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grdMaterials
            // 
            this.grdMaterials.AllowUserToAddRows = false;
            this.grdMaterials.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdMaterials.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMaterials.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdMaterials.ColumnHeadersHeight = 25;
            this.grdMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemName,
            this.colDepartments,
            this.colpacking,
            this.colBlocks,
            this.colLevels,
            this.colGrids,
            this.colQty});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMaterials.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdMaterials.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdMaterials.EnableHeadersVisualStyles = false;
            this.grdMaterials.Location = new System.Drawing.Point(24, 104);
            this.grdMaterials.MultiSelect = false;
            this.grdMaterials.Name = "grdMaterials";
            this.grdMaterials.ReadOnly = true;
            this.grdMaterials.RowHeadersVisible = false;
            this.grdMaterials.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdMaterials.Size = new System.Drawing.Size(1137, 455);
            this.grdMaterials.TabIndex = 31;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colItemName.HeaderText = "Product Discription";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.WatermarkText = "Type Here For Product Selection";
            this.colItemName.Width = 380;
            // 
            // colDepartments
            // 
            this.colDepartments.DataPropertyName = "CategoryName";
            this.colDepartments.HeaderText = "Departments";
            this.colDepartments.Name = "colDepartments";
            this.colDepartments.ReadOnly = true;
            this.colDepartments.Width = 200;
            // 
            // colpacking
            // 
            this.colpacking.DataPropertyName = "PackingSize";
            this.colpacking.HeaderText = "UOM";
            this.colpacking.Name = "colpacking";
            this.colpacking.ReadOnly = true;
            // 
            // colBlocks
            // 
            this.colBlocks.DataPropertyName = "BlockName";
            this.colBlocks.HeaderText = "Blocks";
            this.colBlocks.Name = "colBlocks";
            this.colBlocks.ReadOnly = true;
            this.colBlocks.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBlocks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colLevels
            // 
            this.colLevels.DataPropertyName = "LevelName";
            this.colLevels.HeaderText = "Levels";
            this.colLevels.Name = "colLevels";
            this.colLevels.ReadOnly = true;
            this.colLevels.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLevels.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colGrids
            // 
            this.colGrids.DataPropertyName = "GridName";
            this.colGrids.HeaderText = "Grids";
            this.colGrids.Name = "colGrids";
            this.colGrids.ReadOnly = true;
            this.colGrids.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGrids.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGrids.Width = 140;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // frmInventoryIssuanceLocation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1174, 582);
            this.Controls.Add(this.chkAllProducts);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.PEditBox);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnProductReport);
            this.Controls.Add(this.grdMaterials);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmInventoryIssuanceLocation";
            this.Text = "Materials Location Report";
            this.Load += new System.EventHandler(this.frmInventoryIssuanceLocation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private TabDataGrid grdMaterials;
        private System.Windows.Forms.CheckBox chkAllProducts;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox PEditBox;
        private System.Windows.Forms.Button btnProductReport;
        private System.Windows.Forms.Button btnExport;
        private DataGridViewProductWaterMarkColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevels;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrids;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
    }
}