DROP TABLE OrderRows
DROP TABLE Orders
DROP TABLE Customers
DROP TABLE Products
DROP TABLE Categories
DROP TABLE Addresses

CREATE TABLE Addresses (
	Id int not null identity primary key,
	AddressLine nvarchar(150) not null,
	PostalCode char(5) not null,
	City nvarchar(50) not null
)

CREATE TABLE Categories (
	Id int not null identity primary key,
	Name nvarchar(150) not null unique
)
GO

CREATE TABLE Products (
	Id int not null identity primary key,
	CategoryId int not null references Categories(Id),
	Name nvarchar(150) not null unique,
	Description nvarchar(max) null,
	Price money default 0
)

CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null unique,
	AddressId int not null references Addresses(Id)
)
GO

CREATE TABLE Orders (
	Id int not null identity primary key,
	CustomerId int not null references Customers(Id),
	OrderDate datetime2 not null,
	DueDate datetime2 null,
	TotalVat money not null default 0,
	TotalPrice money not null default 0
)
GO

CREATE TABLE OrderRows (
	OrderId int not null references Orders(Id),
	ProductId int not null references Products(Id),
	Quantity int not null default 1,
	Price money not null default 0

	primary key (OrderId, ProductId)
)
GO