using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MousseModels;
using MousseModels.Models;

namespace MousseModels.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Map> Maps { get; set; }

    }
}
