using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes.Entities
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Money { get; set; }
        public string ImagePath { get; set; }
        public int Level { get; set; }
    }
}
