using System;
using System.Web;
using System.Web.Security;
using AMS.Biz;
using AMS.Common;
using AMS.Common.Biz;
using AMS.Model;

namespace AMS
{
    public partial class UserActivationByEmail : BasePage
    {
        private User _objAnUser;
        private readonly UserBiz _objUserBiz = new UserBiz();

        private UserDetail _objUserDtl;
        private string emailAsUserId, mobileNoAsUserId;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Public/Signin.aspx?ReturnUrl=%2f



            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["email"]))
                {
                    //_objUserDtl=new UserDetail();
                    //_objUserDtl.Email = Request.QueryString["email"];
                    bool isVerified = _objUserBiz.IsUserVerified(Request.QueryString["email"]);
                    if (!isVerified)
                    {
                        int result = _objUserBiz.ActiveUserByEmail(Request.QueryString["email"]);
                        if (result != 0)
                        {
                            ltrlConfirmation.Text =
                                "<span style=\"color:green; font-size:11pt; font-weight:bold \"> Welcome to AMS! Your account has been activated. </span>";
                        }
                    }
                    else
                    {
                        ltrlConfirmation.Text =
                                "<span style=\"color:green; font-size:11pt; font-weight:bold \">  Your are already an Active user. Thanks.. </span>";

                    }
                }
            }
        }


    }
}