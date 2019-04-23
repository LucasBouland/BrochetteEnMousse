using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static MousseModels.Helpers;

namespace MousseModels.Models
{
    public class CampaignViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Visibility Visibility { get; set; }
        public List<string> Players { get; set; }
    }
}
