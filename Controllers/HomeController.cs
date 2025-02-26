﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjektiPersonal.Models;

namespace ProjektiPersonal.Controllers{}

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
      private MyContext _context;    
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;   
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
