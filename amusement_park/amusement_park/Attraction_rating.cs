using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class Attraction_rating
    {
        private int id { get; set; }
        private int person_id, attraction_id, rating;
        private string comment;

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
