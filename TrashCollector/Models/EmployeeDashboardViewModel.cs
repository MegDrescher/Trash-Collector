using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class EmployeeDashboardViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<TodaysPickup> TodayPickups { get; set; }
        public IEnumerable<TodaysPickup> ExtraTodayPickups { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}