GO
CREATE OR ALTER PROCEDURE dbo.CheckAdminLogin
    @Username VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @HashedPassword NVARCHAR(100);

    SELECT @HashedPassword = Password
    FROM dbo.AdminLogins
    WHERE Username = @Username;

    SELECT @HashedPassword AS HashedPassword;
END

GO