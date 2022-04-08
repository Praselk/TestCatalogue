﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCatalogue.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
