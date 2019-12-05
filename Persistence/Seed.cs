using System.Linq;
using Domain;
using System.Collections.Generic;
using System;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if(!context.Empoloyees.Any())
            {
                var employees = new List<Employee>
                {
                    new Employee
                    {
                        EmpCode = "000001",
                        LastName = "Lapina",
                        FirstName = "Walter",
                        MiddleName = "Taboada",
                        DateCreated = DateTime.Now
                    },
                    new Employee
                    {
                        EmpCode = "000002",
                        LastName = "Lapina",
                        FirstName = "Jackie",
                        MiddleName = "Sevilla",
                        DateCreated = DateTime.Now
                    }
                };

                context.Empoloyees.AddRange(employees);
                context.SaveChanges();
            }
        }
    }
}