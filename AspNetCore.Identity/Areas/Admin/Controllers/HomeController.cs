﻿using AspNetCore.Identity.Areas.Admin.Models;
using AspNetCore.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Identity.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
	private readonly UserManager<AppUser> _userManager;

	public HomeController(UserManager<AppUser> userManager)
	{
		_userManager = userManager;
	}

	public IActionResult Index()
	{
		return View();
	}

	public async Task<IActionResult> UserList()
	{
		var userList = await _userManager.Users.ToListAsync();
		var userViewModelList = userList.Select(x => new UserViewModel()
		{
			Id = x.Id,
			Name = x.UserName,
			Email = x.Email
		}).ToList();
		return View(userViewModelList);
	}
}
