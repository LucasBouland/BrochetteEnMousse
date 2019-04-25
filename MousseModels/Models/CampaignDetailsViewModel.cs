using System;
using System.Collections.Generic;
using System.Text;

namespace MousseModels.Models
{
    public class CampaignDetailsViewModel
    {
        public Campaign Campaign { get; set; }
        public Session Session { get; set; }
        public Character Character { get; set; }
        public CampaignUser CampaignUser { get; set; }
        public List<User> Users { get; set; }
        public List<CampaignUser> CampaignUsers { get; set; }
    }
}
