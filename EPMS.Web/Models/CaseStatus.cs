using System;
using System.ComponentModel.DataAnnotations;

namespace EPMS.Web.Models
{
    public class CaseStatus
    {
        #region Persisted Properties
        /// <summary>
        /// Case Status Id
        /// </summary>
        public int? CaseStatusId { get; set; }
        /// <summary>
        /// Case Status Name
        /// </summary>
        [Required(ErrorMessage = "Case Status Name is Required")]
        [StringLength(50, ErrorMessage = "The First Name value cannot exceed 50 characters.")]
        public string CaseStatusName { get; set; }
        /// <summary>
        ///  Case Status Description
        /// </summary>
        public string CaseStatusDescription { get; set; }

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