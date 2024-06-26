using System.ComponentModel.DataAnnotations.Schema;

namespace AMealToGo.models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }
        //public  List<Order> Orders { get; set; }
    }
}
