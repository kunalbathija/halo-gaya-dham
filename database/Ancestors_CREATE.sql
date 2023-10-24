GO
CREATE TABLE dbo.Ancestors
(
	AncestorId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(200),
	LastName VARCHAR(200),
	Gender VARCHAR(5),
	ExpiredOn DATETIME,
	CustomerId INT,
	FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(CustomerId),
	AddedOn DATETIME,
	AddedBy VARCHAR(200),
	EditedOn DATETIME,
	EditedBy VARCHAR(200)
)
GO

