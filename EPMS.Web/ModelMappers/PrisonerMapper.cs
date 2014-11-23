using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Web;
using EPMS.Models.DomainModels;

namespace EPMS.Web.ModelMappers
{
    public static class PrisonerMapper
    {
        public static Prisoner CreateFrom(this Models.Prisoner source, bool isAddEdit)
        {
            var prison= new Prisoner
            {
                PrisonerId = source.PrisonerId != null ? (int) source.PrisonerId: 0,
                //PrisonerId = source.PrisonerId ,
                PrisonerFirstNameE = source.PrisonerFirstNameE,
                PrisonerMiddleNameE = source.PrisonerMiddleNameE,
                PrisonerLastNameE = source.PrisonerLastNameE,
                PrisonerFirstNameA = source.PrisonerFirstNameA,
                PrisonerMiddleNameA = source.PrisonerMiddleNameA,
                PrisonerLastNameA = source.PrisonerLastNameA,
                PrisonerCnic = source.PrisonerCnic,
                PrisonerPassport = source.PrisonerPassport,
                PassportExpiryDate = source.PassportExpiryDate,
                PassportExpiryDateArabic = source.PassportExpiryDateArabic.HasValue? source.PassportExpiryDateArabic.Value.Date.ToString(CultureInfo.InvariantCulture): string.Empty,
                PrisonerAddress = isAddEdit ? source.PrisonerAddress : null,
                PrisonerWorkInfo = isAddEdit ? source.PrisonerWorkInfo : null,
                PrisonerCaseInfo = isAddEdit ? source.PrisonerCaseInfo : null,
                Attachments = source.UploadFile != null ?new Collection<Attachment>(): null
            };
            if (source.UploadFile != null)
            {
                prison.Attachments.Add(new Attachment
                {              
                    AttachmentName = source.AttachmentName,
                    Comment = source.AttachmentComment,
                    CreatedBy = HttpContext.Current.Session["LoginID"] as string,
                    CreatedDate = DateTime.Now,
                    FileName = source.UploadFile != null? source.UploadFile.FileName :"",
                    PrisonerId = source.PrisonerId != null? (int) source.PrisonerId: 0,
                    //PrisonerId = source.PrisonerId ,
                    UpdatedBy = source.UpdatedBy,
                    UpdatedDate = source.UpdatedDate,
                });
            }
            return prison;
        }
        public static Models.Prisoner CreateFrom(this Prisoner source,bool isAddEdit)
        {
            return new Models.Prisoner
            {
                PrisonerId = source.PrisonerId,
                PrisonerFirstNameE = source.PrisonerFirstNameE,
                PrisonerMiddleNameE = source.PrisonerMiddleNameE,
                PrisonerLastNameE = source.PrisonerMiddleNameE,
                PrisonerFirstNameA = source.PrisonerFirstNameA,
                PrisonerMiddleNameA = source.PrisonerMiddleNameA,
                PrisonerLastNameA = source.PrisonerLastNameA,
                PrisonerCnic = source.PrisonerCnic,
                PrisonerPassport = source.PrisonerPassport,
                PassportExpiryDate = source.PassportExpiryDate != null ? source.PassportExpiryDate.Value.Date: (DateTime?)null,
                PassportExpiryDateArabic = !string.IsNullOrEmpty(source.PassportExpiryDateArabic)? (DateTime.Parse(source.PassportExpiryDateArabic)).Date : (DateTime?)null,
                CaseStatus = source.PrisonerCaseInfo.CaseStatus !=null ? source.PrisonerCaseInfo.CaseStatus.CaseStatusName: null,
                CaseType = source.PrisonerCaseInfo.CaseType !=null ? source.PrisonerCaseInfo.CaseType.CaseTypeName: null,
                DetentionAuthority = source.PrisonerCaseInfo.DetentionAuthority !=null ? source.PrisonerCaseInfo.DetentionAuthority.DetentionAuthorityName : null,
                DetentionLocation = source.PrisonerCaseInfo.DetentionLocation !=null ? source.PrisonerCaseInfo.DetentionLocation.DetentionLocationName: null,
                DetentionDate = source.PrisonerCaseInfo.DetentionDate.ToShortDateString(),
                ImprisonmentDate = source.PrisonerCaseInfo.ImprisonmentMonth + "M - " + source.PrisonerCaseInfo.ImprisonmentYear + "Y",
                Iqama = source.PrisonerWorkInfo.Iqama,
                Address = source.PrisonerAddress.PostOfficeOrCity +" "+ source.PrisonerAddress.Province,
                Name = source.PrisonerFirstNameE + " " + source.PrisonerMiddleNameE + " " + source.PrisonerLastNameE,
                PenaltyAmount = source.PrisonerCaseInfo.Penalty,
                PenStatus = source.PrisonerCaseInfo.PenaltyStatus,
                ReleaseDate = source.PrisonerCaseInfo.ReleaseDate !=null? source.PrisonerCaseInfo.ReleaseDate.Value.ToShortDateString(): null,
                PrisonerAddress = isAddEdit ? source.PrisonerAddress: null,
                PrisonerWorkInfo = isAddEdit ? source.PrisonerWorkInfo : null,
                PrisonerCaseInfo = isAddEdit ? source.PrisonerCaseInfo : null,
                Attachments = source.Attachments.Where(x=> x.PrisonerId == source.PrisonerId).Select(x=> x.CreateFrom())
            };
        
        }

