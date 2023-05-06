
CREATE PROC spAddProduct
@Name nvarchar(200),
@Price int
AS
BEGIN
	INSERT INTO BrandsProduct (Name, Price) VALUES (@Name, @Price)
END;

;