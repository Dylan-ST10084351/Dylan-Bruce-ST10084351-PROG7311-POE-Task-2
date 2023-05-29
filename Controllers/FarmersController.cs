using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Data;
using Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Models;
using Microsoft.AspNetCore.Identity;

namespace Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Controllers
{
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public FarmersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public FarmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Farmers
        public async Task<IActionResult> Index()
        {
              return _context.Farmer != null ? 
                          View(await _context.Farmer.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Farmer'  is null.");
        }

        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Farmer == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // GET: Farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmerId,FarmerName,FarmerSurname,EmailAddress,Password")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                //create the farmer
                var user = new IdentityUser { UserName = farmer.EmailAddress, Email = farmer.EmailAddress };
                var result = await _userManager.CreateAsync(user, farmer.Password);

                if (result.Succeeded)
                {
                    //sign in the user
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //save the farmer details
                    _context.Add(farmer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(farmer);
        }

        // POST: Farmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerId,FarmerName,FarmerSurname")] Farmer farmer)
        {
            if (id != farmer.FarmerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerExists(farmer.FarmerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(farmer);
        }

        // GET: Farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Farmer == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Farmer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Farmer'  is null.");
            }
            var farmer = await _context.Farmer.FindAsync(id);
            if (farmer != null)
            {
                _context.Farmer.Remove(farmer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerExists(int id)
        {
          return (_context.Farmer?.Any(e => e.FarmerId == id)).GetValueOrDefault();
        }
    }
}
