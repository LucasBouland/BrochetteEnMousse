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

        DbSet<Campaign> Campaigns { get; set; }
        DbSet<Character> Characters { get; set; }
        DbSet<Session> Sessions { get; set; }
        DbSet<Scenario> Scenarios { get; set; }
        DbSet<Monster> Monsters { get; set; }
        DbSet<Map> Maps { get; set; }

    }
}
