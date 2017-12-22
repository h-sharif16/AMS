using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AMS.Biz;
using AMS.Common;
using AMS.Common.Biz;
using AMS.Model;

namespace AMS.UserUI
{
    public partial class AddApartments : BasePage
    {
        private UserDetail objUserDetail;
        private Apartment objApartment;
        private ApartmentBiz objApartmentBiz;
        private ApartmentPhotoBiz objApartmentPhotoBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
                if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS != null)
                {
                    objUserDetail = (UserDetail)SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;
                    Tab1.CssClass = "Clicked";
                    MainView.ActiveViewIndex = 0;

                    LoadDropDownlist();
                }

            }
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";

            MainView.ActiveViewIndex = 0;

            // GetPersonalGenInitialInfo();
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";

            MainView.ActiveViewIndex = 1;
            if (ddlUserWiseProperty.SelectedIndex > 0)
            {
                ddlUserWisePropertyForPicture.SelectedValue = ddlUserWiseProperty.SelectedValue;
                ddlUserWisePropertyForPicture_SelectedIndexChanged(sender, e);
            }

        }

        private void LoadDropDownlist()
        {

            ddlUserWiseProperty.DataSource = PropertyBiz.GetUserWisePropertyList(objUserDetail.UserID);
            ddlUserWiseProperty.DataBind();
            ddlUserWisePropertyForPicture.DataSource = PropertyBiz.GetUserWisePropertyList(objUserDetail.UserID);
            ddlUserWisePropertyForPicture.DataBind();

            ddlFloorType.DataSource = FloorTypeBiz.GetFloorType();

            ddlFloorType.DataBind();
            ddlFloorType.SelectedIndex = 1;
            ddlVacancyStatus.DataSource = ApartmentStatusBiz.GetApartmentVacanyStatus();

            ddlVacancyStatus.DataBind();

          

        }


        protected void btnPropertyInfoSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS != null &&
              MainView.ActiveViewIndex == 0)
                {
                    objUserDetail = (UserDetail)SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;
                }
                if (SendRequestToSave() >= 1)
                {

                    ltrlSaveMsg.Text =
                        "<span style=\"color: green; font - size: 10pt \">Save Successfull</span>";


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
                objApartment = new Apartment();

                int result = 0;

                objApartmentBiz = new ApartmentBiz();


                objApartment.PropertyId = string.IsNullOrEmpty(ddlUserWiseProperty.SelectedValue.Trim()) ? 0 : Convert.ToInt32(ddlUserWiseProperty.SelectedValue.Trim());
                objApartment.ApartmentNoOrName =   txtApartmentNoOrName.Text.Trim();
                objApartment.LandloadId = objUserDetail.UserID.Trim();
                objApartment.FloorNo = string.IsNullOrEmpty(ddlFloorNo.SelectedValue.Trim()) ? 0 : Convert.ToInt32(ddlFloorNo.SelectedValue.Trim());
                objApartment.ApartmentSpace = string.IsNullOrEmpty(txtApartmentSpace.Text.Trim()) ? 0 : Convert.ToInt32(txtApartmentSpace.Text.Trim());
                objApartment.Beds = string.IsNullOrEmpty(txtBeds.Text.Trim()) ? 0 : Convert.ToInt32(txtBeds.Text.Trim());
                objApartment.AttachBatch = string.IsNullOrEmpty(ddlAttachBatch.SelectedValue.Trim()) ? 0 : Convert.ToInt32(ddlAttachBatch.SelectedValue.Trim());
                objApartment.CommonBath = string.IsNullOrEmpty(ddlCommonBath.SelectedValue.Trim()) ? 0 : Convert.ToInt32(ddlCommonBath.SelectedValue.Trim());
                objApartment.DiningPosition = ddlDiningPosition.SelectedValue.Trim();

                objApartment.StaffRoom = string.IsNullOrEmpty(ddlStaffRoom.SelectedValue.Trim()) ? 0 : Convert.ToInt32(ddlStaffRoom.SelectedValue.Trim());
                objApartment.StaffToilet = string.IsNullOrEmpty(ddlStaffToilet.SelectedValue.Trim()) ? 0 : Convert.ToInt32(ddlStaffToilet.SelectedValue.Trim());
                objApartment.Balconies = string.IsNullOrEmpty(ddlBalconies.SelectedValue.Trim()) ? 0 : Convert.ToInt32(ddlBalconies.SelectedValue.Trim());
                objApartment.FloorTypeId = string.IsNullOrEmpty(ddlFloorType.SelectedValue.Trim()) ? 0 : Convert.ToInt32(ddlFloorType.SelectedValue.Trim());
                objApartment.Rent = string.IsNullOrEmpty(txtRent.Text.Trim()) ? 0 : Convert.ToInt32(txtRent.Text.Trim());
                objApartment.Advance = string.IsNullOrEmpty(txtAdvance.Text.Trim()) ? 0 : Convert.ToInt32(txtAdvance.Text.Trim());
                objApartment.SecurityAmount = string.IsNullOrEmpty(txtSecurityAmount.Text.Trim()) ? 0 : Convert.ToInt32(txtSecurityAmount.Text.Trim());
                objApartment.ServiceCharge = string.IsNullOrEmpty(txtServiceCharge.Text.Trim()) ? 0 : Convert.ToInt32(txtServiceCharge.Text.Trim());
                objApartment.GasBill = string.IsNullOrEmpty(ddlGasBill.SelectedValue.Trim()) ? 0 : Convert.ToDecimal(ddlGasBill.SelectedValue.Trim());
                objApartment.CableTvBill = string.IsNullOrEmpty(txtCableTvBill.Text.Trim()) ? 0 : Convert.ToDecimal(txtCableTvBill.Text.Trim());
                objApartment.InternetBill = string.IsNullOrEmpty(txtInternetBill.Text.Trim()) ? 0 : Convert.ToDecimal(txtInternetBill.Text.Trim());
                //objApartment.InternetBill = Convert.ToDecimal(txtInternetBill.Text.Trim());
                objApartment.Description = txtDescription.Text.Trim();
                objApartment.VacancyStatusId = string.IsNullOrEmpty(ddlVacancyStatus.SelectedValue.Trim()) ? 1 : Convert.ToInt32(ddlVacancyStatus.SelectedValue.Trim());

                result = objApartmentBiz.SaveApartmentInfo(objApartment);

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
            AddPhoto();
            if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS != null)
            {
                List<ApartmentPhotos> objApartmentPhotoList = SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS as List<ApartmentPhotos>;
                gdImage.DataSource = objApartmentPhotoList;
                gdImage.DataBind();
                
            }
        }

        private void AddPhoto()
        {
            if (fudProPertyImage.HasFile && ddlUserWisePropertyForPicture.SelectedIndex>0 && ddlApartmentNo.SelectedIndex>0)
            {
                List<ApartmentPhotos> objApartmentPhotoList = null;
                string path = null;
                objUserDetail = (UserDetail)SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;
                if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS == null)
                {
                    objApartmentPhotoList = new List<ApartmentPhotos>();
                }
                else
                {
                    objApartmentPhotoList = SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS as List<ApartmentPhotos>;
                }



                //string theFileName = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + "-" + fudPropertyPhoto.FileName;
                //string path = FolderPath + theFileName;
                string folderPath = ConfigurationManager.AppSettings["ProfileImageUrl"];//~/UserUI/userImages/

                string directoryPath =
                    folderPath +  objUserDetail.UserID.Trim() +
                                                                  "/Property" +
                                                                  ddlUserWisePropertyForPicture.SelectedValue +
                                                                  "/Apartment" + ddlApartmentNo.SelectedValue +
                                                                  "/ImgTemp"; //Server.MapPath(folderPath + "/" + objUserDetail.UserID.Trim()+"/Property"+ddlUserWisePropertyForPicture.SelectedValue +"/Apartment"+ddlApartmentNo.SelectedValue+ "/ImgTemp");
                string extension = Path.GetExtension(fudProPertyImage.FileName).ToLower();

                if (!Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath(directoryPath)))
                {
                    Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath(directoryPath));
                }
                if (extension != null)
                {
                    path =  directoryPath + "\\" + fudProPertyImage.FileName;


                    if (File.Exists(System.Web.Hosting.HostingEnvironment.MapPath(path)))
                    {
                        File.Delete(System.Web.Hosting.HostingEnvironment.MapPath(path));

                    }
                  
                    fudProPertyImage.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path));
                }

                ApartmentPhotos objPropertyPhoto = new ApartmentPhotos();
                objPropertyPhoto.ApartmentPhotoSerial = objApartmentPhotoList.Count + 1;
                objPropertyPhoto.PhotoName = fudProPertyImage.FileName;
                objPropertyPhoto.PhotoUrl = path;
                objPropertyPhoto.PropertyId = Convert.ToInt32(ddlUserWisePropertyForPicture.SelectedValue.Trim());
                objPropertyPhoto.ApartmentId = Convert.ToInt32(ddlApartmentNo.SelectedValue.Trim());
                objPropertyPhoto.LandloadId = objUserDetail.UserID.Trim();


                objApartmentPhotoList.Add(objPropertyPhoto);
                SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS = objApartmentPhotoList;


            }

            else
            {
                MessageBox("Please upload a file.");
            }
           
        }

        protected void ddlUserWisePropertyForPicture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserWisePropertyForPicture.SelectedIndex > 0)
            {
                ddlApartmentNo.DataSource =
                    ApartmentBiz.GetApartmentDetailByPeopertyId(Convert.ToInt32(ddlUserWisePropertyForPicture.SelectedValue));
                ddlApartmentNo.DataBind();
            }
        }

        protected void btnPropertyPhotoSave_Click(object sender, EventArgs e)
        {
            if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS != null)
            {
                objApartmentPhotoBiz=new ApartmentPhotoBiz();
                List<ApartmentPhotos> objApartmentPhotoList = SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS as List<ApartmentPhotos>;
                int count = objApartmentPhotoBiz.SaveApartmentPhotos(objApartmentPhotoList);
                if (count >= 1)
                {

                    ltrlPhotoSaveMsg.Text =
                        "<span style=\"color: green; font - size: 10pt \">Phtoto Upload Successfull</span>";


                }
                else
                {
                    ltrlPhotoSaveMsg.Text =
                      "<span style=\"color: Red; font - size: 10pt \">Phtoto Upload Failed!</span>";
                }

            }

        }
    }
}