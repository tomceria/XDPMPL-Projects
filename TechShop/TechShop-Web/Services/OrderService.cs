using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop_Web.Models;
using TechShop_Web.Persistence;
using TechShop_Web.Services.IService;

namespace TechShop-Web.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public void AddCustomer(Order order)
        {
            _unitOfWork.Order.Add(order);
            _unitOfWork.Complete();
        }
    }
}
