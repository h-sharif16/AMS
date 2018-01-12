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

namespace AMS.UserUI
{
    public partial class ResponseVisitRequest : BasePage
    {
        private UserDetail objUserDetail;
        private NotificationMessages _objMessages;
        private NotificationBiz _objNotificationBiz;
        private VisitRequestBiz _objVisitRequestBiz;
        private VisitRequest _objVisitRequest;
        string PropertyName, apartmentNo;
        private readonly UserBiz _objUserBiz = new UserBiz();
        private string succesMessage;
        string messageToClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlAcceptReq.Visible = false;
                pnlDenyReq.Visible = false;
                pnlMessage.Visible = false;

                if (Request.QueryString["lId"] != null && SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS != null)
                {
                    objUserDetail = (UserDetail)SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;


                    if (Request.QueryString["lId"].Trim() == objUserDetail.UserID.Trim())
                    {
                        int result = 0;
                        if (Request.QueryString["isAccept"] == "1")
                        {
                            pnlAcceptReq.Visible = true;
                            SetValue();


                        }
                        else
                        {
                            pnlDenyReq.Visible = true;
                            SetValue();

                        }


                    }
                    else
                    {
                        MessageBox("You are not the right person to Response this Request!");
                        HtmlMeta meta = new HtmlMeta();
                        meta.HttpEquiv = "Refresh";
                        meta.Content = "3;url=WelcomeUI.aspx";
                        this.Page.Controls.Add(meta);
                    }
                }
                if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS == null)
                {
                    Session.RemoveAll();
                    Response.Redirect("~/Signin.aspx");
                }
            }
        }

        private void SetValue()
        {
            _objVisitRequest = new VisitRequest();
            _objVisitRequestBiz = new VisitRequestBiz();
            _objVisitRequest = _objVisitRequestBiz.GetVisitRequestDetail(Convert.ToInt32(Request.QueryString["ReqId"]),
                Request.QueryString["lId"].Trim());
            if(_objVisitRequest!=null)
            { 


            PropertyName = CommonBiz.GetSingleString("ams.Properties", "PropertyName",
                "PropertyId=" + _objVisitRequest.PropertyId);
            apartmentNo = CommonBiz.GetSingleString("ams.Apartment", "ApartmentNoOrName",
                "PropertyId=" + _objVisitRequest.PropertyId + " and ApartmentId=" +
                _objVisitRequest.ApartmentId);
            lblRequrstedBy.Text = string.IsNullOrEmpty(_objVisitRequest.ClientName) ? "Not Defined" : _objVisitRequest.ClientName;
            lblClientEmail.Text = string.IsNullOrEmpty(_objVisitRequest.ClientEmail) ? "Not Defined" : _objVisitRequest.ClientEmail;
            lblClientMobileNo.Text = string.IsNullOrEmpty(_objVisitRequest.ClientMobileNo) ? "Not Defined" : _objVisitRequest.ClientMobileNo;
            lblRequestedFor.Text = string.IsNullOrEmpty(PropertyName) ? "Not Defined" : PropertyName + " (" + apartmentNo + ")";
            txtClientMessage.Text = _objVisitRequest.MessageToLandlord;
            ViewState["objVisitRequest"] = _objVisitRequest;
            }
            else
            {
               
                MessageBox("You already respond this Request!");
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "3;url=WelcomeUI.aspx";
                this.Page.Controls.Add(meta);
            }

        }

        protected void chkToViewMessageBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToViewMessageBox.Checked)
            {
                pnlMessage.Visible = true;
                txtMessageToClient.Text = string.Empty;
            }
            else
            {
                pnlMessage.Visible = false;
                txtMessageToClient.Text = string.Empty;
            }
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            objUserDetail = (UserDetail)SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;
            _objVisitRequest = (VisitRequest)ViewState["objVisitRequest"];
            _objVisitRequestBiz = new VisitRequestBiz();
            int result = 0;
            if (chkToViewMessageBox.Checked && !string.IsNullOrEmpty(txtMessageToClient.Text.Trim()))
            {
                messageToClient = txtMessageToClient.Text.Trim();
            }
            else
            {
                messageToClient = "Dear MR. " + _objVisitRequest.ClientName +
                                  ", <br/>Thanks for your interest. Due to unavoidable reasons I can't accept your visit request. Hope we will meet in near future. <br/> Thanks,<br/>" + objUserDetail.FullName;
            }
            _objVisitRequest.MessageToClient = messageToClient;
            _objVisitRequest.IsAccepted = Request.QueryString["isAccept"] == "1" ? true : false;
            _objVisitRequest.ResponseDate = DateTime.Today;
            result = _objVisitRequestBiz.UpdateResposeOnVisitRequest(_objVisitRequest);
            if (result > 0)
            {

                _objMessages = new NotificationMessages();
                _objMessages.ClassificationID = 4;
                _objMessages.NotificationTypeID = 1;

                //Request.Url.GetLeftPart(UriPartial.Authority);
                _objNotificationBiz = new NotificationBiz();

                string body = messageToClient;


                _objNotificationBiz.SendEmail(_objMessages,   _objVisitRequest.ClientEmail, body);

                ltrlEmailSmsNotificationD.Text =
                    "<span style=\"color: green; font - size: 10pt \">Operation Successful</span>";

            }
            else
            {

                ltrlEmailSmsNotificationD.Text =
                   "<span style=\"color: Red; font - size: 10pt \">Operation Failed</span>";

            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            objUserDetail = (UserDetail)SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;
            _objVisitRequest = (VisitRequest) ViewState["objVisitRequest"];
            _objVisitRequestBiz=new VisitRequestBiz();
            int result = 0;
            if (chkToViewMessageBox.Checked && !string.IsNullOrEmpty(txtMessageToClient.Text.Trim()))
            {
                messageToClient = txtMessageToClient.Text.Trim();
            }
            else
            {
                messageToClient = "Dear MR. " + _objVisitRequest.ClientName +
                                  ", <br/>Thanks for your interest. You are welcome to visit as your request.<br/> Thanks,<br/>" + objUserDetail.FullName;
            }
            _objVisitRequest.MessageToClient = messageToClient;
            _objVisitRequest.IsAccepted = Request.QueryString["isAccept"] == "1" ? true : false;
            _objVisitRequest.ResponseDate = DateTime.Today;
            result = _objVisitRequestBiz.UpdateResposeOnVisitRequest(_objVisitRequest);
            if (result > 0)
            {


                _objMessages = new NotificationMessages();
                _objMessages.ClassificationID = 5;
                _objMessages.NotificationTypeID = 1;

                //Request.Url.GetLeftPart(UriPartial.Authority);
                _objNotificationBiz = new NotificationBiz();

                string body = messageToClient;


                _objNotificationBiz.SendEmail(_objMessages, _objVisitRequest.ClientEmail, body);

                ltrlEmailSmsNotificationA.Text =
                    "<span style=\"color: green; font - size: 10pt \">Operation Successful</span>";

            }
            else
            {

                ltrlEmailSmsNotificationA.Text =
                   "<span style=\"color: Red; font - size: 10pt \">Operation Failed</span>";

            }
        }
    }
}