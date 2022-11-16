﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Persistence;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.APP.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _context;
        private readonly IBranchService _braches;

        public VehiclesController(IVehicleService context, IBranchService braches)
        {
            _context = context;
            _braches = braches;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
              return View((await _context.GetAllVehicles()).ToList());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Branches"] = new SelectList(await _braches.GetAllBranches(), "BranchId", "BranchName");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,Model,Make,Year,RegistrationNo,BranchId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await _context.InsertVehicle(vehicle);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.GetVehicleById((int)id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["Branches"] = new SelectList(await _braches.GetAllBranches(), "BranchId", "BranchName", vehicle.BranchId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,Model,Make,Year,RegistrationNo,BranchId")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _context.UpdateVehicle(vehicle);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleId))
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
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.GetVehicleById((int)id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
            }
            var vehicle = await _context.GetVehicleById(id);
            if (vehicle != null)
            {
                await _context.DeleteVehicle(id);
            }
           
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
          return _context.GetAllVehicles().Result.Any(e => e.VehicleId == id);
        }
    }
}