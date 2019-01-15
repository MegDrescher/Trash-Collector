using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace TrashCollector.Models
{
    public class Address
    {

        //[ForeignKey("city")]
        //public int? CityId { get; set; }
        //public City city { get; set; }

        //[ForeignKey("state")]
        //public int? StateId { get; set; }
        //public Stack state { get; set; }
        //public string State { get; set; }
        //public double? latitude { get; set; }
        //public double? longitude { get; set; }
        //public IEnumerable<ZipCode> ZipCode { get; set; }

        [ForeignKey("Zipcode")]

    }
}