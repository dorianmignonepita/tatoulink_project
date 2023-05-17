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
    public class NotificationDTOesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public NotificationDTOesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: NotificationDTOes
        public async Task<IActionResult> Index()
        {
            var notificationDTOs = await _context.NotificationDTO.ToListAsync();
            var notifications = _mapper.Map<List<Notification>>(notificationDTOs);
            return View(notifications);
        }

        // GET: NotificationDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationDTO = await _context.NotificationDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificationDTO == null)
            {
                return NotFound();
            }

            var notification = _mapper.Map<Notification>(notificationDTO);
            return View(notification);
        }

        // GET: NotificationDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NotificationDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SenderId,ReceiverId,JobOfferUserId,Message,Timestamp")] NotificationDTO notificationDTO)
        {
            if (ModelState.IsValid)
            {
                var notification = _mapper.Map<Notification>(notificationDTO);
                _context.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notificationDTO);
        }

        // GET: NotificationDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationDTO = await _context.NotificationDTO.FindAsync(id);
            if (notificationDTO == null)
            {
                return NotFound();
            }
            var notification = _mapper.Map<Notification>(notificationDTO);
            return View(notification);
        }

        // POST: NotificationDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SenderId,ReceiverId,JobOfferUserId,Message,Timestamp")] NotificationDTO notificationDTO)
        {
            if (id != notificationDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var notification = _mapper.Map<Notification>(notificationDTO);
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationDTOExists(notificationDTO.Id))
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
            return View(notificationDTO);
        }

        // GET: NotificationDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationDTO = await _context.NotificationDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificationDTO == null)
            {
                return NotFound();
            }

            var notification = _mapper.Map<Notification>(notificationDTO);
            return View(notification);
        }

        // POST: NotificationDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notificationDTO = await _context.NotificationDTO.FindAsync(id);
            if (notificationDTO != null)
            {
                _context.NotificationDTO.Remove(notificationDTO);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationDTOExists(int id)
        {
            return _context.NotificationDTO.Any(e => e.Id == id);
        }
    }
}

