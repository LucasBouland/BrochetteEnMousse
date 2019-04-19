using MousseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrochetteEnMousse.Services
{
    public interface ICampaignService
    {
        IEnumerable<Campaign> Index();
        Campaign Create(Campaign c);
        Campaign Read(Guid id);
        Campaign Update(Campaign c, Guid id);
        Campaign Delete(Guid id);
    }
}
