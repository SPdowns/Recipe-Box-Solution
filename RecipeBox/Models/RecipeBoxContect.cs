using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class RecipeBoxContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Category> Categories { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<CategoryItem> CategoryRecipe { get; set;}

    public ToDoListMvcSqlEntityIdentityContext(DbContextOptions options) : base(options) { }
  }
}