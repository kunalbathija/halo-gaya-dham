GO
CREATE TABLE dbo.AdminLogins
(
	AdminLoginId INT PRIMARY KEY IDENTITY,
	Username VARCHAR(100),
	Password VARCHAR(100),
	AddedOn DATETIME,
	AddedBy VARCHAR(200),
	EditedOn DATETIME,
	EditedBy VARCHAR(200)
)
GO

GO
ALTER TABLE dbo.AdminLogins
ADD CONSTRAINT UQ_Username UNIQUE (Username) 
GO






