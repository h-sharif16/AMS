using System;

namespace AMS.Common.Model
{
    /// <summary>
    ///     Created By: Md. Hasan Sharif
    ///     Date:       2017-Aug-05
    ///     Modify History
    ///     No      Name        Date            Purpose
    ///     1       Hasa      2017-Aug-05     Add "CreateDate" propertics
    /// </summary>
    [Serializable]
    public class BaseModel
    {
        public bool IsNew { get; set; }
        public bool IsDirty { get; set; }
        public bool IsDelete { get; set; }

        public bool Status { get; set; }
        public DateTime SystemDate { get; set; }
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Remark { get; set; }
    }
}