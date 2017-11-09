using System;
using System.Web;

namespace AMS.SessionUtility
{
    [Serializable]
    public class SessionUtility
    {
        private const string SESSION_KEY_PREFIX = "__AMS__";

        public static SessionContainer AmsSessionContainer
        {
            set
            {
                if (HttpContext.Current.Session != null)
                {
                    HttpContext.Current.Session[SESSION_KEY_PREFIX + "SessionContainer"] = value;
                }
            }
            get
            {
                if (HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session[SESSION_KEY_PREFIX + "SessionContainer"] != null)
                    {
                        return (SessionContainer) HttpContext.Current.Session[SESSION_KEY_PREFIX + "SessionContainer"];
                    }
                    return new SessionContainer();
                }
                return new SessionContainer();
            }
        }
    }
}