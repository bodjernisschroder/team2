namespace Publico_Kommunikation_Project.Models
{
    public class QuoteProduct
    {
        public int QuoteId { get; set; }
        public int ProductId { get; set; }
        public Quote Quote { get; set; }
        public Product Product { get; set; }
        public double QuoteProductTimeEstimate { get; set; }
        public double QuoteProductPrice { get; set; }
    }
}