using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreCet.Models
{
    public class ShopingList
    {
        public int BookId { get; set; }
        public int Count { get; set; }
    }

    public class ShopingCard : List<ShopingList>
    {
        public ShopingCard():base() { }
       
    }
}
