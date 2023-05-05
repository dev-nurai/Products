

--Create Database ----
CREATE DATABASE AmazonDB;

--- Create Table in Database ----

CREATE TABLE BrandsProduct(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(200),
Price INT
);

-- Get All Products ---

SELECT * FROM BrandsProduct

-- Get Product by Id ---

SELECT * FROM BrandsProduct WHERE Id = @Id;

-- Add Product to Database ----

INSERT INTO BrandsProduct (Name, Price) VALUES (@Name, @Price);

--- Update Product ----

UPDATE BrandsProduct SET Name = @Name, Price = @Price WHERE Id = @Id

---- Delete Products ----

DELETE FROM BrandsProduct WHERE Id = @Id


