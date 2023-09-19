using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Attraction
    {
        public int id { get; set; }
        private string name, description;
        private int capacity, ticket_price, time_work;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Ticket_price
        {
            get { return ticket_price; }
            set { ticket_price = value; }
        }

        public int Time_work
        {
            get { return time_work; }
            set { time_work = value; }
        }

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
