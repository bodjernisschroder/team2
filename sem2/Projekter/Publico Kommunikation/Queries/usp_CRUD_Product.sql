-- GET ALL
CREATE PROCEDURE uspGetAllProduct
AS
BEGIN
    SELECT * FROM PRODUCT
END
GO

-- GET BY ID
CREATE PROCEDURE uspGetByKeyProduct
    @ProductId INT
AS
BEGIN
    SELECT * FROM PRODUCT
    WHERE ProductId = @ProductId
END
GO

-- CREATE
CREATE PROCEDURE uspCreateProduct
    @ProductName NVARCHAR(50),
    @CategoryId INT
AS
BEGIN
    INSERT INTO PRODUCT (ProductName, CategoryId)
    VALUES (@ProductName, @CategoryId)
END
GO

-- UPDATE
CREATE PROCEDURE uspUpdateProduct
    @ProductId INT,
    @ProductName NVarChar(50),
    @CategoryId INT
AS
BEGIN
    UPDATE PRODUCT
    SET 
        ProductName = @ProductName, 
        CategoryId = @CategoryId
    WHERE ProductId = @ProductId
END
GO

-- DELETE
CREATE PROCEDURE uspDeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM PRODUCT
    WHERE ProductId = @ProductId
END
GO