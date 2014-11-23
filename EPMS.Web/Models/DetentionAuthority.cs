using System;
using System.ComponentModel.DataAnnotations;

namespace EPMS.Web.Models
{
    public class DetentionAuthority
    {
        #region Persisted Properties
        /// <summary>
        /// Detention Authority Id
        /// </summary>
        public int? DetentionAuthorityId { get; set; }
        /// <summary>
        /// Detention Authority Name
        /// </summary>
        [Required(ErrorMessage = "Detention Authority Name is Required")]
        [StringLength(50, ErrorMessage = "The First Name value cannot exceed 50 characters.")]
        public string DetentionAuthorityName { get; set; }
        /// <summary>
        /// Detention Authority Description
        /// </summary>
        public string DetentionAuthorityDescription { get; set; }

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