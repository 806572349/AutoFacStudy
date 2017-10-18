using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OWinConsoleApp1
{
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        // GET /api/products  
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        // GET /api/products/id  
        public Product GetProduct(int id)
        {
            var product = repository.Get(id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        //GET  /api/products/?category=category  
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository
                .GetAll()
                .Where(r => string.Equals(r.Category, category))
                .Select(r => r);
        }

        // POST api/products insert  
        public void Post([FromBody]Product item)
        {
            repository.Add(item);
        }

        // PUT api/products/5 update  
        public void Put(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/products/5   
        public void Delete(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
