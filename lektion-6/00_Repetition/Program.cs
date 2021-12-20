using _00_Repetition.Handlers;
using _00_Repetition.Models.Forms;

IAuthManager authManager = new AuthManager();

var signUpForm = new SignUpForm();

Console.WriteLine("Registrering");
Console.WriteLine("--------------------------------------------------");

Console.Write("Förnamn: ");
    signUpForm.FirstName = Console.ReadLine();
Console.Write("Efternamn: ");
    signUpForm.LastName = Console.ReadLine();
Console.Write("Email: ");
    signUpForm.Email = Console.ReadLine();
Console.Write("Lösenord: ");
    signUpForm.Password = Console.ReadLine();
Console.Write("Adress: ");
    signUpForm.AddressLine = Console.ReadLine();
Console.Write("Postnummer: ");
    signUpForm.PostalCode = Console.ReadLine();
Console.Write("Stad: ");
    signUpForm.City = Console.ReadLine();

Console.Clear();
authManager.SignUp(signUpForm);





Console.ReadKey();

