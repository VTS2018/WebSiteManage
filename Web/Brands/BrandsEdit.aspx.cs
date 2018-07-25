using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NX.Common;
namespace Web.Brands
{
    public partial class BrandsEdit : ManagePage
    {
        protected string action;
        protected int id;
        protected string strUrlReferrer = "BrandsList.aspx?action=View";

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

        private void ShowInfo(int BrandsID)
        {
            WebSiteData.Brands bll = new WebSiteData.Brands();
            WebSiteModel.Brands model = bll.GetModel(BrandsID);

            this.lblBrandsID.Text = model.BrandsID.ToString();
            this.txtBrandsName.Text = model.BrandsName;
            this.txtSortIndex.Text = model.SortIndex.ToString();
            this.txtRemark.Value = model.Remark;

        }
        #endregion

        #region 添加修改

        private bool DoAdd()
        {
            bool result = true;

            string BrandsName = this.txtBrandsName.Text;
            int SortIndex = int.Parse(this.txtSortIndex.Text);
            string Remark = this.txtRemark.Value;

            WebSiteModel.Brands model = new WebSiteModel.Brands();

            model.BrandsName = BrandsName;
            model.SortIndex = SortIndex;
            model.Remark = Remark;

            WebSiteData.Brands bll = new WebSiteData.Brands();

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }

        private bool DoEdit(int id)
        {
            bool result = true;

            int BrandsID = id;
            string BrandsName = this.txtBrandsName.Text;
            int SortIndex = int.Parse(this.txtSortIndex.Text);
            string Remark = this.txtRemark.Value;


            WebSiteModel.Brands model = new WebSiteModel.Brands();

            model.BrandsID = BrandsID;
            model.BrandsName = BrandsName;
            model.SortIndex = SortIndex;
            model.Remark = Remark;

            WebSiteData.Brands bll = new WebSiteData.Brands();

            if (!bll.Update(model))
            {
                result = false;
            }

            return result;
        }
        #endregion

        protected void btnMutil_Click(object sender, EventArgs e)
        {
            string[] arr = this.txtBrandsName.Text.Split('|');
            WebSiteData.Brands dal = new WebSiteData.Brands();

            int n = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                string BrandsName = arr[i];
                int SortIndex = int.Parse(this.txtSortIndex.Text);
                string Remark = this.txtRemark.Value;

                WebSiteModel.Brands model = new WebSiteModel.Brands();

                model.BrandsName = BrandsName;
                model.SortIndex = SortIndex;
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