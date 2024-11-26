-- GET ALL
CREATE PROCEDURE uspGetAllCategory
AS
BEGIN
    SELECT * FROM CATEGORY
END
GO

-- GET BY ID
CREATE PROCEDURE uspGetByKeyCategory
    @CategoryId INT
AS
BEGIN
    SELECT * FROM CATEGORY
    WHERE CategoryId = @CategoryId
END
GO

-- CREATE
CREATE PROCEDURE uspCreateCategory
    @CategoryName NVARCHAR(50)
AS
BEGIN
    INSERT INTO CATEGORY (CategoryName)
    VALUES (@CategoryName)
END
GO

-- UPDATE
CREATE PROCEDURE uspUpdateCategory
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
CREATE PROCEDURE uspDeleteCategory
    @CategoryId INT
AS
BEGIN
    DELETE FROM CATEGORY
    WHERE CategoryId = @CategoryId
END
GO