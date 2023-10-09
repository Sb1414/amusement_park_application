using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Ticket
    {
        public int id { get; set; }
        private int person_id, attraction_id;

        public int Person_id
        {
            get { return person_id; }
            set { person_id = value; }
        }

        public int Attraction_id
        {
            get { return attraction_id; }
            set { attraction_id = value; }
        }

        public Ticket() { }
        public Ticket(int person_id, int attraction_id)
        {
            this.person_id = person_id;
            this.attraction_id = attraction_id;
        }
    }
}
