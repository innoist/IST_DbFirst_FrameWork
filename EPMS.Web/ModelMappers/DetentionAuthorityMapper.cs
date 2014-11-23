using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPMS.Models.DomainModels;

namespace EPMS.Web.ModelMappers
{
    public static class DetentionAuthorityMapper
    {
        public static DetentionAuthority CreateFrom(this Models.DetentionAuthority source)
        {
            var caseType = new DetentionAuthority
            {
                DetentionAuthorityId = source.DetentionAuthorityId ?? 0,
                DetentionAuthorityName = source.DetentionAuthorityName,
                DetentionAuthorityDescription = source.DetentionAuthorityDescription
            };
            return caseType;
        }
        public static Models.DetentionAuthority CreateFrom(this DetentionAuthority source)
        {
            return new Models.DetentionAuthority
            {
                DetentionAuthorityId = source.DetentionAuthorityId,
                DetentionAuthorityName = source.DetentionAuthorityName,
                DetentionAuthorityDescription = source.DetentionAuthorityDescription
            };

        }
    }
}