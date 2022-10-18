using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;
using System.Data;
using Accounts.EL;
using Accounts.Common;

namespace Accounts.DAL
{
    public class BlocksLevelsDAL
    {
        IDataReader objReader;
        public EntityoperationInfo CreateBlocksLevels(List<BlocksLevelsEL> oelBlockLevelList, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdBlockLevel = new SqlCommand("[Setup].[Proc_CreateBuildingLevels]", objConn);
            cmdBlockLevel.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelBlockLevelList.Count; i++)
            {
                if (oelBlockLevelList[i].IsNew)
                {
                    cmdBlockLevel.CommandText = "[Setup].[Proc_CreateBuildingLevels]";
                }
                else
                    cmdBlockLevel.CommandText = "[Setup].[Proc_UpdateBuildingLevels]";
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdLevel", DbType.Int64)).Value = oelBlockLevelList[i].IdLevel;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdUser", DbType.Int64)).Value = oelBlockLevelList[i].IdUser;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdBlock", DbType.Int64)).Value = oelBlockLevelList[i].IdBlock;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdProject", DbType.Int64)).Value = oelBlockLevelList[i].IdProject;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelBlockLevelList[i].BookNo;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@LevelCode", DbType.Int64)).Value = oelBlockLevelList[i].LevelCode;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@LevelName", DbType.String)).Value = oelBlockLevelList[i].LevelName;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@LevelDiscription", DbType.Int64)).Value = oelBlockLevelList[i].Discription;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelBlockLevelList[i].CreatedDateTime;

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
        public EntityoperationInfo UpdateBlocksLevels(List<BlocksLevelsEL> oelBlockLevelList, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdBlockLevel = new SqlCommand("[Setup].[Proc_UpdateBuildingLevels]", objConn);
            for (int i = 0; i < oelBlockLevelList.Count; i++)
            {
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdLevel", DbType.Int64)).Value = oelBlockLevelList[i].IdLevel;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdUser", DbType.Int64)).Value = oelBlockLevelList[i].IdUser;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdBlock", DbType.Int64)).Value = oelBlockLevelList[i].IdBlock;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdProject", DbType.Int64)).Value = oelBlockLevelList[i].IdProject;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelBlockLevelList[i].BookNo;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@LevelCode", DbType.Int64)).Value = oelBlockLevelList[i].LevelCode;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@LevelName", DbType.String)).Value = oelBlockLevelList[i].LevelName;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@LevelDiscription", DbType.Int64)).Value = oelBlockLevelList[i].Discription;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelBlockLevelList[i].CreatedDateTime;

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
        public EntityoperationInfo DeleteBlocksLevels(Int64 IdBlockLevel, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdBlockLevel = new SqlCommand("[Setup].[Proc_DeleteBuildingLevles]", objConn))
            {
                cmdBlockLevel.CommandType = CommandType.StoredProcedure;
                cmdBlockLevel.Parameters.Add(new SqlParameter("@IdBlockLevel", DbType.Int64)).Value = IdBlockLevel;

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
        public List<BlocksLevelsEL> GetBlocksLevelsByBlockId(Int64 IdBlock, SqlConnection objConn)
        {
            List<BlocksLevelsEL> list = new List<BlocksLevelsEL>();
            SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_GetBlocksLevelsByBlockId]", objConn);

            cmdCategory.Parameters.Add("@IdBlock", SqlDbType.BigInt).Value = IdBlock;

            cmdCategory.CommandType = CommandType.StoredProcedure;
            objReader = cmdCategory.ExecuteReader();
            while (objReader.Read())
            {
                BlocksLevelsEL oelBlockLevel = new BlocksLevelsEL();
                oelBlockLevel.IdLevel = Validation.GetSafeLong(objReader["Level_Id"]);
                oelBlockLevel.LevelCode = Validation.GetSafeString(objReader["Level_Code"]);
                oelBlockLevel.BlockName = Validation.GetSafeString(objReader["Block_Name"]);
                oelBlockLevel.LevelName = Validation.GetSafeString(objReader["Level_Name"]);
                oelBlockLevel.UserId = Validation.GetSafeLong(objReader["User_Id"]);
                oelBlockLevel.IsActive = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);
                oelBlockLevel.Discription = Validation.GetSafeString(objReader["LevelDiscription"]);
                oelBlockLevel.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelBlockLevel);
            }
            return list;
        }
        public List<BlocksEL> GetBlockById(Int64 IdBlock, SqlConnection objConn)
        {
            List<BlocksEL> list = new List<BlocksEL>();
            SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_GetBlockById]", objConn);

            cmdCategory.Parameters.Add("@IdBlock", SqlDbType.BigInt).Value = IdBlock;

            cmdCategory.CommandType = CommandType.StoredProcedure;
            objReader = cmdCategory.ExecuteReader();
            while (objReader.Read())
            {
                BlocksEL oelBlock = new BlocksEL();
                oelBlock.IdBlock = Validation.GetSafeLong(objReader["Block_Id"]);
                oelBlock.BlockCode = Validation.GetSafeString(objReader["Block_Code"]);
                oelBlock.BlockName = Validation.GetSafeString(objReader["Block_Name"]);
                oelBlock.UserId = Validation.GetSafeLong(objReader["User_Id"]);
                oelBlock.IsActive = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);
                oelBlock.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelBlock);
            }
            return list;
        }
        public List<BlocksEL> GetAllBlocks(Int64 IdProject, SqlConnection objConn)
        {
            List<BlocksEL> list = new List<BlocksEL>();
            SqlCommand cmdBlock = new SqlCommand("[Setup].[Proc_GetAllBlocks]", objConn);
            cmdBlock.Parameters.Add(new SqlParameter("@IdProject", DbType.Int64)).Value = IdProject;
            cmdBlock.CommandType = CommandType.StoredProcedure;
            objReader = cmdBlock.ExecuteReader();
            while (objReader.Read())
            {
                BlocksEL oelBlock = new BlocksEL();
                oelBlock.IdBlock = Validation.GetSafeLong(objReader["Block_Id"]);
                oelBlock.BlockCode = Validation.GetSafeString(objReader["Block_Code"]);
                oelBlock.BlockName = Validation.GetSafeString(objReader["Block_Name"]);
                oelBlock.UserId = Validation.GetSafeLong(objReader["User_Id"]);
                oelBlock.IsActive = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);
                oelBlock.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelBlock);
            }
            return list;
        }
    }
}
