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

namespace Accounts.UI
{
    public partial class frmBlocks : MetroForm
    {
        #region Variables
        Int64? IdBlock;
        #endregion
        #region Form Methods And Events
        public frmBlocks()
        {
            InitializeComponent();
        }
        private void frmBlocks_Load(object sender, EventArgs e)
        {
            //GetMaxCategoryCode();
            grdBlocks.AutoGenerateColumns = false;
            GetAllBlocks();
        }
        private void GetMaxCategoryCode()
        {
            var Manager = new CategoryBLL();
            txtBlockCode.Text = Validation.GetSafeString(Manager.GetMaxCategoryCode(Operations.IdCompany));
        }
        #endregion
        #region Simple Methods
        private bool ValidateControls()
        {
            bool isValid = true;
            if (txtBlockName.Text == string.Empty)
                isValid = false;
            return isValid;
        }
        private void ClearControls()
        {
            IdBlock = null;
            txtBlockCode.Text = string.Empty;
            txtBlockName.Text = string.Empty;
            txtBlockCode.Focus();
            chkActive.Checked = false;
            DtBlock.Value = DateTime.Now;
        }
        #endregion
        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            BlocksEL oelBlock = new BlocksEL();
            var Manager = new BlocksBLL();
            if (ValidateControls())
            {
                if (!IdBlock.HasValue)
                {
                    oelBlock.IdBlock = 1;
                }
                else
                {
                    oelBlock.IdBlock = IdBlock.Value;
                }

                oelBlock.IdProject = Operations.IdProject;
                oelBlock.IdUser = Operations.UserID;
                oelBlock.BookNo = Operations.BookNo;
                oelBlock.BlockCode = txtBlockCode.Text;
                oelBlock.BlockName = txtBlockName.Text.Trim();
                oelBlock.Discription = txtBlockDicription.Text;
                oelBlock.CreatedDateTime = DtBlock.Value;
                if (!chkActive.Checked)
                    oelBlock.IsActive = true;
                else
                    oelBlock.IsActive = false;
                oelBlock.UserId = Operations.UserID;
                //if (!IdBlock.HasValue)
                //{
                //    if (Manager.CheckCategoryCodeDuplication(Validation.GetSafeLong(txtBlockCode.Text)))
                //    {
                //        MessageBox.Show("Category Code Already Exists");
                //        return;
                //    }
                //}                    
                if (!IdBlock.HasValue)
                {
                    if (!Manager.CheckBlockNameDuplication(txtBlockName.Text.Trim()))
                    {
                        if (Manager.CreateBlocks(oelBlock).IsSuccess)
                        {
                            //GetMaxCategoryCode();
                            MessageBox.Show("Block Created Successfully....");
                            ClearControls();
                            GetAllBlocks();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Block Title Already Exists");
                    }
                }
                else
                {
                    if (Manager.UpdateBlocks(oelBlock).IsSuccess)
                    {
                        //GetMaxCategoryCode();
                        MessageBox.Show("Block Updated Successfully....");
                        ClearControls();
                        GetAllBlocks();
                    }
                }
            }
        }
        private void btnSaveLevel_Click(object sender, EventArgs e)
        {
            var manager = new BlocksLevelsBLL();
            List<BlocksLevelsEL> list = new List<BlocksLevelsEL>();
            if (!IdBlock.HasValue)
            {
                MessageBox.Show("Block Not Created OR Not Selected To Create OR Update Block Levels");
            }
            else
            {
                if (ValidateRows())
                {
                    for (int i = 0; i < grdLevels.Rows.Count - 1; i++)
                    {
                        BlocksLevelsEL obj = new BlocksLevelsEL();
                        obj.IdBlock = IdBlock.Value;
                        obj.IdProject = Operations.IdProject;
                        obj.IdUser = Operations.UserID;
                        obj.BookNo = Operations.BookNo;
                        if (grdLevels.Rows[i].Cells["colIdLevel"].Value == null)
                        {
                            obj.IsNew = true;
                            obj.IdLevel = 0;
                        }
                        else
                        {
                            obj.IsNew = false;
                            obj.IdLevel = Validation.GetSafeLong(grdLevels.Rows[i].Cells["colIdLevel"].Value);
                        }
                        obj.LevelCode = Validation.GetSafeString(grdLevels.Rows[i].Cells["colLevelCode"].Value);
                        obj.LevelName = Validation.GetSafeString(grdLevels.Rows[i].Cells["colLevelName"].Value);
                        obj.Discription = Validation.GetSafeString(grdLevels.Rows[i].Cells["colLevelDiscription"].Value);
                        obj.CreatedDateTime = DtBlock.Value;
                        list.Add(obj);
                    }
                }
                else
                {
                    MessageBox.Show("At Least Level Title Must Be Given...");
                }
            }
            if (list.Count > 0)
            {
                if (manager.CreateBlocksLevels(list).IsSuccess)
                {
                    MessageBox.Show("Levels Created OR Updated Successfully For " + txtBlockName.Text);
                }
                else
                {
                    MessageBox.Show("Some Error Occured...");
                }
            }
            else
            {
                MessageBox.Show("No Levels Found For Block " + txtBlockName.Text);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new CategoryBLL();
            if (manager.DeleteCategory(IdBlock.Value).IsSuccess)
            {
                GetMaxCategoryCode();
                ClearControls();
            }
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
            if (grdLevels.Rows.Count > 0)
            {
                for (int i = 0; i < grdLevels.Rows.Count - 1; i++)
                {
                    if (grdLevels.Rows[i].Cells["colLevelName"].Value == null)
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
        private void grdBlocks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                e.Value = "Edit";
            }
        }
        private void grdBlocks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                IdBlock = Validation.GetSafeLong(grdBlocks.Rows[e.RowIndex].Cells[0].Value);
                GetBlockById();
                GetBlockLevelsBlockById();
            }
        }
        private void GetAllBlocks()
        {
            var manager = new BlocksBLL();
            List<BlocksEL> list = manager.GetAllBlocks(Operations.IdProject);
            if (list.Count > 0)
            {
                grdBlocks.DataSource = list;
            }
            else
                grdBlocks.DataSource = null;
        }
        private void GetBlockById()
        {
            var manager = new BlocksBLL();
            List<BlocksEL> list = manager.GetBlockById(IdBlock.Value);
            if (list.Count > 0)
            {
                txtBlockCode.Text = list[0].BlockCode;
                txtBlockName.Text = list[0].BlockName;
                txtBlockDicription.Text = list[0].Discription;
                if (list[0].IsActive == true)
                {
                    chkActive.Checked = true;
                }
                else
                    chkActive.Checked = false;
                DtBlock.Value = list[0].CreatedDateTime.Value;
            }
        }
        private void GetBlockLevelsBlockById()
        {
            var manager = new BlocksLevelsBLL();
            List<BlocksLevelsEL> list = manager.GetBlocksLevelsByBlockId(IdBlock.Value);
            if (list.Count > 0)
            {
                grdLevels.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    grdLevels.Rows.Add();
                    grdLevels.Rows[i].Cells["colIdLevel"].Value = list[i].IdLevel;
                    grdLevels.Rows[i].Cells["colLevelCode"].Value = list[i].LevelCode;
                    grdLevels.Rows[i].Cells["colLevelName"].Value = list[i].LevelName;
                    grdLevels.Rows[i].Cells["colLevelDiscription"].Value = list[i].Discription;
                }
            }
            else
            {
                grdLevels.Rows.Clear();
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
                if (grdLevels.Rows.Count > 0)
                {
                    if (grdLevels.Rows[e.RowIndex].Cells[0].Value == null)
                    {
                        grdLevels.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        if (MessageBox.Show("Are You Sure To Delete This Level....", "Deleting Row", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            var manager = new BlocksLevelsBLL();
                            if (manager.DeleteBlocksLevels(Validation.GetSafeLong(grdLevels.Rows[e.RowIndex].Cells[0].Value)).IsSuccess)
                            {
                                MessageBox.Show("Level Deleted Successfully....");
                                GetBlockLevelsBlockById();
                                
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
