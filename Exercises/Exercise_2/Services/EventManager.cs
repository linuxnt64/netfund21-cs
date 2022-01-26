using Exercise_2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2.Services
{
    internal class EventManager
    {
        public List<Participant> Participants = new List<Participant>();

        public void CreateParticipant()
        {
            Console.Clear();
            Console.WriteLine("Create Participant");

            var participant = new Participant();

            Console.Write("Förnamn: ");
                participant.FirstName = Console.ReadLine();
            Console.Write("Efternamn: ");
                participant.LastName = Console.ReadLine();
            Console.Write("E-postadress: ");
                participant.Email = Console.ReadLine();

            Participants.Add(participant);
        }

        public void ListParticipants()
        {
            Console.Clear();
            Console.WriteLine("Participant List");
            foreach (var participant in Participants)
                Console.WriteLine($"{participant.DisplayName} ({participant.Email})");

            Console.ReadKey();
        }

        public void RemoveParticipant()
        {
            Console.Clear();
            Console.WriteLine("Remove Participant");

            Console.Write("E-postadress: ");
            var email = Console.ReadLine();

            Participants = Participants.Where(x => x.Email != email).ToList();
        }


        public void GenerateCouponCode()
        {
            Console.Clear();
            Console.WriteLine("Generate Coupon Code");

            Console.WriteLine(Guid.NewGuid().ToString());
            
            Console.ReadKey();
        }


        public void SaveToFile(string filePath)
        {
            Console.Clear();
            Console.WriteLine("Saving to file");

            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(JsonConvert.SerializeObject(Participants));
            }

            Console.ReadKey();
        }
    }
}
