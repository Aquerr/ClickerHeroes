using ClickerHeroes.Entities;
using ClickerHeroes.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes.Logic
{
    class MonsterGenerator
    {
        private static Random _random = new Random();

        private static IList<MonsterNameImagePathPair> _monsterNameImagePathPairList = new List<MonsterNameImagePathPair>()
        {
            new MonsterNameImagePathPair("Zombie", "../../Images/zombie.png"),
            new MonsterNameImagePathPair("Scorpion", "../../Images/scorpion.jpg"),
            new MonsterNameImagePathPair("Cyklop", "../../Images/no_image.jpg"),
            new MonsterNameImagePathPair("Pająk", "../../Images/no_image.jpg"),
            new MonsterNameImagePathPair("Bandyta", "../../Images/no_image.jpg"),
            new MonsterNameImagePathPair("Mutant", "../../Images/no_image.jpg")
        };

        public static void GenerateNewMonster()
        {
            Monster monster = MainWindow.MonsterList.Last();
            Monster newMonster = new Monster();

            MonsterNameImagePathPair randomMonsterNameImagePathPair = GetRandomMonster();

            newMonster.Id = monster.Id + 1;
            newMonster.Health = monster.Health + 20;
            newMonster.Level = monster.Level + 1;
            newMonster.Name = randomMonsterNameImagePathPair.Name;
            newMonster.ImagePath = randomMonsterNameImagePathPair.ImagePath;
            newMonster.Money = monster.Money + 20;

            MainWindow.MonsterList.Add(newMonster);
        }

        private static MonsterNameImagePathPair GetRandomMonster()
        {
            int randomIndex = _random.Next(0, _monsterNameImagePathPairList.Count);
            return _monsterNameImagePathPairList[randomIndex];
        }
    }
}
