using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Zipcode
    {
        [Key]

        public int Id { get; set; }
        public string zipcode { get; set; }
    }
}