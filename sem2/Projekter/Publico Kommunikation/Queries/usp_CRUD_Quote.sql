-- GET ALL
CREATE OR ALTER PROCEDURE uspGetAllQuote
AS
BEGIN
    SELECT * FROM QUOTE
END
GO

-- GET BY ID
CREATE OR ALTER PROCEDURE uspGetByKeyQuote
    @QuoteId INT
AS
BEGIN
    SELECT * FROM QUOTE
    WHERE QuoteId = @QuoteId
END
GO

-- CREATE
CREATE OR ALTER PROCEDURE uspCreateQuote
    @QuoteName NVARCHAR(50) = 'Tilbud' OUTPUT,
    @Tags NVARCHAR (200) = NULL,
    @FilePath NVARCHAR(200) = NULL,
    @HourlyRate FLOAT,
    @DiscountPercentage DECIMAL(5,2),
    @Sum FLOAT,
    @QuoteId INT OUTPUT
AS
BEGIN
    INSERT INTO QUOTE ([QuoteName], Tags, FilePath ,HourlyRate, DiscountPercentage, [Sum])
    VALUES (@QuoteName, @Tags, @FilePath, @HourlyRate, @DiscountPercentage, @Sum)
    SET @QuoteId = SCOPE_IDENTITY();
    SET @QuoteName = CONCAT(@QuoteName, ' ', @QuoteId)
    UPDATE QUOTE
    SET [QuoteName] = @QuoteName
    WHERE [QuoteId] = @QuoteId;
END
GO

-- UPDATE
CREATE OR ALTER PROCEDURE uspUpdateQuote
    @QuoteId INT,
    @QuoteName NVARCHAR(50),
    @Tags NVARCHAR(200),
    @Filepath NVARCHAR(200),
    @HourlyRate FLOAT,
    @DiscountPercentage DECIMAL(5,2), 
    @Sum FLOAT
AS
BEGIN
    UPDATE QUOTE
    SET 
        [QuoteName] = @QuoteName,
        Tags = @Tags,
        Filepath = @Filepath,
        HourlyRate = @HourlyRate, 
        DiscountPercentage = @DiscountPercentage,
        [Sum] = @Sum
    WHERE QuoteId = @QuoteId
END
GO

-- DELETE
CREATE OR ALTER PROCEDURE uspDeleteQuote
    @QuoteId INT
AS
BEGIN
    DELETE FROM QUOTE
    WHERE QuoteId = @QuoteId
END
GO

-- GET QUOTES BY SEARCH QUERY
CREATE OR ALTER PROCEDURE uspGetQuotesBySearchQuery
    @SearchQuery NVarChar(200)
AS
BEGIN
    SELECT * FROM QUOTE
    WHERE  [QuoteName] LIKE '%' + @SearchQuery + '%' OR
    Tags LIKE '%' + @SearchQuery + '%'
END
GO