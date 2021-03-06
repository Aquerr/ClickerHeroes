﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes.Entities
{
    public class EntitesList
    {
        //TODO: Wszystkie listy powinny być automatycznie generowane.

        //Lista herosów póki co musi pozostać bez zmian.
        public static List<Hero> HeroList = new List<Hero>()
        {
            new Hero() { Id = 1,Bought = false, Name = "Patryk", Damage = 1, Level = 0, Price = 10 },
            new Hero() { Id = 2,Bought = false, Name = "Michał", Damage = 2, Level = 0, Price = 50 },
            new Hero() { Id = 3,Bought = false, Name = "Rafał", Damage = 3, Level = 0, Price = 100 },
            new Hero() { Id = 4,Bought = false, Name = "Bartek", Damage = 4, Level = 0, Price = 100 },
            new Hero() { Id = 5,Bought = false, Name = "Maciek", Damage = 5, Level = 0, Price = 100 },
            new Hero() { Id = 6,Bought = false, Name = "Zbychu", Damage = 6, Level = 0, Price = 100 },
            new Hero() { Id = 7,Bought = false, Name = "Rychu", Damage = 7, Level = 0, Price = 100 }
        };

        //TODO: Miejsc powinno być tylko kilka. Np. Pustkowia, Pustynia, Morze i Las.
        //TODO: Następnie program powinien generować z nich kolejne mapy.
        public static List<Place> PlaceList = new List<Place>()
        {
            new Place() { Id = 1, Level = 1, Name = "Pustkowia", NumberOfMonsters = 10 },
            new Place() { Id = 2, Level = 2, Name = "Pustkowia", NumberOfMonsters = 10 },
            new Place() { Id = 3, Level = 3, Name = "Pustkowia", NumberOfMonsters = 10 },
            new Place() { Id = 4, Level = 4, Name = "Pustkowia", NumberOfMonsters = 10 },
            new Place() { Id = 5, Level = 5, Name = "Pustkowia", NumberOfMonsters = 1 },
            new Place() { Id = 6, Level = 6, Name = "Pustkowia", NumberOfMonsters = 10 },
            new Place() { Id = 7, Level = 7, Name = "Pustkowia", NumberOfMonsters = 10 },
            new Place() { Id = 8, Level = 8, Name = "Pustkowia", NumberOfMonsters = 10 },
            new Place() { Id = 9, Level = 9, Name = "Pustkowia", NumberOfMonsters = 10 },
            new Place() { Id = 10, Level = 10, Name = "Pustkowia", NumberOfMonsters = 1 }
        };

        //TODO: Potworów powinno być kilka. Np. Pirania, Skorpion, Zombie itp.
        //TODO: Następnie program powinien generować z nich kolejne potwory... z nowym Id, DMG itd.
        public static List<Monster> MonsterList = new List<Monster>()
        {
            new Monster() { Id = 1,Level = 1, Health = 4, Money = 5, Name = "Zombie", ImagePath = "../../Images/zombie.png"},
            new Monster() { Id = 2,Level = 2, Health = 5, Money = 10, Name = "Skorpion", ImagePath = "../../Images/scorpion.jpg"},
            new Monster() { Id = 3,Level = 3, Health = 10, Money = 20, Name = "Cyklop" , ImagePath = "../../Images/no_image.jpg"},
            new Monster() { Id = 4,Level = 4, Health = 20, Money = 30, Name = "Mutant" , ImagePath = "../../Images/no_image.jpg"},
            new Monster() { Id = 5,Level = 5, Health = 30, Money = 40, Name = "Pająk"  , ImagePath = "../../Images/no_image.jpg"},
            new Monster() { Id = 6,Level = 6, Health = 70, Money = 50, Name = "Bandyta", ImagePath = "../../Images/no_image.jpg"},
            new Monster() { Id = 7,Level = 7, Health = 100, Money = 60, Name = "Kamień" , ImagePath = "../../Images/no_image.jpg"},
            new Monster() { Id = 8,Level = 8, Health = 200, Money = 70, Name = "Zombie" , ImagePath = "../../Images/no_image.jpg"}
        };
    }
}
