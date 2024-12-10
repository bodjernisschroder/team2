namespace Publico_Kommunikation.MVVM.Models
{
    /// <summary>
    /// Represents the data structure for a <see cref="Product"/> entity.
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
    }
}