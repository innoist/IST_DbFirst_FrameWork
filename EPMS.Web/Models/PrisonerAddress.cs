using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPMS.Web.Models
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
        public string Province { get; set; }
        /// <summary>
        /// District
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// Tehseel
        /// </summary>
        public string Tehseel { get; set; }
        /// <summary>
        /// Post Office or City
        /// </summary>
        public string PostOfficeOrCity { get; set; }
        /// <summary>
        /// Village
        /// </summary>
        public string Village { get; set; }
        /// <summary>
        /// Home Phone
        /// </summary>
        public string HomePhone { get; set; }
        /// <summary>
        /// Mobile Phone 1
        /// </summary>
        public string MobilePhone1 { get; set; }
        /// <summary>
        /// Mobile Phone 2
        /// </summary>
        public string MobilePhone2 { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
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