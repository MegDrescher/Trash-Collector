using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Pickup
    {
        [Key]

        public int PickupId { get; set; }
        public string PickupDay { get; set; }

        [DisplayName("Vacation Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yyyy}")]
        public System.DateTime? VacationStart { get; set; }

        [DisplayName ("Vacation End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? VacationEnd { get; set; }

        [DisplayName("Extra Pickup Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? ExtraPickup { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}