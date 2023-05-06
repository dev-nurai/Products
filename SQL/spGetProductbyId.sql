
CREATE PROC spGetProductbyId
@Id Int
AS
BEGIN
	SELECT * FROM BrandsProduct WHERE Id = @Id
END;
