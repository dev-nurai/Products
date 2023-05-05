using Products.Models;
using System.Collections.Generic;

namespace Products.Repositories
{
    public interface IProducts
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);

    }
}
