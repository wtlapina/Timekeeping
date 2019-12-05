using System;

namespace Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string EmpCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}