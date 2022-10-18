using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.Common;
using Accounts.BLL;
using MetroFramework.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.Common;

namespace Accounts.UI
{
    public partial class frmInventoryIssuance : MetroForm
    {
        #region Variables
        ConnectionInfo oConnectionInfo = new ConnectionInfo();
        frmAccounts frmaccounts;
        frmFindAccounts frmAccount;
        frmFindProducts frmfindProducts;
        frmFindVouchers frmfindVouchers;
        frmAuthentication frmauthentication;
        frmPersons frmpersons;
        frmStockIssuancePrintReport frmprint;
        public decimal OldValue { get; set; }
        public Int64 VoucherNo { get; set; }
        Int64? IdVoucher = null;
        public Int64? CustomerTransactionId { get; set; }
        public Int64? CashTransactionId { get; set; }
        public Int64? SalesTransactionId { get; set; }
        public string VoucherType { get; set; }
        public int StoreType { get; set; }
        string EventCommandName;
        int EventTime = 0;
        public bool IsNetTransaction { get; set; }
        public bool IsImportTransaction { get; set; }
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        string CustomerAccountNo = "", SalesAccountNo = "", CashAccountNo = "", EmpAccountNo = "";
        #endregion
        #region Form Constructor And Load Method
        public frmInventoryIssuance()
        {
            InitializeComponent();
        }
        private void frmSales_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            FillData();
            GetAllBlocks();
            //ShowHideColumns();
            //showhidecolumnsforstoretype();
            EmpEditBox.Focus();
            CheckModulePermissions();
            FillTotalVouchers();
            GetLastVoucherTransactionByType();
            if (StoreType == 1)
            {
                this.Text = "Store Inventory Issuance Gate Pass";
            }
            else
            {
                this.Text = "Store Inventory Receiving Gate Pass";
            }
            //MessageBox.Show(StoreType.ToString());
        }
        private void frmInventoryIssuance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ClearControls();
                FillData();
            }
        }
        #endregion
        #region Simple Methods
        private void GetAllBlocks()
        {
            var manager = new BlocksBLL();
            List<BlocksEL> list = manager.GetAllBlocks(Operations.IdProject);
            if (list.Count > 0)
            {
                list.Insert(0, new BlocksEL() { IdBlock = 0, BlockName = "Select Block" });
                colBlocks.DataSource = list;
                colBlocks.DisplayMember = "BlockName";
                colBlocks.ValueMember = "IdBlock";
            }
            else
                colBlocks.DataSource = null;
        }
        private void GetBlockLevelsBlockById(Int64 IdBlock)
        {
            var manager = new BlocksLevelsBLL();
            List<BlocksLevelsEL> list = manager.GetBlocksLevelsByBlockId(IdBlock);
            DataGridViewComboBoxCell oCellLevel = DgvStockSales.CurrentRow.Cells["colLevels"] as DataGridViewComboBoxCell;
            if (list.Count > 0)
            {
                list.Insert(0, new BlocksLevelsEL() { IdLevel = 0, LevelName = "Select Level" });
                if (oCellLevel != null)
                {
                    oCellLevel.DataSource = list;
                    oCellLevel.ValueMember = "IdLevel";
                    oCellLevel.DisplayMember = "LevelName";
                }
            }
            else
            {
                oCellLevel.DataSource = null;
            }
        }
        private void GetBlockLevelGridsByLevelId(Int64 IdLevel)
        {
            var manager = new BlockLevelGridsBLL();
            List<BlockLevelGridsEL> list = manager.GetBlocksLevelGridsByLevelId(IdLevel);
            DataGridViewComboBoxCell oCell = DgvStockSales.CurrentRow.Cells["colGrids"] as DataGridViewComboBoxCell;
            if (list.Count > 0)
            {
                list.Insert(0, new BlockLevelGridsEL() { IdGrid = 0, GridName = "Select Grid" });

                if (oCell != null)
                {
                    oCell.DataSource = list;
                    oCell.ValueMember = "IdGrid";
                    oCell.DisplayMember = "GridName";
                }

            }
            else
            {
                oCell.DataSource = null;
            }
        }
        private void GetBlockLevelsBlockByIdByRowIndex(Int64 IdBlock, int index)
        {
            var manager = new BlocksLevelsBLL();
            List<BlocksLevelsEL> list = manager.GetBlocksLevelsByBlockId(IdBlock);
            DataGridViewComboBoxCell oCellLevel = DgvStockSales.Rows[index].Cells["colLevels"] as DataGridViewComboBoxCell;
            if (list.Count > 0)
            {
                list.Insert(0, new BlocksLevelsEL() { IdLevel = 0, LevelName = "Select Level" });
                if (oCellLevel != null)
                {
                    oCellLevel.DataSource = list;
                    oCellLevel.ValueMember = "IdLevel";
                    oCellLevel.DisplayMember = "LevelName";
                }
            }
            else
            {
                oCellLevel.DataSource = null;
            }
        }
        private void GetBlockLevelGridsByLevelIdByRowIndex(Int64 IdLevel, int index)
        {
            var manager = new BlockLevelGridsBLL();
            List<BlockLevelGridsEL> list = manager.GetBlocksLevelGridsByLevelId(IdLevel);
            DataGridViewComboBoxCell oCell = DgvStockSales.Rows[index].Cells["colGrids"] as DataGridViewComboBoxCell;
            if (list.Count > 0)
            {
                list.Insert(0, new BlockLevelGridsEL() { IdGrid = 0, GridName = "Select Grid" });

                if (oCell != null)
                {
                    oCell.DataSource = list;
                    oCell.ValueMember = "IdGrid";
                    oCell.DisplayMember = "GridName";
                }

            }
            else
            {
                oCell.DataSource = null;
            }
        }
        private void showhidecolumnsforstoretype()
        {
            if (StoreType == 2)
            {
                DgvStockSales.Columns[6].Visible = false;
                DgvStockSales.Columns[7].Visible = false;
                DgvStockSales.Columns[8].Visible = false;

                DgvStockSales.Columns[3].Width = 560;

            }
        }
        private void ShowHideColumns()
        {
            List<SoftwareTypesEL> list = DataOperations.SoftwareTypes;
            if (list.Count > 0)
            {
                SoftwareTypesEL objActiveType = list.Find(x => x.ActiveSoftware == true);
                if (objActiveType != null)
                {
                    if (objActiveType.SoftwareType == "General Trading")
                    {
                        DgvStockSales.Columns["colEngineNo"].Visible = false;
                        DgvStockSales.Columns["colChassisNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleNo"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colVehicleModel"].Visible = false;
                        DgvStockSales.Columns["colVehicleColors"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;

                        DgvStockSales.Columns["colItemName"].Width = 540;
                        DgvStockSales.Columns["colpacking"].Width = 80;
                        DgvStockSales.Columns["colQty"].Width = 100;
                        DgvStockSales.Columns["colUnitPrice"].Width = 100;
                        DgvStockSales.Columns["colAmount"].Width = 100;
                    }
                    else if (objActiveType.SoftwareType == "General Bhatta")
                    {
                        DgvStockSales.Columns["colCartons"].Visible = false;
                        DgvStockSales.Columns["colEngineNo"].Visible = false;
                        DgvStockSales.Columns["colChassisNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleNo"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colVehicleModel"].Visible = false;
                        DgvStockSales.Columns["colVehicleColors"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;

                        DgvStockSales.Columns["colItemName"].Width = 515;
                        DgvStockSales.Columns["colpacking"].Width = 80;
                        DgvStockSales.Columns["colQty"].Width = 100;
                        DgvStockSales.Columns["colUnitPrice"].Width = 100;
                        DgvStockSales.Columns["colAmount"].Width = 100;
                    }
                    else if (objActiveType.SoftwareType == "General Ledger")
                    {
                        DgvStockSales.Columns["colCartons"].Visible = false;
                        DgvStockSales.Columns["colEngineNo"].Visible = false;
                        DgvStockSales.Columns["colChassisNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleNo"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colVehicleModel"].Visible = false;
                        DgvStockSales.Columns["colVehicleColors"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;

                        DgvStockSales.Columns["colItemName"].Width = 515;
                        DgvStockSales.Columns["colpacking"].Width = 80;
                        DgvStockSales.Columns["colQty"].Width = 100;
                        DgvStockSales.Columns["colUnitPrice"].Width = 100;
                        DgvStockSales.Columns["colAmount"].Width = 100;
                    }
                    else if (objActiveType.SoftwareType == "POS")
                    {
                        DgvStockSales.Columns["colpacking"].Visible = false;
                        DgvStockSales.Columns["colCartons"].Visible = false;
                        DgvStockSales.Columns["colEngineNo"].Visible = false;
                        DgvStockSales.Columns["colChassisNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleNo"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colVehicleModel"].Visible = false;
                        DgvStockSales.Columns["colVehicleColors"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;
                        DgvStockSales.Columns["colDelete"].Visible = false;

                        DgvStockSales.Columns["colItemName"].Width = 400;
                        DgvStockSales.Columns["colQty"].Width = 170;
                        DgvStockSales.Columns["colUnitPrice"].Width = 170;
                        DgvStockSales.Columns["colAmount"].Width = 170;
                    }
                    else if (objActiveType.SoftwareType == "Motor Bikes")
                    {
                        DgvStockSales.Columns["colpacking"].Visible = false;
                        DgvStockSales.Columns["colCartons"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;

                        DgvStockSales.Columns["colItemName"].Width = 250;
                    }
                    else if (objActiveType.SoftwareType == "Motor Cars")
                    {
                        DgvStockSales.Columns["colpacking"].Visible = false;
                        DgvStockSales.Columns["colCartons"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;

                        DgvStockSales.Columns["colItemName"].Width = 250;
                    }
                    else if (objActiveType.SoftwareType == "Medicine Trading")
                    {
                        DgvStockSales.Columns["colEngineNo"].Visible = false;
                        DgvStockSales.Columns["colChassisNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleModel"].Visible = false;
                        DgvStockSales.Columns["colVehicleColors"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;


                        DgvStockSales.Columns["colItemName"].Width = 290;
                    }
                    else if (objActiveType.SoftwareType == "Medicine POS")
                    {
                        DgvStockSales.Columns["colpacking"].Visible = false;
                        DgvStockSales.Columns["colCartons"].Visible = false;
                        DgvStockSales.Columns["colEngineNo"].Visible = false;
                        DgvStockSales.Columns["colChassisNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleNo"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colVehicleModel"].Visible = false;
                        DgvStockSales.Columns["colVehicleColors"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;
                    }
                    else if (objActiveType.SoftwareType == "Mobile Soft")
                    {
                        DgvStockSales.Columns["colItemName"].Width = 260;

                        DgvStockSales.Columns["colpacking"].Visible = true;
                        DgvStockSales.Columns["colCartons"].Visible = false;
                        DgvStockSales.Columns["colEngineNo"].Visible = false;
                        DgvStockSales.Columns["colChassisNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleNo"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colVehicleModel"].Visible = false;
                        DgvStockSales.Columns["colVehicleColors"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;
                    }
                    if (objActiveType.SoftwareType == "Distribution Trading")
                    {
                        DgvStockSales.Columns["colEngineNo"].Visible = false;
                        DgvStockSales.Columns["colChassisNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleNo"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colVehicleModel"].Visible = false;
                        DgvStockSales.Columns["colVehicleColors"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;

                        DgvStockSales.Columns["colItemName"].Width = 540;
                        DgvStockSales.Columns["colpacking"].Width = 80;
                        DgvStockSales.Columns["colQty"].Width = 100;
                        DgvStockSales.Columns["colUnitPrice"].Width = 100;
                        DgvStockSales.Columns["colAmount"].Width = 100;
                    }
                    else if (objActiveType.SoftwareType == "Labs Materials Trading")
                    {
                        DgvStockSales.Columns["colCartons"].Visible = false;
                        DgvStockSales.Columns["colEngineNo"].Visible = false;
                        DgvStockSales.Columns["colChassisNo"].Visible = false;
                        DgvStockSales.Columns["colVehicleNo"].Visible = false;
                        DgvStockSales.Columns["colBatchNo"].Visible = false;
                        DgvStockSales.Columns["colExpiry"].Visible = false;
                        DgvStockSales.Columns["colVehicleModel"].Visible = false;
                        DgvStockSales.Columns["colVehicleColors"].Visible = false;
                        DgvStockSales.Columns["colFirstIMEI"].Visible = false;
                        DgvStockSales.Columns["colSecondIMEI"].Visible = false;

                        DgvStockSales.Columns["colItemName"].Width = 625;
                        DgvStockSales.Columns["colpacking"].Width = 80;
                        DgvStockSales.Columns["colQty"].Width = 100;
                        DgvStockSales.Columns["colUnitPrice"].Width = 100;
                        DgvStockSales.Columns["colAmount"].Width = 100;
                    }
                }
            }
        }
        private void CheckModulePermissions()
        {
            List<UserModulesPermissionsEL> PermissionsList = UserPermissions.GetUserModulePermissionsByUserAndModuleId(Operations.UserID);
            if (PermissionsList != null && PermissionsList.Count > 0)
            {
                if (PermissionsList[0].Saving == true)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
                if (PermissionsList[0].Deleting == true)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
                if (PermissionsList[0].Posting == true)
                {
                    btnSave.Enabled = true;
                    chkPosted.Checked = true;
                    chkPosted.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = false;
                    chkPosted.Checked = false;
                    chkPosted.Enabled = true;
                }
            }
            //else
            //{
            //    btnSave.Enabled = false;
            //    btnDelete.Enabled = false;
            //    chkPosted.Checked = true;
            //    chkPosted.Enabled = true;
            //}

        }
        private void FillEmployees(string AccountNo)
        {
            var manager = new PersonsBLL();
            List<PersonsEL> list = manager.GetPersonByAccount(Operations.IdProject, AccountNo);
            if (list.Count > 0)
            {
                if (list[0].PersonName != string.Empty)
                {
                    EmpEditBox.Text = list[0].PersonName;
                }
                else
                    EmpEditBox.Text = list[0].AccountName;
                txtContact.Text = list[0].Contact;
            }
            else
            {
                var AccountsManager = new AccountsBLL();
                List<AccountsEL> listPerson = AccountsManager.GetAccount(AccountNo, Operations.IdCompany, Operations.IdProject);
                if (list.Count > 0)
                {
                    EmpEditBox.Text = list[0].AccountName;
                }
            }
        }
        private void FillData()
        {
            var manager = new GeneralStockIssuanceHeadBLL();
            InvEditBox.Text = Validation.GetSafeString(manager.GetMaxGeneralStoreStockNumber(Operations.IdProject, Operations.BookNo, StoreType));
        }
        private void FillTotalVouchers()
        {
            var Manager = new VoucherBLL();
            lblTotalVouchers.Text = Manager.GetAllStockTotalTransactionalVouchersByType(Operations.IdProject, Operations.BookNo, StoreType == 1 ? VoucherTypes.GeneralMaterialStoreIssuance.ToString() : VoucherTypes.GeneralMaterialStoreReceiving.ToString(), IsNetTransaction).ToString();
        }
        private void GetLastVoucherTransactionByType()
        {
            var Manager = new VoucherBLL();
            List<VouchersEL> listLast = Manager.GetStockLastVoucherTransactionByType(Operations.IdProject, Operations.BookNo, StoreType == 1 ? VoucherTypes.GeneralMaterialStoreIssuance.ToString() : VoucherTypes.GeneralMaterialStoreReceiving.ToString(), IsNetTransaction);
            if (listLast != null && listLast.Count > 0)
            {
                lblLastVoucherNo.Text = listLast[0].VoucherNo.ToString();
            }
        }
        private void ClearControls()
        {
            DgvStockSales.Rows.Clear();
            VoucherNo = 0;
            IdVoucher = 0;
            txtDescription.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            CustomerTransactionId = null;
            VDate.Value = DateTime.Now;
            SalesTransactionId = null;
            CashTransactionId = null;


            lblStatuMessage.Text = string.Empty;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
            }
            btnSave.Enabled = true;
            btnDelete.Enabled = true;

            txtContact.Text = string.Empty;

            InvEditBox.Enabled = true;
            InvEditBox.Text = string.Empty;
            txtGatePass.Text = string.Empty;
        }
        private bool ValidateRows()
        {

            for (int i = 0; i < DgvStockSales.Rows.Count - 1; i++)
            {
                if (DgvStockSales.Rows[i].Cells["colQty"].Value == null)
                {
                    return false;
                }
                else if (DgvStockSales.Rows[i].Cells["colUnitPrice"].Value == null)
                {
                    return false;
                }
                if (StoreType == 1 || StoreType == 2)
                {
                    if (DgvStockSales.Rows[i].Cells["colBlocks"].Value == null || Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colBlocks"].Value) == 0)
                    {
                        MessageBox.Show("Please Select Block....");
                        return false;
                    }
                    else if (DgvStockSales.Rows[i].Cells["colLevels"].Value == null || Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colLevels"].Value) == 0)
                    {
                        MessageBox.Show("Please Select Level...");
                        return false;
                    }
                    else if (DgvStockSales.Rows[i].Cells["colGrids"].Value == null || Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colGrids"].Value) == 0)
                    {
                        MessageBox.Show("Please Select Grid...");
                        return false;
                    }
                }
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (string.IsNullOrEmpty(EmpAccountNo))
            {
                MessageBox.Show("Issuance Person Is Missing...");
                return false;
            }
            return true;
        }
        private bool ValidateBookPeriod()
        {
            bool Status = true;
            if (Operations.BookPeriod == "" || Operations.BookPeriod == "Open")
            {
                Status = true;
            }
            else
            {
                string[] Period = Operations.BookPeriod.Split('=');
                if (Period.Length == 2)
                {
                    int FirstMonth = Convert.ToInt32(Period[0].Split(',')[0]);
                    int FirstYear = Convert.ToInt32(Period[0].Split(',')[1]);

                    int SecondMonth = Convert.ToInt32(Period[1].Split(',')[0]);
                    int SecondYear = Convert.ToInt32(Period[1].Split(',')[1]);
                    if (VDate.Value.Year == FirstYear || VDate.Value.Year == SecondYear)
                    {
                        if (VDate.Value.Month < FirstMonth && VDate.Value.Year == FirstYear)
                        {
                            Status = false;
                        }
                        else if (VDate.Value.Month > SecondMonth && VDate.Value.Year == SecondYear)
                        {
                            Status = false;
                        }
                        else
                        {
                            Status = true;
                        }
                    }
                    else
                    {
                        Status = false;
                    }
                    //if (VDate.Value.Month == FirstMonth && VDate.Value.Year == FirstYear || (VDate.Value.Month == SecondMonth && VDate.Value.Year == SecondYear))
                    //{
                    //    Status = true;
                    //}
                }
                else
                {
                    Status = false;
                }
            }
            return Status;
        }
        #endregion
        #region Buttons Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Variables
            List<StockReceiptEL> oelStockReceiptCollection = new List<StockReceiptEL>();
            List<VoucherDetailEL> oelSalesDetailCollection = new List<VoucherDetailEL>();
            List<VoucherDetailEL> oelCostOfSalesCollection = new List<VoucherDetailEL>();
            List<ItemsEL> oelItemsCollection = new List<ItemsEL>();
            #endregion
            #region Main Button Area
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    if (ValidateBookPeriod())
                    {
                        #region VoucherHead
                        VouchersEL oelVoucher = new VouchersEL();
                        if (!IdVoucher.HasValue)
                        {
                            oelVoucher.IdVoucher = 0;
                        }
                        else
                        {
                            oelVoucher.IdVoucher = IdVoucher;
                        }
                        oelVoucher.IdUser = Operations.UserID;
                        oelVoucher.IdProject = Operations.IdProject;
                        oelVoucher.BookNo = Operations.BookNo;
                        oelVoucher.TerminalNumber = Validation.GetSafeInteger(XmlConfiguration.ReadXmlTerminalsConfiguration()[0]);
                        if (IdVoucher != null || IdVoucher > 0)
                        {
                            oelVoucher.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        }
                        //oelVoucher.SubAccountNo = EmpAccountNo;
                        oelVoucher.AccountNo = EmpAccountNo;
                        oelVoucher.VDiscription = Validation.GetSafeString(txtDescription.Text);
                        oelVoucher.OutWardGatePassNo = Validation.GetSafeString(txtGatePass.Text);
                        oelVoucher.VDate = VDate.Value;

                        oelVoucher.TotalAmount = Validation.GetSafeDecimal(txtTotalAmount.Text);
                        oelVoucher.VAT = 0;//Validation.GetSafeInteger(txtVat.Text);
                        oelVoucher.VATAmount = 0;//Validation.GetSafeDecimal(txtTotalAmount.Text);
                        oelVoucher.IsRecieved = false;
                        oelVoucher.IsImportTransaction = IsImportTransaction;
                        oelVoucher.IsNetTransaction = IsNetTransaction;
                        oelVoucher.StoreType = StoreType;
                        oelVoucher.Posted = chkPosted.Checked;
                        #endregion
                        #region Add Stock
                        for (int i = 0; i < DgvStockSales.Rows.Count - 1; i++)
                        {
                            VoucherDetailEL oelStoreIssuance = new VoucherDetailEL();
                            ItemsEL oelItem = new ItemsEL();
                            if (DgvStockSales.Rows[i].Cells["ColIdVoucherDetail"].Value != null)
                            {
                                //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                                oelStoreIssuance.IdVoucherDetail = Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["ColIdVoucherDetail"].Value.ToString());
                                oelStoreIssuance.IsNew = false;
                            }
                            else
                            {
                                oelStoreIssuance.IdVoucherDetail = 0;
                                //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                                oelStoreIssuance.IsNew = true;
                            }
                            oelStoreIssuance.SeqNo = i + 1;
                            oelStoreIssuance.IdVoucher = oelVoucher.IdVoucher;
                            oelStoreIssuance.IdItem = Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colIdItem"].Value);
                            oelStoreIssuance.IdGrid = Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colGrids"].Value);
                            oelItem.IdItem = Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colIdItem"].Value);
                            oelStoreIssuance.PackingSize = Validation.GetSafeString(DgvStockSales.Rows[i].Cells["colpacking"].Value);
                            oelStoreIssuance.Discription = "N/A"; //Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colRemarks"].Value);                           
                            oelStoreIssuance.CurrentStock = Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colCurrentStock"].Value);
                            oelStoreIssuance.Units = Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colQty"].Value);
                            oelStoreIssuance.MIR = Validation.GetSafeBooleanNullable(DgvStockSales.Rows[i].Cells["colMIR"].Value);
                            //oelPurchaseDetial.Bonus = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colBonus"].Value);
                            oelStoreIssuance.RemainingUnits = Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colQty"].Value);
                            oelStoreIssuance.UnitPrice = Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colUnitPrice"].Value);
                            oelStoreIssuance.CurrentUnitPrice = Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colUnitPriceFlat"].Value);
                            oelItem.CurrentUnitPrice = Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colUnitPriceFlat"].Value);
                            oelStoreIssuance.Amount = Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colAmount"].Value);
                            //oelSaleDetial.Discount = Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colDiscount"].Value.ToString().Replace('%', ' '));
                            //oelSaleDetial.DiscountAmount = Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colDiscountAmount"].Value);
                            if (StoreType == 1 || StoreType == 2)
                            {
                                if (DgvStockSales.Rows[i].Cells["colBlocks"].Value == null || Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colBlocks"].Value) == 0)
                                {
                                    MessageBox.Show("Please Select Block....");
                                    return;
                                }
                                else if (DgvStockSales.Rows[i].Cells["colLevels"].Value == null || Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colLevels"].Value) == 0)
                                {
                                    MessageBox.Show("Please Select Level...");
                                    return;
                                }
                                else if (DgvStockSales.Rows[i].Cells["colGrids"].Value == null || Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colGrids"].Value) == 0)
                                {
                                    MessageBox.Show("Please Select Grid...");
                                    return;
                                }
                            }
                            oelItemsCollection.Add(oelItem);
                            oelSalesDetailCollection.Add(oelStoreIssuance);
                        }
                        #endregion
                        #region Saving Code
                        if (IdVoucher == null || IdVoucher == 0)
                        {
                            var manager = new GeneralStockIssuanceHeadBLL();

                            EntityoperationInfo infoResult = manager.CreateGeneralStockIssuance(oelVoucher, oelSalesDetailCollection);
                            if (infoResult.IsSuccess)
                            {
                                InvEditBox.Text = infoResult.VoucherNo.ToString();
                                IdVoucher = infoResult.IntID;
                                //FillVoucher();
                                if (MessageBox.Show("Stock Issued Successfully, Do You Want To Print ?...", "Printing Report", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    PrintReport();
                                }
                                ClearControls();
                                FillData();
                            }
                        }
                        else
                        {
                            var manager = new GeneralStockIssuanceHeadBLL();
                            if (manager.UpdateGeneralStockIssuance(oelVoucher, oelSalesDetailCollection))
                            {
                                if (MessageBox.Show("Already Issued Stock Updated Successfully..., Do You Want To Print ?...", "Printing Report", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    PrintReport();
                                }
                                ClearControls();
                                FillData();
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Voucher In This Book Period :" + Operations.BookPeriod);
                    }
                }
                else
                {
                    lblStatuMessage.Text = "Check Values";
                }
            }
            else
            {
                lblStatuMessage.Text = "Incomplete Entry...";
            }
            #endregion
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelItemTransactionCollection = new List<TransactionsEL>();
            var manager = new GeneralStockIssuanceHeadBLL();

            if (IdVoucher > 0)
            {
                if (chkPosted.Checked)
                {
                    if (Operations.IdRole != Validation.GetSafeLong(EnRoles.Administrator))
                    {
                        frmauthentication = new frmAuthentication();
                        frmauthentication.ShowDialog();
                        if (Operations.IsAuthenticate && Operations.IdAuthenticationRole == Validation.GetSafeLong(EnRoles.Administrator) || Operations.IdAuthenticationRole == Validation.GetSafeLong(EnRoles.CheifExecutive))
                        {
                            if (manager.DeleteStockIssuance(IdVoucher.Value).IsSuccess)
                            {
                                MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                                Operations.IsAuthenticate = false;
                                ClearControls();
                                FillData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("You Need Admin OR CEO Login To Delete It...");
                        }
                    }
                    else if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (manager.DeleteStockIssuance(IdVoucher.Value).IsSuccess)
                        {
                            MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                            ClearControls();
                            FillData();
                        }
                    }
                }
                //PurchaseStockReceiptBLL();
                else if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (manager.DeleteStockIssuance(IdVoucher.Value).IsSuccess)
                    {
                        MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                        ClearControls();
                        FillData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Voucher To Delete...");
            }

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmprint = new frmStockIssuancePrintReport();
            if (IdVoucher > 0)
            {
                frmprint.IdVoucher = IdVoucher.Value;
                frmprint.StoreType = StoreType;
                frmprint.ShowDialog();
                //frmprintInvoice.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Invoice To Print....");
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (CustomerAccountNo != string.Empty)
            {
                frmpersons = new frmPersons();
                frmpersons.AccountNo = CustomerAccountNo;
                frmpersons.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Supplier To View Detail....");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            FillData();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (InvEditBox.Text != string.Empty)
            {
                long NextVoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                NextVoucherNo += 1;
                InvEditBox.Text = NextVoucherNo.ToString();
                FillIssuanceWithNumber(NextVoucherNo);
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (InvEditBox.Text != string.Empty)
            {
                long PreviousVoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                PreviousVoucherNo -= 1;
                InvEditBox.Text = PreviousVoucherNo.ToString();
                FillIssuanceWithNumber(PreviousVoucherNo);
            }
            else
            {
                long PreviousVoucherNo = Validation.GetSafeLong(lblLastVoucherNo.Text) + 1;
                PreviousVoucherNo -= 1;
                InvEditBox.Text = PreviousVoucherNo.ToString();
                FillIssuanceWithNumber(PreviousVoucherNo);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Other Controls Methods And Events
        private void InvEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = VoucherTypes.GeneralMaterialStoreIssuance.ToString();
            if (StoreType == 1)
                frmfindVouchers.IsNetTransaction = false;
            else
                frmfindVouchers.IsNetTransaction = true;
            frmfindVouchers.StoreType = StoreType;
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }

        private void InvEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (InvEditBox.Text != string.Empty)
                {
                    FillIssuanceWithNumber(Validation.GetSafeLong(InvEditBox.Text));
                }
            }
        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillVoucher();
                }
            }
            else
                e.Handled = true;
        }
        private void EmpEditCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DgvStockSales.Focus();
            }
            else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                if (EventTime == 0)
                {
                    EventCommandName = "Employees";
                    e.Handled = true;
                    frmAccount = new frmFindAccounts();
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.ShowDialog();
                }
            }
            else
                e.Handled = false;
        }
        #endregion
        #region Custom Controls Methods And Events
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            EmpEditBox.Text = oelAccount.AccountName;
            EmpAccountNo = oelAccount.AccountNo;
            FillEmployees(oelAccount.AccountNo);

        }
        void frmfindProducts_ExecuteFindPorudctsEvent(object Sender, ItemsEL oelItems)
        {
            DgvStockSales.RefreshEdit();
            var manager = new ItemsBLL();
            //if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
            {

                lblStatuMessage.Text = "";
                DgvStockSales.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                DgvStockSales.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                DgvStockSales.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                //DgvStockReceipt.CurrentRow.Cells["ColBatch"].Value = oelItems.BatchNo;
                DgvStockSales.CurrentRow.Cells["colCurrentStock"].Value = manager.GetItemClosingStock(Validation.GetSafeLong(DgvStockSales.CurrentRow.Cells["colIdItem"].Value));
            }
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            VoucherNo = oelVoucher.VoucherNo;
            IdVoucher = oelVoucher.IdVoucher;
            InvEditBox.Text = oelVoucher.VoucherNo.ToString();
            InvEditBox.Enabled = false;
            FillVoucher();

        }
        #endregion
        #region Stock Grid Events
        private void DgvStockSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.F2)
            //{
            //    if (DgvStockReceipt.CurrentCellAddress.X == 2)
            //    {
            //        checkSender = true;
            //        frmstockAccounts = new frmStockAccounts();
            //        frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            //        frmstockAccounts.ShowDialog(this);
            //    }
            //}
        }
        private void DgvStockSales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvStockSales.CurrentCellAddress.X == 3)
            {
                TextBox txtItemName = e.Control as TextBox;
                if (txtItemName != null)
                {
                    txtItemName.KeyPress -= new KeyPressEventHandler(txtItemName_KeyPress);
                    txtItemName.KeyPress += new KeyPressEventHandler(txtItemName_KeyPress);
                }
            }
            else if (DgvStockSales.CurrentCellAddress.X == 6)
            {
                ComboBox oCell = e.Control as ComboBox;
                if (oCell != null)
                {
                    //MessageBox.Show(oCell.SelectedValue.ToString());
                    oCell.SelectedIndexChanged -= new EventHandler(oCell_SelectedIndexChanged);
                    oCell.SelectedIndexChanged += new EventHandler(oCell_SelectedIndexChanged);
                }
            }
            else if (DgvStockSales.CurrentCellAddress.X == 7)
            {
                ComboBox oCellLevels = e.Control as ComboBox;
                if (oCellLevels != null)
                {
                    oCellLevels.SelectedIndexChanged -= new EventHandler(oCellLevels_SelectedIndexChanged);
                    oCellLevels.SelectedIndexChanged += new EventHandler(oCellLevels_SelectedIndexChanged);
                }
            }
        }
        void oCell_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DgvStockSales.CurrentCellAddress.X == 6)
            {
                ComboBox box = sender as ComboBox;
                if (box != null)
                {
                    if (box.SelectedValue != null)
                        //MessageBox.Show(box.SelectedValue.ToString());
                        GetBlockLevelsBlockById(Validation.GetSafeLong(box.SelectedValue));
                }
                //DataGridViewComboBoxCell oCell12 =  DgvStockSales.CurrentRow.Cells["colBlocks"] as DataGridViewComboBoxCell;
                //if (oCell12 != null)
                //{
                //    if(oCell12.Value != null)
                //    MessageBox.Show(oCell12.Value.ToString());
                //}
            }
        }
        void oCellLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DgvStockSales.CurrentCellAddress.X == 7)
            {
                ComboBox levelBox = sender as ComboBox;
                if (levelBox != null)
                {
                    if (levelBox.SelectedValue != null)
                    {
                        GetBlockLevelGridsByLevelId(Validation.GetSafeLong(levelBox.SelectedValue));
                    }
                }
            }
        }
        void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvStockSales.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmfindProducts = new frmFindProducts();
                    frmfindProducts.ExecuteFindPorudctsEvent += new frmFindProducts.FindProductsDelegate(frmfindProducts_ExecuteFindPorudctsEvent);
                    frmfindProducts.SearchText = e.KeyChar.ToString();
                    frmfindProducts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        private void DgvStockSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DgvStockSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                e.Value = "Delete";
            }
        }
        private void DgvStockSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal lineAmount, value = 0;
            if (e.ColumnIndex == 14)
            {
                if (DgvStockSales.Rows[e.RowIndex].Cells["ColIdVoucherDetail"].Value == null)
                {
                    if (DgvStockSales.Rows.Count > 1)
                    {
                        DataGridViewRow oRow = DgvStockSales.Rows[e.RowIndex];
                        DgvStockSales.Rows.Remove(oRow);
                    }
                    DataGridViewCell oCell = DgvStockSales.Rows[e.RowIndex].Cells["colAmount"];
                    for (int i = 0; i < DgvStockSales.Rows.Count - 1; i++)
                    {
                        value += Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colAmount"].Value);
                    }
                    //lineAmount = Validation.GetSafeDecimal(oCell.GetEditedFormattedValue(e.RowIndex, DataGridViewDataErrorContexts.Commit));
                    //txtCreditBalance.Text = (Validation.GetSafeDecimal(txtCreditBalance.Text) - lineAmount).ToString();
                    txtTotalAmount.Text = value.ToString();
                }
                else
                {
                    if (!chkPosted.Checked)
                    {
                        if (DgvStockSales.Rows.Count - 1 == 1)
                        {
                            MessageBox.Show("There Is Only One Record In This Voucher , Please Press Delete Button To Remove This Voucher");
                            return;
                        }
                        var Manager = new VoucherBLL();
                        lineAmount = Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value);
                        txtTotalAmount.Text = (Validation.GetSafeDecimal(txtTotalAmount.Text) - lineAmount).ToString();

                        if (Manager.DeleteChildRecords(Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdDetail"].Value), "StockReceiptVoucher"))
                        {
                            DataGridViewRow oRow = DgvStockSales.Rows[e.RowIndex];
                            DgvStockSales.Rows.Remove(oRow);
                            btnSave_Click(sender, e);
                            MessageBox.Show("This Voucher and Party Ledger Updated Automatically...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Voucher Is Posted...");
                    }

                }
            }
        }
        private void DgvStockSales_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvStockSales.IsCurrentCellDirty)
            {
                DgvStockSales.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void DgvStockSales_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    OldValue = Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
            //}
        }
        private void DgvStockSales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvStockSales.Columns[e.ColumnIndex].Name == "colQty")
            {
                var manager = new ItemsBLL();
                var SManager = new GeneralStockIssuanceDetailsBLL();
                OldValue = 0;
                decimal sumQuantityLoop = 0;
                decimal ClosingStock = manager.GetItemClosingStock(Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value));
                if (Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
                {

                    if (StoreType == 1)
                    {
                        if (IdVoucher == 0 || IdVoucher == null)
                        {
                            if (ClosingStock > 0)
                            {
                                for (int i = 0; i < DgvStockSales.Rows.Count - 1; i++)
                                {
                                    if (Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colIdItem"].Value) == Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value))
                                    {
                                        sumQuantityLoop += Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colQty"].Value);
                                    }
                                }
                                if (sumQuantityLoop == 0)
                                {
                                    sumQuantityLoop = Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value);
                                }
                                if (ClosingStock > sumQuantityLoop || ClosingStock == sumQuantityLoop)
                                {
                                    DgvStockSales.Rows[e.RowIndex].Cells["colUnitPrice"].Value = Math.Abs(Validation.GetSafeDecimal(manager.GetItemsAvgValueWOT(Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value)).ToString("0.00")));
                                    DgvStockSales.Rows[e.RowIndex].Cells["colUnitPriceFlat"].Value = Math.Abs(Validation.GetSafeDecimal(manager.GetItemsFlatValueWOT(Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value)).ToString("0.00")));
                                    DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                                }
                                else
                                {
                                    MessageBox.Show("Closing Stock Is Less Than Issue Quantity for this Product which is '" + ClosingStock + "'....");
                                    DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value = "";
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Quantity Not Available for this Product....");
                                DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value = "";
                                return;
                            }
                        }
                        else
                        {
                            decimal UnpostedQuantity = SManager.GetItemUnPostedIssuanceQuantity(IdVoucher.Value, Operations.IdProject, Operations.BookNo, Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value));
                            for (int i = 0; i < DgvStockSales.Rows.Count - 1; i++)
                            {
                                if (Validation.GetSafeLong(DgvStockSales.Rows[i].Cells["colIdItem"].Value) == Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value))
                                {
                                    sumQuantityLoop += Validation.GetSafeDecimal(DgvStockSales.Rows[i].Cells["colQty"].Value);
                                }
                            }
                            if (sumQuantityLoop == 0)
                            {
                                sumQuantityLoop = Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value);
                            }
                            if (UnpostedQuantity + ClosingStock >= sumQuantityLoop)
                            {
                                DgvStockSales.Rows[e.RowIndex].Cells["colUnitPrice"].Value = Math.Abs(Validation.GetSafeDecimal(manager.GetItemsAvgValueWOT(Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value)).ToString("0.00")));
                                DgvStockSales.Rows[e.RowIndex].Cells["colUnitPriceFlat"].Value = Math.Abs(Validation.GetSafeDecimal(manager.GetItemsFlatValueWOT(Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value)).ToString("0.00")));
                                DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                            }
                            else
                            {
                                MessageBox.Show("Closing Stock Is Less Than Issue Quantity for this Product which is '" + (ClosingStock + UnpostedQuantity) + "'....");
                                DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value = "";
                                return;
                            }
                        }
                    }
                    else if (StoreType == 2)
                    {
                        if (DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value != null && Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value) > 0)
                        {
                            DgvStockSales.Rows[e.RowIndex].Cells["colUnitPrice"].Value = Math.Abs(Validation.GetSafeDecimal(manager.GetItemsAvgValueWOT(Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value)).ToString("0.00")));
                            DgvStockSales.Rows[e.RowIndex].Cells["colUnitPriceFlat"].Value = Math.Abs(Validation.GetSafeDecimal(manager.GetItemsFlatValueWOT(Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value)).ToString("0.00")));
                            DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                        }
                    }
                    for (int i = 0; i < DgvStockSales.Rows.Count - 1; i++)
                    {
                        OldValue += Convert.ToDecimal(DgvStockSales.Rows[i].Cells["colAmount"].Value);
                    }
                    txtTotalAmount.Text = OldValue.ToString();
                    OldValue = 0;
                }
                //decimal ClosingStock = manager.GetItemClosingStock(Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value));
                //if (IdVoucher == 0 || IdVoucher == null)
                //{
                //    if (ClosingStock > 0)
                //    {

                //        if (ClosingStock > Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value) || ClosingStock == Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value))
                //        {
                //            /// Allow Input
                //        }
                //        else
                //        {
                //            MessageBox.Show("Closing Stock Is Less Than Issue Quantity for this Product which is '" + ClosingStock + "'....");
                //            DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value = "";
                //            return;
                //        }

                //    }
                //    else
                //    {
                //        MessageBox.Show("Quantity Not Available for this Product....");
                //        DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value = "";
                //        return;
                //    }
                //}
                //else
                //{
                //    var SManager = new SalesDetailBLL();
                //    decimal UnpostedQuantity = SManager.GetItemUnPostedSoldQuantity(IdVoucher.Value, Operations.IdProject, Operations.BookNo, Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colIdItem"].Value));
                //    if (UnpostedQuantity + ClosingStock >= Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value))
                //    {
                //        // Take No Action Please....
                //    }
                //    else
                //    {
                //        MessageBox.Show("Closing Stock Is Less Than Issue Quantity for this Product which is '" + (ClosingStock + UnpostedQuantity) + "'....");
                //        DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value = "";
                //        return;
                //    }
                //}
            }
            else if (DgvStockSales.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value) *
                                                                            Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            }
            else if (DgvStockSales.Columns[e.ColumnIndex].Name == "colDiscount")
            {
                if (DgvStockSales.Rows[e.RowIndex].Cells["colDiscount"].Value != null)
                {
                    string CellValue = Validation.GetSafeString(DgvStockSales.Rows[e.RowIndex].Cells["colDiscount"].Value);
                    if (CellValue.Contains('%'))
                    {
                        CellValue = CellValue.Substring(0, CellValue.Length - 1);
                    }
                    if (Validation.GetSafeLong(CellValue) > 0)
                    {
                        DgvStockSales.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = (Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value) - ((Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                      * Validation.GetSafeDecimal(CellValue)));

                    }
                    else
                    {
                        DgvStockSales.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value);
                    }
                }
                else
                {
                    DgvStockSales.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value);
                }
                for (int i = 0; i < DgvStockSales.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockSales.Rows[i].Cells["colDiscountAmount"].Value);
                }
                txtTotalAmount.Text = OldValue.ToString();
                OldValue = 0;
            }
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colDisc")
            //{
            //    if (Validation.GetSafeInteger(DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) != 0)
            //    {
            //        DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) * (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value)) / 100;
            //    }
            //    else
            //    {
            //        DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value = "";
            //    }
            //}
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colExpiry")
            //{
            //    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value != null)
            //    {
            //        bool Value = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Contains('/');
            //        if (Value == false)
            //        {
            //            MessageBox.Show("Wrong Expiry Date");
            //            DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //        }
            //        else
            //        {
            //            string[] splitString = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Split('/');
            //            if (splitString.Length == 3)
            //            {
            //                MessageBox.Show("Wrong Expiry Date");
            //                DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //            }
            //            else if (splitString.Length == 2)
            //            {
            //                int Year = Validation.GetSafeInteger(splitString[1]);
            //                int Month = Validation.GetSafeInteger(splitString[0]);
            //                int compareyear = Validation.GetSafeInteger(DateTime.Now.Year.ToString().Substring(2));
            //                int CurrentMonth = Validation.GetSafeInteger(DateTime.Now.Month.ToString());
            //                if (Year == compareyear)
            //                {
            //                    if (Month < CurrentMonth)
            //                    {
            //                        MessageBox.Show("Wrong Expiry Date.. Expiry Month is smaller then current Month");
            //                        DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //                    }
            //                }
            //                else if (Year < compareyear)
            //                {
            //                    MessageBox.Show("Wrong Expiry Date.. Expiry Year is smaller then current year");
            //                    DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //                }
            //            }
            //        }
            //    }
            //}
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    decimal value = 0;
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        if (OldValue > Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = OldValue;
            //            txtTotalAmount.Text = (((Convert.ToInt64(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (value))).ToString());
            //        }
            //        else if (OldValue < Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - OldValue;
            //            txtTotalAmount.Text = (Convert.ToDecimal(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + (value)).ToString();
            //        }
            //        DgvStockReceipt.Text = (DgvStockReceipt.Rows.Count - 1).ToString();
            //    }
            //}
        }
        private void DgvStockSales_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvStockSales.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value));
            }
            //else if (DgvStockSales.Columns[e.ColumnIndex].Name == "colDiscount")
            //{
            //    if (DgvStockSales.Rows[e.RowIndex].Cells["colDiscount"].Value != null && Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colDiscount"].Value) > 0)
            //    {
            //        //DgvStockSales.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = (Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
            //        //                                                                   * Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colDiscount"]);
            //        DgvStockSales.Rows[e.RowIndex].Cells["colDiscount"].Value = Validation.GetSafeString(DgvStockSales.Rows[e.RowIndex].Cells["colDiscount"].Value) + "%";
            //    }
            //    else
            //    {
            //        DgvStockSales.Rows[e.RowIndex].Cells["colDiscount"].Value = "0" + "%";
            //        DgvStockSales.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeLong(DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value);
            //    }
            //    for (int i = 0; i < DgvStockSales.Rows.Count - 1; i++)
            //    {
            //        OldValue += Convert.ToDecimal(DgvStockSales.Rows[i].Cells["colDiscountAmount"].Value);
            //    }
            //    txtTotalAmount.Text = OldValue.ToString();
            //    OldValue = 0;
            //}
            //else if (DgvStockSales.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(DgvStockSales.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            //    for (int i = 0; i < DgvStockSales.Rows.Count - 1; i++)
            //    {
            //        OldValue += Convert.ToDecimal(DgvStockSales.Rows[i].Cells["colAmount"].Value);
            //    }
            //    txtTotalAmount.Text = OldValue.ToString();
            //}
            //DgvStockReceipt.EndEdit();
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            //{
            //    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);

            //}

            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            //        {
            //            OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
            //        }
            //        txtTotalAmount.Text = OldValue.ToString();
            //        OldValue = 0;
            //    }
            //}
            //{
            //    Int64 value = 0;
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        if (OldValue > Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = OldValue;
            //            txtTotalAmount.Text = (((Convert.ToInt64(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (value))).ToString());
            //        }
            //        else if (OldValue < Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - OldValue;
            //            txtTotalAmount.Text = (Convert.ToDecimal(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + (value)).ToString();
            //        }
            //        else
            //        {
            //            txtTotalAmount.Text = OldValue.ToString();
            //        }
            //        OldValue = 0;
            //        DgvStockReceipt.Text = (DgvStockReceipt.Rows.Count - 1).ToString();
            //    }
            //}
        }
        private void DgvStockSales_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void DgvStockSales_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DgvStockReceipt.EndEdit();
            //if (!DgvStockReceipt.IsCurrentRowDirty)
            //{
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }
        #endregion
        #region Grids Transactions Related Methods
        private void FillVoucher()
        {
            #region Variables
            var Manager = new VoucherBLL();
            var SManager = new GeneralStockIssuanceHeadBLL();
            VoucherType = "P";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            #endregion
            #region Filling Sales Header And Detail
            //List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(VEditBox.Text));
            List<VoucherDetailEL> List = SManager.GetGeneralStockIssuance(IdVoucher.Value, Operations.IdProject, Operations.BookNo, StoreType);
            if (List.Count > 0)
            {
                IdVoucher = List[0].IdVoucher;
                InvEditBox.Text = Validation.GetSafeString(List[0].VoucherNo);
                txtGatePass.Text = List[0].OutWardGatePassNo;
                VDate.Value = List[0].VDate.Value;
                txtDescription.Text = List[0].VDiscription;
                txtTotalAmount.Text = List[0].TotalAmount.ToString();
                EmpAccountNo = List[0].AccountNo;
                FillEmployees(List[0].AccountNo);


                chkPosted.Checked = List[0].Posted.Value;
                if (List[0].Posted.Value)
                {
                    //if (Operations.IdRole != Validation.GetSafeLong(EnRoles.Administrator))
                    //{
                    //    btnSave.Enabled = false;
                    //    btnDelete.Enabled = false;
                    //    chkPosted.Enabled = false;
                    //}
                    chkPosted.Enabled = false;
                    lblStatuMessage.Text = "Posted Voucher ...";
                    lblStatuMessage.ForeColor = Color.Red;
                }
                else
                {
                    chkPosted.Enabled = true;
                    //btnSave.Enabled = true;
                    //btnDelete.Enabled = true;
                }
                HandleVoucher(List);
                FillIssuance(List);
            #endregion

            }
            else
            {
                MessageBox.Show("Voucher Number Not Found ...");
                ClearControls();
            }
        }
        private void FillIssuanceWithNumber(Int64 IssuanceNo)
        {
            #region Variables
            var Manager = new VoucherBLL();
            var SManager = new GeneralStockIssuanceHeadBLL();
            VoucherType = "P";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            #endregion
            #region Filling Sales Header And Detail
            //List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(VEditBox.Text));
            List<VoucherDetailEL> List = SManager.GetGeneralStockIssuanceWithIssuanceNumber(IssuanceNo, Operations.IdProject, Operations.BookNo, StoreType);
            if (List.Count > 0)
            {
                IdVoucher = List[0].IdVoucher;
                InvEditBox.Text = Validation.GetSafeString(List[0].VoucherNo);
                txtGatePass.Text = List[0].OutWardGatePassNo;
                VDate.Value = List[0].VDate.Value;
                txtDescription.Text = List[0].VDiscription;
                txtTotalAmount.Text = List[0].TotalAmount.ToString();
                EmpAccountNo = List[0].AccountNo;
                FillEmployees(List[0].AccountNo);


                chkPosted.Checked = List[0].Posted.Value;
                if (List[0].Posted.Value)
                {
                    //if (Operations.IdRole != Validation.GetSafeLong(EnRoles.Administrator))
                    //{
                    //    btnSave.Enabled = false;
                    //    btnDelete.Enabled = false;
                    //    chkPosted.Enabled = false;
                    //}
                    chkPosted.Enabled = false;
                    lblStatuMessage.Text = "Posted Voucher ...";
                    lblStatuMessage.ForeColor = Color.Red;
                }
                else
                {
                    chkPosted.Enabled = true;
                    //btnSave.Enabled = true;
                    //btnDelete.Enabled = true;
                }
                HandleVoucher(List);
                FillIssuance(List);
            #endregion

            }
            else
            {
                MessageBox.Show("Voucher Number Not Found ...");
                ClearControls();
            }
        }
        private void HandleVoucher(List<VoucherDetailEL> list)
        {
            if (list[0].Posted.Value && list[0].IsDeleted == true)
            {
                //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    btnSave.Enabled = false;
                    //btnDelete.Enabled = false;
                    chkPosted.Enabled = false;
                }
                lblVoucherStatus.Visible = true;
                lblVoucherStatus.Text = "Deleted Voucher";
                chkPosted.Checked = list[0].Posted.Value;
            }
            else if (!list[0].Posted.Value && !list[0].IsDeleted == true)
            {
                {
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
                    chkPosted.Enabled = true;
                }
                lblVoucherStatus.Visible = false;
            }
            else if (list[0].Posted.Value && !list[0].IsDeleted == true)
            {
                btnSave.Enabled = false;
                //btnDelete.Enabled = false;
                chkPosted.Enabled = false;
            }
            else if (!list[0].Posted.Value && list[0].IsDeleted == true)
            {
                btnSave.Enabled = false;
                //btnDelete.Enabled = false;
                chkPosted.Enabled = false;
                lblVoucherStatus.Visible = true;
                lblVoucherStatus.Text = "Deleted Voucher";
            }
            else if (!list[0].Posted.Value && list[0].IsDeleted == null)
            {
                btnSave.Enabled = true;
                //btnDelete.Enabled = false;
                chkPosted.Enabled = false;
                lblVoucherStatus.Visible = true;
                lblVoucherStatus.Text = "UnPosted Voucher";
            }
            else if (list[0].Posted.Value && list[0].IsDeleted == null)
            {
                btnSave.Enabled = false;
                //btnDelete.Enabled = false;
                chkPosted.Enabled = false;
                lblVoucherStatus.Visible = true;
                lblVoucherStatus.Text = "Posted Voucher";
            }
            else
            {
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void FillIssuance(List<VoucherDetailEL> List)
        {
            if (DgvStockSales.Rows.Count > 0)
            {
                DgvStockSales.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {

                for (int i = 0; i < List.Count; i++)
                {
                    DgvStockSales.Rows.Add();
                    //DgvStockReceipt.Rows[i].Cells[0].Value = List[i].TransactionID;
                    DgvStockSales.Rows[i].Cells[0].Value = List[i].IdVoucherDetail;
                    DgvStockSales.Rows[i].Cells[1].Value = List[i].IdItem;
                    DgvStockSales.Rows[i].Cells[2].Value = List[i].ItemNo;
                    DgvStockSales.Rows[i].Cells[3].Value = List[i].ItemName;
                    DgvStockSales.Rows[i].Cells[4].Value = List[i].PackingSize;
                    DgvStockSales.Rows[i].Cells[5].Value = List[i].CurrentStock;
                    //if (StoreType == 1)
                    {
                        DgvStockSales.Rows[i].Cells[6].Value = List[i].IdBlock;
                        GetBlockLevelsBlockByIdByRowIndex(List[i].IdBlock, i);
                        DgvStockSales.Rows[i].Cells[7].Value = List[i].IdLevel;
                        GetBlockLevelGridsByLevelIdByRowIndex(List[i].IdLevel, i);
                        DgvStockSales.Rows[i].Cells[8].Value = List[i].IdGrid;
                    }
                    //else
                    {
                        //DgvStockSales.Rows[i].Cells[6].Value = null;
                        //DgvStockSales.Rows[i].Cells[7].Value = null;
                        //DgvStockSales.Rows[i].Cells[8].Value = null;
                    }
                    DgvStockSales.Rows[i].Cells[9].Value = CommonFunctions.RemoveTrailingZeros(List[i].Units);
                    DgvStockSales.Rows[i].Cells[10].Value = List[i].MIR;
                    DgvStockSales.Rows[i].Cells[11].Value = List[i].CurrentStock;
                    DgvStockSales.Rows[i].Cells[12].Value = List[i].UnitPrice;
                    DgvStockSales.Rows[i].Cells[13].Value = List[i].Amount;
                    //DgvStockSales.Rows[i].Cells[18].Value = List[i].Discount.ToString() + "%";
                    //DgvStockSales.Rows[i].Cells[19].Value = List[i].DiscountAmount;

                }
            }
        }
        #endregion
        #region ReportMethod
        private void PrintReport()
        {
            PrintDialog printDialogue = new PrintDialog();
            ReportDocument RptDocument = new ReportDocument();
            TableLogOnInfo oTableLogOnInfo = new TableLogOnInfo();
            if (printDialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strSchemaName = "Transactions";
                RptDocument.Load("..//..//Reports/rptStoreIssuance.rpt");
                DbConnectionStringBuilder connectionBuilder = new DbConnectionStringBuilder();

                connectionBuilder.ConnectionString = DBHelper.DataConnection;
                oConnectionInfo.ServerName = connectionBuilder["Data Source"].ToString();
                oConnectionInfo.DatabaseName = connectionBuilder["initial catalog"].ToString();
                oConnectionInfo.UserID = connectionBuilder["user id"].ToString();
                oConnectionInfo.Password = connectionBuilder["password"].ToString();
                //oConnectionInfo.IntegratedSecurity = true;
                oConnectionInfo.Type = ConnectionInfoType.SQL;


                foreach (CrystalDecisions.CrystalReports.Engine.Table oTable in RptDocument.Database.Tables)
                {
                    oTableLogOnInfo = oTable.LogOnInfo;
                    oTableLogOnInfo.ConnectionInfo = oConnectionInfo;
                    oTable.ApplyLogOnInfo(oTableLogOnInfo);
                }

                for (int i = 0; i <= RptDocument.Database.Tables.Count - 1; i++)
                {
                    RptDocument.Database.Tables[i].Location = oConnectionInfo.DatabaseName + "." + strSchemaName + "." + RptDocument.Database.Tables[i].Location.Substring(RptDocument.Database.Tables[i].Location.LastIndexOf(".") + 1);
                }

                ParameterFieldDefinitions crParamFieldDefinitions = RptDocument.DataDefinition.ParameterFields;
                foreach (ParameterFieldDefinition def in crParamFieldDefinitions)
                {

                    if (def.ReportName == "")
                    {

                        if (def.ParameterFieldName == "@StoreType")
                        {
                            ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                            ParameterValues crCurrentValues = def.CurrentValues;


                            //string TayloringNumber = VoucherNo;

                            crParamDiscreteValue.Value = StoreType;
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }
                        else if (def.ParameterFieldName == "@IdVoucher")
                        {
                            ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                            ParameterValues crCurrentValues = def.CurrentValues;


                            //string TayloringNumber = VoucherNo;

                            crParamDiscreteValue.Value = IdVoucher; //"{" + Operations.IdCompany + "}";
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }
                        else if (def.ParameterFieldName == "@IdProject")
                        {
                            ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                            ParameterValues crCurrentValues = def.CurrentValues;


                            //string TayloringNumber = VoucherNo;

                            crParamDiscreteValue.Value = Operations.IdProject; //"{" + Operations.IdCompany + "}";
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }
                        else if (def.ParameterFieldName == "@BookNo")
                        {
                            ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                            ParameterValues crCurrentValues = def.CurrentValues;


                            //string TayloringNumber = VoucherNo;

                            crParamDiscreteValue.Value = Operations.BookNo; //"{" + Operations.IdCompany + "}";
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }
                        else if (def.ParameterFieldName == "@ProjectName")
                        {
                            ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                            ParameterValues crCurrentValues = def.CurrentValues;


                            //string TayloringNumber = VoucherNo;

                            crParamDiscreteValue.Value = Operations.ProjectName; //"{" + Operations.IdCompany + "}";
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }

                    }
                }
                //PageMargins margins = RptDocument.PrintOptions.PageMargins;
                //margins.bottomMargin = 350;/
                //margins.leftMargin = 350;
                //margins.rightMargin = 350;
                //margins.topMargin = 350;   
                //RptDocument.PrintOptions.ApplyPageMargins(margins);

                RptDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                RptDocument.PrintOptions.PaperSize = PaperSize.PaperA5;
                RptDocument.PrintToPrinter(printDialogue.PrinterSettings.Copies, printDialogue.PrinterSettings.Collate, printDialogue.PrinterSettings.FromPage, printDialogue.PrinterSettings.ToPage);
            }
            //RptDocument.PrintToPrinter(1, false, 0, 0);
            //reportViewer1.repo = RptDocument;

            // crystalReportViewer1.ReportSource = RptDocument;
        }
        #endregion
    }
}
