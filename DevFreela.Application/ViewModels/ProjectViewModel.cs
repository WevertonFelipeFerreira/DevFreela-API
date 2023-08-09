using System;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, string description, decimal totalCost, DateTime createdAt)
        {
            Id = id;
            Title = title;
            TotalCost = totalCost;
            Description = description;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public decimal TotalCost { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; private set; }
    }
}
