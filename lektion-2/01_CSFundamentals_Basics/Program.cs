#region COMMENTS

// inline comment (ctrl + e och sen c) - går endast över en rad

/*  
    block comment (ctrl + shift + *)
    kan gå över flera rader  
*/

/* 
    /// <summary>
    /// Så här kan jag skriva vad den här metoden gör
    /// </summary>
    /// <param name="firstName">Vad innebär firstName</param>
    /// <param name="lastName">Vad innebär lastName</param>    
*/

#endregion

#region DATA TYPES

/* 
    FRONTEND (ASP.NET)  - BACKEND (ASP.NET C#) - DATABASE (MSSQL) 
    FRONTEND (REACT JS) - BACKEND API (C#)     - DATABASE (MSSQL) 


    JS              C#                                           SQL
    --------------------------------------------------------------------------------------------------------------
    Number          sbyte, byte, ushort, int, uint, long,        bit, tinyint, smallint, int, bigint, 
                    ulong, Int16, Int32, Int64, decimal,         decimal, float, real, smallmoney,
                    double, float                                money, numeric
 
    String          char, string                                 char, varchar, text, nchar, nvarchar, ntext                                                               
    Boolean         bool                                         bit
    Object          object                                       ---
    null (Object)   null                                         null
    Undefined       null                                         null
    ---             dynamic                                      ---
    ---             Guid (Global Unique Identifier)              uniqueidentifier


    C# Integrals
    TYPE            BIT             RANGE (START/END)       8,16,32,64,128,256,512,1024,2048,4096,8192,16384,32768,65536
    --------------------------------------------------------------------------------------------------------------------
    sbyte           8               -128                    127
    byte            8               0                       255
    short           16              -32768                  32767
    ushort          16              0                       65535
    int             32              -2147483648             2147483647
    uint            32              0                       4292967295
    long            64              -9223372036854775808    9223372036854775807
    ulong           64              0                       18446744073709551615

    Int16           16              samma som short
    Int32           32              samma som int
    Int64           64              samma som long

    int firstNumber = 1;
    long secondNumber = 2;
    long sum = firstNumber + secondNumber;


    C# Floating Points
    TYPE            BYTES           DECIMAL RANGE       SUFFIX          USED FOR
    ---------------------------------------------------------------------------------------------------------------------
    float           4               6-9 digits          f eller F       lämplig för Machine Learning, iot-sensorer
    double          8               15-16 digits        d eller D       lämplig för optimering av lagring/prestanda
    decimal         16              28-29 digits        m eller M       lämplig för finansiella tal som pengar

    float   sumFloat   = 0.1f + 0.1f + 0.1F;
    double  sumDouble  = 0.1 + 0.1d + 0.1D;
    decimal sumDecimal = 0.1m + 0.1m + 0.1M;

    Console.WriteLine("FLOAT: " + sumFloat);
    Console.WriteLine("DOUBLE: " + sumDouble);
    Console.WriteLine("DECIMAL: " + sumDecimal);


    C# Strings
    TYPE            BIT             SCHEME                      CHAR RANGE
    --------------------------------------------------------------------------------------------------------------------
    char            16              ASCII/UTF-8 (unicode)       ASCII (X+0000 -> X+FFFF) UTF8 (U+0000 -> U+FFFF)
    string          64              ASCII/UTF-8 (unicode)       max 2GB (~ 1 000 000 000 tecken)

    ASCII = Engelskt tangentbord
    UTF-8 = Svenskt tangentbord (dvs specialtecken som åäö)

    var message = new Message(Encoding.UTF8.GetBytes("Här är mitt namn..."));
    var message = new Message(Encoding.ASCII.GetBytes("Har ar mitt namn..."));

    char text = '';
    string text = "Här är en text";

    \       talar om att den ska läsa nästa tecken som en helt vanlig tecken
    @""     talar om att den ska läsa hela textsträngen som helt vanlig text
    $""     vi skriver då med hjälp av placeholders som läggs in i {variablenamnet}  
    \n      vi gör en radbrytning
    \t      vi gör ett tabbindrag

    string citat = "Tommy är den \"bästa\" människan i världen.";
    string citat = "Tommy är den 'bästa' människan i världen.";
    
    string json = "{ \"firstName\": \"Hans\", \"lastName\": \"Mattin-Lassei\", \"age\": 37 }";

    string filePath = "D:\\LEXICON\\NETFUND21\\cs\\lektion-2\\01_CSFundamentals_Basics\\Program.cs";
    string filePath = @"D:\LEXICON\NETFUND21\cs\lektion-2\01_CSFundamentals_Basics\Program.cs";

    string firstName = "Hans";
    string lastName = "Mattin-Lassei";
    int age = 37;
    string city = "Vega";
    string state = "Haninge";

    string placeholder = "Jag heter Hans Mattin-Lassei och jag är 37 år \"gammal\" och bor i Vega i Haninge.";
    string placeholder = "Jag heter " + firstName + " " + lastName + " och jag är " + age + " år \"gammal\" och bor i " + city + " i " + state + ".";
    string placeholder = string.Format("Jag heter {0} {1} och jag är {2} år \"gammal\" och bor i {3} i {4}.", firstName, lastName, age, city, state);
    string placeholder = $"Jag heter {firstName} {lastName} och jag är {age} år \"gammal\" och bor i {city} i {state}.";

    string fileName = "Program.cs";
    string filePath = @$"D:\LEXICON\NETFUND21\cs\lektion-2\01_CSFundamentals_Basics\{fileName}";



    C# Boolean
    TYPE        BIT         VALUES
    --------------------------------------------------------------------------------------------------------------------
    bool        0/1         false/true    


    
    C# Guid (Global Unique Identifier) 
    VARIABLE        BYTES               COMMAND                     RESULT
    --------------------------------------------------------------------------------------------------------------------
    Guid id;        16                  Guid.NewGuid();             8428f0a1-129e-4c57-a5aa-461bfd15da84    

*/
#endregion

