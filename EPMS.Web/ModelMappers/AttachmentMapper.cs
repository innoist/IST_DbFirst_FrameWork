using System;
using System.Configuration;
using EPMS.Models.DomainModels;

namespace EPMS.Web.ModelMappers
{
    public static class AttachmentMapper
    {
        public static Models.Attachment CreateFrom(this Attachment source)
        {
            return new Models.Attachment
                   {
                       AttachmentId = source.AttachmentId,
                       AttachmentName = source.AttachmentName,
                       Comment = source.Comment,
                       CreatedBy = source.CreatedBy,
                       CreatedDate = source.CreatedDate.Value.ToShortDateString(),
                       FileName = FormatFileName(source.FileName),
                       FilePath = ConfigurationManager.AppSettings["PrisonerFiles"] + "/" + source.FileName,
                       PrisonerId = source.PrisonerId,
                       UpdatedBy = source.UpdatedBy,
                       UpdatedDate = source.UpdatedDate,
                   };
        }
        public static Attachment CreateFrom(this Models.Attachment source)
        {
            return new Attachment
            {
                AttachmentId = source.AttachmentId,
                AttachmentName = source.AttachmentName,
                Comment = source.Comment,
                CreatedBy = source.CreatedBy,
                CreatedDate = Convert.ToDateTime(source.CreatedDate),
                FileName = source.FileName,
                FilePath = source.FilePath,
                PrisonerId = source.PrisonerId,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate
            };
        }
        /// <summary>
        /// Method to remove "- PrisonerId" from FileName
        /// </summary>
        /// <param name="fileNameRecieved"></param>
        /// <returns></returns>
        private static string FormatFileName(string fileNameRecieved)
        {
            //string fileNameFormatted = string.Empty;
            //var splittedString = fileNameRecieved.Split('-');
            //for (int i = 0; i < splittedString.Length - 1; i++)
            //{
            //    fileNameFormatted = fileNameFormatted + splittedString[i];
            //}
            //return fileNameFormatted;
            return fileNameRecieved;
        }
    }
}