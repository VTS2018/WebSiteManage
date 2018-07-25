using System;
namespace WebSiteModel
{
    /// <summary>
    /// WebSite:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebSite
    {
        public WebSite()
        { }
        #region Model
        private int _websiteid;
        private string _websitename;
        private int _webstatusid;
        private int _partnerid;
        private string _websitetype;
        private string _background;
        private int _brandsid;
        private string _template;
        private string _templatepic;
        private string _language;
        private int _owner;
        private string _server;
        private string _ipaddress;
        private string _payment;
        private int _iseffective = 0;//设置默认值：表示有效
        private string _programstype;
        private int _sortindex = 99;//设置默认值：99
        private int _ishidden = 0;//设置默认值 表示显示
        private DateTime _adddate;
        private DateTime _offlinedate;
        private string _remark;
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
        public string WebSiteName
        {
            set { _websitename = value; }
            get { return _websitename; }
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
        public string WebSiteType
        {
            set { _websitetype = value; }
            get { return _websitetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Background
        {
            set { _background = value; }
            get { return _background; }
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
        public string Template
        {
            set { _template = value; }
            get { return _template; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TemplatePic
        {
            set { _templatepic = value; }
            get { return _templatepic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Language
        {
            set { _language = value; }
            get { return _language; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Owner
        {
            set { _owner = value; }
            get { return _owner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Server
        {
            set { _server = value; }
            get { return _server; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IPAddress
        {
            set { _ipaddress = value; }
            get { return _ipaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Payment
        {
            set { _payment = value; }
            get { return _payment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Iseffective
        {
            set { _iseffective = value; }
            get { return _iseffective; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProgramsType
        {
            set { _programstype = value; }
            get { return _programstype; }
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
        public int Ishidden
        {
            set { _ishidden = value; }
            get { return _ishidden; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OfflineDate
        {
            set { _offlinedate = value; }
            get { return _offlinedate; }
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

