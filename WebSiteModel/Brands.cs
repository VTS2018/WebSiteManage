using System;
namespace WebSiteModel
{
    /// <summary>
    /// Brands:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Brands
    {
        public Brands()
        { }
        #region Model
        private int _brandsid;
        private string _brandsname;
        private int _sortindex;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int BrandsID
        {
            set { _brandsid = value; }
            get { return _brandsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BrandsName
        {
            set { _brandsname = value; }
            get { return _brandsname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SortIndex
        {
            set { _sortindex = value; }
            get { return _sortindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

