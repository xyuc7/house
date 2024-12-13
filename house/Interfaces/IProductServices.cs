using ApplicationCore.Entities;
using house.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace house.Interfaces
{
    public interface IProductServices
    {
        Task<List<ProductVM>> GetAllAsync();

        Task<ActionResult<ProductVM>> GetByIdAsync(int id);

        Task<IActionResult> DeleteAsync(int id);

        Task<IActionResult> UpdateAsync(ProductVM vm);

        Task<IActionResult> CreateAsync(ProductVM vm);

    }
}
