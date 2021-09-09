using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JooBoxWorld.Models;
using JooBoxWorld.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JooBoxWorld.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UsersController> _logger;
        public UsersController(UserManager<ApplicationUser> userManager, ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        public List<ApplicationUser> Users { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Code { get; set; }
        }
        public IActionResult Index()
        {
            Users = _userManager.Users.Include(p => p.Agent).Include(x => x.FieldManager).Where(p => p.UserName != "i.skngobese@gmail.com").ToList();
            
            return View(Users);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred while deleting user with ID '{user.Id}'.");
            }
            Users = _userManager.Users.Include(p => p.Agent).Include(x => x.FieldManager).Where(p => p.UserName != "i.skngobese@gmail.com").ToList();
            _logger.LogInformation("User with ID '{0}' deleted.", user.Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ResetPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred while deleting user with ID '{user.Id}'.");
            }
            Users = _userManager.Users.Include(p => p.Agent).Include(x => x.FieldManager).Where(p => p.UserName != "i.skngobese@gmail.com").ToList();
            _logger.LogInformation("User with ID '{0}' deleted.", user.Id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, [Bind("Id,CreatedDate,IsActive")] Agent agent)
        {
            return View();
        }
    }
}
