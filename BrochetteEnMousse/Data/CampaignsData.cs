using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrochetteEnMousse.Services;
using MousseModels.Models;

namespace BrochetteEnMousse.Data
{
    public class CampaignsData : ICampaignService
    {
        private readonly List<Campaign> campaigns;

        public CampaignsData()
        {
            campaigns = new List<Campaign>()
            {
                new Campaign() { Name = "Campaign1", Description="Campaign description 1"},
                new Campaign() { Name = "Campaign2", Description="Campaign description 2"},
                new Campaign() { Name = "Campaign3", Description="Campaign description 3" }
            };
        }

        public Campaign Create(Campaign c)
        {
            throw new NotImplementedException();
        }

        public Campaign Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Campaign> Index()
        {
            return campaigns;
        }

        public Campaign Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public Campaign Update(Campaign c, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
