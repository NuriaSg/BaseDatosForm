using BaseDatosForm.Shared;

namespace BaseDatosForm.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        List<Category> Categories { get; set; }
        Task GetCategories();
        Task GetProducts();
        Task<Product> GetOneProduct(int id);
    }
}