#region VARABLES

/*  
    VARIABEL
    SPRÅK       MODELL              EXEMPEL                 BESKRIVNING
    ---------------------------------------------------------------------------------------------------------
    C#          Pascal              FirstName               Stor bokstav på varje ord
    
    JS          camelCase           firstName               första ordet börjar med liten bokstav resten börjar med stor bokstav
    Java        camelCase           firstName               första ordet börjar med liten bokstav resten börjar med stor bokstav
    C/C++       camelCase           firstName               första ordet börjar med liten bokstav resten börjar med stor bokstav
    Python      snake_case          first_name              varje ord separeras med en _
 
 
    Design Pattern
    ----------------------------------------------------------------------------------------------------------
    Field       firstName                                           inuti en klass
    Property    FirstName                                           inuti en klass med Getters Setters
    Parameter   firstName                                           input till en metod
    Variable    firstName, FirstName, firstname, _firstName         inuti en metod

    
    Deklarera variabler
    ----------------------------------------------------------------------------------------------------------
    string firstName                deklarerar med en fast datatyp
    var firstName = "Hans";         deklararer med en icke fast datatyp utan blir den datatypen som sätts
    dynamic firstName = "";         deklararar med en datatyp som är dynamic och du kan stoppa in vad du vill där

    readonly decimal pi = 3.14m;    blir read only dvs jag kan inte ändra värdet på pi
    const decimal pi = 3.14m;       blir read only dvs jag kan inte ändra värdet på pi


        Konvertera om datatyper
        ----------------------------------------------------------------------------------------------------------
        byte.Parse()        omvandlar det som står till en byte
        int.Parse()         omvandlar det som står till ett heltal
        bool.Parse()        omvandlar det som står till en true/false värde
        long.Parse()        omvandlar det som står till ett int64 värde
        decimal.Parse()
        ...


    Console.Write("Ange ditt fullständiga namn: ");
    string fullName = Console.ReadLine();

    Console.Write($"Hej {fullName}. Hur gammal är du? ");
    int age = int.Parse(Console.ReadLine());

    Console.WriteLine($"Hej {fullName}. Jag är också {age} år gammal.");

    var birthYear = DateTime.Now.AddYears(-age).Year;
    Console.WriteLine($"Du föddes år {birthYear}.");
    Console.ReadKey();
*/

#endregion

#region LISTS and ARRAYS

/*  
    LIST - dynamisk lista
    -------------------------------------------------------------------------------------------------------
    List<int> numbers               List<int> numbers = new List<int>();
    List<Customer> customers        List<Customer> customers = new();
    List<string> names              var names = new List<string>();

    index 0,1,2,3,4,5

        // CREATE INSTANCE OF LIST WITH DEFAULT VALUES
        var names = new List<string>() { "Hans" };


        // ADD TO THE END OF THE LIST
        names.Add("Joakim");
        names.Add("Tommy");
        names.Add("Hanna");
        names.Add("Frida");
        names.Add("Martin");
        names.Add("Hans");

        // INSERT AT A SPECIFIC POSITION
        names.Insert(1, "Stefan");

        // SORT THE LIST
        names.Sort();
        names.Reverse();

        // REMOVE FROM LIST
        names.Remove("Stefan");
        names.RemoveAt(1);
        //names.Clear();


        // FILTER THE LIST
        names = names.Where(name => name == "Hans").ToList();

        foreach(var name in names)
            Console.WriteLine(name);



    ARRAY   (en array är inte en lista) - fast lista
    -------------------------------------------------------------------------------
    string[] names                  string[] names = new string[5];     
    int[] numbers                   int[] numbers = new int[] { 1 ,2 ,3, 4 }
    string[] customers              string[] customers = { "Customer 1", "customer 2" }


    string[] names = new string[5];
    names[0] = "Hans";
    names[2] = "Joakim";
    names[3] = "Stefan";
    names[4] = "Hans";

    foreach (string name in names)
        Console.WriteLine(name);

*/

#endregion

#region LOOPS

/* 
    FOR LOOP - loopa igenom något ett givet antal gånger
    ----------------------------------------------------------
    for(int i=0; i < 10; i++) 
    {

    }


    
    FOREACH LOOP - loopa igenom alla objekt i en lista/array oavsett hur stor den är
    ---------------------------------------------------------------------------------
    foreach(var item in items) 
    {

    }
 
    
    VARNING! passa så du inte gör en evighetsloop
    WHILE LOOP - loopa så länge ett visst tillstånd gäller eller inte är uppfyllt 
    ---------------------------------------------------------------------------------
    int i = 0;
    while(i < 10) 
    { 
        i++; 
    }


    VARNING! passa så du inte gör en evighetsloop
    DO-WHILE LOOP - kör loopen minst en gång och kolla sedan om tillståndet 
                    är uppnått annars kör loopen igen
    ---------------------------------------------------------------------------------
    int i = 0;
    do 
    { 
        i++; 
    }
    while(i < 10);


*/


#endregion
