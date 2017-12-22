using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using AMS.Biz;
using AMS.Common;
using AMS.Common.Biz;
using AMS.Model;

namespace AMS
{
    public partial class Default : BasePage
    {
        private ApartmentForAdvartisementBiz objApartmentForAdvartisementBiz;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 
                
                LoadDropDownlist();
                ddlCountry.SelectedIndex = 1;
               ddlCountry_SelectedIndexChanged(sender, e);
                ddlDivision.SelectedIndex = 1;
                ddlDivision_SelectedIndexChanged(sender, e);
                ddlCity.SelectedIndex = 1;
                ddlCity_SelectedIndexChanged(sender, e);
                dllThanaOrArea.SelectedIndex = 1;
                
               GetAddData();
            }
        }
        private void GetAddData()
        {
            List<ApartmentForAdvartisement> objApartmentForAdvartisementList =new List<ApartmentForAdvartisement>();
            objApartmentForAdvartisementBiz=new ApartmentForAdvartisementBiz();
            objApartmentForAdvartisementList = objApartmentForAdvartisementBiz.GetApartmentForAdvartisement();
            GridView1.DataSource = objApartmentForAdvartisementList;
            GridView1.DataBind();
             
        }

        protected void Page_PerInit(object sender, EventArgs e)
        {
            SessionUtility.SessionUtility.AmsSessionContainer.OBJ_ADV_CLASS =
                    objApartmentForAdvartisementBiz.GetApartmentForAdvartisement();

        }
        private void LoadDropDownlist()
        {

            

            ddlCountry.DataSource = CountryBiz.GetCountry();

            ddlCountry.DataBind();
           

            //  LoadThana(-1);

        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                ddlDivision.DataSource = StateDivisionBiz.GetStateDivision(Convert.ToInt32(ddlCountry.SelectedValue));

                ddlDivision.DataBind();
                ddlDivision.SelectedIndex = 1;
                // ddlDivision_SelectedIndexChanged(sender, e);

            }
            else
            {
                ddlDivision.Items.Clear();
                ddlDivision.Items.Insert(0, "--Select Option--");

            }

        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
            {
                ddlCity.DataSource = CityBiz.GetCity(Convert.ToInt32(ddlDivision.SelectedValue));

                ddlCity.DataBind();
                ddlCity.SelectedIndex = 1;
                // ddlCity_SelectedIndexChanged(sender, e);
            }
            else
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Insert(0, "--Select Option--");

            }

        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCity.SelectedValue))
            {
                dllThanaOrArea.DataSource = ThanaOrAreaBiz.GetThanaOrArea(Convert.ToInt32(ddlCity.SelectedValue));

                dllThanaOrArea.DataBind();
                dllThanaOrArea.SelectedIndex = 1;

            }
            else
            {
                dllThanaOrArea.Items.Clear();
                dllThanaOrArea.Items.Insert(0, "--Select Option--");

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell tc in e.Row.Cells)
                {
                    tc.BorderStyle = BorderStyle.None;
                }
            }
        }
    }
}