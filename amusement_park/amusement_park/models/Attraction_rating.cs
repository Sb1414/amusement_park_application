using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Attraction_rating
    {
        public int id { get; set; }
        private int person_id, attraction_id, rating;
        private string comment;

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

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public Attraction_rating() { }
        public Attraction_rating(int person_id, int attraction_id, int rating, string comment)
        {
            this.person_id = person_id;
            this.attraction_id = attraction_id;
            this.rating = rating;
            this.comment = comment;
        }
    }
}
