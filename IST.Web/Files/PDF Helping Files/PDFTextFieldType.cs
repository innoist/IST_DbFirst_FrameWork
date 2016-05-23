using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IST.Web.Files
{
    public class PDFTextFieldType : PDFFieldType
    {
        public override int Type
        {
            get { return 4; }
        }

        public override string ToString()
        {
            return "TextField";
        }
    }
}