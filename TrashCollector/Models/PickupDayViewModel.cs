using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickupDayViewModel
    {
        [Key]
        public int Id { get; set; }
        public string PickUpDay { get; set; }
        public List<PickupDayViewModel> pickups { get; set; }
        public string DaySearch { get; set; }
        public object CustomerID { get; internal set; }
        public DateTime VacationStart { get; internal set; }
        public DateTime VacationEnd { get; internal set; }
        public DateTime ExtraPickUp { get; internal set; }
    }
}