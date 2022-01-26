using System;

namespace Exercise_5.Models
{
    internal class Case
    {
        public Case()
        {

        }

        public Case(int customerId, int statusTypeId, string title, string description)
        {
            CustomerId = customerId;
            StatusTypeId = statusTypeId;
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
        }

        public Case(int id, int customerId, int statusTypeId, string title, string description, DateTime createdDate)
        {
            Id = id;
            CustomerId = customerId;
            StatusTypeId = statusTypeId;
            Title = title;
            Description = description;
            CreatedDate = createdDate;
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StatusTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }


}
