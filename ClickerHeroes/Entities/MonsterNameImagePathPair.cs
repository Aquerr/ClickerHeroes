using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes.Entities
{
    class MonsterNameImagePathPair
    {
        public string Name { get; private set; }
        public string ImagePath { get; private set; }

        public MonsterNameImagePathPair(string name, string imagePath)
        {
            Name = name;
            ImagePath = imagePath;
        }
    }
}
