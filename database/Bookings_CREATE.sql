GO
CREATE TABLE dbo.Bookings
(
	BookingId INT PRIMARY KEY IDENTITY,
	TripId INT,
	FOREIGN KEY (TripId) REFERENCES dbo.Trips(TripId),
	CustomerId INT,
	FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(CustomerId),
	BookingDateTme DATETIME,
	RoomNumber VARCHAR(100),
	AddedOn DATETIME,
	AddedBy VARCHAR(200),
	EditedOn DATETIME,
	EditedBy VARCHAR(200)
)
GO

