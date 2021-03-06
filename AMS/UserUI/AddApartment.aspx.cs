﻿using System;
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
    public partial class AddApartment :  BasePage
    {
        private List<PropertyPhoto> _objPropertyPhotoList;
        private UserDetail objUserDetail;
        private Property objProperty;
        private PropertyBiz objPropertyBiz;
        private PropertyFacilityType objFacilityType;
        private List<PropertyFacilityType> objFacilityTypeList;

        private PropertySecurityType objSecurityType;
        private List<PropertySecurityType> objSecurityTypesList;

        private PropertyPhoto objPhoto;
        private List<PropertySecurityType> objPhotoList;


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
                Tab1.CssClass = "Clicked";
                MainView.ActiveViewIndex = 0;
                LoadDropDownlist();
                  
                
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

        }

        private void LoadDropDownlist()
        {

            ddlUserWiseProperty.DataSource = PropertyTypeBiz.GetPropertyType();
            ddlUserWiseProperty.DataBind();

            //ddlCountry.DataSource = CountryBiz.GetCountry();

            //ddlCountry.DataBind();
            //ckblPropertyFacilities.DataSource = PropertyFacilityTypeBiz.GetPropertyFacilityType();
            //ckblPropertyFacilities.DataBind();
            //ckblPropertySecurity.DataSource = PropertySecurityTypeBiz.GetPropertySecurityType();
            //ckblPropertySecurity.DataBind();

            //  LoadThana(-1);

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
                if (SendRequestToSave()>=1)
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
                objProperty=new Property();

                int result = 0;
                objFacilityTypeList=new List<PropertyFacilityType>();
                objSecurityTypesList = new List<PropertySecurityType>();
                objPropertyBiz=new PropertyBiz();
                 



              //  objProperty.PropertyName = txtPropertyName.Text.Trim();
              //  objProperty.LandloadId = objUserDetail.UserID;
              // objProperty.BuiltYear =Convert.ToDateTime( txtBuiltYear.Text.Trim());
              //  objProperty.CountryID = Convert.ToInt32( ddlCountry.SelectedValue);
              //  objProperty.DivisionId = Convert.ToInt32(ddlDivision.SelectedValue);//Division=State
              //  objProperty.DistrictId = Convert.ToInt32(ddlCity.SelectedValue);//District =City
              //  objProperty.UpazilaId = Convert.ToInt32(dllThanaOrArea.SelectedValue); //UpazilaId=Thana/Area

              //  objProperty.HoldingNo = txtHoldingOrHouseNo.Text.Trim();
              //  objProperty.RoadNo = txtRoadNo.Text.Trim();
              // objProperty.SectorOrBlock =  txtSector.Text.Trim();
              //  objProperty.TotalSpace =Convert.ToInt32( txtTotalSpace.Text.Trim());
              //  objProperty.NoOfFloors = Convert.ToInt32(txtNoOfFloors.Text.Trim());
            
              //  objProperty.IsParkingAvailable = Convert.ToBoolean(rblIsParkingAvailabel.SelectedValue);
              //  if (Convert.ToBoolean(rblIsParkingAvailabel.SelectedValue))
              //  {
              //      objProperty.TotalParkingSpace = Convert.ToInt32(txtParkingTotalSpace.Text.Trim());
              //  }
              //  objProperty.PropertyFacilityTypeList = objFacilityTypeList;
              //  objProperty.PropertySecurityTypeList = objSecurityTypesList;

              //result= objPropertyBiz.SavePropertyInfo(objProperty);
                 
                return result;
            }
            catch (Exception exception)
            {
                MessageBox(exception.Message);
                return 0;
            }
        }
        private void AddPhoto()
        {
            if (fudProPertyImage.HasFile)
            {
                List<PropertyPhoto> objPropertyPhotoList = null;
                string path = null;
                objUserDetail = (UserDetail)SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;
                if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS == null)
                {
                    objPropertyPhotoList = new List<PropertyPhoto>();
                }
                else
                {
                    objPropertyPhotoList = SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS as List<PropertyPhoto>;
                }


                
                //string theFileName = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + "-" + fudPropertyPhoto.FileName;
                //string path = FolderPath + theFileName;
                string folderPath = ConfigurationManager.AppSettings["ProfileImageUrl"];
                string directoryPath = Server.MapPath(folderPath + "/" + objUserDetail.UserID.Trim() + "/ImgTemp" );
                string extension = Path.GetExtension(fudProPertyImage.FileName).ToLower();

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                if (extension != null)
                {
                   path= directoryPath + "/" + fudProPertyImage.FileName;


                    if (File.Exists(Server.MapPath(path)))
                    {
                        File.Delete(Server.MapPath(path));

                    }
                    objUserDetail.ProfileImageUrl = path;
                    fudProPertyImage.SaveAs(Server.MapPath(path));
                }

                PropertyPhoto objPropertyPhoto = new PropertyPhoto();
                objPropertyPhoto.PropertyPhotoSerial = objPropertyPhotoList.Count + 1;
                objPropertyPhoto.PhotoName = fudProPertyImage.FileName;
                objPropertyPhoto.PhotoUrl = path;
                 

                objPropertyPhotoList.Add(objPropertyPhoto);
                SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS = objPropertyPhotoList;

                
            }

            else
            {
                MessageBox("Please upload a file.");
            }
            if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS != null)
            {
                List<PropertyPhoto> objPropertyPhotoList =SessionUtility.SessionUtility.AmsSessionContainer.OBJ_Photo_CLASS as List<PropertyPhoto>;
                foreach (PropertyPhoto objProperty in objPropertyPhotoList)
                {
                    imgPropertyPhotoTemp.ImageUrl = objProperty.PhotoUrl;
                }
            }
        }

        //protected void btnImgUpload_Click(object sender, EventArgs e)
        //{
        //    bool f = fudProPertyImage.HasFile;
        //    AddPhoto();
        //}

        
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            bool f = fudProPertyImage.HasFile;
        }
    }
}