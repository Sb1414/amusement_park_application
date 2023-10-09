using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Person
    {
        public int id { get; set; }
        private int user_id { get; set; }
        private string name, surname, date, email;

        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

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
