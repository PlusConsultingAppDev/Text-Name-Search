CREATE TABLE Employees (
    ID int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(100) not null,
    MiddleName nvarchar(100) not null,
    LastName nvarchar(100) not null,
);
