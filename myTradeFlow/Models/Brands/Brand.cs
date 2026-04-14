using System.Data;

namespace myTradeFlow.Models.Brands
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime UpdateData { get; set; } 
    }
}