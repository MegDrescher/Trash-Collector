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

        [Display(Name = "Pick Up Day Request: Enter your preferred scheduled start date.")]
        public string PickUpStartDate { get; set; }

        [Display(Name = "Pick Up Day Request: Enter your preferred scheduled end date.")]
        public string PickUpEndDate { get; set; }

        [Display(Name = "Schedule Extra Pick Up Day Request: Enter one extra day you'd like to schedule your pick up.")]
        public string CustomPickup { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public bool ConfirmPickup { get; set; }
    }
}