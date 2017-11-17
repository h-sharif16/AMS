using System;
using System.Web;
using System.Web.UI.WebControls;
using AMS.Biz;
using AMS.Common;
using AMS.Common.Biz;
using AMS.Model;
using AMS.Notification.Biz;
using AMS.Notification.Model;
using System.Web.UI.HtmlControls;

namespace AMS
{
    public partial class ResetPassword : BasePage
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            //  Page.Validate();
            if (Page.IsValid)
            {

                if (!string.IsNullOrWhiteSpace(Request.QueryString["email"]))
                {
                    //_objUserDtl=new UserDetail();
                    //_objUserDtl.Email = Request.QueryString["email"];
                    bool isVerified = _objUserBiz.IsUserVerified(Request.QueryString["email"]);
                    if (isVerified)
                    {
                        int result =SendRequestToUpdate(Request.QueryString["email"]);
                        if (result != 0)
                        {
                            panelEmailSmsNotification.Visible = true;
                            ltrlEmailSmsNotification.Text =
                                "<span style=\"color: green; font - size: 10pt \">Update Successfull</span><br/> <span> Page will be Redirect to Sign in page in 5 Seconds</span>";
                            HtmlMeta meta = new HtmlMeta();
                            meta.HttpEquiv = "Refresh";
                            meta.Content = "4;url=Signin.aspx";
                            this.Page.Controls.Add(meta);
                        }
                    }
                    else
                    {
                        panelEmailSmsNotification.Visible = true;
                        ltrlEmailSmsNotification.Text =
                            "<span style=\"color: green; font - size: 10pt \">Update Failed</span>";

                    }
                }
                
            }
            else
            {
                MessageBox("Validation Error!");
            }
        }

        private int SendRequestToUpdate(string email)
        {
            try
            {
                _objUser = new UserDetail();

                int result=0;
               
                _objUser.Password = CommonBiz.GetSwcSH1(txtPassword.Text.Trim()); //Password encrypted by SHA1 algorithm
                _objUser.Email = email;


                _objUser.Status = false;

                result = _objUserBiz.ResetPassword(_objUser);
                
                return result;
            }
            catch (Exception exception)
            {
                MessageBox(exception.Message);
                return 0;
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