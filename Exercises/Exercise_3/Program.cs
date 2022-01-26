using Exercise_3.Services;

var filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\products.json";
IMenuService menu = new MenuService();

menu.ReadFromFile(filePath);


while (true)
{
    Console.Clear();
    Console.WriteLine("1. Create Product");
    Console.WriteLine("2. List Products");
    Console.WriteLine("3. View Product");
    Console.WriteLine("4. Remove Product");
    Console.WriteLine("5. Save to File");
    Console.Write("Choose one option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            menu.Create();
            break;
        case "2":
            menu.List();
            break;
        case "3":
            menu.Details();
            break;
        case "4":
            menu.Remove();
            break;
        case "5":
            menu.SaveToFile(filePath);
            break;
    }
}