using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static MousseModels.Helpers;

namespace MousseModels.Models
{
    public class Session : BaseModel
    {
        public Session()
        {
            Visibility = Visibility.Members;
        }
        public string CampaignID { get; set; }
        [ForeignKey("CampaignID")]
        public Campaign Campaign { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        //TODO Default
        public Visibility Visibility { get; set; }

        public string Description { get; set; }
        public ICollection<SessionUser> SessionUsers { get; set; }

    }
}
