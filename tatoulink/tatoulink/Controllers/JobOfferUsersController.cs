using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tatoulink.DataAccess.Interfaces;
using tatoulink.DataAccess.Repositories;
using tatoulink.Dbo;
using tatoulink.Models;

namespace tatoulink.Controllers
{
    public class JobOfferUsersController : Controller
    {
        private readonly DataAccess.EfModels.DbContext _context;
        protected readonly IMapper _mapper;

        private readonly ILogger<JobOfferUserRepository> _logger;

        protected readonly JobOfferUserRepository _jobOfferUserRepository;

        public JobOfferUsersController(DataAccess.EfModels.DbContext context, IMapper mapper, ILogger<JobOfferUserRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;

            _jobOfferUserRepository = new JobOfferUserRepository(_context, _logger, _mapper);
        }

        // GET: JobOfferUsers
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var appDbContext = _context.JobOfferUsers.Include(j => j.JobOffer).Include(j => j.User);
                return View(await appDbContext.ToListAsync());
            }

            var ListOffer = _context.JobOfferUsers.Include(j => j.JobOffer).Include(j => j.User).Where(j => j.UserId == id);
            return View(await ListOffer.ToListAsync());
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

        // GET: JobOfferUsers/CreateFromJobOffer
        public IActionResult CreateFromJobOffer(int offerId)
        {
            ViewData["JobOfferId"] = new SelectList(_context.JobOffers, "Id", "Id", offerId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: JobOfferUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobOfferId,UserId")] Dbo.JobOfferUser jobOfferUserDBO)
        {
            if (ModelState.IsValid)
            {
                await _jobOfferUserRepository.Insert(jobOfferUserDBO);

                return RedirectToAction(nameof(Index));
            }
            ViewData["JobOfferId"] = new SelectList(_context.JobOffers, "Id", "Id", jobOfferUserDBO.JobOfferId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", jobOfferUserDBO.UserId);
            return View(jobOfferUserDBO);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobOfferId,UserId")] Dbo.JobOfferUser jobOfferUserDBO)
        {
            if (id != jobOfferUserDBO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _jobOfferUserRepository.Update(jobOfferUserDBO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobOfferUserExists(jobOfferUserDBO.Id))
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
            ViewData["JobOfferId"] = new SelectList(_context.JobOffers, "Id", "Id", jobOfferUserDBO.JobOfferId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", jobOfferUserDBO.UserId);
            return View(jobOfferUserDBO);
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

            await _jobOfferUserRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool JobOfferUserExists(int id)
        {
          return (_context.JobOfferUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
