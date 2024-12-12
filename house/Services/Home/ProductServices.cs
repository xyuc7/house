using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using house.Interfaces;
using house.ViewModels.Home;


namespace house.Services.Home
{
    public class ProductServices : IProductServices
    {
        private readonly IRepository<Product> _productRepository;

        public ProductServices(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductVM>> GetAllProductAsync()
        {
            var productEntities = await _productRepository.ListAsync();


            var productVM = productEntities.Select(p => new ProductVM()
            {
                ProductID = p.ProductId,
                ProductName = p.ProductName,
                SupplierID = p.SupplierId,
                CategoryID = p.CategoryId,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                UnitsOnOrder = p.UnitsOnOrder

            }).ToList();

            return productVM;
        }


    }
}
