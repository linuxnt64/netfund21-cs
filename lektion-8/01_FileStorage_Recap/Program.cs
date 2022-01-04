using _01_FileStorage_Recap.Handlers;
using _01_FileStorage_Recap.Models;

JsonHandler jsonHandler = new JsonHandler(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customers.json");
CsvHandler csvHandler = new CsvHandler(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customers.csv");

ReadFiles();
ViewCustomers();
CreateCustomer();
SaveFiles();








void ReadFiles()
{
    try { jsonHandler.ReadFromFile(); }
    catch { }

    try { csvHandler.ReadFromFile(); }
    catch { }
}

void ViewCustomers()
{
    Console.WriteLine("--- Json Customers --- ");
    foreach (var customer in jsonHandler.Get())
        Console.WriteLine($"{customer.DisplayName()}");

    Console.WriteLine("");

    Console.WriteLine("--- Csv Customers --- ");
    foreach (var customer in csvHandler.Get())
        Console.WriteLine($"{customer.DisplayName()}");

    Console.WriteLine();
}

void CreateCustomer()
{
    Console.WriteLine("--- New Customer --- ");
    var customer = new Customer();

    Console.Write("Förnamn: ");
    customer.FirstName = Console.ReadLine();
    Console.Write("Efternamn: ");
    customer.LastName = Console.ReadLine();
    Console.Write("E-postadress: ");
    customer.Email = Console.ReadLine();
    Console.Write("Lösenord: ");
    customer.Password = Console.ReadLine();

    jsonHandler.Add(customer);
    csvHandler.Add(customer);
}

void SaveFiles()
{
    jsonHandler.WriteToFile();
    csvHandler.WriteToFile();
}