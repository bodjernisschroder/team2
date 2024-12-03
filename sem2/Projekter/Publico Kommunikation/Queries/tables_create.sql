--Creates CATEGORY table
CREATE TABLE CATEGORY (
	CategoryId INT IDENTITY PRIMARY KEY,
	CategoryName NVARCHAR(50) NOT NULL,
	CONSTRAINT UQ_Category_CategoryName UNIQUE (CategoryName)
);
GO

--Creates PRODUCT table
CREATE TABLE PRODUCT (
	ProductId INT IDENTITY PRIMARY KEY,
	ProductName NVARCHAR (50) NOT NULL, 
	CategoryId INT NOT NULL,
	CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId) 
		REFERENCES CATEGORY(CategoryId) ON UPDATE CASCADE ON DELETE CASCADE
);
GO

--Creates Quote table
CREATE TABLE QUOTE (
	QuoteId INT IDENTITY PRIMARY KEY,
	[QuoteName] NVARCHAR (50) DEFAULT "Tilbud" NOT NULL,
	Tags NVARCHAR (200) NULL,
	Filepath NVARCHAR (200) NULL,
	HourlyRate FLOAT NULL, 
	DiscountPercentage DECIMAL(5,2) DEFAULT 0 NOT NULL, 
	[Sum] FLOAT DEFAULT 0 NOT NULL,
	CONSTRAINT CK_Quote_HourlyRate_Positive CHECK (HourlyRate >= 0),
	CONSTRAINT CK_Quote_DiscountPercentage_Range CHECK (DiscountPercentage BETWEEN 0 AND 50),
	CONSTRAINT CK_Quote_Sum_Positive CHECK ([Sum] >= 0)
);
GO

--Creates QuoteProduct table 
 CREATE TABLE QUOTE_PRODUCT(
	QuoteId INT,
	ProductId INT,
	QuoteProductTimeEstimate FLOAT NULL,
	QuoteProductPrice FLOAT DEFAULT 0 NOT NULL,
	CONSTRAINT PK_QuoteProduct PRIMARY KEY (QuoteId, ProductId),
	CONSTRAINT FK_QuoteProduct_Product FOREIGN KEY (ProductId) REFERENCES PRODUCT(ProductId),
	CONSTRAINT FK_QuoteProduct_Quote FOREIGN KEY (QuoteId) REFERENCES QUOTE(QuoteId)
 );
GO