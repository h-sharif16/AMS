using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AMS.Biz;
using AMS.Model;

namespace AMS
{
    public partial class AddDetail : System.Web.UI.Page
    {
        private string landloadId;
        private int apartmentId;

        private int propertyId;


        private ApartmentForAdvartisementBiz objApartmentForAdvartisementBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["lId"] != null && Request.QueryString["apId"] != null &&
                    Request.QueryString["ppId"] != null)
                {
                    landloadId = Request.QueryString["lId"].Trim();
                    apartmentId = Convert.ToInt32(Request.QueryString["apId"]);
                    propertyId = Convert.ToInt32(Request.QueryString["ppId"]);
                    GetApartmentImages(landloadId, apartmentId, propertyId);
                }
            }
        }

        private void GetApartmentImages(string landloadId, int apartmentId, int propertyId)
        {
            List<ApartmentForAdvartisement> objApartmentForAdvartisementList = new List<ApartmentForAdvartisement>();
            objApartmentForAdvartisementBiz = new ApartmentForAdvartisementBiz();
            objApartmentForAdvartisementList = objApartmentForAdvartisementBiz.GetApartmentImages(landloadId, apartmentId, propertyId);
            gvApartmentWiseImg.DataSource = objApartmentForAdvartisementList;
            gvApartmentWiseImg.DataBind();
            foreach (ApartmentForAdvartisement objApartmentForAdvartisement in objApartmentForAdvartisementList)
            {
                lblLanloard.Text = objApartmentForAdvartisement.FullName;
                lblLanloardMobile.Text = objApartmentForAdvartisement.MobileNo;
                lblPropertyId.Text = objApartmentForAdvartisement.PropertyId.ToString();
                lblApSpace.Text = objApartmentForAdvartisement.ApartmentSpace.ToString();
                lblBed.Text = objApartmentForAdvartisement.Beds.ToString();
                lblBath.Text = objApartmentForAdvartisement.AttachBatch.ToString();
                lblFloorType.Text = objApartmentForAdvartisement.FloorType;
                lblRent.Text = objApartmentForAdvartisement.Rent.ToString();
            }
        }


      

    }
}