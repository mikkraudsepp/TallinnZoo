using System;
using System.IO.Pipes;

namespace Domain
{
    public class Feedback : BaseEntity
    {
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string SenderEmail { get; set; }
    }
}