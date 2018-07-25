using System;
namespace WebSiteModel
{
    /// <summary>
    /// WebAttitudes:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebAttitudes
    {
        public WebAttitudes()
        { }
        #region Model
        private int _webattitudesid;
        private string _title;
        private int _sortindex;
        private DateTime _adddate;
        private string _remark;
        private string _color = "#000000";
        /// <summary>
        /// 
        /// </summary>
        public int WebAttitudesID
        {
            set { _webattitudesid = value; }
            get { return _webattitudesid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
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
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
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

