using System;
namespace WebSiteModel
{
    /// <summary>
    /// Relation:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Relation
    {
        public Relation()
        { }
        #region Model
        private int _id;
        private int _websiteid;
        private int _webstatusid;
        private int _partnerid;
        private int _websiteloginid;
        private int _brandsid;
        private int _domainid;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int WebSiteID
        {
            set { _websiteid = value; }
            get { return _websiteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int WebStatusID
        {
            set { _webstatusid = value; }
            get { return _webstatusid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PartnerID
        {
            set { _partnerid = value; }
            get { return _partnerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int WebSiteloginID
        {
            set { _websiteloginid = value; }
            get { return _websiteloginid; }
        }
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
        public int DomainID
        {
            set { _domainid = value; }
            get { return _domainid; }
        }
        #endregion Model

    }
}

