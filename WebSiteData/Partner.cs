using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
using NX.Common;
namespace WebSiteData
{
    /// <summary>
    /// 数据访问类:Partner
    /// </summary>
    public partial class Partner
    {
        public Partner()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQLite.GetMaxID("PartnerID", "Partner");
        }

        /// <summary>
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int PartnerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Partnername from Partner ");
            strSql.Append(" where PartnerID=" + PartnerID);
            strSql.Append(" limit 1 ");
            string title = Convert.ToString(DbHelperSQLite.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PartnerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Partner");
            strSql.Append(" where PartnerID=@PartnerID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@PartnerID", DbType.Int32,4)
			};
            parameters[0].Value = PartnerID;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebSiteModel.Partner model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Partner(");
            strSql.Append("Partnername,StarLevel,StarICO,Remark)");
            strSql.Append(" values (");
            strSql.Append("@Partnername,@StarLevel,@StarICO,@Remark)");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@Partnername", DbType.String),
					new SQLiteParameter("@StarLevel", DbType.String),
					new SQLiteParameter("@StarICO", DbType.String),
					new SQLiteParameter("@Remark", DbType.String)};
            parameters[0].Value = model.Partnername;
            parameters[1].Value = model.StarLevel;
            parameters[2].Value = model.StarICO;
            parameters[3].Value = model.Remark;

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
        public bool Update(WebSiteModel.Partner model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Partner set ");
            strSql.Append("Partnername=@Partnername,");
            strSql.Append("StarLevel=@StarLevel,");
            strSql.Append("StarICO=@StarICO,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where PartnerID=@PartnerID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@Partnername", DbType.String),
					new SQLiteParameter("@StarLevel", DbType.String),
					new SQLiteParameter("@StarICO", DbType.String),
					new SQLiteParameter("@Remark", DbType.String),
					new SQLiteParameter("@PartnerID", DbType.Int32,8)};
            parameters[0].Value = model.Partnername;
            parameters[1].Value = model.StarLevel;
            parameters[2].Value = model.StarICO;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.PartnerID;

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
        /// 更新一列数据
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="strSetValue"></param>
        /// <returns></returns>
        public bool UpdateField(int mid, string strSetValue)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" UPDATE [Partner] ");
            strSql.Append(" SET " + strSetValue);
            strSql.Append(" where PartnerID=" + mid.ToString());

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PartnerID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Partner ");
            strSql.Append(" where PartnerID=@PartnerID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@PartnerID", DbType.Int32,4)
			};
            parameters[0].Value = PartnerID;

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
        public bool DeleteList(string PartnerIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Partner ");
            strSql.Append(" where PartnerID in (" + PartnerIDlist + ")  ");
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
        public WebSiteModel.Partner GetModel(int PartnerID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PartnerID,Partnername,StarLevel,StarICO,Remark from Partner ");
            strSql.Append(" where PartnerID=@PartnerID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@PartnerID", DbType.Int32,4)
			};
            parameters[0].Value = PartnerID;

            WebSiteModel.Partner model = new WebSiteModel.Partner();
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
        public WebSiteModel.Partner DataRowToModel(DataRow row)
        {
            WebSiteModel.Partner model = new WebSiteModel.Partner();
            if (row != null)
            {
                if (row["PartnerID"] != null && row["PartnerID"].ToString() != "")
                {
                    model.PartnerID = int.Parse(row["PartnerID"].ToString());
                }
                if (row["Partnername"] != null)
                {
                    model.Partnername = row["Partnername"].ToString();
                }
                if (row["StarLevel"] != null)
                {
                    model.StarLevel = row["StarLevel"].ToString();
                }
                if (row["StarICO"] != null)
                {
                    model.StarICO = row["StarICO"].ToString();
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
            strSql.Append("select PartnerID,Partnername,StarLevel,StarICO,Remark ");
            strSql.Append(" FROM Partner ");
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
            strSql.Append("select count(1) FROM Partner ");
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
                strSql.Append("order by T.PartnerID desc");
            }
            strSql.Append(")AS Row, T.*  from Partner T ");
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
            parameters[0].Value = "Partner";
            parameters[1].Value = "PartnerID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM [Partner]");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            recordCount = Convert.ToInt32(DbHelperSQLite.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQLite.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion  ExtensionMethod
    }
}

