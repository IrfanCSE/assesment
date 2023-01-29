using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using primetechmvc.DTO;
using primetechmvc.IRepository;
using primetechmvc.Models;

namespace primetechmvc.Controllers;

public class LoginController : Controller
{
    private readonly IUser _user;

    public LoginController(IUser user)
    {
        this._user = user;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromForm] UserModel login)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.message = "Invalid Model";
            return View();
        }

        var response = await _user.LoginUser(login);

        if (response.Token == null)
        {
            ViewBag.message = response.Message;
            return View();
        }

        return RedirectToAction("Index", "Student");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
