using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
using NX.Common;
namespace WebSiteData
{
    /// <summary>
    /// 数据访问类:WebStatus
    /// </summary>
    public partial class WebStatus
    {
        public WebStatus()
        { }

        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQLite.GetMaxID("WebStatusID", "WebStatus");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WebStatusID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebStatus");
            strSql.Append(" where WebStatusID=@WebStatusID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebStatusID", DbType.Int32,4)
			};
            parameters[0].Value = WebStatusID;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int WebStatusID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Status from WebStatus ");
            strSql.Append(" where WebStatusID=" + WebStatusID);
            strSql.Append(" limit 1 ");
            string title = Convert.ToString(DbHelperSQLite.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebSiteModel.WebStatus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebStatus(");
            strSql.Append("Status,Remark,Color)");
            strSql.Append(" values (");
            strSql.Append("@Status,@Remark,@Color)");
            strSql.Append(";select LAST_INSERT_ROWID()");

            SQLiteParameter[] parameters = 
            {
				new SQLiteParameter("@Status", DbType.String),
				new SQLiteParameter("@Remark", DbType.String),
                new SQLiteParameter("@Color", DbType.String)
            };

            parameters[0].Value = model.Status;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.Color;

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
        public bool Update(WebSiteModel.WebStatus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebStatus set ");
            strSql.Append("Status=@Status,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Color=@Color");
            strSql.Append(" where WebStatusID=@WebStatusID");

            SQLiteParameter[] parameters = 
            {
					new SQLiteParameter("@Status", DbType.String),
					new SQLiteParameter("@Remark", DbType.String),
					new SQLiteParameter("@Color", DbType.String),
					new SQLiteParameter("@WebStatusID", DbType.Int32,8)
            };

            parameters[0].Value = model.Status;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.Color;
            parameters[3].Value = model.WebStatusID;

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
        public bool Delete(int WebStatusID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebStatus ");
            strSql.Append(" where WebStatusID=@WebStatusID");
            SQLiteParameter[] parameters = 
            {
					new SQLiteParameter("@WebStatusID", DbType.Int32,4)
			};
            parameters[0].Value = WebStatusID;

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
        public bool DeleteList(string WebStatusIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebStatus ");
            strSql.Append(" where WebStatusID in (" + WebStatusIDlist + ")  ");
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
        public WebSiteModel.WebStatus GetModel(int WebStatusID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WebStatusID,Status,Remark,Color from WebStatus ");
            strSql.Append(" where WebStatusID=@WebStatusID");
            SQLiteParameter[] parameters = 
            {
				new SQLiteParameter("@WebStatusID", DbType.Int32,4)
			};
            parameters[0].Value = WebStatusID;

            WebSiteModel.WebStatus model = new WebSiteModel.WebStatus();
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
        public WebSiteModel.WebStatus DataRowToModel(DataRow row)
        {
            WebSiteModel.WebStatus model = new WebSiteModel.WebStatus();
            if (row != null)
            {
                if (row["WebStatusID"] != null && row["WebStatusID"].ToString() != "")
                {
                    model.WebStatusID = int.Parse(row["WebStatusID"].ToString());
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Color"] != null)
                {
                    model.Color = row["Color"].ToString();
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
            strSql.Append("select WebStatusID,Status,Remark,Color");
            strSql.Append(" FROM WebStatus ");
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
            strSql.Append("select count(1) FROM WebStatus ");
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
                strSql.Append("order by T.WebStatusID desc");
            }
            strSql.Append(")AS Row, T.*  from WebStatus T ");
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
            parameters[0].Value = "WebStatus";
            parameters[1].Value = "WebStatusID";
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
            strSql.Append("SELECT * FROM [WebStatus]");

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

