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
    public class WayBillsController : Controller
    {
        private readonly IWaybillService _context;
        private readonly IStatusService _statuses;
        public WayBillsController(IWaybillService context, IStatusService statuses)
        {
            _context = context;
            _statuses = statuses;
        }

        // GET: WayBills
        public async Task<IActionResult> Index()
        {
              return View((await _context.GetAllWayBills()).ToList());
        }

        // GET: WayBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var wayBill = await _context.GetWayBillById((int)id);
            if (wayBill == null)
            {
                return NotFound();
            }

            return View(wayBill);
        }

        // GET: WayBills/Create
        public async Task<IActionResult> Create()
        {
            var genarate = new Random().Next();
            ViewBag.WayBillNo = genarate.ToString().ToUpper();
            ViewData["Status"] = new SelectList(await _statuses.GetStatuses(), "Name", "Name");
            return View();
        }

        // POST: WayBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WayBillId,WaybillNo,WaybillDate,Status,ETADate,ETATime,Quantity,Weight")] WayBill wayBill)
        {
            if (ModelState.IsValid)
            {
               await _context.InsertWayBill(wayBill);
                return RedirectToAction(nameof(Index));
            }
            return View(wayBill);
        }

        // GET: WayBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var wayBill = await _context.GetWayBillById((int)id);
            if (wayBill == null)
            {
                return NotFound();
            }
            ViewData["Status"] = new SelectList(await _statuses.GetStatuses(), "Name", "Name", wayBill.Status);
            return View(wayBill);
        }

        // POST: WayBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WayBillId,WaybillNo,WaybillDate,Status,ETADate,ETATime,Quantity,Weight")] WayBill wayBill)
        {
            if (id != wayBill.WayBillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateWayBill(wayBill);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WayBillExists(wayBill.WayBillId))
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
            return View(wayBill);
        }

        // GET: WayBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var wayBill = await _context.GetWayBillById((int)id);
            if (wayBill == null)
            {
                return NotFound();
            }

            return View(wayBill);
        }

        // POST: WayBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WayBills'  is null.");
            }
            var wayBill = await _context.GetWayBillById((int)id);
            if (wayBill != null)
            {
               await _context.DeleteWayBill(wayBill.WayBillId);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool WayBillExists(int id)
        {
          return _context.GetAllWayBills().Result.Any(e => e.WayBillId == id);
        }
    }
}
