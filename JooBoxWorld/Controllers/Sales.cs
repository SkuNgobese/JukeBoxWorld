using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JooBoxWorld.Data;
using JooBoxWorld.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JooBoxWorld.Controllers
{
    public class Sales : Controller
    {
        private readonly ApplicationDbContext _context;

        public Sales(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index() 
        {
            var sales = new List<FieldManagersViewModel>();
            double sale = 0;
            var fieldManagers = _context.FieldManagers.Include(a => a.Agents).Include(a => a.ApplicationUser).Include(f => f.ApplicationUser.Vouchers);
            foreach (var fieldManager in fieldManagers)
            {
                var agents = _context.Agents.Include(v => v.ApplicationUser.Vouchers).Where(p => p.FieldManager == fieldManager);
                foreach (var agent in agents)
                {
                    foreach (var voucher in agent.ApplicationUser.Vouchers)
                    {
                        sale += voucher.Amount;
                    }
                }
                foreach (var voucher in fieldManager.ApplicationUser.Vouchers)
                {
                    sale += voucher.Amount;
                }
                sales.Add(new FieldManagersViewModel
                {
                    FielManagerId = fieldManager.Id,
                    FName = fieldManager.ApplicationUser.FullName,
                    CreatedDate = fieldManager.CreatedDate,
                    NumberOfAgents = fieldManager.Agents.Count(),
                    _Sales = sale
                });
            }
            return View(sales.ToList());
        }
    }
}
