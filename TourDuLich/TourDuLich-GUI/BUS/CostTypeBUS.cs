using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.BUS
{
    class CostTypeBUSS
    {
        private TourContext _ctx;

        public CostTypeBUSS()
        {
            _ctx = new TourContext();
        }

        public List<CostType> GetAll()
        {
            var costTypes = _ctx.CostTypes.ToList();

            return costTypes;
        }
        public CostType GetOne(int id)
        {
            // if found => return costType, else return null
            return _ctx.CostTypes.Find(id);
        }

        public void CreateOne(CostType costType)
        {
            _ctx.CostTypes.Add(costType);
            _ctx.SaveChanges();
        }

        public CostType UpdateOne(CostType costType)
        {
            // get by id
            var costTypeToUpdate = _ctx.CostTypes.Find(costType.ID);

            // update entity
            costTypeToUpdate.Name = costType.Name;

            // save change to db
            _ctx.SaveChanges();

            return costTypeToUpdate;
        }

        public void DeleteOne(int id)
        {
            var costType = _ctx.CostTypes.Find(id);
            _ctx.CostTypes.Remove(costType);
            _ctx.SaveChanges();
        }
    }
}
