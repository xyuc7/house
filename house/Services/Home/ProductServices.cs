using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using house.Interfaces;
using house.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace house.Services.Home
{
    public class ProductServices : IProductServices
    {
        private readonly IRepository<Product> _productRepository;

        public ProductServices(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductVM>> GetAllAsync()
        {
            var productEntities = await _productRepository.ListAsync();


            var productVM = productEntities.Select(p => new ProductVM()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                SupplierId = p.SupplierId,
                CategoryId = p.CategoryId,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                UnitsOnOrder = p.UnitsOnOrder,
                ReorderLevel = p.ReorderLevel,
                Discontinued = p.Discontinued

            }).ToList();

            return productVM;
        }

        public async Task<IActionResult> CreateAsync(ProductVM vm)
        {
            var newproduct = new Product()
            {
                ProductId = vm.ProductId,
                ProductName = vm.ProductName,
                SupplierId = vm.SupplierId,
                CategoryId = vm.CategoryId,
                QuantityPerUnit = vm.QuantityPerUnit,
                UnitPrice = vm.UnitPrice,
                UnitsInStock = vm.UnitsInStock,
                UnitsOnOrder = vm.UnitsOnOrder,
                ReorderLevel = vm.ReorderLevel,
                Discontinued = vm.Discontinued

            };
            await _productRepository.AddAsync(newproduct);
            return new OkResult();
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _productRepository.SingleOrDefaultAsync(p => p.ProductId == id);
            if (product != null)
            {

                // 刪除Product
                await _productRepository.DeleteAsync(product);

                //await _productRepository.SaveChangesAsync;
            }

            return new NoContentResult();
        }

        public async Task<ActionResult<ProductVM>>GetByIdAsync(int id)
        {
            var pd = await _productRepository.SingleOrDefaultAsync(p => p.ProductId == id);
            if (pd == null)
            {
                return new NotFoundResult();

            }
            var vm = new ProductVM()
            {
                ProductId = pd.ProductId,
                ProductName = pd.ProductName,
                SupplierId = pd.SupplierId,
                CategoryId = pd.CategoryId,
                QuantityPerUnit = pd.QuantityPerUnit,
                UnitPrice = pd.UnitPrice,
                UnitsInStock = pd.UnitsInStock,
                UnitsOnOrder = pd.UnitsOnOrder,
                ReorderLevel = pd.ReorderLevel,
                Discontinued = pd.Discontinued

            };
            return new OkObjectResult(vm);
        }

        public async Task<IActionResult> UpdateAsync(ProductVM vm)
        {
            var pd = await _productRepository.SingleOrDefaultAsync(c => c.ProductId == vm.ProductId);
            if (pd == null)
            {
                return new NotFoundResult();
            }
            {
                pd.ProductId = vm.ProductId;
                pd.ProductName = vm.ProductName;
                pd.SupplierId = vm.SupplierId;
                pd.CategoryId = vm.CategoryId;
                pd.QuantityPerUnit = vm.QuantityPerUnit;
                pd.UnitPrice = vm.UnitPrice;
                pd.UnitsInStock = vm.UnitsInStock;
                pd.UnitsOnOrder = vm.UnitsOnOrder;
                pd.ReorderLevel = vm.ReorderLevel;
                pd.Discontinued = vm.Discontinued;

                await _productRepository.UpdateAsync(pd);

                return new OkObjectResult(pd);
            }
        }
    }
}
