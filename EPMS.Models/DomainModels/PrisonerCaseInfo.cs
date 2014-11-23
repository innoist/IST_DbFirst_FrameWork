using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPMS.Models.DomainModels
{
    public class PrisonerCaseInfo
    {
        public int PrisonerCaseInfoId { get; set; }
        #region Persisted Properties
        /// <summary>
        /// Prisoner Case Info Id
        /// </summary>
        [Key]
        [ForeignKey("Prisoner")]
        public int PrisonerId { get; set; }
        /// <summary>
        /// Detention Date
        /// </summary>
        public DateTime DetentionDate { get; set; }
        /// <summary>
        /// Detention Authority
        /// </summary>
        [ForeignKey("DetentionAuthority")]
        public int? DetentionAuthorityId { get; set; }
        /// <summary>
        /// Detention Location
        /// </summary>
        [ForeignKey("DetentionLocation")]
        public int? DetentionLocationId { get; set; }
        /// <summary>
        /// File Number
        /// </summary>
        [StringLength(50, ErrorMessage = "The File Number value cannot exceed 50 characters.")]
        public string FileNumber { get; set; }
        /// <summary>
        /// Violator's Number
        /// </summary>
        [StringLength(250, ErrorMessage = "The Violators Number value cannot exceed 250 characters.")]
        public string ViolatorsNumber { get; set; }
        /// <summary>
        /// Lockup Number
        /// </summary>
        [StringLength(100, ErrorMessage = "The Lockup Number value cannot exceed 100 characters.")]
        public string LockupNumber { get; set; }
        /// <summary>
        /// Case Type
        /// </summary>
        [ForeignKey("CaseType")]
        public int? CaseTypeId { get; set; }
        /// <summary>
        /// Caste Status
        /// </summary>
        [ForeignKey("CaseStatus")]
        public int? CaseStatusId { get; set; }
        /// <summary>
        /// Case Info Comments
        /// </summary>
        [StringLength(250, ErrorMessage = "The Case Info Comments value cannot exceed 250 characters.")]
        public string CaseInfoComments { get; set; }
        /// <summary>
        /// Court Name
        /// </summary>
        [StringLength(50, ErrorMessage = "The Court Name value cannot exceed 50 characters.")]
        public string CourtName { get; set; }
        /// <summary>
        /// City
        /// </summary>
        [ForeignKey("City")]
        public int? CityId { get; set; }
        /// <summary>
        /// Office or Bench
        /// </summary>
        [StringLength(100, ErrorMessage = "The Office or Bench value cannot exceed 50 characters.")]
        public string OfficeOrBench { get; set; }
        /// <summary>
        /// QaziName
        /// </summary>
        [StringLength(50, ErrorMessage = "The Qazi Name value cannot exceed 50 characters.")]
        public string QaziName { get; set; }
        /// <summary>
        /// Case Under Trial Comments
        /// </summary>
        [StringLength(250, ErrorMessage = "The Case Under Trial Comments value cannot exceed 250 characters.")]
        public string CaseUnderTrialComments { get; set; }
        /// <summary>
        /// Imprisonment Date
        /// </summary>
        public DateTime? ImprisonmentDate { get; set; }
        /// <summary>
        /// Imprisonment Month
        /// </summary>
        public string ImprisonmentMonth { get; set; }
        /// <summary>
        /// Imprisonment year
        /// </summary>
        public string ImprisonmentYear { get; set; }
        /// <summary>
        /// Release Date
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// Death Sentence?
        /// </summary>
        public bool DeathSentence { get; set; }
        /// <summary>
        /// Penalty
        /// </summary>
        public string Penalty { get; set; }
        /// <summary>
        /// Penalty Status
        /// </summary>
        public string PenaltyStatus { get; set; }
        /// <summary>
        /// Outpass Issue Date
        /// </summary>
        public DateTime? OutpassIssueDate { get; set; }
        /// <summary>
        /// Case Closed Comments
        /// </summary>
        [StringLength(250, ErrorMessage = "The Case Close Comments value cannot exceed 250 characters.")]
        public string CaseCloseComments { get; set; }
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
        public virtual CaseType CaseType { get; set; }
        public virtual CaseStatus CaseStatus { get; set; }

        public virtual City City { get; set; }
        public virtual DetentionAuthority DetentionAuthority { get; set; }

        public virtual DetentionLocation DetentionLocation { get; set; }
        
        #endregion
    }
}
