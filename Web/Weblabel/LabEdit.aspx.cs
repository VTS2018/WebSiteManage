﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using NX.Common;

namespace Web.Weblabel
{
    public partial class LabEdit : ManagePage
    {
        protected string action;
        protected int id;
        protected string strUrlReferrer = "LabList.aspx?action=View";

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

        #region 绑定显示

        private void ShowInfo(int WebAttitudesID)
        {
            WebSiteData.WebAttitudes bll = new WebSiteData.WebAttitudes();
            WebSiteModel.WebAttitudes model = bll.GetModel(WebAttitudesID);

            this.lblWebAttitudesID.Text = model.WebAttitudesID.ToString();
            this.txtTitle.Text = model.Title;
            this.txtAddDate.Text = model.AddDate.ToString();
            this.txtRemark.Text = model.Remark;
            this.txtColor.Text = model.Color;
        }

        #endregion


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

            WebSiteModel.WebAttitudes model = new WebSiteModel.WebAttitudes();
            WebSiteData.WebAttitudes bll = new WebSiteData.WebAttitudes();

            string Title = this.txtTitle.Text;
            DateTime AddDate;
            if (Maticsoft.Common.PageValidate.IsDateTime(this.txtAddDate.Text))
            {
                AddDate = DateTime.Parse(this.txtAddDate.Text);
            }
            else
            {
                AddDate = DateTime.Now;
            }
            
            string Remark = this.txtRemark.Text;
            string Color = this.txtColor.Text;

            model.Title = Title;
            model.AddDate = AddDate;
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
            WebSiteData.WebAttitudes bll = new WebSiteData.WebAttitudes();
            WebSiteModel.WebAttitudes model = bll.GetModel(id);

            int WebAttitudesID = id;
            string Title = this.txtTitle.Text;

            DateTime AddDate;
            if (Maticsoft.Common.PageValidate.IsDateTime(this.txtAddDate.Text))
            {
                AddDate = DateTime.Parse(this.txtAddDate.Text);
            }
            else
            {
                AddDate = DateTime.Now;
            }

            string Remark = this.txtRemark.Text;
            string Color = this.txtColor.Text;

            model.WebAttitudesID = WebAttitudesID;
            model.Title = Title;
            model.AddDate = AddDate;
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