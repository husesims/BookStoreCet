namespace BookStoreCet.Data
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string NameSurname { get; set; }
        public string Address { get; set;}
        public string CardInfo { get; set; }
        public virtual ICollection<OrderDetail> Orders { get; set; } =new List<OrderDetail>();

        public string? CetUserId { get; set; }
        public virtual CetUser CetUser { get; set; }
    }
}
