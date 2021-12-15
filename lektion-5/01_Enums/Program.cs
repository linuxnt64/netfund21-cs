/* 
    Enums (Enumerators)
    ---------------------------------------------------------------------------------------------------------------------
    List<T>             Läs- och skrivbar       .Add() = skrivbar               T=DataType=Customer      List<Customer>
    IEnumerable<T>      Läsbar                  .Add() funkar inte här          T=DataType=User          IEnumerable<User>
    Enums               Läsbar          
*/


using _01_Enums;

/* Printer Example */
Task.Run(() => PrinterExample.ShowState());
PrinterExample.Start();
PrinterExample.Print();
PrinterExample.Print();


/* Light Example */
Console.WriteLine($"The light is {LightExample.lightState}");
LightExample.TurnOn();
Console.WriteLine($"The light is {LightExample.lightState}");
LightExample.TurnOff();
Console.WriteLine($"The light is {LightExample.lightState}");


Console.ReadKey();




