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
    public class BlocksDAL
    {
        IDataReader objReader;
        public EntityoperationInfo CreateBlocks(BlocksEL oelBlock, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdBlock = new SqlCommand("[Setup].[Proc_CreateBuildingBlocks]", objConn))
            {
                cmdBlock.CommandType = CommandType.StoredProcedure;
                cmdBlock.Parameters.Add(new SqlParameter("@IdBlock", DbType.Int64)).Value = oelBlock.IdBlock;
                cmdBlock.Parameters.Add(new SqlParameter("@IdUser", DbType.Int64)).Value = oelBlock.UserId;
                cmdBlock.Parameters.Add(new SqlParameter("@IdProject", DbType.Int64)).Value = oelBlock.IdProject;
                cmdBlock.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelBlock.BookNo;
                cmdBlock.Parameters.Add(new SqlParameter("@BlockCode", DbType.Int64)).Value = oelBlock.BlockCode;
                cmdBlock.Parameters.Add(new SqlParameter("@BlockName", DbType.String)).Value = oelBlock.BlockName;
                cmdBlock.Parameters.Add(new SqlParameter("@BlockDiscription", DbType.Int64)).Value = oelBlock.Discription;
                cmdBlock.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelBlock.CreatedDateTime;
             
                if (cmdBlock.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo UpdateBlocks(BlocksEL oelBlock, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdBlock = new SqlCommand("[Setup].[Proc_UpdateBuildingBlocks]", objConn))
            {
                cmdBlock.CommandType = CommandType.StoredProcedure;
                cmdBlock.Parameters.Add(new SqlParameter("@IdBlock", DbType.Int64)).Value = oelBlock.IdBlock;
                cmdBlock.Parameters.Add(new SqlParameter("@IdUser", DbType.Int64)).Value = oelBlock.UserId;
                cmdBlock.Parameters.Add(new SqlParameter("@IdProject", DbType.Int64)).Value = oelBlock.IdProject;
                cmdBlock.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelBlock.BookNo;
                cmdBlock.Parameters.Add(new SqlParameter("@BlockCode", DbType.Int64)).Value = oelBlock.BlockCode;
                cmdBlock.Parameters.Add(new SqlParameter("@BlockName", DbType.String)).Value = oelBlock.BlockName;
                cmdBlock.Parameters.Add(new SqlParameter("@BlockDiscription", DbType.Int64)).Value = oelBlock.Discription;
                cmdBlock.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelBlock.CreatedDateTime;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdBlock.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo DeleteBlocks(Int64 IdBlock, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdBlock = new SqlCommand("[Setup].[Proc_DeleteBuildingBlocks]", objConn))
            {
                cmdBlock.CommandType = CommandType.StoredProcedure;
                cmdBlock.Parameters.Add(new SqlParameter("@IdBlock", DbType.Int64)).Value = IdBlock;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdBlock.ExecuteNonQuery() > -1)
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
        public bool CheckBlockNameDuplication(string BlockName, SqlConnection objConn)
        {
            List<BlocksEL> list = new List<BlocksEL>();
            SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_CheckBlockNameDuplication]", objConn);

            cmdCategory.Parameters.Add("@BlockName", SqlDbType.VarChar).Value = BlockName;

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
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
