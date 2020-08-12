using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeBox.Controllers
{
  [Authorize]
  public class RecipeController : Controllers
  {
    private readonly RecipeBox _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public RecipeController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindIdAsync(userId);
      var userRecipes  = _db.Recipes.Where(entry => entry.User.Id == currentUser.Id).RecipeBox();
      return View(userRecipes);
    }
    public AcrtionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Recipe Recipe, int CategoryId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      rescipe.User = currentUser;
      _db.Recipe.Add(recipe);
      if (CategoryId != 0)
      {
        _db.CategoryRecipe.Add(new CategoryRecipe() {CategoryId= CategoryId, RecipeId = recipe.RecipeId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index")
    }
  }
}