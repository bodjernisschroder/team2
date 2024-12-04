CREATE TABLE QuoteAudit
(
	QuoteAuditId int identity PRIMARY KEY,

	[QuoteId] int,
	[HourlyRate] float null,
	[DiscountPercentage] int,
	[Sum] float,

	Operation NVarChar(10),
	CreateDate DateTime default getDate(),
	UserId NVarChar(30) default system_user
);

GO;

CREATE TRIGGER trgQuoteAuditInsert
ON Quote
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Operation NVARCHAR(10)

	IF EXISTS (SELECT * FROM Deleted)
	BEGIN
		IF EXISTS (SELECT * FROM Inserted)
			SET @Operation = 'UPDATE'
		ELSE
			SET @Operation = 'DELETE'
	END
	ELSE
		SET @Operation = 'INSERT'
	
	IF @Operation = 'INSERT'
	BEGIN
		INSERT INTO QuoteAudit (QuoteId, HourlyRate, DiscountPercentage, Sum, Operation, CreateDate, UserId)
		SELECT QuoteId, HourlyRate, DiscountPercentage, Sum, @Operation, getDate(), system_user
		FROM Inserted;
	END
	ELSE
	BEGIN
		INSERT INTO QuoteAudit (QuoteId, HourlyRate, DiscountPercentage, Sum, Operation, CreateDate, UserId)
		SELECT QuoteId, HourlyRate, DiscountPercentage, Sum, @Operation, getDate(), system_user
		FROM Deleted;
	END
END
