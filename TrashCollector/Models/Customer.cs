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
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Display(Name ="User Name")]
        public string Email { get; set; }

        //[Display(PhoneNumber ="Phone Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [ForeignKey("City")]

        public int? CityId { get; set; }
        public City city { get; set; }

        [ForeignKey("State")]

        public int? StateId { get; set; }
        public State state { get; set; }
        public string State { get; set; }

        [ForeignKey("Zipcode")]
        //[Display(zipcode ="Zip Code")]
        public int? ZipcodeId { get; set; }
        public Zipcode zipcode { get; set; }

       




    }
}