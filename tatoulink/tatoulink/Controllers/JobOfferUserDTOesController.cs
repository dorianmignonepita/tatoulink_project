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
    public class JobOfferUserDTOesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public JobOfferUserDTOesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: JobOfferUserDTOes
        public async Task<IActionResult> Index()
        {
            var jobOfferUserDTOs = await _context.JobOfferUserDTO.ToListAsync();
            var jobOfferUsers = _mapper.Map<List<JobOfferUser>>(jobOfferUserDTOs);
            return View(jobOfferUsers);
        }

        // GET: JobOfferUserDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOfferUserDTO = await _context.JobOfferUserDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOfferUserDTO == null)
            {
                return NotFound();
            }

            var jobOfferUser = _mapper.Map<JobOfferUser>(jobOfferUserDTO);
            return View(jobOfferUser);
        }

        // GET: JobOfferUserDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobOfferUserDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobOfferId,UserId")] JobOfferUserDTO jobOfferUserDTO)
        {
            if (ModelState.IsValid)
            {
                var jobOfferUser = _mapper.Map<JobOfferUser>(jobOfferUserDTO);
                _context.Add(jobOfferUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobOfferUserDTO);
        }

        // GET: JobOfferUserDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOfferUserDTO = await _context.JobOfferUserDTO.FindAsync(id);
            if (jobOfferUserDTO == null)
            {
                return NotFound();
            }
            var jobOfferUser = _mapper.Map<JobOfferUser>(jobOfferUserDTO);
            return View(jobOfferUser);
        }

        // POST: JobOfferUserDTOes/Edit/5
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
                try
                {
                    var jobOfferUser = _mapper.Map<JobOfferUser>(jobOfferUserDTO);
                    _context.Update(jobOfferUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobOfferUserDTOExists(jobOfferUserDTO.Id))
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
            return View(jobOfferUserDTO);
        }

        // GET: JobOfferUserDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOfferUserDTO = await _context.JobOfferUserDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOfferUserDTO == null)
            {
                return NotFound();
            }

            var jobOfferUser = _mapper.Map<JobOfferUser>(jobOfferUserDTO);
            return View(jobOfferUser);
        }

        // POST: JobOfferUserDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobOfferUserDTO = await _context.JobOfferUserDTO.FindAsync(id);
            if (jobOfferUserDTO != null)
            {
                _context.JobOfferUserDTO.Remove(jobOfferUserDTO);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobOfferUserDTOExists(int id)
        {
            return _context.JobOfferUserDTO.Any(e => e.Id == id);
        }
    }
}

