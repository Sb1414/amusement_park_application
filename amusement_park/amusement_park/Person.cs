using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Person
    {
        private int id { get; set; }
        private int user_id { get; set; }
        private string name, surname, date, email;

        public Person() { }
        public Person(string name, string surname, string date, string email)
        {
            this.name = name;
            this.surname = surname;
            this.date = date;
            this.email = email;
        }
    }
}
