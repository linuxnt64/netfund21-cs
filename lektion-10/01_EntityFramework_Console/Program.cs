using _00_EntityFramework_ClassLibrary.Models;
using _00_EntityFramework_ClassLibrary.Services;
UserService userService = new UserService();

MenuOptions();





void MenuOptions()
{
    while(true)
    {
        Console.Clear();
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. List Users");
        Console.Write("Choose one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                MenuOption1();
                break;

            case "2":
                MenuOption2();
                break;
        }
    }
}

void MenuOption1()
{
    Console.Clear();

    var user = new User();
    Console.Write("First Name: ");
    user.FirstName = Console.ReadLine();
    Console.Write("Last Name: ");
    user.LastName = Console.ReadLine();
    Console.Write("Email: ");
    user.Email = Console.ReadLine();
    Console.Write("Street Name: ");
    user.StreetName = Console.ReadLine();
    Console.Write("Postal Code: ");
    user.PostalCode = Console.ReadLine();
    Console.Write("City: ");
    user.City = Console.ReadLine();

    userService.Create(user);
}

void MenuOption2()
{
    Console.Clear();
    Console.WriteLine("Id\tDisplay Name\t\tEmail\t\tAddress");
    Console.WriteLine("------------------------------------------------------------------------------");

    foreach (var user in userService.GetAll())
        Console.WriteLine($"{user.Id}\t{user.DisplayName}\t\t{user.Email}\t\t{user.FullAddress}");

    Console.ReadKey();
}