using System;
namespace WebSiteModel
{
    /// <summary>
    /// WebSitelogin:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebSitelogin
    {
        public WebSitelogin()
        { }
        #region Model
        private int _websiteloginid;
        private int _websiteid;
        private string _background;
        private string _backloginurl;
        private string _username;
        private string _userpwd;
        private string _database;
        private string _controlpanel;
        private string _remark;
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
        public int WebSiteID
        {
            set { _websiteid = value; }
            get { return _websiteid; }
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
        public string BackloginURL
        {
            set { _backloginurl = value; }
            get { return _backloginurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Database
        {
            set { _database = value; }
            get { return _database; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Controlpanel
        {
            set { _controlpanel = value; }
            get { return _controlpanel; }
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

