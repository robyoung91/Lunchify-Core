using Lunchify.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lunchify.Web.Models
{
    public class LunchEventViewModel

    {
        [Required, Display(Name = "Selected Host")]
        public int SelectedUserId { get; set; }

        [Required, Display(Name = "Selected Lunch")]
        public int SelectedLunchId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Capacity { get; set; }


        public IEnumerable<SelectListItem> UserSelectList { get; set; }

        public IEnumerable<SelectListItem> LunchSelectList { get; set; }

        public LunchEvent LunchEvent { get; set; }

    }
}
