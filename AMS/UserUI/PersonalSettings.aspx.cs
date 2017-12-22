using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
    public partial class PersonalSettings : BasePage
    {
        private UserDetail objUserDetail;
        private NotificationMessages _objMessages;
        private NotificationBiz _objNotificationBiz;

        private readonly UserBiz _objUserBiz = new UserBiz();
        private string succesMessage;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Tab1.CssClass = "Clicked";
                MainView.ActiveViewIndex = 0;
                LoadDropDownlist();
                GetPersonalGenInitialInfo();

            }
        }
        private void LoadDropDownlist()
        {

            ddlProfession.DataSource = ProfessionBiz.GetProfession();
            ddlProfession.DataBind();

            ddlReligion.DataSource = ReligionBiz.GetReligion();
            ddlReligion.DataBind();
            //  LoadThana(-1);

        }

        private void GetPersonalGenInitialInfo()
        {
            if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS != null &&
                MainView.ActiveViewIndex == 0)
            {
                objUserDetail = (UserDetail)SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;
                txtFirstName.Text = objUserDetail.FirstName;
                txtMiddleName.Text = objUserDetail.MiddleName;
                txtLastName.Text = objUserDetail.LastName;
                txtEmail.Text = objUserDetail.Email;
                txtNID.Text = objUserDetail.NID;
                txtTIN.Text = objUserDetail.TIN;
                if (!string.IsNullOrWhiteSpace(objUserDetail.DateOfBirth.ToString()))
                {
                    txtDateOfBirth.Text = objUserDetail.DateOfBirth.ToString();
                }

                if (objUserDetail.ProfessionId > 0)
                {
                    ddlProfession.SelectedValue = objUserDetail.ProfessionId.ToString();
                }
                if (objUserDetail.ReligionId > 0)
                {
                    ddlReligion.SelectedValue = objUserDetail.ReligionId.ToString();
                }
                txtOthersProfession.Text = objUserDetail.OthersProfession;
                txtLastName.Text = objUserDetail.LastName;
                txtEmail.ReadOnly = true;

            }
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            Tab4.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;

            GetPersonalGenInitialInfo();
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";
            Tab3.CssClass = "Initial";
            Tab4.CssClass = "Initial";
            MainView.ActiveViewIndex = 1;

        }

        protected void Tab3_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Clicked";
            Tab4.CssClass = "Initial";
            MainView.ActiveViewIndex = 2;

        }

        protected void Tab4_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            Tab4.CssClass = "Clicked";
            MainView.ActiveViewIndex = 3;

        }

        protected void ddlProfession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlProfession.SelectedValue) == 8 || ddlProfession.SelectedItem.Text == "Others")
            {
                panelOtherProfessionTextBox.Visible = true;
                txtOthersProfession.Text = string.Empty;
            }
            else
            {
                panelOtherProfessionTextBox.Visible = false;
                txtOthersProfession.Text = string.Empty;
            }
        }

        protected void btnSaveGeneralInfo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS != null &&
              MainView.ActiveViewIndex == 0)
                {
                    objUserDetail = (UserDetail)SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;
                }
                if (SendRequestToSave() == 1)
                {
                    ltrlSaveMsg.Text =
                                "<span style=\"color: green; font - size: 10pt \">Save Successfull</span><br/> <span> </span>";
                    HtmlMeta meta = new HtmlMeta();
                    meta.HttpEquiv = "Refresh";
                    meta.Content = "4;url=PersonalSettings.aspx";
                    this.Page.Controls.Add(meta);
                    //ltrlSaveMsg.Text =
                    //    "<span style=\"color: green; font - size: 10pt \">Save Successfull</span>";


                }
                else
                {
                    ltrlSaveMsg.Text =
                      "<span style=\"color: Red; font - size: 10pt \">Save Failed!</span>";
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


                int result = 0;
                objUserDetail.Email = txtEmail.Text.Trim();

                objUserDetail.FirstName = txtFirstName.Text.Trim();
                objUserDetail.LastName = txtLastName.Text.Trim();
                objUserDetail.MiddleName = txtMiddleName.Text.Trim();
                objUserDetail.NID = txtNID.Text.Trim();
                objUserDetail.TIN = txtTIN.Text.Trim();
                objUserDetail.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text.Trim());

                objUserDetail.ProfessionId = Convert.ToInt32(ddlProfession.SelectedValue);
                objUserDetail.ReligionId = Convert.ToInt32(ddlReligion.SelectedValue);
                string s = fudProfileImage.FileName;
                FileUpload fileUpload = (FileUpload)Session["ProfileImageUpload"];
                if (fileUpload.HasFile)
                {
                    string folderPath = ConfigurationManager.AppSettings["ProfileImageUrl"];
                    string directoryPath =  folderPath +  objUserDetail.UserID.Trim();
                    string extension = Path.GetExtension(fileUpload.FileName).ToLower();

                    if (!Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath(directoryPath)))
                    {
                        Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath(directoryPath));
                    }
                    if (extension != null)
                    {
                        string path = folderPath + objUserDetail.UserID.Trim() + "\\" + objUserDetail.RoleTypeID +
                                      "-ProfileImg" + objUserDetail.UserID.Trim() + extension;


                        if (File.Exists(System.Web.Hosting.HostingEnvironment.MapPath(path)))
                        {
                            File.Delete(System.Web.Hosting.HostingEnvironment.MapPath(path));

                        }
                        objUserDetail.ProfileImageUrl = path;
                        fileUpload.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path));
                    }

                }

                SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS = objUserDetail;

                result = _objUserBiz.SavePersonalGeneralInfo(objUserDetail);
                //if (result == 1 && (!string.IsNullOrEmpty(objUserDetail.Email) || !string.IsNullOrWhiteSpace(_objUser.Email)))
                //{
                //    _objMessages = new NotificationMessages();
                //    _objMessages.ClassificationID = 1;
                //    _objMessages.NotificationTypeID = 1;
                //    string path = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/" + "UserActivationByEmail.aspx?email=" + objUserDetail.Email;//Request.Url.GetLeftPart(UriPartial.Authority);
                //    _objNotificationBiz = new NotificationBiz();


                //    succesMessage = "Signup Successful";
                //}
                //else if (result == 2)
                //{
                //    succesMessage = "User already Exists!";

                //}

                //else
                //{
                //    succesMessage = "Registration Failed";
                //}
                return result;
            }
            catch (Exception exception)
            {
                MessageBox(exception.Message);
                return 0;
            }
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string extension = Path.GetExtension(fudProfileImage.FileName);
            if (extension != null)
            {
                string fileExtension = extension.ToUpper();
                if (fileExtension == ".PNG" || fileExtension == ".JPEG" || fileExtension == ".JPG" || fileExtension == ".BMP" ||
                    fileExtension == ".GIF" || fileExtension == ".TIFF" || fileExtension == ".IMG")

                {
                    if (Session["ProfileImageUpload"] == null && fudProfileImage.HasFile)
                    {
                        Session["ProfileImageUpload"] = fudProfileImage;
                        //Label1.Text = fudProfileImage.FileName; // get the name 
                    }
                    // This condition will occur on next postbacks        
                    else if (Session["ProfileImageUpload"] != null && (!fudProfileImage.HasFile))
                    {
                        fudProfileImage = (FileUpload)Session["ProfileImageUpload"];

                    }
                    //  when Session will have File but user want to change the file 
                    // i.e. wants to upload a new file using same FileUpload control
                    // so update the session to have the newly uploaded file
                    else if (fudProfileImage.HasFile)
                    {
                        Session["ProfileImageUpload"] = fudProfileImage;
                        //Label1.Text = fudProfileImage.FileName;
                    }
                }
                else
                {
                    MessageBox("Profile Picture is not in a correct formate!!");
                }
            }
        }

        protected void btnSaveContact_Click(object sender, EventArgs e)
        {

        }
    }
}