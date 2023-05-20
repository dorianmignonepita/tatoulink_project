using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
    public class JobOffersController : Controller
    {
        private readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public JobOffersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: JobOffers
        public async Task<IActionResult> Index()
        {
            // REMOVE ALL THE OUTDATED OFFERS :
            var allJobOffers = _context.JobOffers.ToList();

            foreach (var jobOffer in allJobOffers)
            {
                if (jobOffer.ExpiringDate < DateTime.Now)
                {
                    _context.Remove(jobOffer);
                }
            }
            _context.SaveChanges();

            var appDbContext = _context.JobOffers.Include(j => j.Creator);
            return View(await appDbContext.ToListAsync());
        }

        // GET: JobOffers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobOffers == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers
                .Include(j => j.Creator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            return View(jobOffer);
        }

        // GET: JobOffers/Create
        public IActionResult Create()
        {

            ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: JobOffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfferName,Description,CreationDate,Type,Duration,ExpiringDate,CreatorId")] JobOfferDTO jobOfferDTO)
        {

            if (ModelState.IsValid)
            {
                // TO CHANGE
                JobOffer jobOffer = _mapper.Map<JobOffer>(jobOfferDTO);
                _context.Add(jobOffer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "Id", jobOfferDTO.CreatorId);
            return View(jobOfferDTO);
        }

        // GET: JobOffers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobOffers == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "Id", jobOffer.CreatorId);
            return View(jobOffer);
        }

        // POST: JobOffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OfferName,Description,CreationDate,Type,Duration,ExpiringDate,CreatorId")] JobOffer jobOffer)
        {
            if (id != jobOffer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobOffer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobOfferExists(jobOffer.Id))
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
            ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "Id", jobOffer.CreatorId);
            return View(jobOffer);
        }

        // GET: JobOffers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobOffers == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers
                .Include(j => j.Creator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            return View(jobOffer);
        }

        // POST: JobOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobOffers == null)
            {
                return Problem("Entity set 'AppDbContext.JobOffers'  is null.");
            }
            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer != null)
            {
                _context.JobOffers.Remove(jobOffer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobOfferExists(int id)
        {
          return (_context.JobOffers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
