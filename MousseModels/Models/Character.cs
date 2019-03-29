using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MousseModels.Models
{
    public class Character : BaseModel
    {
        [Required]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public bool IsPlayerCharacter { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<CampaignUser> CampaignUsers { get; set; }

    }
}
