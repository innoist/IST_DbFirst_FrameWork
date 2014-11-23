using System.Collections.Generic;
using EPMS.Models.DomainModels;
using EPMS.Models.RequestModels;

namespace EPMS.Web.ViewModels.Prisoner
{
    public class PrisonerAjaxViewModel
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
        public IEnumerable<Models.Prisoner> data;
        /// <summary>
        /// Search Request
        /// </summary>
        public PrisonerSearchRequest PrisonerSearchRequest { get; set; }
    }
}