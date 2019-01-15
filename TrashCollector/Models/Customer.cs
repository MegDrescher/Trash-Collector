using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [ForeignKey("Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
   
        [Display(Name = "Was the trash picked up?")]
        public bool PickupComplete { get; set; }

        [Display(Name = "Pick Up Day Request: Enter your preferred scheduled start date.")]
        public string PickUpStartDate { get; set; }

        [Display(Name = "Pick Up Day Request: Enter your preferred scheduled end date.")]
        public string PickUpEndDate { get; set; }

        [Display(Name ="Schedule Extra Pick Up Day Request: Enter one extra day you'd like to schedule your pick up.")]
        public string CustomPickup { get; set; }

        [Display(Name = "Select Employee or Customer")]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Customer Bill Amount Due")]
        public double BillAmount { get; set; }

    }
}