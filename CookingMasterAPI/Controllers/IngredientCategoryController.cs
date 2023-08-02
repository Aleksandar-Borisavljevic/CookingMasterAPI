using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingMasterAPI.Data;
using CookingMasterAPI.Models.Entity;

namespace CookingMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientCategoryController : ControllerBase
    {
        private readonly APIDbContext _context;
        public IngredientCategoryController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientCategory>>> GetIngredientCategories()
        {
            try
            {
                if (_context.IngredientCategories is null)
                {
                    return NotFound();
                }

                return await _context.IngredientCategories.Where(x => x.DeleteDate == null).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<IngredientCategory>> GetIngredientCategory(int categoryId)
        {
            try
            {
                if (_context.IngredientCategories is null)
                {
                    return NotFound();
                }
                var ingredientCategory = await _context.IngredientCategories.FindAsync(categoryId);
                //var ingredientCategory = await _context.IngredientCategories.SingleOrDefaultAsync(c => c.CategoryId == categoryId);

                if (ingredientCategory is null)
                {
                    return NotFound();
                }
                return ingredientCategory;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
