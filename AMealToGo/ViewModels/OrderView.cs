namespace AMealToGo.ViewModels
{
    public class OrderView
    {
        public int? CustomerId { get; set; }
        public List<OrderItemView> Items { get; set; }
        
    }
}
