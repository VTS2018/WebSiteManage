using System;
namespace WebSiteModel
{
    /// <summary>
    /// WebStatus:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebStatus
    {
        public WebStatus()
        { }
        #region Model
        private int _webstatusid;
        private string _status;
        private string _remark;
        private string _color = "#000000";
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
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Color
        {
            set { _color = value; }
            get { return _color; }
        }
        #endregion Model

    }
}

