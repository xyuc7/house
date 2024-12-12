using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using house.ViewModels.Home;


namespace house.Services.Home
{
    public class ProductServices
    {
        private readonly IRepository<Product> _productRepository;

        public ProductServices(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductVM> GetProductVMAsync() 
        {
            var productEntities = await _productRepository.ListAsync();


            var productVM = new ProductVM() 
            {
            
            
            };

            return productVM;
        }


    }
}
