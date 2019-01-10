using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public bool TimePaid { get; set; }

        public double? TotalPaid { get; set; }
        public double? Amount {get; set;}

        public DateTime Date { get; set; }

        
        [ForeignKey("customer")]
        public int CustomerId { get; set; }

        public Customer customer { get; set; }


    }
}