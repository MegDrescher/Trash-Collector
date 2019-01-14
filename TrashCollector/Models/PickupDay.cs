using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickupDay
    {
        [Key]
        public int Id { get; set; }
        public string PickUpDay { get; set; }
        public object CustomerID { get; internal set; }
    }
}