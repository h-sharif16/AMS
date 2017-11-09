using System;
using System.Web.UI;
using AMS.Model;

namespace AMS.UserUI
{
    public partial class Users : MasterPage
    {
        private UserDetail objUserDetail;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS != null)
                {
                    objUserDetail = (UserDetail) SessionUtility.SessionUtility.AmsSessionContainer.OBJ_USER_CLASS;
                    lblUserName.Text = objUserDetail.FullName;

                    lblUserType.Text = objUserDetail.RoleName;
                }
            }
        }
    }
}