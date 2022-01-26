CREATE TABLE StatusTypes (
	Id int not null identity primary key,
	Status nvarchar(50) not null unique
)

CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null unique
)
GO

CREATE TABLE Cases (
	Id int not null identity primary key,
	CustomerId int not null references Customers(Id),
	StatusTypeId int not null references StatusTypes(Id),
	Title nvarchar(50) not null,
	Description nvarchar(max) not null,
	Created datetime2 not null
)