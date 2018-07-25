using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NX.Common;
using System.Text;
using System.Data;
namespace Web.WebSite
{
    public partial class WebSiteList : ManagePage
    {
        //提问：page这个参数是如何传进来的呢？

        protected int id;
        protected int WebStatusID;
        protected int PartnerID;
        protected int BrandsID;
        protected string WebSiteType = string.Empty;

        protected string property = string.Empty; //所选属性
        protected string keywords = string.Empty; //关键字

        protected int totalCount;//总条数
        protected int page;      //第几页
        protected int pageSize;  //每页条数

        /// <summary>
        /// 用于分页时候的参数列表
        /// </summary>
        protected static string urlParamsPage = "id={0}&WebStatusID={1}&keywords={2}&property={3}&page={4}&PartnerID={5}&BrandsID={6}&WebSiteType={7}";

        /// <summary>
        /// URL参数列表
        /// </summary>
        protected static string urlParams = "id={0}&WebStatusID={1}&keywords={2}&property={3}&PartnerID={4}&BrandsID={5}&WebSiteType={6}";

        /// <summary>
        /// 全局排序条件
        /// </summary>
        protected static string strPaixu = " WebSiteID desc";

        protected void Page_Load(object sender, EventArgs e)
        {
            //问题关于这个地方参数0 "" " "是怎么处理的呢? 如果参数是几个的话
            this.id = DTRequest.GetQueryInt("id");

            this.WebStatusID = DTRequest.GetQueryInt("WebStatusID");
            this.PartnerID = DTRequest.GetQueryInt("PartnerID");
            this.BrandsID = DTRequest.GetQueryInt("BrandsID");
            //中文传参数问题
            this.WebSiteType = HttpContext.Current.Server.UrlDecode(DTRequest.GetString("WebSiteType"));

            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");

            //if (this.id == 0)
            //{
            //    JscriptMsg("网站参数不正确！", "back", "Error");
            //    return;
            //}
            //else
            //{

            //每页数量
            this.pageSize = GetPageSize(14);

            if (!Page.IsPostBack)
            {
                WebStatusBind(); PartnerBind(); BrandsBind(); WebSiteTypeBind();

                //组合查询条件
                string strCondition = " WebSiteID>0 " + CombSqlTxt(this.WebStatusID, this.PartnerID, this.BrandsID, this.keywords, this.property, this.WebSiteType);

                //System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
                //st.Start();
                RptBind(this.id, strCondition, strPaixu);
                //st.Stop();

                //Response.Write(st.ElapsedMilliseconds.ToString());
            }
            //}
        }

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

        #region 组合SQL查询语句==========================

        /// <summary>
        /// 组合SQL条件查询语句
        protected string CombSqlTxt(int WebStatusID, int PartnerID, int BrandsID, string _keywords, string _property, string _webSiteType)
        {
            //定义组合条件
            StringBuilder strTemp = new StringBuilder();

            if (WebStatusID > 0)
            {
                strTemp.Append(" and WebStatusID=" + WebStatusID);
            }

            if (PartnerID > 0)
            {
                strTemp.Append(" and PartnerID=" + PartnerID);
            }

            if (BrandsID > 0)
            {
                strTemp.Append(" and BrandsID=" + BrandsID);
            }
            if (!string.IsNullOrEmpty(_webSiteType))
            {
                strTemp.Append(" and WebSiteType like '%" + _webSiteType + "%'");
            }
            string[] arr = keywords.Replace("'", "").Split('|');

            if (arr.Length == 2)
            {
                _keywords = arr[1];
            }
            else
            {
                _keywords = keywords.Replace("'", "");
            }

            if (!string.IsNullOrEmpty(_keywords))
            {
                switch (arr[0])
                {
                    case "WebSiteName":
                        strTemp.Append(" and WebSiteName like '%" + _keywords + "%'");//模糊查询
                        break;
                    default:
                        strTemp.Append(" and WebSiteName like '%" + _keywords + "%'");//模糊查询
                        break;
                }
            }

            if (!string.IsNullOrEmpty(_property))
            {
                switch (_property)
                {
                    case "show":
                        strTemp.Append(" and Ishidden=0");//0:默认状态表示全部显示
                        break;
                    case "hidden":
                        strTemp.Append(" and Ishidden=1");//1:隐藏状态表示影藏该数据
                        break;
                }
            }
            return strTemp.ToString();
        }

