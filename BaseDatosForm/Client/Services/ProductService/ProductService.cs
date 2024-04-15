using BaseDatosForm.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BaseDatosForm.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
		private readonly NavigationManager _navigationManager;

		public ProductService(HttpClient http,NavigationManager navigationManager)
        {
            _http = http;
			_navigationManager = navigationManager;
		}

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();

		public async Task CreateProduct(Product product)
		{
			var result = await _http.PostAsJsonAsync("api/product", product);
			await SetProducts(result);
		}

		private async Task SetProducts(HttpResponseMessage result)
		{
			var response = await result.Content.ReadFromJsonAsync<List<Product>>();
			Products = response;
			_navigationManager.NavigateTo("products");
		}

		public async Task DeleteProduct(int id)
		{
			var result = await _http.DeleteAsync($"api/product/{id}");
			await SetProducts(result);

		}

		public async Task GetCategories()
		{
			var result = await _http.GetFromJsonAsync<List<Category>>("api/product/category");
			if (result != null)
				Categories = result;

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

		public async Task UpdateProduct(Product product)
		{
			var result = await _http.PutAsJsonAsync($"api/product/{product.Id}", product);
			await SetProducts(result);
		}
	}
}
