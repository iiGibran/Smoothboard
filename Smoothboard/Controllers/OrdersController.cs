using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smoothboard.Data;
using Smoothboard.Models;
using Smoothboard.Models.Domain;

namespace Smoothboard.Controllers
{
    public class OrdersController : Controller
    {
        private readonly SmoothboardDbContext smoothboardDbContext;

        public OrdersController(SmoothboardDbContext smoothboardDbContext)
        {
            this.smoothboardDbContext = smoothboardDbContext;
        }

        // GET: Display list of orders on the main screen
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await smoothboardDbContext.Orders.ToListAsync();
            return View(orders);
        }

        // GET: Display the form to add a new order
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Process the form submission to add a new orderr
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderViewModel addOrderRequest)
        {
            var order = new Order()
            {
                // Initialize properties using data from the view model
                Id = Guid.NewGuid(),
                Name = addOrderRequest.Name,
                Email = addOrderRequest.Email,
                Address = addOrderRequest.Address,
                Phone = addOrderRequest.Phone,
                DropOffDate = addOrderRequest.DropOffDate,
                Width = addOrderRequest.Width,
                Length = addOrderRequest.Length,
                DesignLink = addOrderRequest.DesignLink
            };

            // Add the new order to the database and save changes
            await smoothboardDbContext.Orders.AddAsync(order);
            await smoothboardDbContext.SaveChangesAsync();

            // Redirect to the index view
            return RedirectToAction("Index");
        }

        // GET: Display the order details for editing
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var order = await smoothboardDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                // Create a view model from the order details
                var viewModel = new UpdateOrderViewModel()
                {
                    Id = order.Id,
                    Name = order.Name,
                    Email = order.Email,
                    Address = order.Address,
                    Phone = order.Phone,
                    DropOffDate = order.DropOffDate,
                    Width = order.Width,
                    Length = order.Length,
                    DesignLink = order.DesignLink
                };

                return await Task.Run(() => View("View", viewModel));
            }

            // Redirect to the index view if the order doesn't exist
            return RedirectToAction("Index");
        }

        // POST: Process the form submission to update order details
        [HttpPost]
        public async Task<IActionResult> View(UpdateOrderViewModel model)
        {
            var order = await smoothboardDbContext.Orders.FindAsync(model.Id);

            if (order != null)
            {
                // Update order properties using data from the view model
                order.Name = model.Name;
                order.Email = model.Email;
                order.Address = model.Address;
                order.Phone = model.Phone;
                order.DropOffDate = model.DropOffDate;
                order.Width = model.Width;
                order.Length = model.Length;
                order.DesignLink = model.DesignLink;

                // Save changes to the database
                await smoothboardDbContext.SaveChangesAsync();

                // Redirect to the index view
                return RedirectToAction("Index");
            }

            // Redirect to the index view if the order doesn't exist
            return RedirectToAction("Index");
        }

        // POST: Delete the selected order
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateOrderViewModel model)
        {
            var order = await smoothboardDbContext.Orders.FindAsync(model.Id);

            if (order != null)
            {
                // Remove the order from the database and save changes
                smoothboardDbContext.Orders.Remove(order);
                await smoothboardDbContext.SaveChangesAsync();

                // Redirect to the index view
                return RedirectToAction("Index");
            }

            // Redirect to the index view if the order doesn't exist
            return RedirectToAction("Index");
        }
    }
}
