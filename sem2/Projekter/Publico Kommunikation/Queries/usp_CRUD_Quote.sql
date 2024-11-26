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
CREATE PROCEDURE uspCreateQuote
    @HourlyRate FLOAT NULL,
    @DiscountPercentage DECIMAL(5,2),
    @Sum FLOAT
AS
BEGIN
    INSERT INTO QUOTE (HourlyRate, DiscountPercentage, [Sum])
    VALUES (@HourlyRate, @DiscountPercentage, @Sum)
END
GO

-- UPDATE
CREATE PROCEDURE uspUpdateQuote
    @QuoteId INT,
    @HourlyRate FLOAT,
    @DiscountPercentage DECIMAL(5,2), 
    @Sum FLOAT
AS
BEGIN
    UPDATE QUOTE
    SET 
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