using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Recipe()  
    {
      this.Categories = new HashSet<CategoryRecipe>();
    }
    public int RecipeId { get; set; }
    public string Title { get; set; }
    public string Ingredients { get; set; }
    public string Directions { get; set; }
    public virtual ApplicationUser User { get; set; }
    public ICollection<CategoryRecipe> Categories { get; }
  }
}