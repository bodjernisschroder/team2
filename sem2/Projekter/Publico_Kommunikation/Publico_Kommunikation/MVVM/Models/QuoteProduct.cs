namespace Publico_Kommunikation.MVVM.Models
{
    /// <summary>
    /// Represents the data structure for a <see cref="QuoteProduct"/> entity.
    /// </summary>
    public class QuoteProduct
    {
        public int QuoteId { get; set; }
        public int ProductId { get; set; }
        public double? QuoteProductTimeEstimate { get; set; }
        public double QuoteProductPrice { get; set; }
    }
}