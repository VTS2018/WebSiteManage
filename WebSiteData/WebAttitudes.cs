using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
using NX.Common;
namespace WebSiteData
{
    /// <summary>
    /// 数据访问类:WebAttitudes
    /// </summary>
    public partial class WebAttitudes
    {
        public WebAttitudes()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQLite.GetMaxID("WebAttitudesID", "WebAttitudes");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WebAttitudesID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebAttitudes");
            strSql.Append(" where WebAttitudesID=@WebAttitudesID");
            SQLiteParameter[] parameters = 
            {
				new SQLiteParameter("@WebAttitudesID", DbType.Int32,4)
			};
            parameters[0].Value = WebAttitudesID;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebSiteModel.WebAttitudes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebAttitudes(");
            strSql.Append("Title,SortIndex,AddDate,Remark,Color)");
            strSql.Append(" values (");
            strSql.Append("@Title,@SortIndex,@AddDate,@Remark,@Color)");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SQLiteParameter[] parameters = 
            {
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@SortIndex", DbType.Int32,8),
					new SQLiteParameter("@AddDate", DbType.DateTime),
					new SQLiteParameter("@Remark", DbType.String),
                    new SQLiteParameter("@Color", DbType.String)
            };
            parameters[0].Value = model.Title;
            parameters[1].Value = model.SortIndex;
            parameters[2].Value = model.AddDate;
            parameters[3].Value = model.Remark;
            parameters[3].Value = model.Color;

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
        public bool Update(WebSiteModel.WebAttitudes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebAttitudes set ");
            strSql.Append("Title=@Title,");
            strSql.Append("SortIndex=@SortIndex,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Color=@Color");
            strSql.Append(" where WebAttitudesID=@WebAttitudesID");
            SQLiteParameter[] parameters = 
            {
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@SortIndex", DbType.Int32,8),
					new SQLiteParameter("@AddDate", DbType.DateTime),
					new SQLiteParameter("@Remark", DbType.String),
                    new SQLiteParameter("@Color", DbType.String),

					new SQLiteParameter("@WebAttitudesID", DbType.Int32,8)
            };
            parameters[0].Value = model.Title;
            parameters[1].Value = model.SortIndex;
            parameters[2].Value = model.AddDate;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.Color;

            parameters[5].Value = model.WebAttitudesID;

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
        public bool UpdateField(int WebAttitudesID, string strSetValue)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" UPDATE WebAttitudes ");
            strSql.Append(" SET " + strSetValue);
            strSql.Append(" where WebAttitudesID=" + WebAttitudesID.ToString());

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
        public bool Delete(int WebAttitudesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebAttitudes ");
            strSql.Append(" where WebAttitudesID=@WebAttitudesID");
            SQLiteParameter[] parameters = 
            {
				new SQLiteParameter("@WebAttitudesID", DbType.Int32,4)
			};
            parameters[0].Value = WebAttitudesID;

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
        public bool DeleteList(string WebAttitudesIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebAttitudes ");
            strSql.Append(" where WebAttitudesID in (" + WebAttitudesIDlist + ")  ");
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
        public WebSiteModel.WebAttitudes GetModel(int WebAttitudesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WebAttitudesID,Title,SortIndex,AddDate,Remark,Color from WebAttitudes ");
            strSql.Append(" where WebAttitudesID=@WebAttitudesID");
            SQLiteParameter[] parameters = 
            {
				new SQLiteParameter("@WebAttitudesID", DbType.Int32,4)
			};
            parameters[0].Value = WebAttitudesID;

            WebSiteModel.WebAttitudes model = new WebSiteModel.WebAttitudes();
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
        public WebSiteModel.WebAttitudes DataRowToModel(DataRow row)
        {
            WebSiteModel.WebAttitudes model = new WebSiteModel.WebAttitudes();
            if (row != null)
            {
                if (row["WebAttitudesID"] != null && row["WebAttitudesID"].ToString() != "")
                {
                    model.WebAttitudesID = int.Parse(row["WebAttitudesID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["SortIndex"] != null && row["SortIndex"].ToString() != "")
                {
                    model.SortIndex = int.Parse(row["SortIndex"].ToString());
                }
                if (row["AddDate"] != null && row["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(row["AddDate"].ToString());
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
            strSql.Append("select WebAttitudesID,Title,SortIndex,AddDate,Remark,Color ");
            strSql.Append(" FROM WebAttitudes ");
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
            strSql.Append("select count(1) FROM WebAttitudes ");
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
                strSql.Append("order by T.WebAttitudesID desc");
            }
            strSql.Append(")AS Row, T.*  from WebAttitudes T ");
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
            parameters[0].Value = "WebAttitudes";
            parameters[1].Value = "WebAttitudesID";
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
            strSql.Append("SELECT * FROM [WebAttitudes]");

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

