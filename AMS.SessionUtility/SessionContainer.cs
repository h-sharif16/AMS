using System;

namespace AMS.SessionUtility
{
    [Serializable]
    public class SessionContainer
    {
        public SessionContainer()
        {
            SessionUtility.AmsSessionContainer = this;
        }

        public string UserID { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        //public String OBJ_ACTIVE_DIR As Object
        public object OBJ_CLASS { get; set; }
        public object OBJ_DOC_CLASS { get; set; }
        public object OBJ_Photo_CLASS { get; set; }
        public object OBJ_USER_CLASS { get; set; }
        public object OBJ_ADV_CLASS { get; set; }
        public object OBJ_MENU_CLASS { get; set; }
        public object OBJ_RPTDOC { get; set; }
        public string ErrorMsg { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public DateTime SystemDate { get; set; }
    }
}