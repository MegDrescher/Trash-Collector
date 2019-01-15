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
        public int Id { get; set; }
        public object EmployeeID { get; set; }

        [Display(Name = " First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //public DateTime DOB { get; set; }
        [ForeignKey("Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Phone Number")]

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public string UserName { get; set; }
        [Display(Name = "User Name")]
        public ApplicationUser ApplicationUser { get; set; }
        public string AppUserID { get; internal set; }

    }
}

