using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using NX.Common;

namespace Web.Partner
{
    public partial class PartnerEdit : ManagePage
    {
        protected string action;
        protected int id;
        protected string strUrlReferrer = "PartnerList.aspx?action=View";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            this.action = DTRequest.GetQueryString("action");

            //只有在编辑状态时 才绑定数据
            if (!string.IsNullOrEmpty(this.action) && this.action == ActionEnum.Edit.ToString())
            {
                if (!IsPostBack)
                {
                    ShowInfo(id);
                }
            }
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

        #region 绑定显示

        private void ShowInfo(int PartnerID)
        {
            WebSiteData.Partner bll = new WebSiteData.Partner();
            WebSiteModel.Partner model = bll.GetModel(PartnerID);

            this.lblPartnerID.Text = model.PartnerID.ToString();
            this.txtPartnername.Text = model.Partnername;
            this.txtStarLevel.Text = model.StarLevel;
            this.txtStarICO.Text = model.StarICO;
            this.txtRemark.Value = model.Remark;
        }

        #endregion

        #region 添加修改

        private bool DoAdd()
        {
            bool result = true;

            string Partnername = this.txtPartnername.Text;
            string StarLevel = this.txtStarLevel.Text;
            string StarICO = this.txtStarICO.Text;
            string Remark = this.txtRemark.Value;


            WebSiteModel.Partner model = new WebSiteModel.Partner();

            model.Partnername = Partnername;
            model.StarLevel = StarLevel;
            model.StarICO = StarICO;
            model.Remark = Remark;


            WebSiteData.Partner bll = new WebSiteData.Partner();

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }

        private bool DoEdit(int id)
        {
            bool result = true;

            int PartnerID = id;

            string Partnername = this.txtPartnername.Text;
            string StarLevel = this.txtStarLevel.Text;
            string StarICO = this.txtStarICO.Text;
            string Remark = this.txtRemark.Value;


            WebSiteModel.Partner model = new WebSiteModel.Partner();

            model.PartnerID = PartnerID;
            model.Partnername = Partnername;
            model.StarLevel = StarLevel;
            model.StarICO = StarICO;
            model.Remark = Remark;

            WebSiteData.Partner bll = new WebSiteData.Partner();

            bll.Update(model);

            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }
        #endregion

        //批量添加合作伙伴
        protected void btnMutil_Click(object sender, EventArgs e)
        {
            string[] arr = this.txtPartnername.Text.Split('|');
           
            WebSiteData.Partner dal = new WebSiteData.Partner();
           
            int n = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                string Partnername = arr[i];
                string StarLevel = this.txtStarLevel.Text;
                string StarICO = this.txtStarICO.Text;
                string Remark = this.txtRemark.Value;


                WebSiteModel.Partner model = new WebSiteModel.Partner();

                model.Partnername = Partnername;
                model.StarLevel = StarLevel;
                model.StarICO = StarICO;
                model.Remark = Remark;

                n = dal.Add(model);

                if (n < 1)
                {
                    Response.Write("<span>添加失败了！</span>");
                    continue;
                }
                else
                {
                    Response.Write("<span>添加成功了！</span>");
                }
            }
        }
    }
}