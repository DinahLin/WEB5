using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{

        public class EmployeeBaseViewModel : EmployeeAddViewModel
        {
            [Key]
            public int EmployeeId { get; set; }
        }
    
}