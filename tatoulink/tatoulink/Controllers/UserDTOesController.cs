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
    public class UserDTOesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserDTOesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: UserDTOes
        public async Task<IActionResult> Index()
        {
            var userDTOs = await _context.UserDTO.ToListAsync();
            var users = _mapper.Map<List<User>>(userDTOs);
            return View(users);
        }

        // GET: UserDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDTO = await _context.UserDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDTO == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<User>(userDTO);
            return View(user);
        }

        // GET: UserDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Surname,Birthdate,Password,Email,Status,LastJobs")] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userDTO);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDTO);
        }

        // GET: UserDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDTO = await _context.UserDTO.FindAsync(id);
            if (userDTO == null)
            {
                return NotFound();
            }
            var user = _mapper.Map<User>(userDTO);
            return View(user);
        }

        // POST: UserDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Surname,Birthdate,Password,Email,Status,LastJobs")] UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = _mapper.Map<User>(userDTO);
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDTOExists(userDTO.Id))
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
            return View(userDTO);
        }

        // GET: UserDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDTO = await _context.UserDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDTO == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<User>(userDTO);
            return View(user);
        }

        // POST: UserDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDTO = await _context.UserDTO.FindAsync(id);
            if (userDTO != null)
            {
                _context.UserDTO.Remove(userDTO);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDTOExists(int id)
        {
            return _context.UserDTO.Any(e => e.Id == id);
        }
    }
}

