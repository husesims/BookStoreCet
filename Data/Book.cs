﻿using System.ComponentModel.DataAnnotations;

namespace BookStoreCet.Data
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name  { get; set; }
        [Range(0,1000)]
        public Decimal Price { get; set; }
        [Display(Name="Page Count")]
        public int PageCount { get; set; }
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }   

        public int? PublisherId { get; set; }

        public virtual Publisher? Publisher { get; set; }


        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

    }
}
