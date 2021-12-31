using _02_LocalSqlStorage.Handlers;
using _02_LocalSqlStorage.Models;

ISqlClientHandler sqlClientHandler = new SqlClientHandler();


var shoppingCart = new ShoppingCart();
shoppingCart.CustomerId = 1;
shoppingCart.Items.Add(new CartItem { ProductId = 1, Quantity = 2 , Price = 100 });
shoppingCart.Items.Add(new CartItem { ProductId = 2, Quantity = 1 , Price = 100 });

sqlClientHandler.SaveOrder(shoppingCart);

var order = sqlClientHandler.GetOrder(11);
Console.WriteLine($"{order.Id} {order.Customer.FirstName} {order.Customer.LastName}");
foreach(var item in order.OrderRows)
    Console.WriteLine($"{item.ProductId} {item.Quantity} {item.Price} SubTotal: { (item.Quantity * item.Price)}");