using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Limitation
    {
        public int id { get; set; }
        private int attraction_id, age_person;

        public int Attraction_id
        {
            get { return attraction_id; }
            set { attraction_id = value; }
        }

        public int Age_person
        {
            get { return age_person; }
            set { age_person = value; }
        }

        public Limitation() { }
        public Limitation(int attraction_id, int age_person)
        {
            this.attraction_id = attraction_id;
            this.age_person = age_person;
        }
    }
}
