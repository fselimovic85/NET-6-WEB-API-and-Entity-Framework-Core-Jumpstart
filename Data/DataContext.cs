using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id=1, Name="FireBall", Damage=30 },
                new Skill { Id = 2, Name = "Frenzy", Damage = 20},
                new Skill { Id = 3, Name = "Blizzard", Damage = 50 }
                );
        }
        public DbSet<Character> Characters {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Weapon> Weapon {get; set;}
        public DbSet<Skill> Skills {get; set;}



    }
}