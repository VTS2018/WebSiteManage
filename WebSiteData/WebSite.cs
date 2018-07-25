using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
using NX.Common;
namespace WebSiteData
{
    /// <summary>
    /// 数据访问类:WebSite
    /// </summary>
    public partial class WebSite
    {
        public WebSite()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQLite.GetMaxID("WebSiteID", "WebSite");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WebSiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebSite");
            strSql.Append(" where WebSiteID=@WebSiteID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,4)
			};
            parameters[0].Value = WebSiteID;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WebSiteModel.WebSite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebSite(");
            strSql.Append("WebSiteName,WebStatusID,PartnerID,WebSiteType,Background,BrandsID,Template,TemplatePic,Language,Owner,Server,IPAddress,Payment,Iseffective,ProgramsType,SortIndex,Ishidden,AddDate,OfflineDate,Remark)");
            strSql.Append(" values (");
            strSql.Append("@WebSiteName,@WebStatusID,@PartnerID,@WebSiteType,@Background,@BrandsID,@Template,@TemplatePic,@Language,@Owner,@Server,@IPAddress,@Payment,@Iseffective,@ProgramsType,@SortIndex,@Ishidden,@AddDate,@OfflineDate,@Remark)");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteName", DbType.String),
					new SQLiteParameter("@WebStatusID", DbType.Int32,8),
					new SQLiteParameter("@PartnerID", DbType.Int32,8),
					new SQLiteParameter("@WebSiteType", DbType.String),
					new SQLiteParameter("@Background", DbType.String),
					new SQLiteParameter("@BrandsID", DbType.Int32,8),
					new SQLiteParameter("@Template", DbType.String),
					new SQLiteParameter("@TemplatePic", DbType.String),
					new SQLiteParameter("@Language", DbType.String),
					new SQLiteParameter("@Owner", DbType.Int32,8),
					new SQLiteParameter("@Server", DbType.String),
					new SQLiteParameter("@IPAddress", DbType.String),
					new SQLiteParameter("@Payment", DbType.String),
					new SQLiteParameter("@Iseffective", DbType.Int32,8),
					new SQLiteParameter("@ProgramsType", DbType.String),
					new SQLiteParameter("@SortIndex", DbType.Int32,8),
					new SQLiteParameter("@Ishidden", DbType.Int32,8),
					new SQLiteParameter("@AddDate", DbType.DateTime),
					new SQLiteParameter("@OfflineDate", DbType.DateTime),
					new SQLiteParameter("@Remark", DbType.String)};
            parameters[0].Value = model.WebSiteName;
            parameters[1].Value = model.WebStatusID;
            parameters[2].Value = model.PartnerID;
            parameters[3].Value = model.WebSiteType;
            parameters[4].Value = model.Background;
            parameters[5].Value = model.BrandsID;
            parameters[6].Value = model.Template;
            parameters[7].Value = model.TemplatePic;
            parameters[8].Value = model.Language;
            parameters[9].Value = model.Owner;
            parameters[10].Value = model.Server;
            parameters[11].Value = model.IPAddress;
            parameters[12].Value = model.Payment;
            parameters[13].Value = model.Iseffective;
            parameters[14].Value = model.ProgramsType;
            parameters[15].Value = model.SortIndex;
            parameters[16].Value = model.Ishidden;
            parameters[17].Value = model.AddDate;
            parameters[18].Value = model.OfflineDate;
            parameters[19].Value = model.Remark;

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
        public bool Update(WebSiteModel.WebSite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSite set ");
            strSql.Append("WebSiteName=@WebSiteName,");
            strSql.Append("WebStatusID=@WebStatusID,");
            strSql.Append("PartnerID=@PartnerID,");
            strSql.Append("WebSiteType=@WebSiteType,");
            strSql.Append("Background=@Background,");
            strSql.Append("BrandsID=@BrandsID,");
            strSql.Append("Template=@Template,");
            strSql.Append("TemplatePic=@TemplatePic,");
            strSql.Append("Language=@Language,");
            strSql.Append("Owner=@Owner,");
            strSql.Append("Server=@Server,");
            strSql.Append("IPAddress=@IPAddress,");
            strSql.Append("Payment=@Payment,");
            strSql.Append("Iseffective=@Iseffective,");
            strSql.Append("ProgramsType=@ProgramsType,");
            strSql.Append("SortIndex=@SortIndex,");
            strSql.Append("Ishidden=@Ishidden,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("OfflineDate=@OfflineDate,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where WebSiteID=@WebSiteID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteName", DbType.String),
					new SQLiteParameter("@WebStatusID", DbType.Int32,8),
					new SQLiteParameter("@PartnerID", DbType.Int32,8),
					new SQLiteParameter("@WebSiteType", DbType.String),
					new SQLiteParameter("@Background", DbType.String),
					new SQLiteParameter("@BrandsID", DbType.Int32,8),
					new SQLiteParameter("@Template", DbType.String),
					new SQLiteParameter("@TemplatePic", DbType.String),
					new SQLiteParameter("@Language", DbType.String),
					new SQLiteParameter("@Owner", DbType.Int32,8),
					new SQLiteParameter("@Server", DbType.String),
					new SQLiteParameter("@IPAddress", DbType.String),
					new SQLiteParameter("@Payment", DbType.String),
					new SQLiteParameter("@Iseffective", DbType.Int32,8),
					new SQLiteParameter("@ProgramsType", DbType.String),
					new SQLiteParameter("@SortIndex", DbType.Int32,8),
					new SQLiteParameter("@Ishidden", DbType.Int32,8),
					new SQLiteParameter("@AddDate", DbType.DateTime),
					new SQLiteParameter("@OfflineDate", DbType.DateTime),
					new SQLiteParameter("@Remark", DbType.String),
					new SQLiteParameter("@WebSiteID", DbType.Int32,8)};
            parameters[0].Value = model.WebSiteName;
            parameters[1].Value = model.WebStatusID;
            parameters[2].Value = model.PartnerID;
            parameters[3].Value = model.WebSiteType;
            parameters[4].Value = model.Background;
            parameters[5].Value = model.BrandsID;
            parameters[6].Value = model.Template;
            parameters[7].Value = model.TemplatePic;
            parameters[8].Value = model.Language;
            parameters[9].Value = model.Owner;
            parameters[10].Value = model.Server;
            parameters[11].Value = model.IPAddress;
            parameters[12].Value = model.Payment;
            parameters[13].Value = model.Iseffective;
            parameters[14].Value = model.ProgramsType;
            parameters[15].Value = model.SortIndex;
            parameters[16].Value = model.Ishidden;
            parameters[17].Value = model.AddDate;
            parameters[18].Value = model.OfflineDate;
            parameters[19].Value = model.Remark;
            parameters[20].Value = model.WebSiteID;

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

            strSql.Append(" UPDATE WebSite ");
            strSql.Append(" SET " + strSetValue);
            strSql.Append(" where WebSiteID=" + mid.ToString());

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
        public bool Delete(int WebSiteID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebSite ");
            strSql.Append(" where WebSiteID=@WebSiteID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,4)
			};
            parameters[0].Value = WebSiteID;

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
        public bool DeleteList(string WebSiteIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebSite ");
            strSql.Append(" where WebSiteID in (" + WebSiteIDlist + ")  ");
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
        public WebSiteModel.WebSite GetModel(int WebSiteID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WebSiteID,WebSiteName,WebStatusID,PartnerID,WebSiteType,Background,BrandsID,Template,TemplatePic,Language,Owner,Server,IPAddress,Payment,Iseffective,ProgramsType,SortIndex,Ishidden,AddDate,OfflineDate,Remark from WebSite ");
            strSql.Append(" where WebSiteID=@WebSiteID");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,4)
			};
            parameters[0].Value = WebSiteID;

            WebSiteModel.WebSite model = new WebSiteModel.WebSite();
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
        public WebSiteModel.WebSite DataRowToModel(DataRow row)
        {
            WebSiteModel.WebSite model = new WebSiteModel.WebSite();
            if (row != null)
            {
                if (row["WebSiteID"] != null && row["WebSiteID"].ToString() != "")
                {
                    model.WebSiteID = int.Parse(row["WebSiteID"].ToString());
                }
                if (row["WebSiteName"] != null)
                {
                    model.WebSiteName = row["WebSiteName"].ToString();
                }
                if (row["WebStatusID"] != null && row["WebStatusID"].ToString() != "")
                {
                    model.WebStatusID = int.Parse(row["WebStatusID"].ToString());
                }
                if (row["PartnerID"] != null && row["PartnerID"].ToString() != "")
                {
                    model.PartnerID = int.Parse(row["PartnerID"].ToString());
                }
                if (row["WebSiteType"] != null)
                {
                    model.WebSiteType = row["WebSiteType"].ToString();
                }
                if (row["Background"] != null)
                {
                    model.Background = row["Background"].ToString();
                }
                if (row["BrandsID"] != null && row["BrandsID"].ToString() != "")
                {
                    model.BrandsID = int.Parse(row["BrandsID"].ToString());
                }
                if (row["Template"] != null)
                {
                    model.Template = row["Template"].ToString();
                }
                if (row["TemplatePic"] != null)
                {
                    model.TemplatePic = row["TemplatePic"].ToString();
                }
                if (row["Language"] != null)
                {
                    model.Language = row["Language"].ToString();
                }
                if (row["Owner"] != null && row["Owner"].ToString() != "")
                {
                    model.Owner = int.Parse(row["Owner"].ToString());
                }
                if (row["Server"] != null)
                {
                    model.Server = row["Server"].ToString();
                }
                if (row["IPAddress"] != null)
                {
                    model.IPAddress = row["IPAddress"].ToString();
                }
                if (row["Payment"] != null)
                {
                    model.Payment = row["Payment"].ToString();
                }
                if (row["Iseffective"] != null && row["Iseffective"].ToString() != "")
                {
                    model.Iseffective = int.Parse(row["Iseffective"].ToString());
                }
                if (row["ProgramsType"] != null)
                {
                    model.ProgramsType = row["ProgramsType"].ToString();
                }
                if (row["SortIndex"] != null && row["SortIndex"].ToString() != "")
                {
                    model.SortIndex = int.Parse(row["SortIndex"].ToString());
                }
                if (row["Ishidden"] != null && row["Ishidden"].ToString() != "")
                {
                    model.Ishidden = int.Parse(row["Ishidden"].ToString());
                }
                if (row["AddDate"] != null && row["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(row["AddDate"].ToString());
                }
                if (row["OfflineDate"] != null && row["OfflineDate"].ToString() != "")
                {
                    model.OfflineDate = DateTime.Parse(row["OfflineDate"].ToString());
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
            strSql.Append("select WebSiteID,WebSiteName,WebStatusID,PartnerID,WebSiteType,Background,BrandsID,Template,TemplatePic,Language,Owner,Server,IPAddress,Payment,Iseffective,ProgramsType,SortIndex,Ishidden,AddDate,OfflineDate,Remark ");
            strSql.Append(" FROM WebSite ");
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
            strSql.Append("select count(1) FROM WebSite ");
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
                strSql.Append("order by T.WebSiteID desc");
            }
            strSql.Append(")AS Row, T.*  from WebSite T ");
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
            parameters[0].Value = "WebSite";
            parameters[1].Value = "WebSiteID";
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
            strSql.Append("SELECT * FROM [WebSite]");

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

