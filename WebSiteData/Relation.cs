using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace WebSiteData
{
	/// <summary>
	/// 数据访问类:Relation
	/// </summary>
	public partial class Relation
	{
		public Relation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ID", "Relation"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Relation");
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
		public int Add(WebSiteModel.Relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Relation(");
			strSql.Append("WebSiteID,WebStatusID,PartnerID,WebSiteloginID,BrandsID,DomainID)");
			strSql.Append(" values (");
			strSql.Append("@WebSiteID,@WebStatusID,@PartnerID,@WebSiteloginID,@BrandsID,@DomainID)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,8),
					new SQLiteParameter("@WebStatusID", DbType.Int32,8),
					new SQLiteParameter("@PartnerID", DbType.Int32,8),
					new SQLiteParameter("@WebSiteloginID", DbType.Int32,8),
					new SQLiteParameter("@BrandsID", DbType.Int32,8),
					new SQLiteParameter("@DomainID", DbType.Int32,8)};
			parameters[0].Value = model.WebSiteID;
			parameters[1].Value = model.WebStatusID;
			parameters[2].Value = model.PartnerID;
			parameters[3].Value = model.WebSiteloginID;
			parameters[4].Value = model.BrandsID;
			parameters[5].Value = model.DomainID;

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
		public bool Update(WebSiteModel.Relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Relation set ");
			strSql.Append("WebSiteID=@WebSiteID,");
			strSql.Append("WebStatusID=@WebStatusID,");
			strSql.Append("PartnerID=@PartnerID,");
			strSql.Append("WebSiteloginID=@WebSiteloginID,");
			strSql.Append("BrandsID=@BrandsID,");
			strSql.Append("DomainID=@DomainID");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@WebSiteID", DbType.Int32,8),
					new SQLiteParameter("@WebStatusID", DbType.Int32,8),
					new SQLiteParameter("@PartnerID", DbType.Int32,8),
					new SQLiteParameter("@WebSiteloginID", DbType.Int32,8),
					new SQLiteParameter("@BrandsID", DbType.Int32,8),
					new SQLiteParameter("@DomainID", DbType.Int32,8),
					new SQLiteParameter("@ID", DbType.Int32,8)};
			parameters[0].Value = model.WebSiteID;
			parameters[1].Value = model.WebStatusID;
			parameters[2].Value = model.PartnerID;
			parameters[3].Value = model.WebSiteloginID;
			parameters[4].Value = model.BrandsID;
			parameters[5].Value = model.DomainID;
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
			strSql.Append("delete from Relation ");
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
			strSql.Append("delete from Relation ");
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
		public WebSiteModel.Relation GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,WebSiteID,WebStatusID,PartnerID,WebSiteloginID,BrandsID,DomainID from Relation ");
			strSql.Append(" where ID=@ID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ID", DbType.Int32,4)
			};
			parameters[0].Value = ID;

			WebSiteModel.Relation model=new WebSiteModel.Relation();
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
		public WebSiteModel.Relation DataRowToModel(DataRow row)
		{
			WebSiteModel.Relation model=new WebSiteModel.Relation();
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
				if(row["WebStatusID"]!=null && row["WebStatusID"].ToString()!="")
				{
					model.WebStatusID=int.Parse(row["WebStatusID"].ToString());
				}
				if(row["PartnerID"]!=null && row["PartnerID"].ToString()!="")
				{
					model.PartnerID=int.Parse(row["PartnerID"].ToString());
				}
				if(row["WebSiteloginID"]!=null && row["WebSiteloginID"].ToString()!="")
				{
					model.WebSiteloginID=int.Parse(row["WebSiteloginID"].ToString());
				}
				if(row["BrandsID"]!=null && row["BrandsID"].ToString()!="")
				{
					model.BrandsID=int.Parse(row["BrandsID"].ToString());
				}
				if(row["DomainID"]!=null && row["DomainID"].ToString()!="")
				{
					model.DomainID=int.Parse(row["DomainID"].ToString());
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
			strSql.Append("select ID,WebSiteID,WebStatusID,PartnerID,WebSiteloginID,BrandsID,DomainID ");
			strSql.Append(" FROM Relation ");
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
			strSql.Append("select count(1) FROM Relation ");
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
			strSql.Append(")AS Row, T.*  from Relation T ");
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
			parameters[0].Value = "Relation";
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

