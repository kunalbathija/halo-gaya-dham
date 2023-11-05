GO
CREATE TABLE dbo.ContactDetails
(
	ContactDetailId INT PRIMARY KEY IDENTITY,
	Email VARCHAR(500),
	PhoneNumber VARCHAR(13),
	CustomerId INT,
	FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(CustomerId),
	AddedOn DATETIME,
	AddedBy VARCHAR(200),
	EditedOn DATETIME,
	EditedBy VARCHAR(200)
)
GO

