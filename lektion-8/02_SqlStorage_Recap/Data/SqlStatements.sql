DECLARE @AddressLine nvarchar(50) SET @AddressLine = 'Nordkapsvägen 1'
DECLARE @PostalCode char(5) SET @PostalCode = '12345'
DECLARE @City nvarchar(50) SET @City = 'Vega'

DECLARE @CategoryName nvarchar(50) SET @CategoryName = 'Datorer'

DECLARE @CategoryId int SET @CategoryId = 1
DECLARE @ProductName nvarchar(50) SET @ProductName = 'Produkt 1'
DECLARE @ProductDescription nvarchar(50) SET @ProductDescription = 'Detta är en beskrivning för Produkt 1'
DECLARE @ProductPrice money SET @ProductPrice = 100

DECLARE @FirstName nvarchar(50) SET @FirstName = 'Hans'
DECLARE @LastName nvarchar(50) SET @LastName = 'Mattin-Lassei'
DECLARE @Email varchar(150) SET @Email = 'hans@domain.com'
DECLARE @AddressId int SET @AddressId = 3

DECLARE @CustomerId int SET @CustomerId = 2
DECLARE @OrderDate datetime2 SET @OrderDate = GETDATE()
DECLARE @DueDate datetime2 SET @DueDate = GETDATE()
DECLARE @TotalVat money SET @TotalVat = 0
DECLARE @TotalPrice money SET @TotalPrice = 0

DECLARE @OrderId int SET @OrderId = 3
DECLARE @ProductId int SET @ProductId = 2
DECLARE @Quantity int SET @Quantity = 1
DECLARE @Price int SET @Price = 100

IF NOT EXISTS(SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode) INSERT INTO Addresses OUTPUT inserted.Id VALUES (@AddressLine, @PostalCode, @City) ELSE SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode
IF NOT EXISTS(SELECT Id FROM Categories WHERE Name = @CategoryName) INSERT INTO Categories OUTPUT inserted.Id VALUES (@CategoryName) ELSE SELECT Id FROM Categories WHERE Name = @CategoryName
IF NOT EXISTS(SELECT Id FROM Products WHERE Name = @ProductName) INSERT INTO Products OUTPUT inserted.Id VALUES (@CategoryId, @ProductName, @ProductDescription, @ProductPrice) ELSE SELECT Id FROM Products WHERE Name = @ProductName
IF NOT EXISTS(SELECT Id FROM Customers WHERE Email = @Email) IF EXISTS(SELECT Id FROM Addresses WHERE Id = @AddressId) INSERT INTO Customers OUTPUT inserted.Id VALUES (@FirstName, @LastName, @Email, @AddressId) ELSE SELECT Id FROM Customers WHERE Email = @Email
IF EXISTS(SELECT Id FROM Customers WHERE Id = @CustomerId) INSERT INTO Orders OUTPUT inserted.Id VALUES (@CustomerId, @OrderDate, @DueDate, @TotalVat, @TotalPrice)
IF EXISTS(SELECT Id FROM Orders WHERE Id = @OrderId) IF EXISTS (SELECT Id FROM Products WHERE Id = @ProductId) INSERT INTO OrderRows VALUES (@OrderId, @ProductID, @Quantity, @Price)
