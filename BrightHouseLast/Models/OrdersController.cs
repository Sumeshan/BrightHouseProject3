using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BrightHouseLast.Models
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly BrightHouseLastContext _context;
        private readonly IOrderRepository Access = new OrderRepository();

        public OrdersController(BrightHouseLastContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            IEnumerable<Orders> orders = await Access.GetOrders();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Orders orders = await Access.GetOrders(id);
            
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RowID,OrderID,OrderDate,ShipDate,ShipMode,CustomerID,Segment,PostalCode,City,State,Country,Region,Market,ProductID,Category,SubCategory,ProductName,Sales,Quantity,Discount,Profit,ShippingCost,OrderPriority")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                await Access.Add(orders);
            }
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Orders orders = await Access.GetOrders(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,RowID,OrderID,OrderDate,ShipDate,ShipMode,CustomerID,Segment,PostalCode,City,State,Country,Region,Market,ProductID,Category,SubCategory,ProductName,Sales,Quantity,Discount,Profit,ShippingCost,OrderPriority")] Orders orders)
        {
            if (id != orders.Id)
            {
                
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await Access.Update(orders);
                    
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await Access.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
