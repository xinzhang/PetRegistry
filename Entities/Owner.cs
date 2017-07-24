using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Owner
    {
        public Owner()
        {
            this.Pets = new List<Pet>();
        }

        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public IList<Pet> Pets { get; set; }
    }

}
