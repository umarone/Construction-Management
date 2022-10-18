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
using SpreadsheetLight;
using System.Diagnostics;

namespace Accounts.UI
{
    public partial class frmInventoryIssuanceLocation : MetroForm
    {
        #region Variables
        frmFindProducts frmfindstock;
        Int64? IdItem;
        #endregion
        public frmInventoryIssuanceLocation()
        {
            InitializeComponent();
        }
        private void frmInventoryIssuanceLocation_Load(object sender, EventArgs e)
        {
            this.grdMaterials.AutoGenerateColumns = false;
        }
        private void PEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                e.Handled = true;
                frmfindstock = new frmFindProducts();
                frmfindstock.SearchText = e.KeyChar.ToString();
                frmfindstock.ExecuteFindPorudctsEvent += new frmFindProducts.FindProductsDelegate(frmfindstock_ExecuteFindPorudctsEvent);
                frmfindstock.ShowDialog();
            }
        }
        private void PEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindstock = new frmFindProducts();
            frmfindstock.ExecuteFindPorudctsEvent += new frmFindProducts.FindProductsDelegate(frmfindstock_ExecuteFindPorudctsEvent);
            frmfindstock.ShowDialog();
        }
        void frmfindstock_ExecuteFindPorudctsEvent(object Sender, ItemsEL oelItems)
        {
            PEditBox.Text = oelItems.ItemName;
            IdItem = oelItems.IdItem;
        }
        private void btnProductReport_Click(object sender, EventArgs e)
        {
            var manager = new GeneralStockIssuanceHeadBLL();
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            if (!chkAllProducts.Checked)
            {
                list = manager.GetMaterialLocation(IdItem.Value);
            }
            else
                list = manager.GetAllMaterialLocation();

            if (list.Count > 0)
            {
                grdMaterials.DataSource = list;
            }
            else
            {
                MessageBox.Show("No Data Found...");
                grdMaterials.DataSource = null;
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grdMaterials.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in grdMaterials.Columns)
                {
                    if (column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }
                }

                //Add Header Rows....
                dt.Rows.Add();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Rows[0][i] = dt.Columns[i].ColumnName; //"Account Name"; 
                }

                // Add Empty Row....
                dt.Rows.Add();
                for (int i = 0; i < grdMaterials.Columns.Count; i++)
                {
                    if (i != dt.Columns.Count)
                    {
                        dt.Rows[1][i] = "";
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (DataGridViewRow row in grdMaterials.Rows)
                {
                    dt.Rows.Add();
                    int colindex = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //if (cell.Value != null)
                        //{
                        if (cell.Visible)
                        {
                            //dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                            dt.Rows[dt.Rows.Count - 1][colindex] = cell.Value ?? 0.ToString();
                            colindex++;
                        }
                        //}
                    }
                }

                SLDocument slExcelExport = new SLDocument();


                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    slExcelExport.SetColumnWidth(i, 20);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        slExcelExport.SetCellValue(j + 1, i + 1, dt.Rows[j].ItemArray[i].ToString());
                    }
                }
                slExcelExport.Save();

                Process.Start("Book1.xlsx");
            }
        }
        private void chkAllProducts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllProducts.Checked)
            {
                grdMaterials.Columns[0].Visible = true;
                grdMaterials.Columns[1].Visible = true;
                grdMaterials.DataSource = null;

                grdMaterials.Columns[3].Width = 100;
                grdMaterials.Columns[4].Width = 100;
                grdMaterials.Columns[5].Width = 140;
            }
            else
            {
                grdMaterials.Columns[0].Visible = false;
                grdMaterials.Columns[1].Visible = false;

                grdMaterials.Columns[3].Width = 200;
                grdMaterials.Columns[4].Width = 200;
                grdMaterials.Columns[5].Width = 200;


                grdMaterials.DataSource = null;
            }
        }
    }
}
