using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPMS.Web.Models
{
    public class DetentionLocation
    {
        #region Persisted Properties
        /// <summary>
        /// Detention Location Id
        /// </summary>
        public int? DetentionLocationId { get; set; }
        /// <summary>
        /// Detention Location Name
        /// </summary>
        [Required(ErrorMessage = "Detention Location Name is Required")]
        [StringLength(50, ErrorMessage = "The First Name value cannot exceed 50 characters.")]
        public string DetentionLocationName { get; set; }
        /// <summary>
        /// Detention Location Description
        /// </summary>
        public string DetentionLocationDescription { get; set; }

        public string CreatedBy { get; set; }
        /// <summary>
        /// Record Updated By
        /// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Record Updated Date
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        #endregion
    }
}