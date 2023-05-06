using AmazonProducts.DbContext;
using AmazonProducts.Models;
using Dapper;

namespace AmazonProducts.Repositories
{
    public class Products : IProducts
    {
        private readonly DapperContext _dapperContext;

        public Products(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }


        public List<Product> GetProducts()
        {
            var query = "EXEC dbo.spGetAllProducts";

            using (var connection = _dapperContext.CreateConnection())
            {
                var products = connection.Query<Product>(query);
                return products.ToList();
            }
        }

        public Product GetProduct(int id)
        {
            var query = "EXEC dbo.spGetProductbyId @Id = @Id";

            using (var connection = _dapperContext.CreateConnection())
            {
                var product = connection.QueryFirstOrDefault<Product>(query, new { Id = id });
                return product;
            }
        }

        public void AddProduct(Product product)
        {
            var query = "EXEC spAddProduct @Name = @ProductName, @Price = @ProductPrice";

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, new {ProductName = product.Name, ProductPrice = product.Price});
            }
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }

            var query = "EXEC dbo.spUpdateProduct @Name = @ProductName, @Price = @ProductPrice, @Id = @ProductId";

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, new {ProductName = product.Name, ProductPrice = product.Price, ProductId = product.Id});
            }
        }

        public void DeleteProduct(int id)
        {
            var query = "EXEC spDeleteProduct @Id = @ProductId";

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, new { ProductId = id });
            }
        }


    }
}
