using BrochetteEnMousse.Controllers;
using Microsoft.AspNetCore.Mvc;
using MousseModels.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using MousseModels.Data;

namespace XUnitTestMousse.Controller
{
    public class CampaignTest
    {

        [Fact]
        public async Task IndexTestAsync()
        {
            
        }

        [Fact]
        public async Task Details()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=brochetteMousse;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var _context = new ApplicationDbContext(optionsBuilder.Options);
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Name == "TestCampaignAll");
            Console.WriteLine(campaign);
            Assert.NotNull(campaign);

        }

        [Fact]
        public void CreateTest()
        {

        }

        [Fact]
        public void SelectTest()
        {

        }

        [Fact]
        public void EditTest()
        {

        }

        [Fact]
        public void DeleteTest()
        {

        }
        
    }
}
