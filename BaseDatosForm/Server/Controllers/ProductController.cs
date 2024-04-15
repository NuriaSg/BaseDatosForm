
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BaseDatosForm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public static List<Category> category = new List<Category>{
          new Category{Id=1, Name= "Square Cubes"},
          new Category{Id=2, Name= "Triangular Cubes"},
          new Category{Id=3, Name= "Special Cubes"}
        };
    
        public static List<Product> products = new List<Product>{
          new Product{Id=1, Title= "Classic Rubik's Cube", 
              Description="The Rubik's Cube is a three-dimensional mechanical puzzle created by Hungarian sculptor and architecture professor Ernő Rubik in 1974.", 
              Price=9.99m,
              Category = category[0]
          },

          new Product{
                    Id = 2,
                    Title = "Pyraminx",
                    Description = "The Pyraminx is a mechanical puzzle shaped like a tetrahedron similar to a Rubik's cube. It was invented by Uwe Meffert in 1970.",
                    Price = 7.99m,
                    Category = category[1]
          },
          new Product{
                    Id = 3,
                    Title = "Skewb",
                    Description = "The Skewb is a three-dimensional mechanical puzzle like a Rubik's cube, made up of pieces that can rotate and change position.",
                    Price = 9.99m,
                    Category = category[2]

                },
          new Product{
                    Id = 4,
                    Title = "Megaminx",
                    Description = "The Megaminx, or \"Magic Dodecahedron\", was invented by several people simultaneously and produced by different manufacturing companies with slightly different designs.\r\nThe Megaminx has the shape of a dodecahedron, it has 12 central pieces, one on each face; 20 corners and 30 edges.",
                    Price = 20.99m,
                    Category = category[2]

                },

        };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetOneProduct(int id)
        {
            var product= products.FirstOrDefault(h => h.Id == id);
            if (product == null)
            {
                return NotFound("No product here");
            }
            return Ok(products);
        }

    }
}
