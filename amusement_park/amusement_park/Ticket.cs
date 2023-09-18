using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Ticket
    {
        private int id { get; set; }
        private int person_id { get; set; }
        private int attraction_id { get; set; }

        public Ticket() { }
        public Ticket(int person_id, int attraction_id)
        {
            this.person_id = person_id;
            this.attraction_id = attraction_id;
        }
    }
}
