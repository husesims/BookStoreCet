using BookStoreCet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreCet.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesMenuViewComponent(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories =await dbContext.Categories.OrderBy(c=>c.Name).ToListAsync();
            return View(categories);

        }
    }
}
