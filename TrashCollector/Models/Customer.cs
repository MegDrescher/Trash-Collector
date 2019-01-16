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
        [Display(Name ="Address")]
        public string Address { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name ="ZipCode")]
        [ForeignKey("ZipCode")]
        public string ZipCode { get; set; }
        public string CustomerZip { get; set; }

        [Display(Name = "Select Employee or Customer")]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Customer Bill Amount Due")]
        public double BillAmount { get; set; }
        public bool PickupComplete { get; internal set; }
        public bool PickupStatus { get; set; }
        public double BalanceDue { get; set; }


    }
}