namespace Day3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        //foreign key to categoy
        public int CategoryId { get; set; }
        
        //navigation property to category
        public Category? Category { get; set; }



    }
}
