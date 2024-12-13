using ApplicationCore.Entities;
using house.Interfaces;
using house.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace house.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var model = await _productServices.GetAllAsync();

            return Ok(model);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVM>> GetById(int id)
        {
            var model = await _productServices.GetByIdAsync(id);

            return Ok(model.Result);
        }

        // POST api/<ProductController>
        public async Task<IActionResult> Create([FromBody] ProductVM vm)
        {

            if (vm == null)
            {
                return BadRequest();
            }

            var model = await _productServices.CreateAsync(vm);

            return Ok(model);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ProductVM vm)
        {

            if (vm == null)
            {
                return BadRequest();
            }

            var model = await _productServices.UpdateAsync(vm);

            return Ok(model);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            var model = await _productServices.DeleteAsync(id);

            return Ok(model);
        }
    }
}
