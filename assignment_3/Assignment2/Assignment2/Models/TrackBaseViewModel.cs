using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Assignment2.Models
{
    public class TrackBaseViewModel :TrackAddViewModel
    {
        [Key]
        public int TrackId { get; set; }

    }
}