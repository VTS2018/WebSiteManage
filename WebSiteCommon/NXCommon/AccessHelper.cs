using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace AccessDBUtility
{
    public class AccessHelper
    {
        public AccessHelper(string strMdbPath)
        {
            //private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString;
            //private string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "F:\\MoviData\\567yy\\play\\aiqing.mdb";
            this.connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strMdbPath;
        }
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        #region 返回单个值

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <param name="cmdParms">参数数组</param>
        /// <returns>查询结果（object</returns>
        public object GetSingle(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        #endregion

        #region 返回DataSet
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">SQL查询语句</param>
        /// <param name="Times">超时时间</param>
        /// <returns></returns>
        public DataSet Query(string SQLString, int Times)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">SQL查询语句</param>
        /// <param name="cmdParms">参数数组</param>
        /// <returns></returns>
        public DataSet Query(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                    return ds;
                }
            }
        }

        #endregion

        #region 返回DataTable

        public DataTable DataTableQuery(string SQLString)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                DataTable dt = new DataTable();
                try
                {

                    conn.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(SQLString, conn);
                    sda.Fill(dt);
                    //dt.TableName = "dt";
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return dt;
            }

        }

        public DataTable DataTableQuery(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, conn, null, SQLString, cmdParms);
                using (OleDbDataAdapter sda = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    try
                    {
                        sda.Fill(dt);
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                    return dt;
                }
            }
        }

        #endregion

        #region 返回ExecuteReader

        /// <summary>
        /// 获得DataReader对象
        /// </summary>
        /// <param name="strSQL">查询的SQL语句</param>
        /// <returns></returns>
        public OleDbDataReader ExecuteReader(string strSQL)
        {
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            try
            {
                conn.Open();
                OleDbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 获得DataReader对象
        /// </summary>
        /// <param name="strSQL">查询的SQL语句</param>
        /// <param name="cmdParms">参数数组</param>
        /// <returns></returns>
        public   OleDbDataReader ExecuteReader(string strSQL, params OleDbParameter[] cmdParms)
        {
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);

            PrepareCommand(cmd, conn, null, strSQL, cmdParms);
            try
            {
                OleDbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        #endregion

        #region 判断是否存在
        public bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }

            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Exists(string strSql, params OleDbParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }

            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 返回受影响的行数
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);

                        int rows = cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        #endregion

        #region 准备执行一个命令

        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            //判断连接的状态。如果是关闭状态，则打开
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            //cmd属性赋值
            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //是否需要用到事务处理
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;

            //添加cmd需要的存储过程参数
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }

        }

        #region PrepareCommand2

        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private void PrepareCommand2(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.CommandType = CommandType.Text;//cmdType;

            if (cmdParms != null)
            {
                foreach (OleDbParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        #endregion
        #endregion

    }
}
