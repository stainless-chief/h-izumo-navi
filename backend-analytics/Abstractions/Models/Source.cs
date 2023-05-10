namespace Abstractions.Models
{
    public class Source
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TotalEvents { get; set; }

        public Source()
        { 
        }

        public Source(Source source) 
        { 
            Code = source.Code;
            Name = source.Name;
            Description = source.Description;
            TotalEvents = source.TotalEvents;
        }
    }
}
