using Exercise_2.Services;
var eventManager = new EventManager();
var filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\users.json";

while(true)
{
    Console.Clear();
    Console.WriteLine("1. Create Participant");
    Console.WriteLine("2. List Participants");
    Console.WriteLine("3. Remove Participant");
    Console.WriteLine("4. Generate Coupon Code");
    Console.WriteLine("5. Save to File");
    Console.Write("Choose one option: ");
    var option = Console.ReadLine();

    switch(option)
    {
        case "1":
            eventManager.CreateParticipant();
            break;
        case "2":
            eventManager.ListParticipants();
            break;
        case "3":
            eventManager.RemoveParticipant();
            break;
        case "4":
            eventManager.GenerateCouponCode();
            break;
        case "5":
            eventManager.SaveToFile(filePath);
            break;
    }
}