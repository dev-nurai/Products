﻿using Dapper;
using Products.Models;
using Products.DbContext;
using System.Linq;

namespace Products.Repositories
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
            var query = "SELECT * FROM Products";
            
            using (var connection = _dapperContext.CreateConnection())
            {
                var products = connection.Query<Product>(query);
                return products.ToList();
            }

        }

        public Product GetProduct(int id)
        {
            var query = "SELECT * FROM Products WHERE Id = @Id";

            using (var connection = _dapperContext.CreateConnection())
            {
                var product = connection.QueryFirstOrDefault<Product>(query, new {Id = id});
                return product;
            }
        }

        public void AddProduct(Product product)
        {
            var query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";

            if(product != null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, product);
            }

        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }

            var query = "UPDATE Products SET Name = @Name, Price = @Price, WHERE Id = @Id";

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, product);
            }
        }

        public void DeleteProduct(int id)
        {
            var query = "DELETE FROM Products WHERE Id = @Id";

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, new { Id = id });
            }
        }

    }
}