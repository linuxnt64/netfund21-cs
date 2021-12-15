/* 
    STACK vs. HEAP (Minneshantering)
    ---------------------------------------------------------------------------------------------------------------------------
    STACK           snabbt men klarar bara av enkla saker, direkt association, litet utrymme fyll upp snabbt (stack overflow)
    HEAP            långsamt men klarar av mer komplexa saker, pekar på en minnesplats dynamiskt allokerat
                    felmeddelande vi kan få är not set to an instance of an object.


    Value Types         STACK           int, double, decimal, float, bool, (string), enum, struct
    Reference Types     HEAP            array, list, object, (String), class
 
    string/String är speciellt för att den ligger på stacken men en string använder sig av pekare för att att bygga ihop sin sträng.
*/

using s = _02_Structs.Structs;
using c = _02_Structs.Classes;

/* struct example */
s.Customer structCustomer1 = new s.Customer() { Name = "Hans", Email = "hans@domain.com" };
s.Customer structCustomer2 = structCustomer1;   // Kopierar objektet

Console.WriteLine("Struct Example - STACK");
Console.WriteLine("------------------------------------------------------");
Console.WriteLine($"structCustomer1: {structCustomer1.Name}");
Console.WriteLine($"structCustomer2: {structCustomer2.Name}");
Console.WriteLine("");

structCustomer1.Name = "Tommy";
Console.WriteLine($"structCustomer1 (modified): {structCustomer1.Name}");
Console.WriteLine($"structCustomer2: {structCustomer2.Name}");
Console.WriteLine("\n\n");





/* class example */
c.Customer classCustomer1 = new c.Customer() { Name = "Hans", Email = "hans@domain.com" };
c.Customer classCustomer2 = classCustomer1; // Refererar objektet

Console.WriteLine("Class Example - HEAP");
Console.WriteLine("------------------------------------------------------");
Console.WriteLine($"classCustomer1: {classCustomer1.Name}");
Console.WriteLine($"classCustomer2: {classCustomer2.Name}");
Console.WriteLine("");

classCustomer1.Name = "Tommy";
Console.WriteLine($"classCustomer1 (modified): {classCustomer1.Name}");
Console.WriteLine($"classCustomer2: {classCustomer2.Name}");
Console.WriteLine("\n\n");




/* list example */
List<string> list1 = new List<string>() { "Hans", "Tommy" };
List<string> list2 = list1;

Console.WriteLine("List Example - HEAP");
Console.WriteLine("------------------------------------------------------");
foreach (var item in list1) { Console.WriteLine($"list1: {item}"); }
Console.WriteLine("");
foreach (var item in list2) { Console.WriteLine($"list2: {item}"); }
Console.WriteLine("");

list1.Add("Anki");
foreach (var item in list1) { Console.WriteLine($"list1 (modified): {item}"); }
Console.WriteLine("");
foreach (var item in list2) { Console.WriteLine($"list2: {item}"); }
Console.WriteLine("\n\n");



/* string example */
string name1 = "Hans";
string name2 = name1;


Console.WriteLine("String Example - SPECIAL STACK/HEAP");
Console.WriteLine("------------------------------------------------------");
Console.WriteLine($"name1: {name1}");
Console.WriteLine($"name2: {name2}");
Console.WriteLine("");

name1 = "Tommy";
Console.WriteLine($"name1 (modified): {name1}");
Console.WriteLine($"name2: {name2}");




Console.ReadKey();