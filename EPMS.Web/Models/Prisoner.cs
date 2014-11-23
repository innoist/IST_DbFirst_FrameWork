using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EPMS.Web.Models
{
    public class Prisoner
    {
        #region Persisted Properties
        /// <summary>
        /// Prisoner Id
        /// </summary>
        public int? PrisonerId { get; set; }
        /// <summary>
        /// Prisoner First Name English
        /// </summary>
        [Required(ErrorMessage = "Prisoner First Name is required")]
        [StringLength(25, ErrorMessage = "The First Name value cannot exceed 25 characters.")]
        public string PrisonerFirstNameE { get; set; }
        /// <summary>
        /// Prisoner Middle Name English
        /// </summary>
        [Required(ErrorMessage = "Prisoner Middle Name is required")]
        [Display(Name = "Middle Name(English)")]
        [StringLength(25, ErrorMessage = "The Middle Name value cannot exceed 25 characters.")]
        public string PrisonerMiddleNameE { get; set; }
        /// <summary>
        /// Prisoner Last Name English
        /// </summary>
        [Required(ErrorMessage = "Prisoner Lase Name is required")]
        [StringLength(25, ErrorMessage = "The Last Name value cannot exceed 25 characters.")]
        public string PrisonerLastNameE { get; set; }
        /// <summary>
        /// Prisoner First Name Arabic
        /// </summary>
        [StringLength(25, ErrorMessage = "The First Name value cannot exceed 25 characters.")]
        public string PrisonerFirstNameA { get; set; }
        /// <summary>
        /// Prisoner Middle Name Arabic
        /// </summary>
        [StringLength(25, ErrorMessage = "The Middle Name value cannot exceed 25 characters.")]
        public string PrisonerMiddleNameA { get; set; }
        /// <summary>
        /// Prisoner Last Name Arabic
        /// </summary>
        [StringLength(25, ErrorMessage = "The Last Name value cannot exceed 25 characters.")]
        public string PrisonerLastNameA { get; set; }
        /// <summary>
        /// Prisoner CNIC #
        /// </summary>
        [StringLength(25, ErrorMessage = "The CNIC value cannot exceed 25 characters.")]
        public string PrisonerCnic { get; set; }
        /// <summary>
        /// Prisoner Passport #
        /// </summary>
        [StringLength(50, ErrorMessage = "The Passport value cannot exceed 50 characters.")]
        public string PrisonerPassport { get; set; }
        /// <summary>
        /// Prisoner Passport Expiry
        /// </summary>
        public DateTime? PassportExpiryDate { get; set; }
        /// <summary>
        /// Passport Expiry date Arabic
        /// </summary>
        public DateTime? PassportExpiryDateArabic { get; set; }

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
        public string FilePath { get; set; }
        public string FileName { get; set; }
        [StringLength(50, ErrorMessage = "The Attachment Name value cannot exceed 50 characters.")]
        public string AttachmentName { get; set; }
        [StringLength(250, ErrorMessage = "The Attachment Comment value cannot exceed 250 characters.")]
        public string AttachmentComment { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }

        #endregion

        #region Reference Properties
        public virtual EPMS.Models.DomainModels.PrisonerAddress PrisonerAddress { get; set; }
        public virtual EPMS.Models.DomainModels.PrisonerWorkInfo PrisonerWorkInfo { get; set; }
        public virtual EPMS.Models.DomainModels.PrisonerCaseInfo PrisonerCaseInfo { get; set; }
        public virtual EPMS.Models.DomainModels.Attachment Attachment { get; set; }
        public virtual string CaseStatus { get; set; }
        public virtual string DetentionLocation { get; set; }
        public virtual string DetentionAuthority { get; set; }
        public virtual string CaseType { get; set; }
        public IList<CaseType> CaseTypes { get; set; }
        public virtual string ImprisonmentDate { get; set; }
        public virtual string Iqama { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string PenaltyAmount { get; set; }
        public virtual string PenStatus { get; set; }
        public virtual string ReleaseDate { get; set; }
        public virtual string DetentionDate { get; set; }
        public virtual DateTime? ReleaseDateDt { get; set; }
        public virtual DateTime DetentionDateDt { get; set; }
        public virtual string EmployerName { get; set; }
        public virtual string EmployerAddress { get; set; }
        public virtual string JobTitle { get; set; }
        public virtual string Profession { get; set; }
        public virtual string EmployerContact { get; set; }
        public virtual string CourtName { get; set; }
        public virtual string CourtCity { get; set; }
        public virtual string OfficeOrBranch { get; set; }
        public virtual string QaziName { get; set; }
        public virtual string PrisonerContact1 { get; set; }
        public virtual string PrisonerContact2 { get; set; }
        public virtual string PrisonerContact3 { get; set; }

        #endregion
    }
}