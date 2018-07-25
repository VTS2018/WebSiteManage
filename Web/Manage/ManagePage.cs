using System;
using System.Web;
namespace Web
{
    #region 枚举==============================================

    /// <summary>
    /// 统一管理操作枚举
    /// </summary>
    public enum ActionEnum
    {
        /// <summary>
        /// 所有
        /// </summary>
        All,
        /// <summary>
        /// 查看
        /// </summary>
        View,
        /// <summary>
        /// 添加
        /// </summary>
        Add,
        /// <summary>
        /// 修改
        /// </summary>
        Edit,
        /// <summary>
        /// 删除
        /// </summary>
        Delete
    }

    /// <summary>
    /// 属性类型枚举
    /// </summary>
    public enum AttributeEnum
    {
        /// <summary>
        /// 输入框
        /// </summary>
        Text,
        /// <summary>
        /// 下拉框
        /// </summary>
        Select,
        /// <summary>
        /// 单选框
        /// </summary>
        Radio,
        /// <summary>
        /// 复选框
        /// </summary>
        CheckBox
    }

    #endregion

    public class ManagePage : System.Web.UI.Page
    {
        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);
        }

        void ManagePage_Load(object sender, EventArgs e)
        {
            if (!IsLogin())
            {
                Response.Write("<script type='text/javascript'>var url=top.location.href.replace(/Default.aspx/, 'Login.aspx');top.location.href=url;</script>");
                //Response.Redirect("~/Login.aspx");
                //Response.Write("<script>alert(top.location.href);</script>");
                Response.End();
            }
        }
        private bool IsLogin()
        {
            bool bl = false;
            if (Session["admin"] != null)
            {
                bl = true;
            }
            return bl;
        }

        #region JS提示============================================

        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
            //string msbox = "jsAlert('123ok')";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }

        /// <summary>
        /// 带回传函数的添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        /// <param name="callback">JS回调函数</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss, string callback)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\", " + callback + ")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        #endregion
    }
}