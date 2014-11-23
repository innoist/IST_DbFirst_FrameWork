using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EPMS.Models.DomainModels;

namespace EPMS.Web.Models
{
    public class PrisonerCaseInfo
    {
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
        public DetentionAuthority DetentionAuthority { get; set; }
        /// <summary>
        /// Detention Location
        /// </summary>
        public DetentionLocation DetentionLocation { get; set; }
        /// <summary>
        /// File Number
        /// </summary>
        public string FileNumber { get; set; }
        /// <summary>
        /// Violator's Number
        /// </summary>
        public string ViolatorsNumber { get; set; }
        /// <summary>
        /// Lockup Number
        /// </summary>
        public string LockupNumber { get; set; }
        /// <summary>
        /// Case Type
        /// </summary>
        public CaseType CaseType { get; set; }
        /// <summary>
        /// Caste Status
        /// </summary>
        public CaseStatus CaseStatus { get; set; }
        /// <summary>
        /// Case Info Comments
        /// </summary>
        public string CaseInfoComments { get; set; }
        /// <summary>
        /// Court Name
        /// </summary>
        public string CourtName { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public City City { get; set; }
        /// <summary>
        /// Office or Bench
        /// </summary>
        public string OfficeOrBench { get; set; }
        /// <summary>
        /// QaziName
        /// </summary>
        public string QaziName { get; set; }
        /// <summary>
        /// Case Under Trial Comments
        /// </summary>
        public string CaseUnderTrialComments { get; set; }
        /// <summary>
        /// Imprisonment Date
        /// </summary>
        public DateTime ImprisonmentDate { get; set; }
        /// <summary>
        /// Release Date
        /// </summary>
        public DateTime ReleaseDate { get; set; }
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
        public DateTime OutpassIssueDate { get; set; }
        /// <summary>
        /// Case Closed Comments
        /// </summary>
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

        #endregion
    }
}