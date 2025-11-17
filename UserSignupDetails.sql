USE OnlineTicketBookingSystem;
GO

CREATE TABLE UserSignup (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100) UNIQUE,
    Password NVARCHAR(50),
    ConfirmPassword NVARCHAR(50)
);
GO
