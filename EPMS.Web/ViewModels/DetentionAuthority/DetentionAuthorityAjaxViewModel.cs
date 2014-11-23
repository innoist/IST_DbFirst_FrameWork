using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPMS.Models.RequestModels;

namespace EPMS.Web.ViewModels.DetentionAuthority
{
    public class DetentionAuthorityAjaxViewModel
    {
        /// <summary>
        /// To draw table
        /// </summary>
        private int draw = 1;

        /// <summary>
        /// Total Records in DB
        /// </summary>
        public int recordsTotal;

        /// <summary>
        /// Total Records Filtered
        /// </summary>
        public int recordsFiltered;

        /// <summary>
        /// Data
        /// </summary>
        public IEnumerable<Models.DetentionAuthority> data;
        /// <summary>
        /// Search Request
        /// </summary>
        public DetentionAuthoritySearchRequest DetentionAuthoritySearchRequest { get; set; }
    }
}