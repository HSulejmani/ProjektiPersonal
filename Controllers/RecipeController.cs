using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjektiPersonal.Models;

namespace ProjektiPersonal.Controllers { }

public class RecipeController : Controller
{

    private readonly UserManager<ApplicationUser> _userManager;
    private MyContext _context;
    public RecipeController(UserManager<ApplicationUser> userManager, MyContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult GetRecipeCard([FromBody] List<Recipe> recipes)
    {
        return PartialView("_RecipeCard", recipes);
    }

    public IActionResult Search([FromQuery] string recipe)
    {
        ViewBag.Recipe = recipe;
        return View();
    }
    public IActionResult Order([FromQuery] string id)
    {
        ViewBag.Id = id;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ShowOrder(OrderRecipeDetails orderRecipeDetails)
    {
        Random random = new Random();
        ViewBag.Price = Math.Round(random.Next(15, 500) / 5.0);
        var user = await _userManager.GetUserAsync(HttpContext.User);
        ViewBag.UserId = user?.Id;
        ViewBag.Address = user?.Address;
        return PartialView("_ShowOrder", orderRecipeDetails);
    }
    [HttpPost]
    [Authorize]
    public IActionResult Order([FromForm] Order order)
    {
        order.OrderDate = DateTime.Now;
        if (ModelState.IsValid)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ControllerContext.RouteData.Values.Add("id", order.Id);
        return RedirectToAction(nameof(Order));
    }
}
