using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchify.Data.Models
{
    public class LunchEvent
    {
        public int Id { get; set; }

        [Required]
        public User Host { get; set; }

        [Required]
        public Lunch Lunch { get; set; }

        [Required, MaxLength(255)]
        public string Location { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}
