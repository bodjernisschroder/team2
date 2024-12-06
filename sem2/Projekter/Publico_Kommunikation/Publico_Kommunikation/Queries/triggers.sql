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

GO;

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
