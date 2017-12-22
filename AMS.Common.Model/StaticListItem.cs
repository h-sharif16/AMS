using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Common.Model
{
    /// <summary>
    /// Created By: Md. Hasan Sharif
    /// Date:       2017-Nov-18
    /// Modify History
    /// No      Name        Date            Purpose
    /// 
    /// </summary>
    [Serializable()]
    public class StaticListItem
    {
        public StaticListItem()
        {
        }

        public StaticListItem(string dataValue, string dataText)
        {
            this.DataValue = dataValue;
            this.DataText = dataText;
        }

        public string DataValue { get; set; }
        public string DataText { get; set; }
    }
}
