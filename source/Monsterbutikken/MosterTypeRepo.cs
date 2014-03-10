using System.Collections.Generic;
using System.Linq;
using Monsterbutikken.Models;

namespace Monsterbutikken
{
    public static class MosterTypeRepo
    {
        public static IEnumerable<MonsterJson> MonsterList
        {
            get
            {
                var list = new List<MonsterJson>
                {
                    new MonsterJson{name = "Ao (skilpadde)", price = 100000},
                    new MonsterJson{name = "Bakeneko", price = 120000},
                    new MonsterJson{name = "Basilisk", price = 175000},
                    new MonsterJson{name = "Det erymanthiske villsvin", price = 100},
                    new MonsterJson{name = "Griff", price = 100},
                    new MonsterJson{name = "Hamløper", price = 100},
                    new MonsterJson{name = "Hippogriff", price = 100},
                    new MonsterJson{name = "Hydra", price = 100},
                    new MonsterJson{name = "Kentaur", price = 100},
                    new MonsterJson{name = "Kerberos", price = 100},
                    new MonsterJson{name = "Kraken", price = 100},
                    new MonsterJson{name = "Mannbjørn", price = 100},
                    new MonsterJson{name = "Mantikora", price = 100},
                    new MonsterJson{name = "Margyge", price = 100},
                    new MonsterJson{name = "Marmæle", price = 100},
                    new MonsterJson{name = "Minotauros", price = 100},
                    new MonsterJson{name = "Nekomusume", price = 100},
                    new MonsterJson{name = "Rokk", price = 100},
                    new MonsterJson{name = "Seljordsormen", price = 100},
                    new MonsterJson{name = "Sfinks", price = 100},
                    new MonsterJson{name = "Sirene", price = 100},
                    new MonsterJson{name = "Sjøorm", price = 100},
                    new MonsterJson{name = "Succubus", price = 100},
                    new MonsterJson{name = "Valravn", price = 100},
                    new MonsterJson{name = "Vampyr", price = 100},
                    new MonsterJson{name = "Varulv", price = 100}
                };
                return list.OrderBy(m => m.name);
            }
        }

        public static MonsterJson GetMonster(string monsternavn)
        {
            return MonsterList.SingleOrDefault(m => m.name == monsternavn);
        }
    }
}