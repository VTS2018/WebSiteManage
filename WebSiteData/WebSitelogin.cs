using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace WebSiteData
{
	/// <summary>
	/// 数据访问类:WebSitelogin
	/// </summary>
	public partial class WebSitelogin
	{
		public WebSitelogin()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("WebSiteloginID", "WebSitelogin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int WebSiteloginID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WebSitelogin");
			strSql.Append(" where WebSiteloginID=@WebSiteloginID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteloginID", DbType.Int32,4)
			};
			parameters[0].Value = WebSiteloginID;
            
			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(WebSiteModel.WebSitelogin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WebSitelogin(");
			strSql.Append("WebSiteID,Background,BackloginURL,Username,UserPwd,Database,Controlpanel,Remark)");
			strSql.Append(" values (");
			strSql.Append("@WebSiteID,@Background,@BackloginURL,@Username,@UserPwd,@Database,@Controlpanel,@Remark)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,8),
					new SQLiteParameter("@Background", DbType.String),
					new SQLiteParameter("@BackloginURL", DbType.String),
					new SQLiteParameter("@Username", DbType.String),
					new SQLiteParameter("@UserPwd", DbType.String),
					new SQLiteParameter("@Database", DbType.String),
					new SQLiteParameter("@Controlpanel", DbType.String),
					new SQLiteParameter("@Remark", DbType.String)};
			parameters[0].Value = model.WebSiteID;
			parameters[1].Value = model.Background;
			parameters[2].Value = model.BackloginURL;
			parameters[3].Value = model.Username;
			parameters[4].Value = model.UserPwd;
			parameters[5].Value = model.Database;
			parameters[6].Value = model.Controlpanel;
			parameters[7].Value = model.Remark;

			object obj = DbHelperSQLite.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(WebSiteModel.WebSitelogin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WebSitelogin set ");
			strSql.Append("WebSiteID=@WebSiteID,");
			strSql.Append("Background=@Background,");
			strSql.Append("BackloginURL=@BackloginURL,");
			strSql.Append("Username=@Username,");
			strSql.Append("UserPwd=@UserPwd,");
			strSql.Append("Database=@Database,");
			strSql.Append("Controlpanel=@Controlpanel,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where WebSiteloginID=@WebSiteloginID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,8),
					new SQLiteParameter("@Background", DbType.String),
					new SQLiteParameter("@BackloginURL", DbType.String),
					new SQLiteParameter("@Username", DbType.String),
					new SQLiteParameter("@UserPwd", DbType.String),
					new SQLiteParameter("@Database", DbType.String),
					new SQLiteParameter("@Controlpanel", DbType.String),
					new SQLiteParameter("@Remark", DbType.String),
					new SQLiteParameter("@WebSiteloginID", DbType.Int32,8)};
			parameters[0].Value = model.WebSiteID;
			parameters[1].Value = model.Background;
			parameters[2].Value = model.BackloginURL;
			parameters[3].Value = model.Username;
			parameters[4].Value = model.UserPwd;
			parameters[5].Value = model.Database;
			parameters[6].Value = model.Controlpanel;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.WebSiteloginID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int WebSiteloginID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WebSitelogin ");
			strSql.Append(" where WebSiteloginID=@WebSiteloginID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteloginID", DbType.Int32,4)
			};
			parameters[0].Value = WebSiteloginID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string WebSiteloginIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WebSitelogin ");
			strSql.Append(" where WebSiteloginID in ("+WebSiteloginIDlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
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
		public WebSiteModel.WebSitelogin GetModel(int WebSiteloginID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select WebSiteloginID,WebSiteID,Background,BackloginURL,Username,UserPwd,Database,Controlpanel,Remark from WebSitelogin ");
			strSql.Append(" where WebSiteloginID=@WebSiteloginID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteloginID", DbType.Int32,4)
			};
			parameters[0].Value = WebSiteloginID;

			WebSiteModel.WebSitelogin model=new WebSiteModel.WebSitelogin();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public WebSiteModel.WebSitelogin DataRowToModel(DataRow row)
		{
			WebSiteModel.WebSitelogin model=new WebSiteModel.WebSitelogin();
			if (row != null)
			{
				if(row["WebSiteloginID"]!=null && row["WebSiteloginID"].ToString()!="")
				{
					model.WebSiteloginID=int.Parse(row["WebSiteloginID"].ToString());
				}
				if(row["WebSiteID"]!=null && row["WebSiteID"].ToString()!="")
				{
					model.WebSiteID=int.Parse(row["WebSiteID"].ToString());
				}
				if(row["Background"]!=null)
				{
					model.Background=row["Background"].ToString();
				}
				if(row["BackloginURL"]!=null)
				{
					model.BackloginURL=row["BackloginURL"].ToString();
				}
				if(row["Username"]!=null)
				{
					model.Username=row["Username"].ToString();
				}
				if(row["UserPwd"]!=null)
				{
					model.UserPwd=row["UserPwd"].ToString();
				}
				if(row["Database"]!=null)
				{
					model.Database=row["Database"].ToString();
				}
				if(row["Controlpanel"]!=null)
				{
					model.Controlpanel=row["Controlpanel"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select WebSiteloginID,WebSiteID,Background,BackloginURL,Username,UserPwd,Database,Controlpanel,Remark ");
			strSql.Append(" FROM WebSitelogin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM WebSitelogin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.WebSiteloginID desc");
			}
			strSql.Append(")AS Row, T.*  from WebSitelogin T ");
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
			parameters[0].Value = "WebSitelogin";
			parameters[1].Value = "WebSiteloginID";
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

