using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFQuestionnaire.Models
{
    class Report
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double ResultPrecent { get; set; }
        public DateTime DateSurvey { get; set; }
    }
}
