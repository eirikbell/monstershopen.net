using DomainModel;

namespace DataLayer.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.MonsterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataLayer.MonsterContext context)
        {
            context.Monsters.AddOrUpdate(m => m.Name,
                new Monster {Name = "Ao (skilpadde)", Price = 100000},
                new Monster {Name = "Bakeneko", Price = 120000},
                new Monster {Name = "Basilisk", Price = 175000},
                new Monster {Name = "Det erymanthiske villsvin", Price = 100},
                new Monster {Name = "Griff", Price = 100},
                new Monster {Name = "Hamløper", Price = 100},
                new Monster {Name = "Hippogriff", Price = 100},
                new Monster {Name = "Hydra", Price = 100},
                new Monster {Name = "Kentaur", Price = 100},
                new Monster {Name = "Kerberos", Price = 100},
                new Monster {Name = "Kraken", Price = 100},
                new Monster {Name = "Mannbjørn", Price = 100},
                new Monster {Name = "Mantikora", Price = 100},
                new Monster {Name = "Margyge", Price = 100},
                new Monster {Name = "Marmæle", Price = 100},
                new Monster {Name = "Minotauros", Price = 100},
                new Monster {Name = "Nekomusume", Price = 100},
                new Monster {Name = "Rokk", Price = 100},
                new Monster {Name = "Seljordsormen", Price = 100},
                new Monster {Name = "Sfinks", Price = 100},
                new Monster {Name = "Sirene", Price = 100},
                new Monster {Name = "Sjøorm", Price = 100},
                new Monster {Name = "Succubus", Price = 100},
                new Monster {Name = "Valravn", Price = 100},
                new Monster {Name = "Vampyr", Price = 100},
                new Monster {Name = "Varulv", Price = 100}
                );
        }
    }
}
