using BaseDatosForm.Shared;

namespace BaseDatosForm.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        List<Category> Categories { get; set; }
        Task GetCategory();
        Task GetProducts();
        Task<Product> GetOneProduct(int id);
    }
}