        #endregion

        #region 数据绑定=================================

        /// <summary>
        /// 绑定状态
        /// </summary>
        private void WebStatusBind()
        {
            WebSiteData.WebStatus webStatus = new WebSiteData.WebStatus();
            //获得某一个站点所有的数据分类
            DataTable dt = webStatus.GetList("").Tables[0];

            this.ddlWebStatus.Items.Clear();
            this.ddlWebStatus.Items.Add(new ListItem("网站状态", ""));//默认值是0

            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["WebStatusID"].ToString();
                string Title = dr["Status"].ToString().Trim();
                this.ddlWebStatus.Items.Add(new ListItem(Title, Id));
            }
        }

        /// <summary>
        /// 绑定合作伙伴信息
        /// </summary>
        private void PartnerBind()
        {
            WebSiteData.Partner partner = new WebSiteData.Partner();

            //获得某一个站点所有的数据分类
            DataTable dt = partner.GetList("").Tables[0];

            this.ddlPartner.Items.Clear();
            this.ddlPartner.Items.Add(new ListItem("合作伙伴", ""));//默认值是0

            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["PartnerID"].ToString();
                string Title = dr["Partnername"].ToString().Trim();
                this.ddlPartner.Items.Add(new ListItem(Title, Id));
            }
        }

        /// <summary>
        /// 绑定品牌信息
        /// </summary>
        private void BrandsBind()
        {
            WebSiteData.Brands brands = new WebSiteData.Brands();

            //获得某一个站点所有的数据分类
            DataTable dt = brands.GetList("").Tables[0];

            this.ddBrands.Items.Clear();
            this.ddBrands.Items.Add(new ListItem("品牌信息", ""));//默认值是0

            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["BrandsID"].ToString();
                string Title = dr["BrandsName"].ToString().Trim();
                this.ddBrands.Items.Add(new ListItem(Title, Id));
            }
        }

        /// <summary>
        /// 绑定品牌信息
        /// </summary>
        private void WebSiteTypeBind()
        {
            this.ddlWebSiteType.Items.Clear();
            this.ddlWebSiteType.Items.Add(new ListItem("网站类型", ""));//默认值是0

            this.ddlWebSiteType.Items.Add(new ListItem("综合站", "综合站"));
            this.ddlWebSiteType.Items.Add(new ListItem("中转站", "中转站"));
            this.ddlWebSiteType.Items.Add(new ListItem("商品站", "商品站"));
            this.ddlWebSiteType.Items.Add(new ListItem("SEO", "SEO"));
        }

        /// <summary>
        /// 组合查询的条件
        /// </summary>
        /// <param name="_strWhere">组合条件</param>
        /// <param name="_orderby"></param>
        private void RptBind(int id, string _strWhere, string _orderby)
        {
            //得到第几页数据
            this.page = DTRequest.GetQueryInt("page", 1);

            if (this.WebStatusID > 0)
            {
                this.ddlWebStatus.SelectedValue = this.WebStatusID.ToString();
            }

            if (this.PartnerID > 0)
            {
                this.ddlPartner.SelectedValue = this.PartnerID.ToString();
            }

            if (this.BrandsID > 0)
            {
                this.ddBrands.SelectedValue = this.BrandsID.ToString();
            }

            this.ddlWebSiteType.SelectedValue = this.WebSiteType;

            //绑定多选的属性
            this.ddlProperty.SelectedValue = this.property;

            //绑定关键字
            this.txtKeywords.Text = this.keywords;

            WebSiteData.WebSite webSite = new WebSiteData.WebSite();

            //参数分别是：每页条数  第几页  查询条件 排序条件 数据总数
            this.rptList.DataSource = webSite.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();


            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();

            string pageUrl = Utils.CombUrlTxt("WebSiteList.aspx", urlParamsPage, this.id.ToString(), this.WebStatusID.ToString(), this.keywords, this.property, "__id__", this.PartnerID.ToString(), this.BrandsID.ToString(), this.WebSiteType);

            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            PageContent2.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

            litCount.Text = this.totalCount.ToString();
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //string str = "" + "|";
            Response.Redirect(Utils.CombUrlTxt("WebSiteList.aspx", urlParams, this.id.ToString(), this.WebStatusID.ToString(), this.txtKeywords.Text, this.property, this.PartnerID.ToString(), this.BrandsID.ToString(), this.WebSiteType));

        }

        protected void ddlWebStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("WebSiteList.aspx", urlParams, this.id.ToString(), ddlWebStatus.SelectedValue, this.keywords, this.property, this.PartnerID.ToString(), this.BrandsID.ToString(), this.WebSiteType));
        }

        protected void ddlPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("WebSiteList.aspx", urlParams, this.id.ToString(), this.WebStatusID.ToString(), this.keywords, this.property, ddlPartner.SelectedValue, this.BrandsID.ToString(), this.WebSiteType));

        }

        protected void ddlWebSiteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //"id={0}&WebStatusID={1}&keywords={2}&property={3}&PartnerID={4}&BrandsID={5}&WebSiteType={6}";
            string str = Utils.CombUrlTxt("WebSiteList.aspx", urlParams, this.id.ToString(), this.WebStatusID.ToString(), this.keywords, this.property, this.PartnerID.ToString(), this.BrandsID.ToString(), ddlWebSiteType.SelectedValue);
            Response.Redirect(str);
            Response.Write(ddlWebSiteType.SelectedValue + str);
        }

        protected void ddBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("WebSiteList.aspx", urlParams, this.id.ToString(), this.WebStatusID.ToString(), this.keywords, this.property, this.PartnerID.ToString(), ddBrands.SelectedValue, this.WebSiteType));
        }

        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("WebSiteList.aspx", urlParams, this.id.ToString(), this.WebStatusID.ToString(), this.keywords, ddlProperty.SelectedValue, this.PartnerID.ToString(), this.BrandsID.ToString(), this.WebSiteType));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool bl = true;//标记变量
            WebSiteData.WebSite bll = new WebSiteData.WebSite();

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
                JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("WebSiteList.aspx", urlParams, this.keywords), "Success");

            }
            else
            {
                JscriptMsg("批量删除操作中...有一个没有删除成功！", "back", "Error");
            }
        }

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

            Response.Redirect(Utils.CombUrlTxt("WebSiteList.aspx", urlParams, this.id.ToString(), this.WebStatusID.ToString(), this.keywords, this.property, this.PartnerID.ToString(), this.BrandsID.ToString(), this.WebSiteType));

        }

        protected void btnSaveSort_Click(object sender, EventArgs e)
        {
            WebSiteData.WebSite bll = new WebSiteData.WebSite();

            //在图文展示的情况下 rptList.Items.Count 数量为0 所以 不成功

            for (int i = 0; i < this.rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;

                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "SortIndex=" + sortId.ToString());
            }

            JscriptMsg("保存排序成功啦！", Utils.CombUrlTxt("WebSiteList.aspx", urlParams, txtKeywords.Text), "Success");

        }

        public string RetutnStatusHTML(int id)
        {
            string strR = string.Empty;
            WebSiteModel.WebStatus model = new WebSiteData.WebStatus().GetModel(id);

            if (model != null)
            {
                strR = "<span style=\"color: " + model.Color + "; font-weight: bold\">" + model.Status + "</span>";
            }
            else
            {
                strR = "<span style=\"color:#000; font-weight: bold\">未设置状态</span>";
            }

            return strR;
        }

        public string RetutnOwerHTML(int id)
        {
            string strR = string.Empty;
            switch (id)
            {
                case 0:
                    strR = "<span>公司</span>";
                    break;
                case 1:
                    strR = "<span>客户</span>";
                    break;
                default:
                    break;
            }
            return strR;
        }

        public string RetutnIseffectiveHTML(int id)
        {
            string strR = string.Empty;

            switch (id)
            {
                case 0:
                    strR = "<span>有效</span>";
                    break;
                case 1:
                    strR = "<span>无效</span>";
                    break;
                default:
                    break;
            }
            return strR;
        }

        protected void btnSetLab_Click(object sender, EventArgs e)
        {

        }
    }
}