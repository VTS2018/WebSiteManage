using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
using NX.Common;
namespace WebSiteData
{
    /// <summary>
    /// 数据访问类:Brands
    /// </summary>
    public partial class Brands
    {
        public Brands()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQLite.GetMaxID("BrandsID", "Brands");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BrandsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Brands");
            strSql.Append(" where BrandsID=@BrandsID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@BrandsID", DbType.Int32,4)
			};
            parameters[0].Value = BrandsID;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int BrandsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BrandsName from Brands ");
            strSql.Append(" where BrandsID=" + BrandsID);
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
        public int Add(WebSiteModel.Brands model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Brands(");
            strSql.Append("BrandsName,SortIndex,Remark)");
            strSql.Append(" values (");
            strSql.Append("@BrandsName,@SortIndex,@Remark)");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@BrandsName", DbType.String),
					new SQLiteParameter("@SortIndex", DbType.Int32,8),
					new SQLiteParameter("@Remark", DbType.String)};
            parameters[0].Value = model.BrandsName;
            parameters[1].Value = model.SortIndex;
            parameters[2].Value = model.Remark;

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
        public bool Update(WebSiteModel.Brands model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Brands set ");
            strSql.Append("BrandsName=@BrandsName,");
            strSql.Append("SortIndex=@SortIndex,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where BrandsID=@BrandsID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@BrandsName", DbType.String),
					new SQLiteParameter("@SortIndex", DbType.Int32,8),
					new SQLiteParameter("@Remark", DbType.String),
					new SQLiteParameter("@BrandsID", DbType.Int32,8)};
            parameters[0].Value = model.BrandsName;
            parameters[1].Value = model.SortIndex;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.BrandsID;

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

            strSql.Append(" UPDATE [Brands] ");
            strSql.Append(" SET " + strSetValue);
            strSql.Append(" where BrandsID=" + mid.ToString());

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
        public bool Delete(int BrandsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Brands ");
            strSql.Append(" where BrandsID=@BrandsID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@BrandsID", DbType.Int32,4)
			};
            parameters[0].Value = BrandsID;

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
        public bool DeleteList(string BrandsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Brands ");
            strSql.Append(" where BrandsID in (" + BrandsIDlist + ")  ");
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
        public WebSiteModel.Brands GetModel(int BrandsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BrandsID,BrandsName,SortIndex,Remark from Brands ");
            strSql.Append(" where BrandsID=@BrandsID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@BrandsID", DbType.Int32,4)
			};
            parameters[0].Value = BrandsID;

            WebSiteModel.Brands model = new WebSiteModel.Brands();
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
        public WebSiteModel.Brands DataRowToModel(DataRow row)
        {
            WebSiteModel.Brands model = new WebSiteModel.Brands();
            if (row != null)
            {
                if (row["BrandsID"] != null && row["BrandsID"].ToString() != "")
                {
                    model.BrandsID = int.Parse(row["BrandsID"].ToString());
                }
                if (row["BrandsName"] != null)
                {
                    model.BrandsName = row["BrandsName"].ToString();
                }
                if (row["SortIndex"] != null && row["SortIndex"].ToString() != "")
                {
                    model.SortIndex = int.Parse(row["SortIndex"].ToString());
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
            strSql.Append("select BrandsID,BrandsName,SortIndex,Remark ");
            strSql.Append(" FROM Brands ");
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
            strSql.Append("select count(1) FROM Brands ");
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
                strSql.Append("order by T.BrandsID desc");
            }
            strSql.Append(")AS Row, T.*  from Brands T ");
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
            parameters[0].Value = "Brands";
            parameters[1].Value = "BrandsID";
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
            strSql.Append("SELECT [BrandsID],[BrandsName],[SortIndex],[Remark] FROM [Brands]");

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

