using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Attraction
    {
        private int id { get; set; }
        private string name, description;
        private int capacity, ticket_price, time_work;

        public Attraction() { }
        public Attraction(string name, string description, int capacity, int ticket_price, int time_work)
        {
            this.name = name;
            this.description = description;
            this.capacity = capacity;
            this.ticket_price = ticket_price;
            this.time_work = time_work;
        }

    }
}
