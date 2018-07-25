using System;
namespace WebSiteModel
{
    /// <summary>
    /// Domain:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Domain
    {
        public Domain()
        { }
        #region Model
        private int _domainid;
        private int _websiteid;
        private DateTime _registdate;
        private DateTime _expiredate;
        private string _regaccount;
        private string _dnsprovider;
        private string _dns;
        private string _dnsaccount;
        private string _ipaddress;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int DomainID
        {
            set { _domainid = value; }
            get { return _domainid; }
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
        public DateTime RegistDate
        {
            set { _registdate = value; }
            get { return _registdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpireDate
        {
            set { _expiredate = value; }
            get { return _expiredate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegAccount
        {
            set { _regaccount = value; }
            get { return _regaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DNSprovider
        {
            set { _dnsprovider = value; }
            get { return _dnsprovider; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DNS
        {
            set { _dns = value; }
            get { return _dns; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DNSAccount
        {
            set { _dnsaccount = value; }
            get { return _dnsaccount; }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
    }
}

