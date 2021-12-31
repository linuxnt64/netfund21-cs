--IF NOT EXISTS (SELECT Id FROM Products WHERE Name = @Name) INSERT INTO Products (Name, Description, StockPrice) VALUES (@Name, @Description, @StockPrice)
--IF NOT EXISTS (SELECT Id FROM Customers WHERE Email = @Email) INSERT INTO Customers (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)
--SELECT * FROM Products WHERE Id = @Id
--SELECT Id, FirstName, LastName, Email FROM Customers

DECLARE @Name nvarchar(150) SET @Name = 'Product 5'
DECLARE @Description nvarchar(150) SET @Description = 'Description for product 5'
DECLARE @StockPrice money SET @StockPrice = 100

DECLARE @Id int SET @Id = 5
DECLARE @FirstName nvarchar(50) SET @FirstName = 'Hans'
DECLARE @LastName nvarchar(50) SET @LastName = 'Mattin-Lassei'
DECLARE @Email nvarchar(100) SET @Email = 'hans@domain.com'
DECLARE @Password nvarchar(max) SET @Password = 'BytMig123'

DECLARE @CustomerId int SET @CustomerId = 1
DECLARE @OrderDate datetime2 SET @OrderDate = GETDATE()
DECLARE @DueDate datetime2 SET @DueDate = GETDATE()
DECLARE @VAT money SET @VAT = 0
DECLARE @TotalPrice money SET @TotalPrice = 0

IF EXISTS (SELECT Id FROM Customers WHERE Id = @CustomerId) INSERT INTO Orders (CustomerId, OrderDate, DueDate, VAT, TotalPrice) OUTPUT Inserted.Id VALUES (@CustomerId, @OrderDate, @DueDate, @VAT, @TotalPrice)

INSERT INTO OrderRows (OrderId, ProductId, Quantity, Price) VALUES (@OrderId, @ProductId, @Quantity, @Price)


SELECT * FROM Orders