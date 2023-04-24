using BookStoreCet.Data;
using System.ComponentModel.DataAnnotations;

namespace BookStoreCet.Models
{
    public class PurchaseModel
    {
        public string NameSurname { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set;}
        
        public string CardInfo { get; set; }
        public Book? PurchasedBook { get; set; }

        public int PurchasedBookId { get; set; }
    }
}
