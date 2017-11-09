using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS.Common
{
    public class BasePage : Page
    {
        public BasePage()
        {
            MaintainScrollPositionOnPostBack = true;
        }

        protected override void InitializeCulture()
        {
            var cultureName = "en-GB";
            UICulture = cultureName;
            Culture = cultureName;
            var objCultureInfo = new CultureInfo(cultureName);
            objCultureInfo.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            Thread.CurrentThread.CurrentCulture = objCultureInfo;
            Thread.CurrentThread.CurrentUICulture = objCultureInfo;
            base.InitializeCulture();
        }

        public void MessageBox(string message)
        {
            var lblMessageBoxForAlert = new Label();
            lblMessageBoxForAlert.ID = "testjavascriptlabelid";
            lblMessageBoxForAlert.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert(" + "'" +
                                         message + "'" + ");</script>";
            Page.Controls.Add(lblMessageBoxForAlert);
        }

        public void MessageBox(string message, string url)
        {
            var script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(GetType(), "SuccessMessage", script, true);
        }

        public void ClearControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox)) //Clear TextBox
                {
                    ((TextBox) c).Text = "";
                }
                if (c.GetType() == typeof(DropDownList)) //Clear DropDownList
                {
                    ((DropDownList) c).ClearSelection();
                }
                if (c.GetType() == typeof(CheckBox)) //Clear CheckBox
                {
                    ((CheckBox) c).Checked = false;
                }
                if (c.GetType() == typeof(CheckBoxList)) //Clear CheckBoxList
                {
                    ((CheckBoxList) c).ClearSelection();
                }
                if (c.GetType() == typeof(RadioButton)) //Clear RadioButton
                {
                    ((RadioButton) c).Checked = false;
                }
                if (c.GetType() == typeof(RadioButtonList)) //Clear RadioButtonList
                {
                    ((RadioButtonList) c).ClearSelection();
                }
                if (c.GetType() == typeof(HiddenField)) //Clear HiddenField
                {
                    ((HiddenField) c).Value = "";
                }

                if (c.HasControls())
                {
                    ClearControls(c);
                }
            }
        }

        public void ClearControls(Control parent, bool isWithLabel)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox)) //Clear TextBox
                {
                    ((TextBox) c).Text = "";
                }
                if (c.GetType() == typeof(DropDownList)) //Clear DropDownList
                {
                    ((DropDownList) c).ClearSelection();
                }
                if (c.GetType() == typeof(CheckBox)) //Clear CheckBox
                {
                    ((CheckBox) c).Checked = false;
                }
                if (c.GetType() == typeof(CheckBoxList)) //Clear CheckBoxList
                {
                    ((CheckBoxList) c).ClearSelection();
                }
                if (c.GetType() == typeof(RadioButton)) //Clear RadioButton
                {
                    ((RadioButton) c).Checked = false;
                }
                if (c.GetType() == typeof(RadioButtonList)) //Clear RadioButtonList
                {
                    ((RadioButtonList) c).ClearSelection();
                }
                if (c.GetType() == typeof(HiddenField)) //Clear HiddenField
                {
                    ((HiddenField) c).Value = "";
                }
                if (c.GetType() == typeof(Label)) //Clear Label
                {
                    ((Label) c).Text = "";
                }
                if (c.HasControls())
                {
                    ClearControls(c);
                }
            }
        }
    }
}