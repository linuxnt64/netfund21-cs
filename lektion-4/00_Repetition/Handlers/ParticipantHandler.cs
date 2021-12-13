using _00_Repetition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Repetition.Handlers
{
    internal class ParticipantHandler
    {
        private static List<Participant> participantList = new List<Participant>();





        public static void AddParticipantToList(Participant participant)
        {
            participantList.Add(participant);
        }


        public static bool RemoveParticipantFromList(Guid id)
        {
            try
            {                     
                participantList = participantList.Where(x => x.Id != id).ToList();
            }
            catch
            {
                return false;
            }
           
            return true;
        }


        public static IEnumerable<Participant> GetParticipantList()
        {
            return participantList.OrderBy(x => x.FullName);
        }

        public static Participant GetParticipant(Guid id)
        {
            return participantList.FirstOrDefault(x => x.Id == id);
        }
    }
}
