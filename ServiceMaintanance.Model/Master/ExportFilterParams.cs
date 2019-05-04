using System;
using System.Collections.Generic;

namespace ServiceMaintanance.Model.Master
{
    /// <summary>
    /// SearchingParams Model for all searching params
    /// </summary>
    public class ExportFilterParams
    {
        //public string Email { get; set; }
        public int CompanyId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string RailRoadId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime ?ToDate { get; set; }
    }
}
