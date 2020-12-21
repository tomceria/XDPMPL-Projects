using TechShop_Web.Services.IService;
using System.Collections.Generic;
using TechShop_Web.Models;
using TechShop_Web.Persistence;

namespace TechShop_Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetAllProducts() {
            return _unitOfWork.Product.GetAll();
        }

        public Product GetOneProduct(int id) {
            return _unitOfWork.Product.GetBy(id);
        }
        public IEnumerable<ProductType> GetProductTypes() {
            return _unitOfWork.Product.GetProductTypes();
        }
    }
}