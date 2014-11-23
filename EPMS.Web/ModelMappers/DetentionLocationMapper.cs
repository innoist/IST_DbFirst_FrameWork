using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPMS.Models.DomainModels;

namespace EPMS.Web.ModelMappers
{
    public static class DetentionLocationMapper
    {
        public static DetentionLocation CreateFrom(this Models.DetentionLocation source)
        {
            var caseType = new DetentionLocation
            {
                DetentionLocationId = source.DetentionLocationId ?? 0,
                DetentionLocationName = source.DetentionLocationName,
                DetentionLocationDescription = source.DetentionLocationDescription
            };
            return caseType;
        }
        public static Models.DetentionLocation CreateFrom(this DetentionLocation source)
        {
            return new Models.DetentionLocation
            {
                DetentionLocationId = source.DetentionLocationId,
                DetentionLocationName = source.DetentionLocationName,
                DetentionLocationDescription = source.DetentionLocationDescription
            };

        }
    }
}