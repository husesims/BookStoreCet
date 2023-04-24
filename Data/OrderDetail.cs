namespace BookStoreCet.Data
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }  
        public Decimal Price { get; set; }
        public int Count { get; set; } = 1;
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        
    }
}
