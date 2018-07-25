using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace WebSiteData
{
    /// <summary>
    /// 数据访问类:Domain
    /// </summary>
    public partial class Domain
    {
        public Domain()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQLite.GetMaxID("DomainID", "Domain");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DomainID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Domain");
            strSql.Append(" where DomainID=@DomainID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@DomainID", DbType.Int32,4)
			};
            parameters[0].Value = DomainID;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebSiteModel.Domain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Domain(");
            strSql.Append("WebSiteID,RegistDate,ExpireDate,RegAccount,DNSprovider,DNS,DNSAccount,IPAddress,Remark)");
            strSql.Append(" values (");
            strSql.Append("@WebSiteID,@RegistDate,@ExpireDate,@RegAccount,@DNSprovider,@DNS,@DNSAccount,@IPAddress,@Remark)");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,8),
					new SQLiteParameter("@RegistDate", DbType.DateTime),
					new SQLiteParameter("@ExpireDate", DbType.DateTime),
					new SQLiteParameter("@RegAccount", DbType.String),
					new SQLiteParameter("@DNSprovider", DbType.String),
					new SQLiteParameter("@DNS", DbType.String),
					new SQLiteParameter("@DNSAccount", DbType.String),
					new SQLiteParameter("@IPAddress", DbType.String),
					new SQLiteParameter("@Remark", DbType.String)};
            parameters[0].Value = model.WebSiteID;
            parameters[1].Value = model.RegistDate;
            parameters[2].Value = model.ExpireDate;
            parameters[3].Value = model.RegAccount;
            parameters[4].Value = model.DNSprovider;
            parameters[5].Value = model.DNS;
            parameters[6].Value = model.DNSAccount;
            parameters[7].Value = model.IPAddress;
            parameters[8].Value = model.Remark;

            object obj = DbHelperSQLite.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WebSiteModel.Domain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Domain set ");
            strSql.Append("WebSiteID=@WebSiteID,");
            strSql.Append("RegistDate=@RegistDate,");
            strSql.Append("ExpireDate=@ExpireDate,");
            strSql.Append("RegAccount=@RegAccount,");
            strSql.Append("DNSprovider=@DNSprovider,");
            strSql.Append("DNS=@DNS,");
            strSql.Append("DNSAccount=@DNSAccount,");
            strSql.Append("IPAddress=@IPAddress,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where DomainID=@DomainID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,8),
					new SQLiteParameter("@RegistDate", DbType.DateTime),
					new SQLiteParameter("@ExpireDate", DbType.DateTime),
					new SQLiteParameter("@RegAccount", DbType.String),
					new SQLiteParameter("@DNSprovider", DbType.String),
					new SQLiteParameter("@DNS", DbType.String),
					new SQLiteParameter("@DNSAccount", DbType.String),
					new SQLiteParameter("@IPAddress", DbType.String),
					new SQLiteParameter("@Remark", DbType.String),
					new SQLiteParameter("@DomainID", DbType.Int32,8)};
            parameters[0].Value = model.WebSiteID;
            parameters[1].Value = model.RegistDate;
            parameters[2].Value = model.ExpireDate;
            parameters[3].Value = model.RegAccount;
            parameters[4].Value = model.DNSprovider;
            parameters[5].Value = model.DNS;
            parameters[6].Value = model.DNSAccount;
            parameters[7].Value = model.IPAddress;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.DomainID;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int DomainID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Domain ");
            strSql.Append(" where DomainID=@DomainID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@DomainID", DbType.Int32,4)
			};
            parameters[0].Value = DomainID;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string DomainIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Domain ");
            strSql.Append(" where DomainID in (" + DomainIDlist + ")  ");
            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebSiteModel.Domain GetModel(int DomainID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DomainID,WebSiteID,RegistDate,ExpireDate,RegAccount,DNSprovider,DNS,DNSAccount,IPAddress,Remark from Domain ");
            strSql.Append(" where DomainID=@DomainID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@DomainID", DbType.Int32,4)
			};
            parameters[0].Value = DomainID;

            WebSiteModel.Domain model = new WebSiteModel.Domain();
            DataSet ds = DbHelperSQLite.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebSiteModel.Domain DataRowToModel(DataRow row)
        {
            WebSiteModel.Domain model = new WebSiteModel.Domain();
            if (row != null)
            {
                if (row["DomainID"] != null && row["DomainID"].ToString() != "")
                {
                    model.DomainID = int.Parse(row["DomainID"].ToString());
                }
                if (row["WebSiteID"] != null && row["WebSiteID"].ToString() != "")
                {
                    model.WebSiteID = int.Parse(row["WebSiteID"].ToString());
                }
                if (row["RegistDate"] != null && row["RegistDate"].ToString() != "")
                {
                    model.RegistDate = DateTime.Parse(row["RegistDate"].ToString());
                }
                if (row["ExpireDate"] != null && row["ExpireDate"].ToString() != "")
                {
                    model.ExpireDate = DateTime.Parse(row["ExpireDate"].ToString());
                }
                if (row["RegAccount"] != null)
                {
                    model.RegAccount = row["RegAccount"].ToString();
                }
                if (row["DNSprovider"] != null)
                {
                    model.DNSprovider = row["DNSprovider"].ToString();
                }
                if (row["DNS"] != null)
                {
                    model.DNS = row["DNS"].ToString();
                }
                if (row["DNSAccount"] != null)
                {
                    model.DNSAccount = row["DNSAccount"].ToString();
                }
                if (row["IPAddress"] != null)
                {
                    model.IPAddress = row["IPAddress"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DomainID,WebSiteID,RegistDate,ExpireDate,RegAccount,DNSprovider,DNS,DNSAccount,IPAddress,Remark ");
            strSql.Append(" FROM Domain ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Domain ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQLite.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.DomainID desc");
            }
            strSql.Append(")AS Row, T.*  from Domain T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQLite.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@tblName", DbType.VarChar, 255),
                    new SQLiteParameter("@fldName", DbType.VarChar, 255),
                    new SQLiteParameter("@PageSize", DbType.Int32),
                    new SQLiteParameter("@PageIndex", DbType.Int32),
                    new SQLiteParameter("@IsReCount", DbType.bit),
                    new SQLiteParameter("@OrderType", DbType.bit),
                    new SQLiteParameter("@strWhere", DbType.VarChar,1000),
                    };
            parameters[0].Value = "Domain";
            parameters[1].Value = "DomainID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

