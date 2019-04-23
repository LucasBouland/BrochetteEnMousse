using BrochetteEnMousse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using MousseModels.Data;
using MousseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrochetteEnMousse.Services.Infrastructure
{
    public class CampaignRepository : ICrudTest<Campaign>
    {

        private readonly ApplicationDbContext _dbContext;

        public CampaignRepository (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create()
        {
            throw new NotImplementedException();
        }

        public Task Create(Campaign obj)
        {
            _dbContext.Campaigns.Add(obj);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConfirmed(Campaign obj)
        {
            _dbContext.Remove(obj);
            return _dbContext.SaveChangesAsync();
        }

        public Task<Campaign> Details(string id)
        {
            return _dbContext.Campaigns
                .Include(s => s.Name)
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public Task<List<Campaign>> Index()
        {
            return _dbContext.Campaigns
                .Include(s => s.Name)
                .OrderByDescending(s => s.Name)
                .ToListAsync();
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, Campaign obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }
    }
}
