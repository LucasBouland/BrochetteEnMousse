using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MousseModels.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Pseudo { get; set; }
        public ICollection<CampaignUser> CampaignUsers { get; set; }
        public ICollection<SessionUser> SessionUsers { get; set; }
    } 
}
