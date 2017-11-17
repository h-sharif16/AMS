using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AMS.Biz;
using AMS.Common;
using AMS.Common.Biz;
using AMS.Model;
using AMS.Notification.Biz;
using AMS.Notification.Model;

namespace AMS
{
    public partial class PasswordRetriveLink :  BasePage
    {
        private User _objAnUser;
        private readonly UserBiz _objUserBiz = new UserBiz();

        private NotificationMessages _objMessages;
        private NotificationBiz _objNotificationBiz;
        private UserDetail _objUserDtl;



        private string emailAsUserId, mobileNoAsUserId;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Public/Signin.aspx?ReturnUrl=%2f

            if (!IsPostBack)
            {
                panelLoginErrorMessage.Visible = false;
                panelEmailSmsSuccessNotification.Visible = false;
            }
        }

        protected void btnRetiriveLoginInfo_Click(object sender, EventArgs e)
        {
            //  Page.Validate();
            try
            {

                _objUserDtl = GetLoginDetail();
                if (_objUserDtl == null || _objUserDtl.RoleTypeID.ToString() == string.Empty)
                {
                    panelLoginErrorMessage.Visible = true;

                    return;
                }
                else
                {
                    _objMessages = new NotificationMessages();
                    _objMessages.ClassificationID = 1;
                    _objMessages.NotificationTypeID = 1;
                    string path = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/" + "ResetPassword.aspx?email=" + _objUserDtl.Email;//Request.Url.GetLeftPart(UriPartial.Authority);
                    _objNotificationBiz = new NotificationBiz();

                    string body = "Hello " + _objUserDtl.FirstName + ",";
                    body += "<br /><br />Please goto the following link to reset your password.";
                    body += "<br /> <a href='" + path + "' >Click here to reset your password. </a> <br /><br />If you have any problems or concerns, please contact customer support.</br></br>Thanks";

                    _objNotificationBiz.SendEmail(_objMessages, _objUserDtl.Email, body);
                    HtmlMeta meta = new HtmlMeta();
                    meta.HttpEquiv = "Refresh";
                    meta.Content = "4;url=Signin.aspx";
                    this.Page.Controls.Add(meta);

                    panelLoginErrorMessage.Visible = false;
                    panelEmailSmsSuccessNotification.Visible = true;
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
                //                _objAnUser.Password = CommonBiz.GetSwcSH1(txtPassword.Text.Trim());

                return _objUserDtl = _objUserBiz.uspGetUserBasicInfoByEmailOrMobileNo(_objAnUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
