using System;
namespace WebSiteModel
{
	/// <summary>
	/// Partner:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Partner
	{
		public Partner()
		{}
		#region Model
		private int _partnerid;
		private string _partnername;
		private string _starlevel;
		private string _starico;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int PartnerID
		{
			set{ _partnerid=value;}
			get{return _partnerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Partnername
		{
			set{ _partnername=value;}
			get{return _partnername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StarLevel
		{
			set{ _starlevel=value;}
			get{return _starlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StarICO
		{
			set{ _starico=value;}
			get{return _starico;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

