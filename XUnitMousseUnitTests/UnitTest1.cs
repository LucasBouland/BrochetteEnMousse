using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using MousseModels.Data;
using MousseModels.Models;

namespace XUnitMousseUnitTests
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BrochetteLocal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var _context = new ApplicationDbContext(optionsBuilder.Options);
            var campaign =  _context.Campaigns.FirstOrDefaultAsync( c => c.Name == "TestCampaignAll");
            Assert.NotNull(campaign);

        }
    }
}
