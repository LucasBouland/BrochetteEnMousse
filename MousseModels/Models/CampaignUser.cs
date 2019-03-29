using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MousseModels.Models
{
    public class CampaignUser: BaseModel
    {
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        public string CampaignID { get; set; }
        [ForeignKey("CampaignID")]
        public Campaign Campaign { get; set; }
        [Required]
        public bool IsGameMaster { get; set; }
    }
}
