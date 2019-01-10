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
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Display(Name = "User Name")]
        public string Email { get; set; }
        public DayTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        [Display(Name ="Phone Number")]



        [ForeignKey("Zipcode")]
        //[Display(zipcode ="Zip Code")]
        public int? ZipcodeId { get; set; }
        public Zipcode zipcode { get; set; }

        public IEnumerable<Zipcode> ZipCode { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

}