using System;
using System.Web;
using System.Web.Security;
using AMS.Biz;
using AMS.Common;
using AMS.Common.Biz;
using AMS.Model;

namespace AMS
{
    public partial class Signin : BasePage
    {
        private User _objAnUser;
        private readonly UserBiz _objUserBiz = new UserBiz();

        private UserDetail _objUserDtl;
        private string emailAsUserId, mobileNoAsUserId;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Public/Signin.aspx?ReturnUrl=%2f
            var url = HttpContext.Current.Request.Url.AbsoluteUri;


            if (HttpContext.Current.Request.Url.AbsolutePath == "~/Signin.aspx?ReturnUrl=%2f")
            {
                Response.Redirect("~/Signin.aspx");
            }
            if (!IsPostBack)
            {
                panelLoginErrorMessage.Visible = false;
            }
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            //  Page.Validate();
            try
            {
                if (Page.IsValid)
                {
                    _objUserDtl = GetLoginDetail();
                    if (_objUserDtl == null || _objUserDtl.RoleTypeID.ToString() == string.Empty)
                    {
                        panelLoginErrorMessage.Visible = true;
                         
                        return;
                    }
                    else
                    {
                          SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS = _objUserDtl;
                    FormsAuthentication.RedirectFromLoginPage(txtUserId.Text.Trim(), chkRememberMe.Checked);
                        panelLoginErrorMessage.Visible = false;
                    }
                  
                }
                else
                {
                    MessageBox("Validation Error!");
                }
            }
            catch (Exception ex)
            {
                MessageBox(ex.Message);
            }
        }

        private void GetUserIdFromEmailOrMobileNo()
        {
            var userId = txtUserId.Text.Trim();
            bool isEmail, isNumber;

            isEmail = CommonBiz.IsValidEmail(userId);
            isNumber = CommonBiz.IsNumeric(userId);
            if (isEmail)

            {
                emailAsUserId = userId;
            }


            if (isNumber)
            {
                mobileNoAsUserId = userId;
            }
        }

        private UserDetail GetLoginDetail()
        {
            _objAnUser = new User();
            try
            {
                GetUserIdFromEmailOrMobileNo();
                _objAnUser.Email = emailAsUserId;
                _objAnUser.MobileNo = mobileNoAsUserId;
                _objAnUser.Password = CommonBiz.GetSwcSH1(txtPassword.Text.Trim());

                return _objUserDtl = _objUserBiz.GetUserBasicInfo(_objAnUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}