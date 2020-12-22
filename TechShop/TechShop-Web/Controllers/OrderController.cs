using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechShop_Web.Models;
using TechShop_Web.Services.IService;

namespace TechShop_Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IComboService _comboService;

        public OrderController(IOrderService orderService, ICustomerService customerService, IComboService comboService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _comboService = comboService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PurchaseProduct([Bind("Id,Price")] Product product)
        {
            var user = _customerService.GetCurrentUser(User);

            var order = new Order()
            {
                CustomerId = user.CustomerId,
                Date = DateTime.Now,
                ComboName = null,
                PaidPrice = product.Price,
                DeliveryAddress = user.Customer.Address,
                OrderDetails = new List<OrderDetail>()
                {
                    new OrderDetail()
                    {
                        ProductId = product.Id,
                        Quantity = 1,
                        Price = product.Price
                    }
                }
            };
            
            _orderService.AddOrder(order);
            
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PurchaseCombo([Bind("Id,Name,Price")] Combo combo)
        {
            var user = _customerService.GetCurrentUser(User);
            combo = _comboService.GetOneCombo(combo.Id);

            var order = new Order()
            {
                CustomerId = user.CustomerId,
                Date = DateTime.Now,
                ComboName = combo.Name,
                PaidPrice = combo.Price,
                DeliveryAddress = user.Customer.Address,
                OrderDetails = combo.ComboDetails.Select(o => new OrderDetail
                {
                    Price = o.Product.Price,
                    Quantity = o.Quantity,
                    ProductId = o.ProductId
                }).ToList()
            };
            
            _orderService.AddOrder(order);
            
            return RedirectToAction("Index", "Home");
        }
    }
}