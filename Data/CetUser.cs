using Microsoft.AspNetCore.Identity;

namespace BookStoreCet.Data
{
    public class CetUser : IdentityUser
    {
        public string? FullName { get; set; }

        public DateTime? BirthDate { get; set; }

        public List<Order> Orders { get; set; }

    }
}