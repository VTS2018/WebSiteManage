using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace WebSiteData
{
	/// <summary>
	/// 数据访问类:WebToAttribute
	/// </summary>
	public partial class WebToAttribute
	{
		public WebToAttribute()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ID", "WebToAttribute"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WebToAttribute");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(WebSiteModel.WebToAttribute model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WebToAttribute(");
			strSql.Append("WebSiteID,WebAttitudesID,Title,Content,Addtime,Remark)");
			strSql.Append(" values (");
			strSql.Append("@WebSiteID,@WebAttitudesID,@Title,@Content,@Addtime,@Remark)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,8),
					new SQLiteParameter("@WebAttitudesID", DbType.Int32,8),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@Content", DbType.String),
					new SQLiteParameter("@Addtime", DbType.DateTime),
					new SQLiteParameter("@Remark", DbType.String)};
			parameters[0].Value = model.WebSiteID;
			parameters[1].Value = model.WebAttitudesID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.Addtime;
			parameters[5].Value = model.Remark;

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
		public bool Update(WebSiteModel.WebToAttribute model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WebToAttribute set ");
			strSql.Append("WebSiteID=@WebSiteID,");
			strSql.Append("WebAttitudesID=@WebAttitudesID,");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("Addtime=@Addtime,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,8),
					new SQLiteParameter("@WebAttitudesID", DbType.Int32,8),
					new SQLiteParameter("@Title", DbType.String),
					new SQLiteParameter("@Content", DbType.String),
					new SQLiteParameter("@Addtime", DbType.DateTime),
					new SQLiteParameter("@Remark", DbType.String),
					new SQLiteParameter("@ID", DbType.Int32,8)};
			parameters[0].Value = model.WebSiteID;
			parameters[1].Value = model.WebAttitudesID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.Addtime;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WebToAttribute ");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WebToAttribute ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public WebSiteModel.WebToAttribute GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,WebSiteID,WebAttitudesID,Title,Content,Addtime,Remark from WebToAttribute ");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)
			};
			parameters[0].Value = ID;

			WebSiteModel.WebToAttribute model=new WebSiteModel.WebToAttribute();
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
		public WebSiteModel.WebToAttribute DataRowToModel(DataRow row)
		{
			WebSiteModel.WebToAttribute model=new WebSiteModel.WebToAttribute();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["WebSiteID"]!=null && row["WebSiteID"].ToString()!="")
				{
					model.WebSiteID=int.Parse(row["WebSiteID"].ToString());
				}
				if(row["WebAttitudesID"]!=null && row["WebAttitudesID"].ToString()!="")
				{
					model.WebAttitudesID=int.Parse(row["WebAttitudesID"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["Addtime"]!=null && row["Addtime"].ToString()!="")
				{
					model.Addtime=DateTime.Parse(row["Addtime"].ToString());
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
			strSql.Append("select ID,WebSiteID,WebAttitudesID,Title,Content,Addtime,Remark ");
			strSql.Append(" FROM WebToAttribute ");
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
			strSql.Append("select count(1) FROM WebToAttribute ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from WebToAttribute T ");
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
			parameters[0].Value = "WebToAttribute";
			parameters[1].Value = "ID";
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

