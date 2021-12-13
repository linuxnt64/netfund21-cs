/*
    Helpers/Handlers/Services = är klasser som hjälper oss att göra olika metoder.
    Models = är modeller dvs klasser över objekt som vi använder oss utav. En del av MVC (Model View Controller).
    Class = är en mall/modell över hur ett objekt ser ut. Kan vara vad som helst.  
*/

using _00_Repetition.Handlers;

int option = -1;
FileHandler.ReadFromFile();

do
{
    option = MenuHandler.Menu();
    Console.Clear();

    switch(option)
    {
        case 1:
            MenuHandler.MenuOption_Create();
            break;
        case 2:
            MenuHandler.MenuOption_Remove();
            break;
        case 3:
            MenuHandler.MenuOption_List();
            break;
        case 4:
            FileHandler.SaveToFile();
            break;
        case 5:
            MenuHandler.MenuOption_Settings();
            break;

        default:
            break;
    }

    Console.Clear();
}
while(option != 0);
