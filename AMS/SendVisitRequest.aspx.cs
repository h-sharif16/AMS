using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AMS.Biz;
using AMS.Common;
using AMS.Common.Biz;
using AMS.Model;
using AMS.Notification.Biz;
using AMS.Notification.Model;

namespace AMS
{
    public partial class SendVisitRequest : BasePage
    {
        private UserDetail objUser;
        private UserBiz objUserBiz;
        private NotificationMessages _objMessages;
        private NotificationBiz _objNotificationBiz;
        private VisitRequestBiz _objVisitRequestBiz;
        private VisitRequest _objVisitRequest;
        private string succesMessage;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendVisitReq_Click(object sender, EventArgs e)
        {
            string landloardEmail;
            int result = 0, VisitReqId;
            bool isAlreadyRequestedForVisit;
            _objVisitRequestBiz = new VisitRequestBiz();
            if (Request.QueryString["lId"] != null && Request.QueryString["apId"] != null &&
                Request.QueryString["ppId"] != null)
            {
                _objVisitRequest = new VisitRequest();

                landloardEmail = GetLandloardEmail(Request.QueryString["lId"]);
                _objVisitRequest.PropertyId = Convert.ToInt32(Request.QueryString["ppId"]);
                _objVisitRequest.LandlordId = Request.QueryString["lId"].Trim();
                _objVisitRequest.ApartmentId = Convert.ToInt32(Request.QueryString["apId"]);
                _objVisitRequest.ClientEmail = txtClientEmail.Text.Trim();
                _objVisitRequest.ClientMobileNo = txtClientMobileNo.Text.Trim();
                _objVisitRequest.ClientName = txtClientName.Text.Trim();
                _objVisitRequest.MessageToLandlord = txtVisitReqMessage.Text.Trim();
                _objVisitRequest.RequestDate = DateTime.Today;
                isAlreadyRequestedForVisit = _objVisitRequestBiz.GetIsAlreadyRequestedForVisit(_objVisitRequest);
                if (!isAlreadyRequestedForVisit)
                {
                    result = _objVisitRequestBiz.SaveVisitRequest(_objVisitRequest,out VisitReqId);
                    if (result > 0)
                    {
                        string PropertyName, apartmentNo;
                        PropertyName = CommonBiz.GetSingleString("ams.Properties", "PropertyName",
                            "PropertyId=" + _objVisitRequest.PropertyId);
                        apartmentNo = CommonBiz.GetSingleString("ams.Apartment", "ApartmentNoOrName",
                            "PropertyId=" + _objVisitRequest.PropertyId + " and ApartmentId=" +
                            _objVisitRequest.ApartmentId);
                        _objMessages = new NotificationMessages();
                        _objMessages.ClassificationID = 4;
                        _objMessages.NotificationTypeID = 1;
                        string path = Request.Url.Scheme + "://" + Request.Url.Authority +
                                      Request.ApplicationPath.TrimEnd('/') + "/" + "UserUI/ResponseVisitRequest.aspx";
                        //Request.Url.GetLeftPart(UriPartial.Authority);
                        _objNotificationBiz = new NotificationBiz();
                        objUser = (UserDetail) ViewState["UserDetailVwState"];
                        string body = "Hello <br/> " + objUser.FullName + ",";
                        body += "<br /><br /> " + _objVisitRequest.ClientName + " wants to visit your apartment " +
                                apartmentNo + " of " + PropertyName + "<br/>";
                        body += "<span style=\"font-size: 11pt;font-weight: bold\">Messege from Client:</span><br/>" +
                                _objVisitRequest.MessageToLandlord + "<br/>";
                        body += "<br /> If you want to accept this visit Request please click <a href='" + path +
                                "?isAccept=1&lId=" + _objVisitRequest.LandlordId +
                                "&ReqId=" + VisitReqId + "' > accept </a> <br /><br /> Or To deny click  <a href='" + path + "?isAccept=0&lId=" +
                                _objVisitRequest.LandlordId + "&ReqId="+VisitReqId+"'> deny </a> <br /><br />";

                        _objNotificationBiz.SendEmail(_objMessages, landloardEmail, body);
                        ltrlEmailSmsNotification.Text =
                            "<span style=\"color: green; font - size: 10pt \">Request Successful</span>";
                    }
                    else
                    {
                        ltrlEmailSmsNotification.Text =
                            "<span style=\"color: Red; font - size: 10pt \">Request Failed</span>";
                    }

                }
                else
                {
                    ltrlEmailSmsNotification.Text =
                           "<span style=\"color: Red; font - size: 10pt \">You have already a pending Request. Thanks..</span>";
                }



            }
            else
            {
                MessageBox("Request Failed!");
            }

        }

        private string GetLandloardEmail(string landlordEmail)
        {
            objUser = new UserDetail();
            objUserBiz = new UserBiz();
            objUser = objUserBiz.GetLandloardEmail(landlordEmail);
            ViewState["UserDetailVwState"] = objUser;
            return objUser.Email;
        }
    }
}