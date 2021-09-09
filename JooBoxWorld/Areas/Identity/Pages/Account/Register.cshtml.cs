using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using JooBoxWorld.Data;
using JooBoxWorld.Models;
using JooBoxWorld.Models.Validations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace JooBoxWorld.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Please choose {0}")]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Please enter {0}")]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please make sure there are no spaces, special characters & numbers on {0}")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please make sure there are no spaces, special characters & numbers on {0}")]
            [Display(Name = "Middle Name")]
            public string MiddleName { get; set; }

            [Required(ErrorMessage = "Please enter {0}")]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please make sure there are no spaces, special characters & numbers on {0}")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [PersonalData]
            [RSAIDNumber]
            [Display(Name = "ID number")]
            public string IdNo { get; set; }

            [Required(ErrorMessage = "Please select {0}")]
            [Display(Name = "Role")]
            public string Role { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [StringLength(10, ErrorMessage = "{0} must be 10 digits long", MinimumLength = 10)]
            [Display(Name = "Contact number", Prompt = "0781234567")]
            [DataType(DataType.PhoneNumber)]
            public string ContactNo { get; set; }

            [StringLength(10, ErrorMessage = "{0} must be 10 digits long", MinimumLength = 10)]
            [Display(Name = "Home tel.", Prompt = "0121234567")]
            [DataType(DataType.PhoneNumber)]
            public string HomeTel { get; set; }

            [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Street address cannot contain special characters")]
            [Display(Name = "Street", Prompt = "385 Jorissen St")]
            public string Street { get; set; }

            [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "{0} cannot contain numbers or special characters")]
            [Display(Name = "Suburb", Prompt = "Faerie Glen")]
            public string Suburb { get; set; }

            [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "{0} cannot contain numbers or special characters")]
            [Display(Name = "City", Prompt = "Pretoria")]
            public string City { get; set; }

            [StringLength(4, ErrorMessage = "Postal Code is 4 digits long", MinimumLength = 4)]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "{0} cannot contain letter or special characters")]
            [Display(Name = "Code", Prompt = "0002")]
            public string Code { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var identityInfo = new IdentityInfo(Input.IdNo);
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, Title = Input.Title, FirstName = Input.FirstName, MiddleName = Input.MiddleName, LastName = Input.LastName, IdNo = Input.IdNo, DoB = identityInfo.BirthDate, Gender = identityInfo.Gender };
                var contact = new Contact { ContactNo = Input.ContactNo, HomeTel = Input.HomeTel, ApplicationUser = user };
                var address = new Address { Street = Input.Street, Suburb = Input.Suburb, City = Input.City, Code = Input.Code, ApplicationUser = user };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    switch (Input.Role)
                    {
                        case "Agent":
                            await _userManager.AddToRoleAsync(user, "Agent");
                            var agent = new Agent { 
                                ApplicationUser = user, 
                                CreatedDate = DateTime.Now, 
                                IsActive = true 
                            };
                            await _context.AddAsync(agent);                            
                            break;
                        case "FieldManager":
                            await _userManager.AddToRoleAsync(user, "FieldManager");
                            var fieldManager = new FieldManager
                            {
                                ApplicationUser = user,
                                CreatedDate = DateTime.Now,
                                IsActive = true
                            };
                            await _context.AddAsync(fieldManager);
                            break;
                        case "Admin":
                            await _userManager.AddToRoleAsync(user, "Admin");
                            break;
                        default:
                            await _userManager.AddToRoleAsync(user, "Visitor");
                            break;
                    }
                    _logger.LogInformation("User added to role.");

                    await _context.AddAsync(contact);
                    await _context.AddAsync(address);
                    await _context.SaveChangesAsync();

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Dear {Input.Title} {Input.LastName}, <br/><br/> Your JooBox World user account has been created: <br/> Username: {Input.Email} <br/> Password: {Input.Password} <br/><br/> Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
