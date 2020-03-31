using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchify.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

    }
}
