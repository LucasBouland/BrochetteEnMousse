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
            campaigns.Add(c);
            return c;
        }

        public void Delete(Guid id)
        {
            var existing = campaigns.First(a => a.ID == id.ToString());
            campaigns.Remove(existing);
        }

        public IEnumerable<Campaign> Index()
        {
            return campaigns;
        }

        public Campaign Read(Guid id)
        {
            return campaigns.Where(a => a.ID == id.ToString())
            .FirstOrDefault();
        }

        public void Update(Campaign c, Guid id)
        {
            var camp = campaigns.Where(a => a.ID == id.ToString()).FirstOrDefault();
            camp = c;
        }
    }
}
