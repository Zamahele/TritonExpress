using System;
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
    public class AllocationsController : Controller
    {
        private readonly IAllocationService _context;
        private readonly IVehicleService _vehicle;
        private readonly IWaybillService _waybill;

        public AllocationsController(IAllocationService context, IVehicleService vehicle, IWaybillService waybill)
        {
            _context = context;
            _vehicle = vehicle;
            _waybill = waybill;
        }

        // GET: Allocations
        public async Task<IActionResult> Index()
        {
            return View((await _context.GetAllLocations()).ToList());
        }

        // GET: Allocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.GetAllLocationById((int)id);
            if (allocation == null)
            {
                return NotFound();
            }

            return View(allocation);
        }

        // GET: Allocations/Create
        public async Task<IActionResult> Create()
        {
            ViewData["VehicleId"] = new SelectList(await _vehicle.GetAllVehicles(), "VehicleId", "Make");
            ViewData["WayBillId"] = new SelectList(await _waybill.GetAllWayBills(), "WayBillId", "WaybillNo");
            return View();
        }

        // POST: Allocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocationId,VehicleId,WayBillId,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy")] Allocation allocation)
        {
            if (ModelState.IsValid)
            {
                await _context.InsertAllLocation(allocation);
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(await _vehicle.GetAllVehicles(), "VehicleId", "Make", allocation.VehicleId);
            ViewData["WayBillId"] = new SelectList(await _waybill.GetAllWayBills(), "WayBillId", "WaybillNo", allocation.WayBillId);
            return View(allocation);
        }

        // GET: Allocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.GetAllLocationById((int)id);
            if (allocation == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(await _vehicle.GetAllVehicles(), "VehicleId", "Make", allocation.VehicleId);
            ViewData["WayBillId"] = new SelectList(await _waybill.GetAllWayBills(), "WayBillId", "WaybillNo", allocation.WayBillId);
            return View(allocation);
        }

        // POST: Allocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocationId,VehicleId,WayBillId,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy")] Allocation allocation)
        {
            if (id != allocation.AllocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _context.UpdateAllLocation(allocation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocationExists(allocation.AllocationId))
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
            ViewData["VehicleId"] = new SelectList(await _vehicle.GetAllVehicles(), "VehicleId", "Make", allocation.VehicleId);
            ViewData["WayBillId"] = new SelectList(await _waybill.GetAllWayBills(), "WayBillId", "WaybillNo", allocation.WayBillId);
            return View(allocation);
        }

        // GET: Allocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.GetAllLocationById((int)id);
            if (allocation == null)
            {
                return NotFound();
            }

            return View(allocation);
        }

        // POST: Allocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AllLocations'  is null.");
            }
            var allocation = await _context.GetAllLocationById((int) id);
            if (allocation != null)
            {
               await _context.DeleteAllLocation(id);
            }
           
            return RedirectToAction(nameof(Index));
        }

        private bool AllocationExists(int id)
        {
          return _context.GetAllLocations().Result.Any(e => e.AllocationId == id);
        }
    }
}
