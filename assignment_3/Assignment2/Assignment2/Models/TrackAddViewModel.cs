using Assignment2.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class TrackAddViewModel
    {
        public TrackAddViewModel()
        {
           
        }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

      
        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }

        public virtual Genre Genre { get; set; }



        public virtual MediaType MediaType { get; set; }

        public class PopViewModel
        {
            [Required, StringLength(80)]            
            public string Id { get; set; }
        }
    }
}


