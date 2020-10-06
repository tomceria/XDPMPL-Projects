using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.BUS
{
    class TourGroupCostBUS
    {
        private TourContext _ctx;

        public TourGroupCostBUS()
        {
            _ctx = new TourContext();
        }

        public List<TourGroupCost> GetAll()
        {
            var tourGroupCosts = _ctx.TourGroupCosts.ToList();

            return tourGroupCosts;
        }
        public TourGroupCost GetOne(int id)
        {
            // if found => return tourGroupCost, else return null
            return _ctx.TourGroupCosts.Find(id);
        }

        public void CreateOne(TourGroupCost tourGroupCost)
        {
            _ctx.TourGroupCosts.Add(tourGroupCost);
            _ctx.SaveChanges();
        }

        public TourGroupCost UpdateOne(TourGroupCost tourGroupCost)
        {
            // get by id
            var tourGroupCostToUpdate = _ctx.TourGroupCosts.Find(tourGroupCost.ID);

            // update entity
            tourGroupCostToUpdate.TourGroupID = tourGroupCost.TourGroupID;
            tourGroupCostToUpdate.CostTypeID = tourGroupCost.CostTypeID;
            tourGroupCostToUpdate.Note = tourGroupCost.Note;

            // save change to db
            _ctx.SaveChanges();

            return tourGroupCostToUpdate;
        }

        public void DeleteOne(int id)
        {
            var tourGroupCost = _ctx.TourGroupCosts.Find(id);
            _ctx.TourGroupCosts.Remove(tourGroupCost);
            _ctx.SaveChanges();
        }
    }
}
