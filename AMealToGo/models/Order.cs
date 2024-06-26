using System.ComponentModel.DataAnnotations.Schema;

namespace AMealToGo.models
{
    public class Order
    {
        
       // public static DateTime DateTime { get; internal set; }
        public int OrderId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int OrderStatusId { get; set; }
        public decimal? OrderTotal { get; set; }
        public DateTime? DateOrdered { get; set; }

        [ForeignKey(nameof(OrderStatusId))]
        public OrderStatus OrderStatus { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
    
    }
    public enum Status
    {
        OrderPlaced = 1, InTransit = 2, Delivered = 3
    }

}


