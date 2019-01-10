using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class TodaysPickup
    {
        [Key]
        public int Id { get; set; }
        public bool GeneralActive { get; set; }

        public bool ExtraActive { get; set; }
        [ForeignKey("customer")]
        public int CustomerId { get; set; }

        public Customer customer { get; set; }

    }
   
}


