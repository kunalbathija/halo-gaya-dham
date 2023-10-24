GO
CREATE TABLE dbo.Payments
(
	PaymentId INT PRIMARY KEY IDENTITY,
	BookingId INT,
	FOREIGN KEY (BookingId) REFERENCES dbo.Bookings(BookingId),
	PaymentAmount VARCHAR(100),
	IsPaid BIT,
	PaidBy VARCHAR(100),
	RecievedBy VARCHAR(100),
	RecievedOn DATETIME,
	Notes VARCHAR(500),
	AddedOn DATETIME,
	AddedBy VARCHAR(200),
	EditedOn DATETIME,
	EditedBy VARCHAR(200)
)
GO

