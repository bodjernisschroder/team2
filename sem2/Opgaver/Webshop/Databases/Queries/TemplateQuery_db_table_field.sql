--Create Database 

CREATE DATABASE Template; 

USE Template; 


--Creates tables 

CREATE TABLE CLASSTEMPLATE (
    ClassTemplateId INT IDENTITY PRIMARY KEY,  
    Description NVARCHAR(255) NULL,
    RelatedId INT NOT NULL,         
	CONSTRAINT FK_ClassTemplate_RelatedId FOREIGN KEY (RelatedId) 
		REFERENCES RELATEDTABLE(RelatedId) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE RELATEDTABLE (
    RelatedId INT IDENTITY PRIMARY KEY, 
    RelatedName NVARCHAR(50) UNIQUE NOT NULL,
	Value INT DEFAULT 0 NOT NULL,
CONSTRAINT CK_RelatedTable_Value CHECK (Value BETWEEN 0 AND 100)
);
    

--Insert values 

INSERT INTO CLASSTEMPLATE (ClassTemplateId, RelatedId, Description)
VALUES
(1, 101, 'First class template'),
(2, 102, 'Second class template'),
(3, 103, 'Third class template');

