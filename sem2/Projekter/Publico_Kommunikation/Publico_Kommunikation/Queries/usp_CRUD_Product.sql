-- GET ALL
CREATE OR ALTER PROCEDURE uspGetAllProduct
AS
BEGIN
    SELECT * FROM PRODUCT
END
GO

-- GET BY ID
CREATE OR ALTER PROCEDURE uspGetByKeyProduct
    @ProductId INT
AS
BEGIN
    SELECT * FROM PRODUCT
    WHERE ProductId = @ProductId
END
GO

-- CREATE
CREATE OR ALTER PROCEDURE uspCreateProduct
    @ProductName NVARCHAR(50),
    @CategoryId INT
AS
BEGIN
    INSERT INTO PRODUCT (ProductName, CategoryId)
    VALUES (@ProductName, @CategoryId)
END
GO

-- UPDATE
CREATE OR ALTER PROCEDURE uspUpdateProduct
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
CREATE OR ALTER PROCEDURE uspDeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM PRODUCT
    WHERE ProductId = @ProductId
END
GO