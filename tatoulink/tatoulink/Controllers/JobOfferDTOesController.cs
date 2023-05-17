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
    public class JobOfferDTOesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public JobOfferDTOesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: JobOfferDTOes
        public async Task<IActionResult> Index()
        {
            var jobOffers = await _context.JobOffers.ToListAsync();
            var jobOfferDTOs = _mapper.Map<List<JobOfferDTO>>(jobOffers);
            return View(jobOfferDTOs);
        }

        // GET: JobOfferDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers.FirstOrDefaultAsync(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            var jobOfferDTO = _mapper.Map<JobOfferDTO>(jobOffer);
            return View(jobOfferDTO);
        }

        // GET: JobOfferDTOes/Create
        public IActionResult Create()
        {
            return View();
        }
         
        // POST: JobOfferDTOes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfferName,Description,CreationDate,Type,Duration,ExpiringDate,CreatorId")] JobOfferDTO jobOfferDTO)
        {
            if (ModelState.IsValid)
            {
                var jobOffer = _mapper.Map<JobOffer>(jobOfferDTO);
                _context.Add(jobOffer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobOfferDTO);
        }

        // GET: JobOfferDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            var jobOfferDTO = _mapper.Map<JobOfferDTO>(jobOffer);
            return View(jobOfferDTO);
        }

        // POST: JobOfferDTOes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobOfferDTO jobOfferDTO)
        {
            if (id != jobOfferDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var jobOffer = _mapper.Map<JobOffer>(jobOfferDTO);
                _context.Update(jobOffer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(jobOfferDTO);
        }

        // GET: JobOfferDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers.FirstOrDefaultAsync(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            var jobOfferDTO = _mapper.Map<JobOfferDTO>(jobOffer);
            return View(jobOfferDTO);
        }

        // POST: JobOfferDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            _context.JobOffers.Remove(jobOffer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
