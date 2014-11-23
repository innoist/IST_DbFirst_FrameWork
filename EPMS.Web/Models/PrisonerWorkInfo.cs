using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EPMS.Models.DomainModels;

namespace EPMS.Web.Models
{
    public class PrisonerWorkInfo
    {
        #region Persisted Properties
        /// <summary>
        /// Work Info ID
        /// </summary>
        [Key]
        [ForeignKey("Prisoner")]
        public int PrisonerId { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Work City
        /// </summary>
        public City WorkCity { get; set; }
        /// <summary>
        /// Iqama Number
        /// </summary>
        public string Iqama { get; set; }
        /// <summary>
        /// Iqama Expiry Date
        /// </summary>
        public DateTime IqamaExpiryDate { get; set; }
        /// <summary>
        /// Job Title in English
        /// </summary>
        public string JobTitleE { get; set; }
        /// <summary>
        /// Profession in English
        /// </summary>
        public string ProfessionE { get; set; }
        /// <summary>
        /// Job Title in Arabic
        /// </summary>
        public string JobTitleA { get; set; }
        /// <summary>
        /// Profession in Arabic
        /// </summary>
        public string ProfessionA { get; set; }
        /// <summary>
        /// Employer Name
        /// </summary>
        public string EmployerName { get; set; }
        /// <summary>
        /// Employer Address
        /// </summary>
        public string EmployerAddress { get; set; }
        /// <summary>
        /// Employer Phone
        /// </summary>
        public string EmployerPhone { get; set; }
        /// <summary>
        /// Work Info Comments
        /// </summary>
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

        #endregion
    }
}