using BaseDatosForm.Shared;
using System.Net.Http.Json;

namespace BaseDatosForm.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();

		public Task GetCategories()
		{
			throw new NotImplementedException();
		}

        public async Task<Product> GetOneProduct(int id)
        {
			var result = await _http.GetFromJsonAsync<Product>($"api/product/{id}");
			if (result != null)
				return result;
            throw new Exception("Product not found");
		}

        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<List<Product>>("api/product");
            if (result != null)
                Products = result;

            
        }
    }
}
