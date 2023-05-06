

CREATE PROC spDeleteProduct
@Id int
AS
BEGIN
	DELETE FROM BrandsProduct
	WHERE Id = @Id
END;

