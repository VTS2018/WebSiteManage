using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using NX.Common;
namespace Web.WebStatus
{
    public partial class WebStatusList : ManagePage
    {
        protected string keywords = string.Empty;

        protected int totalCount;//总条数
        protected int page;      //第几页
        protected int pageSize;  //每页条数

        /// <summary>
        /// 用于分页时候的参数列表
        /// </summary>
        protected static string urlParamsPage = "keywords={0}&page={1}";

        /// <summary>
        /// URL参数列表
        /// </summary>
        protected static string urlParams = "keywords={0}";
        protected static string strPanxu = " WebStatusID desc  ";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");

            //每页数量
            this.pageSize = GetPageSize(14);

            if (!Page.IsPostBack)
            {
                //组合查询条件
                string strCondition = " WebStatusID>0 " + CombSqlTxt(this.keywords);
                RptBind(strCondition, strPanxu);
            }
        }


        #region 数据绑定=================================

        /// <summary>
        /// 组合查询的条件
        /// </summary>
        /// <param name="_strWhere">组合条件</param>
        /// <param name="_orderby"></param>
        private void RptBind(string _strWhere, string _orderby)
        {
            //得到第几页数据
            this.page = DTRequest.GetQueryInt("page", 1);

            //绑定关键字
            this.txtKeywords.Text = this.keywords;

            WebSiteData.WebStatus mdata = new WebSiteData.WebStatus();

            //参数分别是：每页条数  第几页  查询条件 排序条件 数据总数
            this.rptList.DataSource = mdata.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("WebStatusList.aspx", urlParamsPage, this.keywords, "__id__");

            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            litCount.Text = this.totalCount.ToString();
        }

        #endregion

        #region 组合SQL查询语句==========================

        /// <summary>
        /// 组合SQL条件查询语句
        /// </summary>
        /// <param name="_keywords">关键字</param>
        /// <returns></returns>
        protected string CombSqlTxt(string _keywords)
        {
            //定义组合条件
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");//踢出逗号
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Status like '%" + _keywords + "%'");//模糊查询
            }
            return strTemp.ToString();
        }

        #endregion

        #region 返回资讯每页数量=========================

        private int GetPageSize(int _default_size)
        {
            int _pagesize;

            if (int.TryParse(Utils.GetCookie("pageSize"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        #endregion

        #region 设置操作=================================

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("pageSize", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("WebStatusList.aspx", urlParams, txtKeywords.Text));
        }

        #endregion

        //搜搜番号
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("WebStatusList.aspx", urlParams, txtKeywords.Text));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool bl = true;//标记变量

            WebSiteData.WebStatus bll = new WebSiteData.WebStatus();
           
            //遍历提交过来的对象集合
            for (int i = 0; i < this.rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");

                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        //将捕获代码的程序 放置在最底层
                        bl = true;
                    }
                    else
                    {
                        //表示其中有一个选项没有删除成功
                        bl = false;
                        Response.Write("出错的ID为" + id.ToString());
                        break;
                    }
                }

            }

            if (bl)
            {
                JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("WebStatusList.aspx", urlParams, this.keywords), "Success");

            }
            else
            {
                JscriptMsg("批量删除操作中...有一个没有删除成功！", "back", "Error");
            }
        }
    }
}