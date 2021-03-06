﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buffet.Data;
using Buffet.Models;
using Microsoft.AspNetCore.Authorization;

namespace Buffet.Controllers
{
    public class GuestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuestsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Guests
        public async Task<IActionResult> Index()
        {
            // Adding code to sort the indext list desending.
            // source: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-3.1#add-column-sort-links
            
            var guests = from s in _context.Guests
                           select s;

            guests = guests.OrderByDescending(s => s.RoomNr);

            return View(await guests.AsNoTracking().ToListAsync());
        }

        [Authorize("CanEnterReception")]
        // GET: Guests
        public async Task<IActionResult> Reception()
        {
            // Adding code to sort the indext list desending.
            // source: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-3.1#add-column-sort-links

            var guests = from s in _context.Guests
                         select s;

            guests = guests.OrderByDescending(s => s.RoomNr);

            return View(await guests.AsNoTracking().ToListAsync());
        }


        [Authorize("CanEnterReception")]
        // GET: Guests
        public async Task<IActionResult> GuestEatenToday()
        { 
            var guest = await _context.Guests.ToListAsync(); 
            var guests = from s in _context.Guests
              select s;

          var receptions = new List<Reception>();

          foreach (var g in guest)
          {
              if (!receptions.Exists(x => x.Room == g.RoomNr) && g.Date.Date == DateTime.Today && g.Checked == true)
              {
                  var r = new Reception(g.RoomNr, 0, 0);
                  receptions.Add(r);
              }
          }

          foreach (var r in receptions)
          {
              r.NrAdults = guest.Where(g => g.AgeStatus=="Adult" && g.RoomNr == r.Room && g.Date.Date == DateTime.Today && g.Checked == true).Count();
              r.NrChildren = guest.Where(g => g.AgeStatus=="Child" && g.RoomNr == r.Room && g.Date.Date == DateTime.Today && g.Checked == true).Count();
          }

          return View(receptions);
        }

        [Authorize("CanEnterRestaurant")]
        public async Task<IActionResult> Resturant()
        {
            // Adding code to sort the indext list desending.
            // source: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-3.1#add-column-sort-links

            var guests = from s in _context.Guests
                         select s;

            guests = guests.OrderByDescending(s => s.RoomNr);

            return View(await guests.AsNoTracking().ToListAsync());
        }

        // Called on Post from Resturant to update the chechin status.
        [HttpPost]
        [Authorize("CanEnterRestaurant")]
        public async Task<IActionResult> Resturant(long id)
        {
            // Finds the guest in the database based on the ID:
            var guest = await _context.Guests
                .FirstOrDefaultAsync(m => m.GuestId == id);
            if (guest == null)
            {
                return NotFound();
            }

            // Sets the checkin status to True:
            guest.Checked = true;


            // Updates the database:
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.GuestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(await _context.Guests.AsNoTracking().ToListAsync());
        }


        // GET: Guests/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests
                .FirstOrDefaultAsync(m => m.GuestId == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // GET: Guests/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize("CanEnterReception")]
        // POST: Guests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestId,AgeStatus,RoomNr,Date,Checked")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Reception));
            }
            return View(guest);
        }

        [Authorize("CanEnterReception")]
        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }

        [Authorize("CanEnterReception")]
        // POST: Guests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("GuestId,AgeStatus,RoomNr,Date,Checked")] Guest guest)
        {
            if (id != guest.GuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.GuestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Reception));
            }
            return View(guest);
        }

        [Authorize("CanEnterReception")]
        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests
                .FirstOrDefaultAsync(m => m.GuestId == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        [Authorize("CanEnterReception")]
        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var guest = await _context.Guests.FindAsync(id);
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestExists(long id)
        {
            return _context.Guests.Any(e => e.GuestId == id);
        }
    }
}
