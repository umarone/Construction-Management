using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Accounts.EL;
using System.Data.SqlClient;
using Accounts.Common;

namespace Accounts.DAL
{
    public class BlockLevelGridsDAL
    {
        IDataReader objReader;
        public EntityoperationInfo CreateBlocksLevelGrids(List<BlockLevelGridsEL> oelBlockLevelGridList, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdBlockLevel = new SqlCommand("[Setup].[Proc_CreateBuildingLevelGrids]", objConn);
            cmdBlockLevel.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelBlockLevelGridList.Count; i++)
            {
                if (oelBlockLevelGridList[i].IsNew)
                {
                    cmdBlockLevel.CommandText = "[Setup].[Proc_CreateBuildingLevelGrids]";
                }
                else
                    cmdBlockLevel.CommandText = "[Setup].[Proc_UpdateBuildingLevelGrids]";
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdGrid", DbType.Int64)).Value = oelBlockLevelGridList[i].IdGrid;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdUser", DbType.Int64)).Value = oelBlockLevelGridList[i].IdUser;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdLevel", DbType.Int64)).Value = oelBlockLevelGridList[i].IdLevel;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdProject", DbType.Int64)).Value = oelBlockLevelGridList[i].IdProject;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelBlockLevelGridList[i].BookNo;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@GridCode", DbType.Int64)).Value = oelBlockLevelGridList[i].GridCode;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@GridName", DbType.String)).Value = oelBlockLevelGridList[i].GridName;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@GridDiscription", DbType.Int64)).Value = oelBlockLevelGridList[i].Discription;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelBlockLevelGridList[i].CreatedDateTime;

                if (cmdBlockLevel.ExecuteNonQuery() > -1)
                {
                    infoResult.IsSuccess = true;
                }
                else
                {
                    infoResult.IsSuccess = false;
                }
                cmdBlockLevel.Parameters.Clear();
            }

            return infoResult;
        }
        public EntityoperationInfo UpdateBlocksLevelGrids(List<BlockLevelGridsEL> oelBlockLevelGridList, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdBlockLevel = new SqlCommand("[Setup].[Proc_UpdateBuildingLevelGrids]", objConn);
            for (int i = 0; i < oelBlockLevelGridList.Count; i++)
            {
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdGrid", DbType.Int64)).Value = oelBlockLevelGridList[i].IdGrid;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdUser", DbType.Int64)).Value = oelBlockLevelGridList[i].IdUser;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdLevel", DbType.Int64)).Value = oelBlockLevelGridList[i].IdLevel;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdProject", DbType.Int64)).Value = oelBlockLevelGridList[i].IdProject;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelBlockLevelGridList[i].BookNo;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@GridCode", DbType.Int64)).Value = oelBlockLevelGridList[i].GridCode;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@GridName", DbType.String)).Value = oelBlockLevelGridList[i].GridName;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@GridDiscription", DbType.Int64)).Value = oelBlockLevelGridList[i].Discription;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelBlockLevelGridList[i].CreatedDateTime;

                if (cmdBlockLevel.ExecuteNonQuery() > -1)
                {
                    infoResult.IsSuccess = true;
                }
                else
                {
                    infoResult.IsSuccess = false;
                }
                cmdBlockLevel.Parameters.Clear();
            }


            return infoResult;
        }
        public EntityoperationInfo DeleteBlocksLevelGrids(Int64 IdBlockLevelGrid, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdBlockLevel = new SqlCommand("[Setup].[Proc_DeleteBuildingLevleGrids]", objConn))
            {
                cmdBlockLevel.CommandType = CommandType.StoredProcedure;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdBlockLevelGrid", DbType.Int64)).Value = IdBlockLevelGrid;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdBlockLevel.ExecuteNonQuery() > -1)
                {
                    infoResult.IsSuccess = true;
                }
                else
                {
                    infoResult.IsSuccess = false;
                }
            }
            return infoResult;
        }
        public List<BlockLevelGridsEL> GetBlocksLevelGridsByLevelId(Int64 IdLevel, SqlConnection objConn)
        {
            List<BlockLevelGridsEL> list = new List<BlockLevelGridsEL>();
            SqlCommand cmdGrid = new SqlCommand("[Setup].[Proc_GetBlockLevelsGridByLevelId]", objConn);

            cmdGrid.Parameters.Add("@IdLevel", SqlDbType.BigInt).Value = IdLevel;

            cmdGrid.CommandType = CommandType.StoredProcedure;
            objReader = cmdGrid.ExecuteReader();
            while (objReader.Read())
            {
                BlockLevelGridsEL oelBlockLevel = new BlockLevelGridsEL();
                oelBlockLevel.IdGrid = Validation.GetSafeLong(objReader["Grid_Id"]);
                oelBlockLevel.GridCode = Validation.GetSafeString(objReader["Grid_Code"]);
                oelBlockLevel.LevelName = Validation.GetSafeString(objReader["Level_Name"]);
                oelBlockLevel.GridName = Validation.GetSafeString(objReader["Grid_Name"]);
                oelBlockLevel.UserId = Validation.GetSafeLong(objReader["User_Id"]);
                oelBlockLevel.IsActive = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);
                oelBlockLevel.Discription = Validation.GetSafeString(objReader["GridDiscription"]);
                oelBlockLevel.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelBlockLevel);
            }
            return list;
        }
    }
}
