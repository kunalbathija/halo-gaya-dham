GO
CREATE PROCEDURE dbo.InsertAdminLogin
    @Username VARCHAR(100),
    @Password VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AddedOn DATETIME, @EditedOn DATETIME, @AddedBy VARCHAR(200), @EditedBy VARCHAR(200);
    SET @AddedOn = GETDATE();
    SET @EditedOn = GETDATE();
    SET @AddedBy = 'System';
    SET @EditedBy = 'System';

    INSERT INTO dbo.AdminLogins (Username, Password, AddedOn, AddedBy, EditedOn, EditedBy)
    VALUES (@Username, @Password, @AddedOn, @AddedBy, @EditedOn, @EditedBy);
END
GO