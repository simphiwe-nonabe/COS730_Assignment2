using Microsoft.EntityFrameworkCore;
using LotusOrganiser.Entities;

namespace LotusOrganiser.Data
{
    public class LotusOrganiserDbContext : DbContext
    {
        public LotusOrganiserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<Person> Persons { get; set; }

    }
}