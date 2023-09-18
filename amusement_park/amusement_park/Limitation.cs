using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Limitation
    {
        private int id { get; set; }
        private int attraction_id, age_person;
        public Limitation() { }
        public Limitation(int attraction_id, int age_person)
        {
            this.attraction_id = attraction_id;
            this.age_person = age_person;
        }
    }
}
