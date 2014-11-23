using EPMS.Models.DomainModels;

namespace EPMS.Models.ModelMapers
{
    public static class CaseStatusMapper
    {
        public static void UpdateTo(this CaseStatus source, CaseStatus target)
        {
            target.CaseStatusId = source.CaseStatusId;
            target.CaseStatusName = source.CaseStatusName;
            target.CaseStatusDescription = source.CaseStatusDescription;

        }
    }
}
