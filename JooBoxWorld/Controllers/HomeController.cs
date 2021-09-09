using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JooBoxWorld.Models;
using JooBoxWorld.Data;
using Microsoft.EntityFrameworkCore;

namespace JooBoxWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ApplicationDbContext context,ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var vouchers = await _context.Vouchers.ToListAsync();
            if(TempData["voucherN"] == null && TempData["voucher"] != null)
            {
                TempData["voucher"] = new Voucher();
            }
            if (TempData["voucherA"] == null)
            {
                TempData["voucherA"] = "0";
            }

            return View(vouchers);
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
}
