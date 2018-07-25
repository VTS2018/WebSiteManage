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
    public partial class WebStatusEdit :ManagePage
    {
        protected string action;
        protected int id;
        protected string strUrlReferrer = "WebStatusList.aspx?action=View";

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
       
        private void ShowInfo(int WebStatusID)
        {
            WebSiteData.WebStatus bll = new WebSiteData.WebStatus();
            WebSiteModel.WebStatus model = bll.GetModel(WebStatusID);

            this.lblWebStatusID.Text = model.WebStatusID.ToString();
            this.txtStatus.Text = model.Status;
            this.txtRemark.Value = model.Remark;
            this.txtColor.Text = model.Color;
        }
        #endregion

        #region 添加修改

        private bool DoAdd()
        {
            bool result = true;

            WebSiteData.WebStatus bll = new WebSiteData.WebStatus();
            WebSiteModel.WebStatus model = new WebSiteModel.WebStatus();

            string Status = this.txtStatus.Text;
            string Remark = this.txtRemark.Value;
            string Color = this.txtColor.Text;

            model.Status = Status;
            model.Remark = Remark;
            model.Color = Color;

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }

        private bool DoEdit(int id)
        {
            bool result = true;
            WebSiteData.WebStatus bll = new WebSiteData.WebStatus();
            WebSiteModel.WebStatus model = bll.GetModel(id);

            int WebStatusID = id;
            string Status = this.txtStatus.Text;
            string Remark = this.txtRemark.Value;
            string Color = this.txtColor.Text;

            model.WebStatusID = WebStatusID;
            model.Status = Status;
            model.Remark = Remark;
            model.Color = Color;

            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }
        #endregion
    }
}