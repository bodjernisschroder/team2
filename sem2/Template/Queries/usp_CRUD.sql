-- GET ALL
CREATE PROCEDURE uspGetAllClassTemplate
AS
BEGIN
    SELECT * FROM ClassTemplate
END
GO

-- GET BY ID
CREATE PROCEDURE uspGetByIdClassTemplate
    @ClassTemplateId INT
AS
BEGIN
    SELECT * FROM ClassTemplate
    WHERE ClassTemplateId = @ClassTemplateId
END
GO

-- CREATE
CREATE PROCEDURE uspCreateClassTemplate
    @Description NVARCHAR(100),
    @RelatedId INT
AS
BEGIN
    INSERT INTO ClassTemplate ([Description], RelatedId)
    VALUES (@Description, @RelatedId)
END
GO

-- UPDATE
CREATE PROCEDURE uspUpdateClassTemplate
    @ClassTemplateId INT,
    @Description NVarChar(100),
    @RelatedId INT
AS
BEGIN
    UPDATE ClassTemplate
    SET 
        [Description] = @Description, 
        relatedId = @RelatedId
    WHERE ClassTemplateId = @ClassTemplateId
END
GO

-- DELETE
CREATE PROCEDURE uspDeleteClassTemplate
    @ClassTemplateId INT
AS
BEGIN
    DELETE FROM ClassTemplate
    WHERE ClassTemplateId = @ClassTemplateId
END
GO