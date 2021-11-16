using Microsoft.EntityFrameworkCore;
using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData
{
    public class PartyFinderContext : DbContext
    {
        
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Event> Event { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=hildur.ucn.dk; User=dmaa0920_1086216; Database=dmaa0920_1086216; Password=Password1!;Trusted_Connection=False;");
        }

    }
}
