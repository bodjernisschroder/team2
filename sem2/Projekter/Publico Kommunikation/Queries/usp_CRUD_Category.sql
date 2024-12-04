-- GET ALL
CREATE OR ALTER PROCEDURE uspGetAllCategory
AS
BEGIN
    SELECT * FROM CATEGORY
END
GO

-- GET BY ID
CREATE OR ALTER PROCEDURE uspGetByKeyCategory
    @CategoryId INT
AS
BEGIN
    SELECT * FROM CATEGORY
    WHERE CategoryId = @CategoryId
END
GO

-- CREATE
CREATE OR ALTER PROCEDURE uspCreateCategory
    @CategoryName NVARCHAR(50)
AS
BEGIN
    INSERT INTO CATEGORY (CategoryName)
    VALUES (@CategoryName)
END
GO

-- UPDATE
CREATE OR ALTER PROCEDURE uspUpdateCategory
    @CategoryId INT,
    @CategoryName NVarChar(50)
AS
BEGIN
    UPDATE CATEGORY
    SET 
        CategoryName = @CategoryName
    WHERE CategoryId = @CategoryId
END
GO

-- DELETE
CREATE OR ALTER PROCEDURE uspDeleteCategory
    @CategoryId INT
AS
BEGIN
    DELETE FROM CATEGORY
    WHERE CategoryId = @CategoryId
END
GO