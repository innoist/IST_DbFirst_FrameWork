using System;

namespace EPMS.Models.DomainModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RollNumber { get; set; }
        public int Age { get; set; }
        public int Contact { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public string MartialStatus { get; set; }
        public string EmailAddress { get; set; }
    }
}
