using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;

using Accounts.BLL;
using Accounts.EL;
using Accounts.Common;
using SpreadsheetLight;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using System.Diagnostics;

namespace Accounts.UI
{
    public partial class frmLevelGrids : MetroForm
    {
        #region Variables
        Int64? IdGrid;
        SLDocument Sldocument;
        #endregion
        #region Form Methods And Events
        public frmLevelGrids()
        {
            InitializeComponent();
        }
        private void frmLevelGrids_Load(object sender, EventArgs e)
        {           
            GetAllBlocks();
        }
        #endregion
        #region Simple Methods
        private bool ValidateControls()
        {
            bool isValid = true;
            //if (txtBlockName.Text == string.Empty)
            //    isValid = false;
            return isValid;
        }
        private void ClearControls()
        {
            IdGrid = null;
            txtFileName.Text = string.Empty;
            //txtBlockCode.Text = string.Empty;
            //txtBlockName.Text = string.Empty;
            //txtBlockCode.Focus();
            //chkActive.Checked = false;
            //DtBlock.Value = DateTime.Now;
        }
        #endregion
        #region Button Events
        private void btnSaveLevel_Click(object sender, EventArgs e)
        {
            var manager = new BlockLevelGridsBLL();
            List<BlockLevelGridsEL> list = new List<BlockLevelGridsEL>();
            if (cbxLevels.SelectedIndex == 0 || cbxLevels.SelectedIndex == -1)
            {
                MessageBox.Show("Level Not Created OR Not Selected To Create OR Update Grids");
            }
            else
            {
                if (ValidateRows())
                {
                    for (int i = 0; i < grdGrids.Rows.Count - 1; i++)
                    {
                        BlockLevelGridsEL obj = new BlockLevelGridsEL();
                        obj.IdLevel = Validation.GetSafeLong(cbxLevels.SelectedValue);
                        obj.IdProject = Operations.IdProject;
                        obj.IdUser = Operations.UserID;
                        obj.BookNo = Operations.BookNo;
                        if (grdGrids.Rows[i].Cells["colIdGrid"].Value == null)
                        {
                            obj.IsNew = true;
                            obj.IdGrid = 0;
                        }
                        else
                        {
                            obj.IsNew = false;
                            obj.IdGrid = Validation.GetSafeLong(grdGrids.Rows[i].Cells["colIdGrid"].Value);
                        }
                        obj.GridCode = Validation.GetSafeString(grdGrids.Rows[i].Cells["colGridCode"].Value);
                        obj.GridName = Validation.GetSafeString(grdGrids.Rows[i].Cells["colGridName"].Value);
                        obj.Discription = Validation.GetSafeString(grdGrids.Rows[i].Cells["colGridDiscription"].Value);
                        obj.CreatedDateTime = DateTime.Now;
                        list.Add(obj);
                    }
                }
                else
                {
                    MessageBox.Show("At Least Grid Title Must Be Given...");
                }
            }
            if (list.Count > 0)
            {
                if (manager.CreateBlocksLevelGrids(list).IsSuccess)
                {
                    MessageBox.Show("Grid Created OR Updated Successfully For " + cbxLevels.Text);
                    GetBlockLevelGridsByLevelId();
                }
                else
                {
                    MessageBox.Show("Some Error Occured...");
                }
            }
            else
            {
                MessageBox.Show("No Grid Found For Level" + cbxLevels.Text);
            }
        }
        private void txtFileName_ButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
            }
        }
        private void btnReadFile_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txtFileName.Text == string.Empty)
            {
                MessageBox.Show("Please Load File First To Read Blocks Data :");
            }
            else if (grdGrids.Rows.Count > 1)
            {
                MessageBox.Show("Please Clear Below Data To Read File");
            }
            else
            {
                Sldocument = new SLDocument(txtFileName.Text);
                while (true)
                {
                    Sldocument.SelectWorksheet("Grids");
                    if (!Sldocument.HasCellValue("C" + (i + 2)))
                    {
                        if (Sldocument.GetCellValueAsString("C2") == string.Empty)
                        {
                            MessageBox.Show("Improper File Format");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("File Data Is Complete....Now Press Save Button To Save Grids...");
                            break;
                        }
                    }
                    else
                    {
                        grdGrids.Rows.Add();
                        grdGrids.Rows[i].Cells[2].Value = Sldocument.GetCellValueAsString("C" + (i + 2));
                    }
                    i++;
                }
            }
        }
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            grdGrids.Rows.Clear();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Other Controls Methods and Events
        private bool ValidateRows()
        {
            bool IsValid = true;
            if (grdGrids.Rows.Count > 0)
            {
                for (int i = 0; i < grdGrids.Rows.Count - 1; i++)
                {
                    if (grdGrids.Rows[i].Cells["colGridName"].Value == null)
                    {
                        IsValid = false;
                        break;
                    }
                }
            }
            return IsValid;
        }
        #endregion
        #region Block Grid Methods And Events
        private void GetAllBlocks()
        {
            var manager = new BlocksBLL();
            List<BlocksEL> list = manager.GetAllBlocks(Operations.IdProject);
            if (list.Count > 0)
            {
                list.Insert(0, new BlocksEL() { IdBlock = 0, BlockName = "Select Block" });
                cbxBlocks.DataSource = list;
                cbxBlocks.DisplayMember = "BlockName";
                cbxBlocks.ValueMember = "IdBlock";
            }
            else
                cbxBlocks.DataSource = null;
        }
        private void cbxBlocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBlocks.SelectedIndex > 0)
            {
                var manager = new BlocksLevelsBLL();
                List<BlocksLevelsEL> list = manager.GetBlocksLevelsByBlockId(Validation.GetSafeLong(cbxBlocks.SelectedValue));
                if (list.Count > 0)
                {
                    list.Insert(0, new BlocksLevelsEL() { IdLevel = 0, LevelName = "Select Level " });
                    cbxLevels.DataSource = list;
                    cbxLevels.DisplayMember = "LevelName";
                    cbxLevels.ValueMember = "IdLevel";
                }
                else
                {
                    cbxLevels.DataSource = null;
                    if (grdGrids.Rows.Count > 0)
                    {
                        grdGrids.Rows.Clear();
                    }
                }
            }
        }
        private void cbxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLevels.SelectedIndex > 0)
            {
                GetBlockLevelGridsByLevelId();
            }
            else
                grdGrids.Rows.Clear();
        }
        private void GetBlockLevelGridsByLevelId()
        {
            var manager = new BlockLevelGridsBLL();
            List<BlockLevelGridsEL> list = manager.GetBlocksLevelGridsByLevelId(Validation.GetSafeLong(cbxLevels.SelectedValue));
            if (list.Count > 0)
            {
                grdGrids.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    grdGrids.Rows.Add();
                    grdGrids.Rows[i].Cells["colIdGrid"].Value = list[i].IdGrid;
                    grdGrids.Rows[i].Cells["colGridCode"].Value = list[i].GridCode;
                    grdGrids.Rows[i].Cells["colGridName"].Value = list[i].GridName;
                    grdGrids.Rows[i].Cells["colGridDiscription"].Value = list[i].Discription;
                }
            }
            else
            {
                grdGrids.Rows.Clear();
            }
        }
        #endregion
        #region Level Grid Methods And Events
        private void grdLevels_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = "Delete";
            }
        }
        private void grdLevels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (grdGrids.Rows.Count > 0)
                {
                    if (grdGrids.Rows[e.RowIndex].Cells[0].Value == null)
                    {
                        grdGrids.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        if (MessageBox.Show("Are You Sure To Delete This Grid....", "Deleting Grid", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            var manager = new BlockLevelGridsBLL();
                            if (manager.DeleteBlocksLevelGrids(Validation.GetSafeLong(grdGrids.Rows[e.RowIndex].Cells[0].Value)).IsSuccess)
                            {
                                MessageBox.Show("Level Deleted Successfully....");
                                GetBlockLevelGridsByLevelId();
                                
                            }
                            else
                            {
                                MessageBox.Show("Some Problem Occured....");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Row To Delete....");
                }
            }
        }
        #endregion
    }
}
