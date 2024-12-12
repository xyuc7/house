using ApplicationCore.Entities;
using house.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace house.Interfaces
{
    public interface IProductServices
    {
        Task<List<ProductVM>> GetAllProductAsync();

        //Task<ActionResult<ProductVM>> GetByIdAsync(string id);

        //Task<IActionResult> DeleteAsync(string id);

        //Task<IActionResult> UpdateAsync(ProductVM vm);

        //Task<IActionResult> CreateAsync(ProductVM vm);
    }
}
