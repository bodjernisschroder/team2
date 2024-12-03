-- GET ALL
CREATE PROCEDURE uspGetAllQuote
AS
BEGIN
    SELECT * FROM QUOTE
END
GO

-- GET BY ID
CREATE PROCEDURE uspGetByKeyQuote
    @QuoteId INT
AS
BEGIN
    SELECT * FROM QUOTE
    WHERE QuoteId = @QuoteId
END
GO

-- CREATE
CREATE OR ALTER PROCEDURE uspCreateQuote
    @QuoteName NVARCHAR(200),
    @Tags NVARCHAR (200),
    @FilePath NVARCHAR(200),
    @HourlyRate FLOAT,
    @DiscountPercentage DECIMAL(5,2),
    @Sum FLOAT,
    @QuoteId INT OUTPUT
AS
BEGIN
    INSERT INTO QUOTE ([QuoteName], Tags, FilePath ,HourlyRate, DiscountPercentage, [Sum])
    VALUES (@QuoteName, @Tags, @FilePath, @HourlyRate, @DiscountPercentage, @Sum)
    SET @QuoteId = SCOPE_IDENTITY();
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
CREATE PROCEDURE uspDeleteQuote
    @QuoteId INT
AS
BEGIN
    DELETE FROM QUOTE
    WHERE QuoteId = @QuoteId
END
GO