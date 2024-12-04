-- GET ALL
CREATE OR ALTER PROCEDURE uspGetAllQuoteProduct
AS
BEGIN
    SELECT * FROM QUOTE_PRODUCT
END
GO

-- GET BY ID
CREATE OR ALTER PROCEDURE uspGetByCompositeKeyQuoteProduct
    @QuoteId INT, 
	@ProductId INT
AS
BEGIN
    SELECT * FROM QUOTE_PRODUCT
    WHERE QuoteId = @QuoteId AND ProductId = @ProductId
END
GO

-- GET BY ID ONE
CREATE OR ALTER PROCEDURE uspGetByKeyOneQuoteProduct
    @QuoteId INT
AS
BEGIN
    SELECT * FROM QUOTE_PRODUCT
    WHERE QuoteId = @QuoteId
END
GO

-- GET BY ID TWO
CREATE OR ALTER PROCEDURE uspGetByKeyTwoQuoteProduct
    @ProductId INT
AS
BEGIN
    SELECT * FROM QUOTE_PRODUCT
    WHERE ProductId = @ProductId
END
GO

-- CREATE
CREATE OR ALTER PROCEDURE uspCreateQuoteProduct
    @QuoteId INT, 
    @ProductId INT,
    @QuoteProductTimeEstimate FLOAT,
    @QuoteProductPrice FLOAT
AS
BEGIN
    INSERT INTO QUOTE_PRODUCT (QuoteId, ProductId, QuoteProductTimeEstimate, QuoteProductPrice)
    VALUES (@QuoteId, @ProductId, @QuoteProductTimeEstimate, @QuoteProductPrice)
END
GO

-- UPDATE
CREATE OR ALTER PROCEDURE uspUpdateQuoteProduct
    @QuoteId INT,
    @ProductId INT,
    @QuoteProductTimeEstimate FLOAT,
    @QuoteProductPrice FLOAT
AS
BEGIN
    UPDATE QUOTE_PRODUCT
    SET 
        QuoteId = @QuoteId, 
        ProductId = @ProductId,
        QuoteProductTimeEstimate = @QuoteProductTimeEstimate, 
        QuoteProductPrice = @QuoteProductPrice
    WHERE QuoteId = @QuoteId AND ProductId = @ProductId
END
GO

-- DELETE
CREATE OR ALTER PROCEDURE uspDeleteQuoteProduct
    @QuoteId INT, 
    @ProductId INT
AS
BEGIN
    DELETE FROM QUOTE_PRODUCT
    WHERE QuoteId = @QuoteId AND ProductId = @ProductId
END
GO