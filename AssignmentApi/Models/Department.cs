﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public ICollection<Employee> employees { get; set; }
    }
}
