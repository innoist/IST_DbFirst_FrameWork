using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPMS.Models.DomainModels
{
    public class PrisonerAddress
    {
        #region Persisted Properties
        /// <summary>
        /// Address Id
        /// </summary>
        [Key]
        [ForeignKey("Prisoner")]
        public int PrisonerId { get; set; }
        /// <summary>
        /// Province
        /// </summary>
        [StringLength(50, ErrorMessage = "The Province value cannot exceed 50 characters.")]
        public string Province { get; set; }
        /// <summary>
        /// District
        /// </summary>
        [StringLength(50, ErrorMessage = "The District value cannot exceed 50 characters.")]
        public string District { get; set; }
        /// <summary>
        /// Tehseel
        /// </summary>
        [StringLength(50, ErrorMessage = "The Tehseel value cannot exceed 50 characters.")]
        public string Tehseel { get; set; }
        /// <summary>
        /// Post Office or City
        /// </summary>
        [StringLength(50, ErrorMessage = "The Post Office or City value cannot exceed 50 characters.")]
        public string PostOfficeOrCity { get; set; }
        /// <summary>
        /// Village
        /// </summary>
        [StringLength(50, ErrorMessage = "The Village value cannot exceed 50 characters.")]
        public string Village { get; set; }
        /// <summary>
        /// Home Phone
        /// </summary>
        [StringLength(25, ErrorMessage = "The Home Phone value cannot exceed 25 characters.")]
        public string HomePhone { get; set; }
        /// <summary>
        /// Mobile Phone 1
        /// </summary>
        [StringLength(25, ErrorMessage = "The Mobile Phone 1 value cannot exceed 25 characters.")]
        public string MobilePhone1 { get; set; }
        /// <summary>
        /// Mobile Phone 2
        /// </summary>
        [StringLength(25, ErrorMessage = "The Mobile Phone 2 value cannot exceed 25 characters.")]
        public string MobilePhone2 { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
        [StringLength(250, ErrorMessage = "The Address Comment value cannot exceed 250 characters.")]
        public string AddressComments { get; set; }
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
