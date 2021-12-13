/*
    Getters Setters (Encapsulation - OOP)
    -----------------------------------------------------------------------------------------------------
    SET         SPARA/SKRIV         customer.FirstName = "Hans";
    GET         HÄMTA/LÄS           console.WriteLine(customer.FirstName);

    public string FirstName { get; set; }

    public string FirstName { get; private set; }

    public string FirstName { get; }

    public string FirstName => $"";

    private string _firstName;
    public string FirstName 
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
 
*/




using _02_GettersSetters;

var ex1 = new Example1();
var ex2 = new Example2();

// SET
ex1.FirstName = "Hans";
ex1.Email = "HANS.mAttIN-Lassei@DOMA.com";

ex2.FirstName = "Hans";
ex2.LastName = "Mattin-Lassei";
ex2.Id = "sadfasfd";
ex2.FullName = "Arne Wise";



// GET
Console.WriteLine(ex1.FirstName);
Console.WriteLine(ex1.Email);

Console.WriteLine(ex2.Id);
Console.WriteLine(ex2.FullName);