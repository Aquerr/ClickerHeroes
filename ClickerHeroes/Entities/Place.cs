using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroes.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int NumberOfMonsters { get; set; }
    }
}
