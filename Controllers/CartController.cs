using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjektiPersonal.Models;
using ProjektiPersonal.Repository;

namespace ProjektiPersonal.Controller { }
[Authorize]
public class CartController : Controller
{
    private readonly IData data;
    private readonly MyContext context;
    public CartController(IData data, MyContext context)
    {
        this.data = data;
        this.context = context;
    }
    public async Task<IActionResult> Index()
    {
        var user = await data.GetUser(HttpContext.User);
        var cartsList = context.Carts.Where(c=> c.UserId == user.Id).ToList(); 
        return View(cartsList);
    }
    [HttpPost]
    public async Task<IActionResult> SaveCart(Cart cart)
    {
        var user = await data.GetUser(HttpContext.User);
        cart.UserId = user?.Id;
        if (ModelState.IsValid)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
            return Ok();
        }
        return BadRequest();
    }
    [HttpGet]
    public async  Task<IActionResult> GetGetAddedCarts()
    {
        var user = await data.GetUser(HttpContext.User);
        var carts = context.Carts.Where(c => c.UserId == user.Id).Select(c => c.RecipeId).ToList();
        return Ok(carts);
    }
    [HttpPost]
    public IActionResult RemoveCartFromList(string Id)
    {
        if(!string.IsNullOrEmpty(Id))
        {
            var cart = context.Carts.Where(c=>c.RecipeId == Id).FirstOrDefault();
            if(cart != null)
            {
            context.Carts.Remove(cart);
            context.SaveChanges();
            return Ok();
            }
        }
        return BadRequest();
    }
    [HttpGet]
    public async Task<IActionResult> GetCartList()
    {
        var user = await data.GetUser(HttpContext.User);
        var cartList = context.Carts.Where(c =>c.UserId == user.Id).Take(3).ToList();
        return PartialView("_CartList",cartList);
    }
}
