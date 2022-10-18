using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;


namespace Accounts.BLL
{
    public class BlockLevelGridsBLL
    {
        BlockLevelGridsDAL dal;
        public BlockLevelGridsBLL()
        {
            dal = new BlockLevelGridsDAL();
        }
        public EntityoperationInfo CreateBlocksLevelGrids(List<BlockLevelGridsEL> oelBlockLevelGridList)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CreateBlocksLevelGrids(oelBlockLevelGridList, objConn);
            }
            catch (Exception ex)
            {

                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        //public EntityoperationInfo UpdateBlocksLevelGrids(List<BlockLevelGridsEL> oelBlockLevelGridList)
        //{
        //}
        public EntityoperationInfo DeleteBlocksLevelGrids(Int64 IdBlockLevelGrid)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteBlocksLevelGrids(IdBlockLevelGrid, objConn);
            }
            catch (Exception ex)
            {

                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<BlockLevelGridsEL> GetBlocksLevelGridsByLevelId(Int64 IdLevel)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetBlocksLevelGridsByLevelId(IdLevel, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
    }
}
