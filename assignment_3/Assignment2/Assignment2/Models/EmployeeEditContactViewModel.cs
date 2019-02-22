using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class EmployeeEditContactViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        [Required]
        [StringLength(60)]
        public string Email { get; set; }
    }
}