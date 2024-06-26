using System.ComponentModel.DataAnnotations.Schema;

namespace AMealToGo.models
{
    public class Product
    {
        public int ProductId  { get; set; }
        public string Name { get; set; }
        public int? CategoryId  { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        [ForeignKey(nameof (CategoryId))]
        public Category? Category { get; set; }
    }
}
