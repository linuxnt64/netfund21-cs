using _01_Exersice2_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Exersice2_Example.Services
{
    internal class EventService
    {
        private static List<Participant> participants = new List<Participant>();




        public static void CreateParticipant()
        {
            /* Skapar en deltagare och sätter värden för de olika properties */
            Participant participant = new Participant();

            Console.Write("Förnamn: ");
                participant.FirstName = Console.ReadLine();
            
            Console.Write("Efternamn: ");
                participant.LastName = Console.ReadLine();
            
            Console.Write("E-postadress: ");
                participant.Email = Console.ReadLine();
            
            Console.Write("Speciella önskemål: ");
                participant.SpecialRequests = Console.ReadLine();

            participants.Add(participant);

        }

        public static void ShowParticipants()
        {
            /* loopar igenom alla deltagare i listan och skriver ut information om respektive */
            foreach (var p in participants)
            {
                Console.WriteLine("");
                Console.WriteLine($"Deltagarens namn: {p.FullName}");
                Console.WriteLine($"Deltagarens email: {p.Email}");
            }
        }

        public static void DeleteParticipant()
        {
            Console.Write("E-postadress på den som ska tas bort: ");
            var email = Console.ReadLine();
            participants = participants.Where(participant => participant.Email != email).ToList();
        }

        public static void GenerateCoupon()
        {
            var code = Guid.NewGuid();
            Console.WriteLine($"Rabattkod: {code}");
        }

        public static void SaveList()
        {
            string[] lines = new string[participants.Count];

            for(int i = 0; i < participants.Count; i++)
            {
                lines[i] = $"{participants[i].FirstName},{participants[i].LastName},{participants[i].Email},{participants[i].SpecialRequests}";
            }

            File.WriteAllLines(@"d:\participantlist.txt", lines);
        }

        public static void ShowMenu()
        {
            int choice = -1;

            do
            {
                Console.WriteLine("### MENY ###");
                Console.WriteLine("1. Skapa en deltagare");
                Console.WriteLine("2. Ta bort en deltagare");
                Console.WriteLine("3. Lista upp alla deltagare");
                Console.WriteLine("4. Skapa en rabattkod");
                Console.WriteLine("5. Spara deltagarlistan");
                Console.WriteLine("0. Avsluta");
                Console.Write("\nVälj ett av alternativen ovan: ");
                choice = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        CreateParticipant();
                        break;
                    case 2:
                        DeleteParticipant();
                        break;
                    case 3:
                        ShowParticipants();
                        Console.ReadKey();
                        break;
                    case 4:
                        GenerateCoupon();
                        Console.ReadKey();
                        break;
                    case 5:
                        SaveList();
                        break;
                }

                Console.Clear();
            }
            while (choice != 0);
        }
    }
}
