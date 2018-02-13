using System;

namespace Assignment.models
{
    public class Project
    {
        public Int32 ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string Category { get; set; }
        public string Responsible { get; set; }
        public double? SavingsAmount { get; set; }
        public string Currency { get; set; }
        public string Complexity { get; set; }
    }
}
