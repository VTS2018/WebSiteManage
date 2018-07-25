using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NX.Common;

namespace Web.WebSite
{
    public partial class WebSiteEdit : ManagePage
    {
        protected string action;
        protected int id;
        protected string strUrlReferrer = "WebSiteList.aspx?action=View";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            this.action = DTRequest.GetQueryString("action");

            //只有在编辑状态时 才绑定数据
            if (!string.IsNullOrEmpty(this.action))
            {
                if (!IsPostBack)
                {
                    WebStatusBind(); PartnerBind(); BrandsBind(); WebSiteTypeBind();
                    if (this.action == ActionEnum.Edit.ToString())
                    {
                        ShowInfo(id);
                    }
                }
            }
        }

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

            this.ddlWebSiteType.Items.Add(new ListItem("综合站", "综合站"));//默认值是0
            this.ddlWebSiteType.Items.Add(new ListItem("中转站", "中转站"));//默认值是0
            this.ddlWebSiteType.Items.Add(new ListItem("商品站", "商品站"));//默认值是0
            this.ddlWebSiteType.Items.Add(new ListItem("SEO", "SEO"));      //默认值是0
        }

        private void ShowInfo(int WebSiteID)
        {
            WebSiteData.WebSite bll = new WebSiteData.WebSite();
            WebSiteModel.WebSite model = bll.GetModel(WebSiteID);

            this.lblWebSiteID.Text = model.WebSiteID.ToString();
            this.txtWebSiteName.Text = model.WebSiteName;

            ddlWebStatus.SelectedValue = model.WebStatusID.ToString();
            ddlPartner.SelectedValue = model.PartnerID.ToString();
            ddlWebSiteType.SelectedValue = model.WebSiteType;

            this.txtBackground.Text = model.Background;

            ddBrands.SelectedValue = model.BrandsID.ToString();

            this.txtTemplate.Text = model.Template;
            this.txtTemplatePic.Text = model.TemplatePic;
            this.txtLanguage.Text = model.Language;

            //设置radio的值
            this.txtOwner.SelectedValue = model.Owner.ToString();

            this.txtServer.Text = model.Server;
            this.txtIPAddress.Text = model.IPAddress;
            this.txtPayment.Value = model.Payment;
            //this.txtIseffective.Text = model.Iseffective.ToString();
            this.txtProgramsType.Text = model.ProgramsType;
            //this.txtSortIndex.Text = model.SortIndex.ToString();
            //this.txtIshidden.Text = model.Ishidden.ToString();
            this.txtAddDate.Text = model.AddDate.ToString();
            this.txtOfflineDate.Text = model.OfflineDate.ToString();
            this.txtRemark.Value = model.Remark;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.action == "Edit")
            {
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改成功啦！", this.strUrlReferrer, "Success");
            }
            else
            {
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加成功啦！", this.strUrlReferrer, "Success");
            }
        }

        #region 添加修改

        private bool DoAdd()
        {
            bool result = true;

            WebSiteModel.WebSite model = new WebSiteModel.WebSite();
            WebSiteData.WebSite bll = new WebSiteData.WebSite();

            string WebSiteName = this.txtWebSiteName.Text;
            int WebStatusID = int.Parse(ddlWebStatus.SelectedValue);
            int PartnerID = int.Parse(ddlPartner.SelectedValue);
            string WebSiteType = ddlWebSiteType.SelectedValue;
            string Background = this.txtBackground.Text;
            int BrandsID = int.Parse(ddBrands.SelectedValue);

            string Template = this.txtTemplate.Text;
            string TemplatePic = this.txtTemplatePic.Text;
            string Language = this.txtLanguage.Text;

            int Owner = 0;
            if (this.txtOwner.SelectedValue == "1")
            {
                Owner = 1;
            }

            string Server = this.txtServer.Text;
            string IPAddress = this.txtIPAddress.Text;
            string Payment = this.txtPayment.Value;

            //int Iseffective = int.Parse(this.txtIseffective.Text);
            string ProgramsType = this.txtProgramsType.Text;

            //int SortIndex = int.Parse(this.txtSortIndex.Text);
            //int Ishidden = int.Parse(this.txtIshidden.Text);

            DateTime AddDate;
            if (Maticsoft.Common.PageValidate.IsDateTime(this.txtAddDate.Text))
            {
                AddDate = DateTime.Parse(this.txtAddDate.Text);
            }
            else
            {
                AddDate = DateTime.Now;
            }

            DateTime OfflineDate;
            if (Maticsoft.Common.PageValidate.IsDateTime(this.txtOfflineDate.Text))
            {
                OfflineDate = DateTime.Parse(this.txtOfflineDate.Text);
            }
            else
            {
                OfflineDate = DateTime.Now;
            }

            string Remark = this.txtRemark.Value;
            
            model.WebSiteName = WebSiteName;
            model.WebStatusID = WebStatusID;
            model.PartnerID = PartnerID;
            model.WebSiteType = WebSiteType;
            model.Background = Background;
            model.BrandsID = BrandsID;
            model.Template = Template;
            model.TemplatePic = TemplatePic;
            model.Language = Language;
            model.Owner = Owner;
            model.Server = Server;
            model.IPAddress = IPAddress;
            model.Payment = Payment;

            //model.Iseffective = Iseffective;
            model.ProgramsType = ProgramsType;

            //model.SortIndex = SortIndex;
            //model.Ishidden = Ishidden;

            model.AddDate = AddDate;
            model.OfflineDate = OfflineDate;
            model.Remark = Remark;

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }
        private bool DoEdit(int id)
        {
            bool result = true;

            WebSiteData.WebSite bll = new WebSiteData.WebSite();
            
            //先获取在修改，这样就会覆盖掉model本身的默认字段值，因为有些字段值在编辑页面没有显示
            WebSiteModel.WebSite model = bll.GetModel(id);

            int WebSiteID = id;

            string WebSiteName = this.txtWebSiteName.Text;
            int WebStatusID = int.Parse(ddlWebStatus.SelectedValue);
            int PartnerID = int.Parse(ddlPartner.SelectedValue);
            string WebSiteType = ddlWebSiteType.SelectedValue;
            string Background = this.txtBackground.Text;
            int BrandsID = int.Parse(ddBrands.SelectedValue);

            string Template = this.txtTemplate.Text;
            string TemplatePic = this.txtTemplatePic.Text;
            string Language = this.txtLanguage.Text;


            int Owner = 0;
            if (this.txtOwner.SelectedValue == "1")
            {
                Owner = 1;
            }

            string Server = this.txtServer.Text;
            string IPAddress = this.txtIPAddress.Text;
            string Payment = this.txtPayment.Value;
            //int Iseffective = int.Parse(this.txtIseffective.Text);
            string ProgramsType = this.txtProgramsType.Text;
            //int SortIndex = int.Parse(this.txtSortIndex.Text);
            //int Ishidden = int.Parse(this.txtIshidden.Text);

            DateTime AddDate;
            if (Maticsoft.Common.PageValidate.IsDateTime(this.txtAddDate.Text))
            {
                AddDate = DateTime.Parse(this.txtAddDate.Text);
            }
            else
            {
                AddDate = DateTime.Now;
            }

            DateTime OfflineDate;
            if (Maticsoft.Common.PageValidate.IsDateTime(this.txtOfflineDate.Text))
            {
                OfflineDate = DateTime.Parse(this.txtOfflineDate.Text);
            }
            else
            {
                OfflineDate = DateTime.Now;
            }


            string Remark = this.txtRemark.Value;

            model.WebSiteID = WebSiteID;
            model.WebSiteName = WebSiteName;
            model.WebStatusID = WebStatusID;
            model.PartnerID = PartnerID;
            model.WebSiteType = WebSiteType;
            model.Background = Background;
            model.BrandsID = BrandsID;
            model.Template = Template;
            model.TemplatePic = TemplatePic;
            model.Language = Language;
            model.Owner = Owner;
            model.Server = Server;
            model.IPAddress = IPAddress;
            model.Payment = Payment;
            //model.Iseffective = Iseffective;
            model.ProgramsType = ProgramsType;
            //model.SortIndex = SortIndex;
            //model.Ishidden = Ishidden;
            model.AddDate = AddDate;
            model.OfflineDate = OfflineDate;
            model.Remark = Remark;

            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }

        #endregion

        #region MyRegion
        //protected void btnExcel_Click(object sender, EventArgs e)
        //{
        //    string strPath = "F:\\a.xlsx";
        //    System.Data.OleDb.OleDbDataReader reader = WebSiteCommon.Common.ExcelToDataReader(strPath, "Sheet1", WebSiteCommon.ExcelVersions.Excel12);


        //    WebSiteData.WebSite bll = new WebSiteData.WebSite();
        //    int n = 0;
        //    while (reader.Read())
        //    {
        //        WebSiteModel.WebSite model = new WebSiteModel.WebSite();

        //        string WebSiteName = reader["域名"].ToString();
        //        int WebStatusID = int.Parse(reader["状态"].ToString());
        //        int PartnerID = int.Parse(reader["合作方"].ToString());
        //        string WebSiteType = reader["网站类型"].ToString();
        //        string Background = reader["所属后台"].ToString();
        //        int BrandsID = int.Parse(reader["产品类型"].ToString());
        //        string Template = reader["模板类型"].ToString();
        //        string TemplatePic = " ";
        //        string Language = reader["网站语系"].ToString();
        //        int Owner = int.Parse(reader["网站所属"].ToString());//0：公司；1客户
        //        string Server = reader["服务器"].ToString();
        //        string IPAddress = reader["IP"].ToString();
        //        string Payment = reader["付款方式"].ToString();
        //        int Iseffective = 0;//0：有效；1无效

        //        string ProgramsType = this.txtProgramsType.Text;
        //        int SortIndex = 99;
        //        int Ishidden = 0;//0：显示；1隐藏

        //        string str = reader["日期"].ToString() == string.Empty ? "2000/1/1" : reader["日期"].ToString();

        //        DateTime AddDate = DateTime.Parse(str);
        //        DateTime OfflineDate = DateTime.Parse("2000/1/1");
        //        string Remark = reader["备注"].ToString();

        //        model.WebSiteName = WebSiteName;
        //        model.WebStatusID = WebStatusID;
        //        model.PartnerID = PartnerID;
        //        model.WebSiteType = WebSiteType;
        //        model.Background = Background;
        //        model.BrandsID = BrandsID;
        //        model.Template = Template;
        //        model.TemplatePic = TemplatePic;
        //        model.Language = Language;
        //        model.Owner = Owner;
        //        model.Server = Server;
        //        model.IPAddress = IPAddress;
        //        model.Payment = Payment;
        //        model.Iseffective = Iseffective;
        //        model.ProgramsType = ProgramsType;
        //        model.SortIndex = SortIndex;
        //        model.Ishidden = Ishidden;
        //        model.AddDate = AddDate;
        //        model.OfflineDate = OfflineDate;
        //        model.Remark = Remark;

        //        n = bll.Add(model);
        //        if (n < 1)
        //        {
        //            Response.Write("失败");
        //            continue;

        //        }
        //        else
        //        {
        //            Response.Write("成功");
        //        }
        //    }

        //} 
        #endregion

    }
}