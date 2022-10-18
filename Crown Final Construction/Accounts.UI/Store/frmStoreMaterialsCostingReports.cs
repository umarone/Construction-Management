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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Common;

namespace Accounts.UI
{
    public partial class frmStoreMaterialsCostingReports : MetroForm
    {
        #region Variables
        string ReportName = "";
        ConnectionInfo oConnectionInfo = new ConnectionInfo();
        #endregion
        #region Forms Methods and events
        public frmStoreMaterialsCostingReports()
        {
            InitializeComponent();
        }
        private void frmStoreMaterialsCostingReports_Load(object sender, EventArgs e)
        {

        }
        #endregion
        #region Button Events
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ctx1.Show(btnPrint, new Point(0, btnPrint.Height));
        }
        #endregion
        #region Menu  Strip Events
        private void departmentWiseCostingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportName = "rptAllMaterialsCostingsByDepartments.rpt";
            PrintReport();
        }
        private void blockWiseCostingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportName = "rptAllMaterialsCostingByBlocks.rpt";
            PrintReport();
        }

        private void levelWiseCostingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportName = "rptAllMaterialsCostingByLevels.rpt";
            PrintReport();
        }

        private void gridWiseCostingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportName = "rptAllMaterialsCostingByGrids.rpt";
            PrintReport();
        }
        private void PrintReport()
        {
            string strSchemaName = "Transactions";
            ReportDocument RptDocument = new ReportDocument();
            RptDocument.Load("..//..//StoreReports/" + ReportName);
            TableLogOnInfo oTableLogOnInfo = new TableLogOnInfo();
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

                    if (def.ParameterFieldName == "@StartDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        //string TayloringNumber = VoucherNo;

                        crParamDiscreteValue.Value = dtStart.Value; //"{" + Operations.IdCompany + "}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@EndDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        //string TayloringNumber = VoucherNo;

                        crParamDiscreteValue.Value = dtEnd.Value; //"{" + Operations.IdCompany + "}";
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

            ReportCostingPreview.ReportSource = RptDocument;
            //RptDocument.PrintToPrinter(1, false, 0, 0);
            //reportViewer1.repo = RptDocument;

            // crystalReportViewer1.ReportSource = RptDocument;
        }
        #endregion
    }
}
