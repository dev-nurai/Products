
CREATE PROC spUpdateProduct
@Name nvarchar(200),
@Price int,
@Id int
AS
BEGIN
	UPDATE BrandsProduct
	SET Name = @Name, Price = @Price
	WHERE Id = @Id
END;

