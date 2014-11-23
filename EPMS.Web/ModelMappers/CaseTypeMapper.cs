using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using EPMS.Models.DomainModels;

namespace EPMS.Web.ModelMappers
{
    public static class CaseTypeMapper
    {

        public static CaseType CreateFrom(this Models.CaseType source)
        {
            var caseType = new CaseType
            {
                CaseTypeId = source.CaseTypeId ?? 0,
                CaseTypeName = source.CaseTypeName,
                CaseTypeDescription = source.CaseTypeDescription
            };
            return caseType;
        }
        public static Models.CaseType CreateFrom(this CaseType source)
        {
            return new Models.CaseType
            {
                CaseTypeId = source.CaseTypeId,
                CaseTypeName = source.CaseTypeName,
                CaseTypeDescription = source.CaseTypeDescription
            };

        }
    }
}