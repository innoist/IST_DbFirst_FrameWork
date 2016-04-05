using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EPMS.Models.DomainModels
{
    public class Prisoner
    {
        #region Persisted Properties

        public int PrisonerId { get; set; }
        public string PrisonerFirstNameE { get; set; }
        public string PrisonerMiddleNameE { get; set; }
        public string PrisonerLastNameE { get; set; }
        public string PrisonerFirstNameA { get; set; }
        public string PrisonerMiddleNameA { get; set; }
        public string PrisonerLastNameA { get; set; }
        public string PrisonerCnic { get; set; }
        public string PrisonerPassport { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string PassportExpiryDateArabic { get; set; }
        public string FatherOrHusbandName { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public string PassportIssuePlace { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string HeightInM { get; set; }
        public string HeightInCm { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public int? Province_ProvinceId { get; set; }
        public int? Tehseel_TehseelId { get; set; }
        public int? District_DistrictId { get; set; }
        public string PersonalInfoComments { get; set; }
        
        #endregion

        #region Reference Properties

        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual PrisonerCaseInfo PrisonerCaseInfo { get; set; }
        public virtual PrisonerWorkInfo PrisonerWorkInfo { get; set; }
        public virtual PrisonerAddress PrisonerAddress { get; set; }
    
        #endregion

    }
}
