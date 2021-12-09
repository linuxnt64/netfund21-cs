using _02_Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Classes.Services
{
    internal class ParticipantService
    {
        public void CreateParticipant()
        {
            Participant participant = new Participant();

            Console.Write("Förnamn: ");
            participant.FirstName = Console.ReadLine();
            
            Console.Write("Efternamn: ");
            participant.LastName = Console.ReadLine();
            
            Console.Write("E-postadress: ");
            participant.Email = Console.ReadLine();
            
            Console.Write("Speciella önskemål: ");
            participant.SpecialRequests = Console.ReadLine();
        }
    }
}