        public static Models.Prisoner CreateFrom(this Prisoner source)
        {
            return new Models.Prisoner
            {
                PrisonerPassport = source.PrisonerPassport ?? string.Empty,
                CaseType = (source.PrisonerCaseInfo.CaseType != null &&
                                    !string.IsNullOrEmpty(source.PrisonerCaseInfo.CaseType.CaseTypeName))
                ? source.PrisonerCaseInfo.CaseType.CaseTypeName : string.Empty,
                Iqama = source.PrisonerWorkInfo.Iqama ?? string.Empty,
                Address = source.PrisonerAddress.PostOfficeOrCity ?? string.Empty + " " + source.PrisonerAddress.Province,
                Name = source.PrisonerFirstNameE + " " + source.PrisonerMiddleNameE + " " + source.PrisonerLastNameE,
                ReleaseDate = source.PrisonerCaseInfo.ReleaseDate != null? source.PrisonerCaseInfo.ReleaseDate.Value.ToShortDateString(): null,
                DetentionDate = source.PrisonerCaseInfo.DetentionDate.ToShortDateString(),
                ReleaseDateDt = source.PrisonerCaseInfo.ReleaseDate ?? null,
                DetentionDateDt = source.PrisonerCaseInfo.DetentionDate,
                //new fields for reports
                PrisonerCnic = source.PrisonerCnic,
                DetentionLocation = source.PrisonerCaseInfo.DetentionLocation != null ? source.PrisonerCaseInfo.DetentionLocation.DetentionLocationName : string.Empty,
                PenaltyAmount = source.PrisonerCaseInfo.Penalty,
                PenStatus = source.PrisonerCaseInfo.PenaltyStatus,
                ImprisonmentDate = source.PrisonerCaseInfo.ImprisonmentDate.HasValue
                ? source.PrisonerCaseInfo.ImprisonmentDate.Value.ToShortDateString() : string.Empty,
                EmployerName = source.PrisonerWorkInfo.EmployerName ?? null,
                EmployerContact = source.PrisonerWorkInfo.EmployerPhone ?? null,
                EmployerAddress = source.PrisonerWorkInfo.EmployerAddress ?? null,
                JobTitle = source.PrisonerWorkInfo.JobTitleE ?? null,
                Profession = source.PrisonerWorkInfo.ProfessionE ?? null,
                CourtName = source.PrisonerCaseInfo.CourtName ?? null,
                CourtCity = source.PrisonerCaseInfo.City !=null ? source.PrisonerCaseInfo.City.CityName: string.Empty,
                OfficeOrBranch = source.PrisonerCaseInfo.OfficeOrBench ?? null,
                QaziName = source.PrisonerCaseInfo.QaziName,
                CaseStatus = source.PrisonerCaseInfo.CaseStatus !=null ? source.PrisonerCaseInfo.CaseStatus.CaseStatusName: string.Empty,
                PrisonerContact1 = source.PrisonerAddress.HomePhone ?? null,
                PrisonerContact2 = source.PrisonerAddress.MobilePhone1 ?? null,
                PrisonerContact3 = source.PrisonerAddress.MobilePhone2 ?? null
            };

        }
    }
}