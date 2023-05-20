using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tatoulink.DataAccess.EfModels;
using tatoulink.DataAccess.Repositories;

namespace tatoulink.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly DataAccess.EfModels.DbContext _context;
        protected readonly IMapper _mapper;

        private readonly ILogger<NotificationRepository> _logger;

        protected readonly NotificationRepository _notificationRepository;

        public NotificationsController(DataAccess.EfModels.DbContext context, IMapper mapper, ILogger<NotificationRepository> logger)
        {
            _context = context;
            _mapper = mapper;

            _logger = logger;

            _notificationRepository = new NotificationRepository(_context, _logger, _mapper);
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Notifications.Include(n => n.JobOfferUser).Include(n => n.Receiver).Include(n => n.Sender);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.JobOfferUser)
                .Include(n => n.Receiver)
                .Include(n => n.Sender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            ViewData["JobOfferUserId"] = new SelectList(_context.JobOfferUsers, "Id", "Id");
            ViewData["ReceiverId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SenderId,ReceiverId,JobOfferUserId,Message,Timestamp")] Dbo.Notification notificationDBO)
        {
            if (ModelState.IsValid)
            {
                await _notificationRepository.Insert(notificationDBO);

                return RedirectToAction(nameof(Index));
            }
            ViewData["JobOfferUserId"] = new SelectList(_context.JobOfferUsers, "Id", "Id", notificationDBO.JobOfferUserId);
            ViewData["ReceiverId"] = new SelectList(_context.Users, "Id", "Id", notificationDBO.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id", notificationDBO.SenderId);
            return View(notificationDBO);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            ViewData["JobOfferUserId"] = new SelectList(_context.JobOfferUsers, "Id", "Id", notification.JobOfferUserId);
            ViewData["ReceiverId"] = new SelectList(_context.Users, "Id", "Id", notification.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id", notification.SenderId);
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SenderId,ReceiverId,JobOfferUserId,Message,Timestamp")] Dbo.Notification notificationDBO)
        {
            if (id != notificationDBO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _notificationRepository.Update(notificationDBO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notificationDBO.Id))
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
            ViewData["JobOfferUserId"] = new SelectList(_context.JobOfferUsers, "Id", "Id", notificationDBO.JobOfferUserId);
            ViewData["ReceiverId"] = new SelectList(_context.Users, "Id", "Id", notificationDBO.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id", notificationDBO.SenderId);
            return View(notificationDBO);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.JobOfferUser)
                .Include(n => n.Receiver)
                .Include(n => n.Sender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notifications == null)
            {
                return Problem("Entity set 'AppDbContext.Notifications'  is null.");
            }

            await _notificationRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
          return (_context.Notifications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
