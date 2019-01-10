using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class DayTime
    {
        [Key]

        public int Id { get; set; }
        public string TimeOfDay { get; set; }

    }
}