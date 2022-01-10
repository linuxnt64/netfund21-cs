DROP TABLE Products
DROP TABLE Categories

CREATE TABLE Categories (
	Id int not null identity primary key,
	Name nvarchar(50) not null unique
)
GO

CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(150) not null unique,
	Description nvarchar(max) null,
	Price money not null,
	CategoryId int not null references Categories(Id)
)