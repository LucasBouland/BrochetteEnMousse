using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MousseModels.Models
{
    public class CharacterCampaign : BaseModel
    {
        public string CharacterID { get; set; }
        [ForeignKey("CharacterID")]
        public Character Character { get; set; }
        public string CampaignID { get; set; }
        [ForeignKey("CampaignID")]
        public Campaign Campaign { get; set; }
    }
}
