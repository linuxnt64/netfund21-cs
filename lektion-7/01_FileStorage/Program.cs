using _01_FileStorage.Handlers;
using _01_FileStorage.Models;

var customer = new Customer { Id = 1, FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" };


Console.WriteLine("--- CSV EXEMPEL ---");

ICsvFileHandler csvFile = new CsvFileHandler();
csvFile.AddToList(customer);
csvFile.SaveToFile();
foreach(var csvCustomer in csvFile.GetCustomers())
    Console.WriteLine($"{csvCustomer.FirstName} {csvCustomer.LastName}");




Console.WriteLine("--- JSON EXEMPEL ---");

IJsonFileHandler jsonFile = new JsonFileHandler();
jsonFile.AddToList(customer);
jsonFile.SaveToFile();
foreach (var jsonCustomer in jsonFile.GetCustomers())
    Console.WriteLine($"{jsonCustomer.FirstName} {jsonCustomer.LastName}");