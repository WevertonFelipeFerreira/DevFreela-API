using System;

namespace DevFreela.Core.Entities
{
    public class Skills
    {
        public Skills(string description, DateTime createdAt)
        {
            Description = description;
            CreatedAt = DateTime.Now;
        }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
