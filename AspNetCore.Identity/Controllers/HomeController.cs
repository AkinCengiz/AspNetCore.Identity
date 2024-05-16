using AspNetCore.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AspNetCore.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
    {
	    _logger = logger;
	    _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult SignUp()
    {

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
	    if (!ModelState.IsValid)
	    {
		    return View();
	    }

		var identityResult = await _userManager.CreateAsync(new() { UserName = model.UserName, Email = model.Email, PhoneNumber = model.Phone },
		    model.Password);
	    
	    if (identityResult.Succeeded)
	    {
            TempData["SuccessMessage"] = "Kullanýcý baþarýyla oluþturuldu";
			return RedirectToAction(nameof(HomeController.SignUp));
	    }

	    foreach (IdentityError item in identityResult.Errors)
	    {
		    ModelState.AddModelError(string.Empty, item.Description);
	    }
		return View(model);
	}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
