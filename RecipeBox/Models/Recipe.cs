using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe()
  {
    public Recipe()  
    {
      this.Categories = new HashSet<CategoryRecipe>();
      IsComplete = false;
    }
    public int RecipeId { get; set; }
    public string Title { get; set; }
    public string 
  }
}