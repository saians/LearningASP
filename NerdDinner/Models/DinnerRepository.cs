using System;
using System.Linq;

namespace NerdDinner.Models
{
    public class DinnerRepository
    {
        private NerdDinnerDataContext db = new NerdDinnerDataContext();


        //QUERY METHODS

        public IQueryable<Dinner> FindAllDinner()
        {
            return db.Dinners;
        }

        public IQueryable<Dinner> FindUpcomingDinners()
        {
            return from dinner in db.Dinners
                   where dinner.EventDate > DateTime.Now
                   orderby dinner.EventDate
                   select dinner;
        }

        public Dinner GetDinnner(int id)
        {
            return db.Dinners.SingleOrDefault(d => d.DinnerID == id);
        }

        //INSERT / DELETE METHODS

        public void Add(Dinner dinner)
        {
            db.Dinners.InsertOnSubmit(dinner);
        }

        public void Delete(Dinner dinner)
        {
            db.RSVPs.DeleteAllOnSubmit(dinner.RSVPs);
            db.Dinners.DeleteOnSubmit(dinner);
        }

        //PERSISTENCE

        public void Save()
        {
            db.SubmitChanges();
        }

    }
}