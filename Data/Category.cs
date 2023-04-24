using System.ComponentModel.DataAnnotations;

namespace BookStoreCet.Data
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }


        public virtual List<Book>? Books { get; set; } = new List<Book>();
    }
}
