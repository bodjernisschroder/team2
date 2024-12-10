-- Creates CATEGORY AUDIT table
CREATE TABLE CATEGORY_AUDIT
(
	CategoryAuditId INT IDENTITY PRIMARY KEY,

	[CategoryId] INT,
	[CategoryName] NVARCHAR(50),

	Operation NVARCHAR(10),
	CreateDate DATETIME DEFAULT GETDATE(),
	UserId NVARCHAR(30) DEFAULT SYSTEM_USER
);

GO

-- Creates CATEGORY logging trigger
CREATE OR ALTER TRIGGER trgCategoryAuditInsert
ON CATEGORY
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Operation NVARCHAR(10)

	IF EXISTS (SELECT * FROM DELETED)
	BEGIN
		IF EXISTS (SELECT * FROM INSERTED)
			SET @Operation = 'UPDATE'
		ELSE
			SET @Operation = 'DELETE'
	END
	ELSE
		SET @Operation = 'INSERT'
	
	IF @Operation = 'INSERT' OR @Operation = 'UPDATE'
	BEGIN
		INSERT INTO CATEGORY_AUDIT (CategoryId, [CategoryName], Operation, CreateDate, UserId)
		SELECT CategoryId, [CategoryName], @Operation, GETDATE(), SYSTEM_USER
		FROM INSERTED;
	END
	ELSE IF @Operation = 'DELETE'
	BEGIN
		INSERT INTO CATEGORY_AUDIT (CategoryId, [CategoryName], Operation, CreateDate, UserId)
		SELECT CategoryId, [CategoryName], @Operation, GETDATE(), SYSTEM_USER
		FROM DELETED;
	END
END

GO

-- Creates PRODUCT AUDIT table
CREATE TABLE PRODUCT_AUDIT
(
	ProductAuditId INT IDENTITY PRIMARY KEY,

	[ProductId] INT,
	[ProductName] NVARCHAR(50),
	CategoryId INT,

	Operation NVARCHAR(10),
	CreateDate DATETIME DEFAULT GETDATE(),
	UserId NVARCHAR(30) DEFAULT SYSTEM_USER
);

GO

-- Creates PRODUCT logging trigger
CREATE OR ALTER TRIGGER trgProductAuditInsert
ON PRODUCT
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Operation NVARCHAR(10)

	IF EXISTS (SELECT * FROM DELETED)
	BEGIN
		IF EXISTS (SELECT * FROM INSERTED)
			SET @Operation = 'UPDATE'
		ELSE
			SET @Operation = 'DELETE'
	END
	ELSE
		SET @Operation = 'INSERT'
	
	IF @Operation = 'INSERT' OR @Operation = 'UPDATE'
	BEGIN
		INSERT INTO PRODUCT_AUDIT (ProductId, [ProductName], CategoryId, Operation, CreateDate, UserId)
		SELECT ProductId, [ProductName], CategoryId, @Operation, GETDATE(), SYSTEM_USER
		FROM INSERTED;
	END
	ELSE IF @Operation = 'DELETE'
	BEGIN
		INSERT INTO PRODUCT_AUDIT (ProductId, [ProductName], CategoryId, Operation, CreateDate, UserId)
		SELECT ProductId, [ProductName], CategoryId, @Operation, GETDATE(), SYSTEM_USER
		FROM DELETED;
	END
END

GO

-- Creates QUOTE AUDIT table
CREATE TABLE QUOTE_AUDIT
(
	QuoteAuditId INT IDENTITY PRIMARY KEY,

	[QuoteId] INT,
	[QuoteName] NVARCHAR(50),
	Tags NVARCHAR(200), 
	FilePath NVARCHAR(200),
	[HourlyRate] FLOAT NULL,
	[DiscountPercentage] INT,
	[Sum] FLOAT,

	Operation NVARCHAR(10),
	CreateDate DATETIME DEFAULT GETDATE(),
	UserId NVARCHAR(30) DEFAULT SYSTEM_USER
);

GO

-- Creates QUOTE logging Trigger
CREATE OR ALTER TRIGGER trgQuoteAuditInsert
ON QUOTE
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Operation NVARCHAR(10)

	IF EXISTS (SELECT * FROM DELETED)
	BEGIN
		IF EXISTS (SELECT * FROM INSERTED)
			SET @Operation = 'UPDATE'
		ELSE
			SET @Operation = 'DELETE'
	END
	ELSE
		SET @Operation = 'INSERT'
	
	IF @Operation = 'INSERT' OR @Operation = 'UPDATE'
	BEGIN
		INSERT INTO QUOTE_AUDIT (QuoteId, [QuoteName], Tags, FilePath, HourlyRate, DiscountPercentage, [Sum], Operation, CreateDate, UserId)
		SELECT QuoteId, [QuoteName], Tags, FilePath, HourlyRate, DiscountPercentage, [Sum], @Operation, GETDATE(), SYSTEM_USER
		FROM INSERTED;
	END
	ELSE IF @Operation = 'DELETE'
	BEGIN
		INSERT INTO QUOTE_AUDIT (QuoteId, [QuoteName], Tags, FilePath, HourlyRate, DiscountPercentage, [Sum], Operation, CreateDate, UserId)
		SELECT QuoteId, [QuoteName], Tags, FilePath, HourlyRate, DiscountPercentage, [Sum], @Operation, GETDATE(), SYSTEM_USER
		FROM DELETED;
	END
END

GO

-- Creates QUOTEPRODUCT AUDIT table
CREATE TABLE QUOTE_PRODUCT_AUDIT
(
	QuoteProductAuditId INT IDENTITY PRIMARY KEY,

	[QuoteId] INT,
	ProductId INT,
	QuoteProductTimeEstimate FLOAT,
	QuoteProductPrice FLOAT,

	Operation NVARCHAR(10),
	CreateDate DATETIME DEFAULT GETDATE(),
	UserId NVARCHAR(30) DEFAULT SYSTEM_USER
);

GO

-- Creates QUOTEPRODUCT logging Trigger
CREATE OR ALTER TRIGGER trgQuoteProductAuditInsert
ON QUOTE_PRODUCT
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Operation NVARCHAR(10)

	IF EXISTS (SELECT * FROM DELETED)
	BEGIN
		IF EXISTS (SELECT * FROM INSERTED)
			SET @Operation = 'UPDATE'
		ELSE
			SET @Operation = 'DELETE'
	END
	ELSE
		SET @Operation = 'INSERT'
	
	IF @Operation = 'INSERT' OR @Operation = 'UPDATE'
	BEGIN
		INSERT INTO QUOTE_PRODUCT_AUDIT (QuoteId, ProductId, QuoteProductTimeEstimate, QuoteProductPrice, Operation, CreateDate, UserId)
		SELECT QuoteId, ProductId, QuoteProductTimeEstimate, QuoteProductPrice, @Operation, GETDATE(), SYSTEM_USER
		FROM INSERTED;
	END
	ELSE IF @Operation = 'DELETE'
	BEGIN
		INSERT INTO QUOTE_PRODUCT_AUDIT (QuoteId, ProductId, QuoteProductTimeEstimate, QuoteProductPrice, Operation, CreateDate, UserId)
		SELECT QuoteId, ProductId, QuoteProductTimeEstimate, QuoteProductPrice, @Operation, GETDATE(), SYSTEM_USER
		FROM DELETED;
	END
END

GO