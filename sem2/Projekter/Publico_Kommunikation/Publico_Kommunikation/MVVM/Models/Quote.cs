namespace Publico_Kommunikation.MVVM.Models
{
    /// <summary>
    /// Represents the data structure for a <see cref="Quote"/> entity.
    /// </summary>
    public class Quote
    {
        public int QuoteId { get; set; }
        public string QuoteName { get; set; }
        public string? Tags { get; set; }
        public string? FilePath { get; set; }
        public double HourlyRate { get; set; }
        public int DiscountPercentage { get; set; }
        public double Sum { get; set; }
    }
}