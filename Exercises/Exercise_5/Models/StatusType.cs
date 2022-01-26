namespace Exercise_5.Models
{
    internal class StatusType
    {
        public StatusType()
        {

        }

        public StatusType(string status)
        {
            Status = status;
        }

        public StatusType(int id, string status)
        {
            Id = id;
            Status = status;
        }

        public int Id { get; set; }
        public string Status { get; set; }
    }


}
