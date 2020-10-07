using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Hero
{
    public class Hero
    {
        public int id { get; set; }
        public string name { get; set; }

        public Hero (int Id, string Name){
            id = Id;
            name = Name;
        }


    }
    
}
