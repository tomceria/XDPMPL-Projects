using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.Services.IService
{
    public interface IComboService
    {
        IEnumerable<Combo> GetAllCombos();
        Combo GetOneCombo(int id);
    }
}