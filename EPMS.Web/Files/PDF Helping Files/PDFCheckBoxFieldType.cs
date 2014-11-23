namespace EPMS.Web.Files
{
    public class PDFCheckBoxFieldType : PDFFieldType
    {
        public override int Type
        {
            get { return 2; }
        }

        public override string ToString()
        {
            return "CheckBox";
        }
    }
}