using System.Collections.Generic;
using TechShop_Web.Models;
using TechShop_Web.Persistence;
using TechShop_Web.Services.IService;

namespace TechShop_Web.Services
{
    public class ComboService : IComboService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComboService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IEnumerable<Combo> GetAllCombos()
        {
            return _unitOfWork.Combo.GetAll();
        }

        public Combo GetOneCombo(int id)
        {
            return _unitOfWork.Combo.GetBy(id);
        }
    }
}