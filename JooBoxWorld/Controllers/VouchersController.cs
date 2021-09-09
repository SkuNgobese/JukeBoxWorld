using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JooBoxWorld.Data;
using JooBoxWorld.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace JooBoxWorld.Controllers
{
    public class VouchersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static Random random = new Random();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<VouchersController> _logger;
        public VouchersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<VouchersController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: Vouchers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vouchers.ToListAsync());
        }

        // GET: Vouchers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucher = await _context.Vouchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voucher == null)
            {
                return NotFound();
            }

            return View(voucher);
        }

        // GET: Vouchers/Create
        public IActionResult Generate()
        {
            return View();
        }

        // POST: Vouchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate([Bind("Id,VNumber,Amount,SellDate,IsUsed")] Voucher voucher)
        {
            //var currentUser = User;
            var id = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(id);
            if (ModelState.IsValid && voucher.Amount > 0)
            {
                int lengthOfVoucher = 10;
                //ABCDEFGHIJKLMNOPQRSTUVWXYZ
                char[] keys = "0123456789".ToCharArray();

                var token = GenerateVoucher(keys, lengthOfVoucher);
                while (VoucherExists(token))
                {
                    token = GenerateVoucher(keys, lengthOfVoucher);
                }
                
                voucher.Id = Guid.NewGuid();
                voucher.SellDate = DateTime.Now;
                voucher.VNumber = token;
                voucher.IsUsed = false;
                if(User.IsInRole("Agent"))
                {
                    voucher.ApplicationUser = user;
                }
                else if(User.IsInRole("FieldManager"))
                {
                    voucher.ApplicationUser = user;
                }
                _context.Add(voucher);
                await _context.SaveChangesAsync();
                _logger.LogInformation(user.FullName + " sold voucher " + voucher.VNumber);
                Console.WriteLine(token);
                //TempData["voucherA"] = voucher.Amount.ToString();
                TempData["voucherN"] = Regex.Replace(voucher.VNumber, @"^(....)(..)(....)$", "$1-$2-$3"); 
                return RedirectToAction(nameof(Index),"Home");
            }
            
            return RedirectToAction(nameof(Index),"Home");
        }

        private static string GenerateVoucher(char[] keys, int lengthOfVoucher)
        {
            return Enumerable
                .Range(1, lengthOfVoucher) // for(i.. ) 
                .Select(k => keys[random.Next(0, keys.Length - 1)])  // generate a new random char 
                .Aggregate("", (e, c) => e + c); // join into a string
        }

        // GET: Vouchers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucher = await _context.Vouchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voucher == null)
            {
                return NotFound();
            }

            return View(voucher);
        }

        // POST: Vouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var voucher = await _context.Vouchers.FindAsync(id);
            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoucherExists(string token)
        {
            return _context.Vouchers.Any(e => e.VNumber == token);
        }
    }
}
