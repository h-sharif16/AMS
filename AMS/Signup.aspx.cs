using System;
using System.Web;
using System.Web.UI.WebControls;
using AMS.Biz;
using AMS.Common;
using AMS.Common.Biz;
using AMS.Model;
using AMS.Notification.Biz;
using AMS.Notification.Model;

namespace AMS
{
    public partial class Signup : BasePage
    {
        private NotificationMessages _objMessages;
        private NotificationBiz _objNotificationBiz;

        private UserDetail _objUser;
        private readonly UserBiz _objUserBiz = new UserBiz();
        private string succesMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelEmailSmsNotification.Visible = false;
                // createToken();    //to check page is refreshed
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            //  Page.Validate();
            if (Page.IsValid)
            {
                if (SendRequestToSave() == 1)
                {
                    ClearControls(this);
                    panelEmailSmsNotification.Visible = true;
                    ltrlEmailSmsNotification.Text =
                        "<span style=\"color: green; font - size: 10pt \">To active your account an activation link has been send to your Email</span>";

                    //Response.Redirect("Signin.aspx");
                }
            }
            else
            {
                MessageBox("Validation Error!");
            }
        }

        private int SendRequestToSave()
        {
            try
            {
                _objUser = new UserDetail();

                int result=0;
                _objUser.Email = txtEmail.Text.Trim();
                _objUser.MobileNo = txtMobileNo.Text.Trim();
                _objUser.FirstName = txtFirstName.Text.Trim();
                _objUser.LastName = txtLastName.Text.Trim();
                _objUser.Password = CommonBiz.GetSwcSH1(txtPassword.Text.Trim()); //Password encrypted by SHA1 algorithm
                _objUser.RoleTypeID = Convert.ToChar(ddlAccountType.SelectedValue);


                _objUser.Status = false;

                result = _objUserBiz.Save(_objUser);
                if ( result==1 && (!string.IsNullOrEmpty(_objUser.Email) || !string.IsNullOrWhiteSpace(_objUser.Email)))
                {
                    _objMessages = new NotificationMessages();
                    _objMessages.ClassificationID = 1;
                    _objMessages.NotificationTypeID = 1;
                    string path = Request.Url.Scheme + "://" + Request.Url.Authority +Request.ApplicationPath.TrimEnd('/') + "/"+ "UserActivationByEmail.aspx?email=" + _objUser.Email;//Request.Url.GetLeftPart(UriPartial.Authority);
                    _objNotificationBiz = new NotificationBiz();
               
                    string body = "Hello " + _objUser.FirstName + ",";
                    body += "<br /><br />Please click the following link to activate your account";
                    body += "<br /> <a href='"+ path+"' >Click here to activate your account. </a> <br /><br />Thanks";
                    
                   _objNotificationBiz.SendEmail(_objMessages, _objUser.Email,body);
                    succesMessage = "Signup Successful";
                }
                else if (result==2)
                {
                    succesMessage = "User already Exists!";
                   
                }

                else
                {
                    succesMessage ="Registration Failed";
                }
                return result;
            }
            catch (Exception exception)
            {
                MessageBox(exception.Message);
                return 0;
            }
        }

        protected void cusfvEmailMobileNo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() == string.Empty && txtMobileNo.Text.Trim() == string.Empty)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        //    string expectedToken = (string)Session["token"];
        //{
        //private bool TokenIsValid()
        //}
        //    hf.Value = token;
        //    Session["token"] = token;
        //    string token = System.Guid.NewGuid().ToString();
        //{
        //public void createToken()
        //    if (expectedToken == null)
        //        return false;

        //    string actualToken = hf.Value;

        //    return expectedToken == actualToken;
        //}
    }
}