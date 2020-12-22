using System.Collections.Generic;
using TechShop_Web.Models;
using TechShop_Web.Persistence;
using TechShop_Web.Services.IService;

namespace TechShop_Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrder(Order order)
        {
            _unitOfWork.Order.Add(order);
            
            List<QuantityLog> quantityLogs = new List<QuantityLog>();
            foreach (var orderDetail in order.OrderDetails)
            {
                var oldQuantity = _unitOfWork.Product.GetLatestQuantityLogBy(orderDetail.ProductId)?.Quantity ?? 0;
                var quantityLog = new QuantityLog()
                {
                    ProductId = orderDetail.ProductId,
                    Date = order.Date,
                    Quantity = oldQuantity - orderDetail.Quantity
                };
                
                quantityLogs.Add(quantityLog);
            }

            _unitOfWork.Product.AddQuantityLogs(quantityLogs);
            
            _unitOfWork.Complete();
        }
    }
}