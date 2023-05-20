using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tatoulink.DTO;
using tatoulink.Models;

namespace tatoulink.Controllers
{
    public class JobOfferUsersController : Controller
    {
        private readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public JobOfferUsersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: JobOfferUsers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.JobOfferUsers.Include(j => j.JobOffer).Include(j => j.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: JobOfferUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobOfferUsers == null)
            {
                return NotFound();
            }

            var jobOfferUser = await _context.JobOfferUsers
                .Include(j => j.JobOffer)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOfferUser == null)
            {
                return NotFound();
            }

            return View(jobOfferUser);
        }

        // GET: JobOfferUsers/Create
        public IActionResult Create()
        {
            ViewData["JobOfferId"] = new SelectList(_context.JobOffers, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: JobOfferUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobOfferId,UserId")] JobOfferUserDTO jobOfferUserDTO)
        {
            if (ModelState.IsValid)
            {
                JobOfferUser jobOfferUser = _mapper.Map<JobOfferUser>(jobOfferUserDTO);
                _context.Add(jobOfferUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobOfferId"] = new SelectList(_context.JobOffers, "Id", "Id", jobOfferUserDTO.JobOfferId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", jobOfferUserDTO.UserId);
            return View(jobOfferUserDTO);
        }

        // GET: JobOfferUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobOfferUsers == null)
            {
                return NotFound();
            }

            var jobOfferUser = await _context.JobOfferUsers.FindAsync(id);
            if (jobOfferUser == null)
            {
                return NotFound();
            }
            ViewData["JobOfferId"] = new SelectList(_context.JobOffers, "Id", "Id", jobOfferUser.JobOfferId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", jobOfferUser.UserId);
            return View(jobOfferUser);
        }

        // POST: JobOfferUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobOfferId,UserId")] JobOfferUserDTO jobOfferUserDTO)
        {
            if (id != jobOfferUserDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                JobOfferUser jobOfferUser = _mapper.Map<JobOfferUser>(jobOfferUserDTO);
                try
                {
                    _context.Update(jobOfferUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobOfferUserExists(jobOfferUser.Id))
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
            ViewData["JobOfferId"] = new SelectList(_context.JobOffers, "Id", "Id", jobOfferUserDTO.JobOfferId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", jobOfferUserDTO.UserId);
            return View(jobOfferUserDTO);
        }

        // GET: JobOfferUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobOfferUsers == null)
            {
                return NotFound();
            }

            var jobOfferUser = await _context.JobOfferUsers
                .Include(j => j.JobOffer)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOfferUser == null)
            {
                return NotFound();
            }

            return View(jobOfferUser);
        }

        // POST: JobOfferUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobOfferUsers == null)
            {
                return Problem("Entity set 'AppDbContext.JobOfferUsers'  is null.");
            }
            var jobOfferUser = await _context.JobOfferUsers.FindAsync(id);
            if (jobOfferUser != null)
            {
                _context.JobOfferUsers.Remove(jobOfferUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobOfferUserExists(int id)
        {
          return (_context.JobOfferUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
