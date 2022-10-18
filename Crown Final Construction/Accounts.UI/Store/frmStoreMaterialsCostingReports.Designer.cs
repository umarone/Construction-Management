namespace Accounts.UI
{
    partial class frmStoreMaterialsCostingReports
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
            this.dtStart = new MetroFramework.Controls.MetroDateTime();
            this.dtEnd = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ctx1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.departmentWiseCostingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockWiseCostingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelWiseCostingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridWiseCostingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new MetroFramework.Controls.MetroButton();
            this.ReportCostingPreview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(88, 77);
            this.dtStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(220, 29);
            this.dtStart.TabIndex = 0;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(354, 77);
            this.dtEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(218, 29);
            this.dtEnd.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.MistyRose;
            this.metroLabel1.Location = new System.Drawing.Point(35, 82);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(48, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "From :";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.MistyRose;
            this.metroLabel2.Location = new System.Drawing.Point(317, 82);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(31, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "To :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // ctx1
            // 
            this.ctx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departmentWiseCostingReportToolStripMenuItem,
            this.blockWiseCostingReportToolStripMenuItem,
            this.levelWiseCostingReportToolStripMenuItem,
            this.gridWiseCostingReportToolStripMenuItem});
            this.ctx1.Name = "ctx1";
            this.ctx1.Size = new System.Drawing.Size(248, 92);
            // 
            // departmentWiseCostingReportToolStripMenuItem
            // 
            this.departmentWiseCostingReportToolStripMenuItem.Name = "departmentWiseCostingReportToolStripMenuItem";
            this.departmentWiseCostingReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.departmentWiseCostingReportToolStripMenuItem.Text = "Department Wise Costing Report";
            this.departmentWiseCostingReportToolStripMenuItem.Click += new System.EventHandler(this.departmentWiseCostingReportToolStripMenuItem_Click);
            // 
            // blockWiseCostingReportToolStripMenuItem
            // 
            this.blockWiseCostingReportToolStripMenuItem.Name = "blockWiseCostingReportToolStripMenuItem";
            this.blockWiseCostingReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.blockWiseCostingReportToolStripMenuItem.Text = "Block Wise Costing Report";
            this.blockWiseCostingReportToolStripMenuItem.Click += new System.EventHandler(this.blockWiseCostingReportToolStripMenuItem_Click);
            // 
            // levelWiseCostingReportToolStripMenuItem
            // 
            this.levelWiseCostingReportToolStripMenuItem.Name = "levelWiseCostingReportToolStripMenuItem";
            this.levelWiseCostingReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.levelWiseCostingReportToolStripMenuItem.Text = "Level Wise Costing Report";
            this.levelWiseCostingReportToolStripMenuItem.Click += new System.EventHandler(this.levelWiseCostingReportToolStripMenuItem_Click);
            // 
            // gridWiseCostingReportToolStripMenuItem
            // 
            this.gridWiseCostingReportToolStripMenuItem.Name = "gridWiseCostingReportToolStripMenuItem";
            this.gridWiseCostingReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.gridWiseCostingReportToolStripMenuItem.Text = "Grid Wise Costing Report";
            this.gridWiseCostingReportToolStripMenuItem.Click += new System.EventHandler(this.gridWiseCostingReportToolStripMenuItem_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.RosyBrown;
            this.btnPrint.ContextMenuStrip = this.ctx1;
            this.btnPrint.Location = new System.Drawing.Point(588, 73);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(109, 35);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Load";
            this.btnPrint.UseCustomBackColor = true;
            this.btnPrint.UseSelectable = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ReportCostingPreview
            // 
            this.ReportCostingPreview.ActiveViewIndex = -1;
            this.ReportCostingPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportCostingPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportCostingPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportCostingPreview.Location = new System.Drawing.Point(23, 121);
            this.ReportCostingPreview.Name = "ReportCostingPreview";
            this.ReportCostingPreview.ShowGroupTreeButton = false;
            this.ReportCostingPreview.ShowParameterPanelButton = false;
            this.ReportCostingPreview.Size = new System.Drawing.Size(712, 270);
            this.ReportCostingPreview.TabIndex = 6;
            this.ReportCostingPreview.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Location = new System.Drawing.Point(24, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 62);
            this.panel1.TabIndex = 7;
            // 
            // frmStoreMaterialsCostingReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 436);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.ReportCostingPreview);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.panel1);
            this.Name = "frmStoreMaterialsCostingReports";
            this.Text = "Costing Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStoreMaterialsCostingReports_Load);
            this.ctx1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime dtStart;
        private MetroFramework.Controls.MetroDateTime dtEnd;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.ContextMenuStrip ctx1;
        private System.Windows.Forms.ToolStripMenuItem departmentWiseCostingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockWiseCostingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelWiseCostingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridWiseCostingReportToolStripMenuItem;
        private MetroFramework.Controls.MetroButton btnPrint;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportCostingPreview;
        private System.Windows.Forms.Panel panel1;
    }
}