using _04_Console_NoGUI.Handlers;
using _04_Console_NoGUI.Models;

IUserManager userManager = new UserManager();

Console.Write("Förnamn: ");
var firstName = Console.ReadLine();
Console.Write("Efternamn: ");
var lastName = Console.ReadLine();
Console.Write("Email: ");
var email = Console.ReadLine();
Console.Write("Lösenord: ");
var password = Console.ReadLine();
Console.Write("Adress: ");
var addressLine = Console.ReadLine();
Console.Write("Postnummer: ");
var postalCode = Console.ReadLine();
Console.Write("Stad: ");
var city = Console.ReadLine();

var _user = new User
{
    FirstName = firstName,
    LastName = lastName,
    Email = email,
    Password = password,
    AddressLine = addressLine,
    PostalCode = postalCode,
    City = city
};

userManager.CreateUser(_user);
userManager.CreateUser(_user);
userManager.CreateUser(_user);
userManager.CreateUser(_user);
userManager.CreateUser(_user);




var users = userManager.GetUsers();
foreach (var user in users)
    Console.WriteLine(user.DisplayName);