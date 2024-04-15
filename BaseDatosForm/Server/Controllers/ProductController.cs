
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BaseDatosForm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
		private readonly DataContext _context;

		public ProductController(DataContext context)
        {
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products= await _context.Products.Include(sh => sh.Category).ToListAsync();
            return Ok(products);
        }

		[HttpGet("category")]
		public async Task<ActionResult<List<Product>>> GetCategories()
		{
			var categories = await _context.Categories.ToListAsync();
			return Ok(categories);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetOneProduct(int id)
		{
			var result = await _context.Products
				.Include(h => h.Category)
				.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return NotFound("Sorry, no product here. :/");
            }
            return Ok(result);
        }

		[HttpPost]
		public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
		{
			product.Category = null;
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return Ok(await GetDbProducts());
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<List<Product>>> UpdateProduct(Product product, int id)
		{
			var dbproduct = await _context.Products
			.Include(h => h.Category)
			.FirstOrDefaultAsync(h => h.Id == id);
			if(dbproduct == null)
				return NotFound("Product not found");

			dbproduct.Title = product.Title;
			dbproduct.Description = product.Description;
			dbproduct.Price = product.Price;
			dbproduct.CategoryId = product.CategoryId;

			await _context.SaveChangesAsync();
			return Ok(await GetDbProducts());
		}


		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
		{
			var dbproduct = await _context.Products
			.Include(h => h.Category)
			.FirstOrDefaultAsync(h => h.Id == id);
			if (dbproduct == null)
				return NotFound("Product not found");

			_context.Products.Remove(dbproduct);

			await _context.SaveChangesAsync();
			return Ok(await GetDbProducts());
		}

		private async Task<List<Product>> GetDbProducts()
		{
			return await _context.Products.Include(sh => sh.Category).ToListAsync();
		}
	}
}
