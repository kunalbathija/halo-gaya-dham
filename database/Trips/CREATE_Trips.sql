GO
CREATE TABLE dbo.Trips
(
	TripId INT PRIMARY KEY IDENTITY,
	FromPlace VARCHAR(200),
	FromDateTime DATETIME,
	ToPlace VARCHAR(200),
	ToDateTime DATETIME,
	ReturnDepartureDateTime DATETIME,
	ReturnArrivalDateTime DATETIME,
	HotelName VARCHAR(100),
	AddedOn DATETIME,
	AddedBy VARCHAR(200),
	EditedOn DATETIME,
	EditedBy VARCHAR(200)
)
GO

