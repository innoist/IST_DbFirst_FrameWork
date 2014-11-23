using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EPMS.Models.DomainModels
{
    public class Prisoner
    {
        #region Persisted Properties

        /// <summary>
        /// Prisoner Id
        /// </summary>
        public int PrisonerId { get; set; }
        /// <summary>
        /// Prisoner First Name English
        /// </summary>
        public string PrisonerFirstNameE { get; set; }
        /// <summary>
        /// Prisoner Middle Name English
        /// </summary>
        public string PrisonerMiddleNameE { get; set; }
        /// <summary>
        /// Prisoner Last Name English
        /// </summary>
        public string PrisonerLastNameE { get; set; }
        /// <summary>
        /// Prisoner First Name Arabic
        /// </summary>
        public string PrisonerFirstNameA { get; set; }
        /// <summary>
        /// Prisoner Middle Name Arabic
        /// </summary>
        public string PrisonerMiddleNameA { get; set; }
        /// <summary>
        /// Prisoner Last Name Arabic
        /// </summary>
        public string PrisonerLastNameA { get; set; }
        /// <summary>
        /// Prisoner CNIC #
        /// </summary>
        public string PrisonerCnic { get; set; }
        /// <summary>
        /// Prisoner Passport #
        /// </summary>
        public string PrisonerPassport { get; set; }
        /// <summary>
        /// Prisoner Passport Expiry
        /// </summary>
        public DateTime? PassportExpiryDate { get; set; }
        /// <summary>
        /// Prisoner Expiry Date Arabic
        /// </summary>
        public string PassportExpiryDateArabic { get; set; }
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

        public virtual PrisonerAddress PrisonerAddress { get; set; }

        public virtual PrisonerWorkInfo PrisonerWorkInfo { get; set; }

        public virtual PrisonerCaseInfo PrisonerCaseInfo { get; set; }

        public virtual ICollection<Attachment> Attachments{ get; set; } 
    
        #endregion

    }
}
