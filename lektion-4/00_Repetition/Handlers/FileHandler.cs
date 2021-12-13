using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Repetition.Handlers
{
    internal class FileHandler
    {
        private static string _filePath = @"d:\test";

        public static void SetFilePath(string filePath)
        {
            _filePath = filePath.Trim();
        }


        public static void SaveToFile()
        {
            var list = ParticipantHandler.GetParticipantList();

            using (StreamWriter sw = new StreamWriter(@$"{_filePath}\participant-list.csv"))
            {
                sw.WriteLine("id;firstName;lastName;email");

                foreach (var participant in list)
                {
                    sw.WriteLine($"{participant.Id};{participant.FirstName};{participant.LastName};{participant.Email}");
                }
            }
        }

        public static void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(@$"{_filePath}\participant-list.csv"))
            {
                var line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    var values = line.Split(";");

                    try
                    {
                        ParticipantHandler.AddParticipantToList(new Models.Participant
                        {
                            Id = Guid.Parse(values[0]),
                            FirstName = values[1],
                            LastName = values[2],
                            Email = values[3]
                        });
                    }
                    catch { }

                }
            }
        }
    }
}
