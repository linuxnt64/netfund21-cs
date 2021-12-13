using _00_Repetition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Repetition.Handlers
{
    internal class MenuHandler
    {
        /// <summary>
        /// Prints out the Main Menu in the console
        /// </summary>
        /// <returns>The selected menu value (between 0-3)</returns>
        public static int Menu()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("---      MENU OPTIONS      ---");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1. Create Participant");
            Console.WriteLine("2. Remove Participant");
            Console.WriteLine("3. Show Participants List");
            Console.WriteLine("4. Save Participants List");
            Console.WriteLine("5. Settings");
            Console.WriteLine("0. Quit Application");
            Console.WriteLine("");
            Console.Write("Select an option (0-3): ");

            return int.Parse(Console.ReadLine() ?? "-1");
        }

        public static void MenuOption_Create()
        {           
            Console.WriteLine("------------------------------");
            Console.WriteLine("---   CREATE PARTICIPANT   ---");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");

            var participant = new Participant();
            
            Console.Write("First Name: "); 
            participant.FirstName = Console.ReadLine() ?? "";

            Console.Write("Last Name: ");
            participant.LastName = Console.ReadLine() ?? "";

            Console.Write("Email Address: ");
            participant.Email = Console.ReadLine() ?? "";

            if(!string.IsNullOrEmpty(participant.FirstName) || !string.IsNullOrEmpty(participant.LastName) || !string.IsNullOrEmpty(participant.Email))
            {
                ParticipantHandler.AddParticipantToList(participant);
                Console.WriteLine($"\nParticipant {participant.FullName} was added to the participant list.");
            }
            else
            {
                Console.WriteLine("No values was supplied. No participant was created.");
            }

            
            Task.Delay(1500).Wait();
        }

        public static void MenuOption_Remove()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("---   REMOVE PARTICIPANT   ---");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.Write("Enter the ID for the Participant to delete: ");
            var id = Console.ReadLine();

            if(!string.IsNullOrEmpty(id))
            {
                var participant = ParticipantHandler.GetParticipant(Guid.Parse(id));

                if (ParticipantHandler.RemoveParticipantFromList(participant.Id))
                    Console.WriteLine($"Participant { participant.FullName } was removed from the participant list.");
                else
                    Console.WriteLine($"Unable to remove Participant from the list.");
            }
            else
                Console.WriteLine($"No id was supplied.");

            Task.Delay(1500).Wait();
        }

        public static void MenuOption_List()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("---    PARTICIPANT LIST    ---");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");

            foreach (var participant in ParticipantHandler.GetParticipantList())
                Console.WriteLine($"{participant.Id} : {participant.FullName} ({participant.Email})");

            Console.WriteLine("");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        public static void MenuOption_Settings()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("---        SETTINGS        ---");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");

            Console.Write("Enter your preferred file path (eg. c:\folder): ");
            FileHandler.SetFilePath(Console.ReadLine());
        }
    }
}
