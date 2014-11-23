using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPMS.Models.DomainModels
{
    public class PrisonerWorkInfo
    {
        #region Persisted Properties
        /// <summary>
        /// Work Info ID
        /// </summary>
        [Key]
        public int PrisonerWorkInfoId { get; set; }
        [ForeignKey("Prisoner")]
        public int PrisonerId { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        [StringLength(50, ErrorMessage = "The Country value cannot exceed 50 characters.")]
        public string Country { get; set; }
        /// <summary>
        /// City
        /// </summary>
        [ForeignKey("WorkCity")]
        public int? CityId { get; set; }
        /// <summary>
        /// Iqama Number
        /// </summary>
        [StringLength(50, ErrorMessage = "The Iqama value cannot exceed 50 characters.")]
        public string Iqama { get; set; }
        /// <summary>
        /// Iqama Expiry Date
        /// </summary>
        public DateTime? IqamaExpiryDate { get; set; }
        /// <summary>
        /// Job Title in English
        /// </summary>
        [StringLength(50, ErrorMessage = "The Job Title value cannot exceed 50 characters.")]
        public string JobTitleE { get; set; }
        /// <summary>
        /// Profession in English
        /// </summary>
        [StringLength(50, ErrorMessage = "The Profession value cannot exceed 50 characters.")]
        public string ProfessionE { get; set; }
        /// <summary>
        /// Job Title in Arabic
        /// </summary>
        [StringLength(50, ErrorMessage = "The Job Title value cannot exceed 50 characters.")]
        public string JobTitleA { get; set; }
        /// <summary>
        /// Profession in Arabic
        /// </summary>
        [StringLength(50, ErrorMessage = "The Profession value cannot exceed 50 characters.")]
        public string ProfessionA { get; set; }
        /// <summary>
        /// Employer Name
        /// </summary>
        [StringLength(50, ErrorMessage = "The Employer Name value cannot exceed 50 characters.")]
        public string EmployerName { get; set; }
        /// <summary>
        /// Employer Address
        /// </summary>
        [StringLength(100, ErrorMessage = "The Employer Address value cannot exceed 100 characters.")]
        public string EmployerAddress { get; set; }
        /// <summary>
        /// Employer Phone
        /// </summary>
        [StringLength(25, ErrorMessage = "The Employer Phone value cannot exceed 25 characters.")]
        public string EmployerPhone { get; set; }
        /// <summary>
        /// Work Info Comments
        /// </summary>
        [StringLength(250, ErrorMessage = "The Work Info Comments value cannot exceed 250 characters.")]
        public string WorkInfoComments { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
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

        #region Reference Properties
        /// <summary>
        /// Prisoner
        /// </summary>
        public virtual Prisoner Prisoner { get; set; }

        public virtual City City { get; set; }

        #endregion
    }
}
