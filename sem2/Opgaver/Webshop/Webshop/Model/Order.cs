using System;

namespace Webshop
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
    }
}