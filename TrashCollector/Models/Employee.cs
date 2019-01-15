using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeZip { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } 

        [Display(Name ="Today's Pickup")]
        public string TodaysPickup { get; set; }
        [Display(Name = "Confirm Pickup")]
        public string ConfirmPickup { get; set; }

        [ForeignKey("Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Phone Number")]
        //public DateTime DOB { get; set; }
        
        public IEnumerable<Customer> Customers { get; set; }

        [Display(Name = "Select Employee or Customer")]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}

