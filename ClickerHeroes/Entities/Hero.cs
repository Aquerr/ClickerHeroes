using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set;  }
        public string Description { get; set; }
        public int Level { get; set; }
        public int Price { get; set; }
        public int Damage { get; set; }
        public string ImagePath { get; set; }
        public bool Bought { get; set; }
    }
}
