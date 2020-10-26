using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.DAL
{
    class TourGroupDetailDAL
    {
        private TourContext _ctx;

        public TourGroupDetailDAL()
        {
            _ctx = new TourContext();
        }

        public List<TourGroupDetail> GetAll()
        {
            var tourGroupDetails = _ctx.TourGroupDetails.ToList();

            return tourGroupDetails;
        }
        public TourGroupDetail GetOne(int id)
        {
            // if found => return tourGroupDetail, else return null
            return _ctx.TourGroupDetails.Find(id);
        }

        public void CreateOne(TourGroupDetail tourGroupDetail)
        {
            _ctx.TourGroupDetails.Add(tourGroupDetail);
            _ctx.SaveChanges();
        }

        public TourGroupDetail UpdateOne(TourGroupDetail tourGroupDetail)
        {
            // get by id
            var tourGroupDetailToUpdate = _ctx.TourGroupDetails.Find(tourGroupDetail.ID);

            // update entity
            tourGroupDetailToUpdate.TourGroupID = tourGroupDetail.TourGroupID;
            tourGroupDetailToUpdate.CustomerID = tourGroupDetail.CustomerID;

            // save change to db
            _ctx.SaveChanges();

            return tourGroupDetailToUpdate;
        }

        public void DeleteOne(int id)
        {
            var tourGroupDetail = _ctx.TourGroupDetails.Find(id);
            _ctx.TourGroupDetails.Remove(tourGroupDetail);
            _ctx.SaveChanges();
        }
    }
}
