#pragma warning disable CS8618
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ProjektiPersonal.Models;
public class MyContext : IdentityDbContext<ApplicationUser>
{   
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<Order> Orders {get; set;}
    public DbSet<ApplicationUser> ApplicationUsers {get; set;}
    public DbSet<Cart> Carts {get;set;}

    public DbSet<IdentityUserClaim<string>> IdentityUserClaim { get; set; }

protected override void OnModelCreating(ModelBuilder builder)
{
    builder.Entity<IdentityUserClaim<string>>().HasKey(p => new { p.Id });
    base.OnModelCreating(builder);
}

   //  public class FoodDBContext:IdentityDbContext<ApplicationUser>
    //{
    //    
    //    public FoodDBContext(DbContextOptions<FoodDBContext> options):base(options)
    //    {

    //    }
    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);
    //    }
   // }
}
