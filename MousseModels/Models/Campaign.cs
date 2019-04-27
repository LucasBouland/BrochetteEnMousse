using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static MousseModels.Helpers;

namespace MousseModels.Models
{
    public class Campaign : BaseModel
    {

        public Campaign()
        {
            Visibility = Visibility.Members;
        }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        //TODO Default
        public Visibility Visibility { get; set; }
        public ICollection<CampaignUser> CampaignUsers { get; set; }
        public ICollection<CharacterCampaign> CharacterCampaigns { get; set; }

        public ICollection<Session> Sessions { get; set; }

    }
}
