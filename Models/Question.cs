using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFQuestionnaire.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Issue { get; set; }
        public string Answer { get; set; }

        public override string ToString()
        {
            return $"{Issue}";
        }
    }
}
