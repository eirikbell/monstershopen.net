﻿using System.Data.Entity;
using DomainModel;

namespace DataLayer
{
    public class MonsterContext : DbContext
    {
        public MonsterContext()
            : base("Monster")
        {
            Database.SetInitializer<MonsterContext>(null);
        }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}