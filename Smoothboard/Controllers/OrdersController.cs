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

        // showing the list of orders on the main screen

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await smoothboardDbContext.Orders.ToListAsync();
            return View(orders);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // When we submit the form we should be able to get the values in a post methode here under

        [HttpPost]
        public async Task<IActionResult> Add(AddOrderViewModel addOrderRequest)
        {
            var order = new Order()
            {
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

            await smoothboardDbContext.Orders.AddAsync(order);
            await smoothboardDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Create the Edit function

        [HttpGet]
        public async Task<IActionResult> View(Guid id) 
        {
            var order = await smoothboardDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null) 
            {
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

            return RedirectToAction("Index");
        }

        // Submit the Edited Details function

        [HttpPost]

        public async Task<IActionResult> View(UpdateOrderViewModel model)
        {
            var order = await smoothboardDbContext.Orders.FindAsync(model.Id);

            if (order != null) 
            {
                order.Name = model.Name;
                order.Email = model.Email;
                order.Address = model.Address;
                order.Phone = model.Phone;
                order.DropOffDate = model.DropOffDate;
                order.Width = model.Width;
                order.Length = model.Length;
                order.DesignLink = model.DesignLink;

                await smoothboardDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }


        // Delete the selected Order Details function

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateOrderViewModel model)
        {
            var order = await smoothboardDbContext.Orders.FindAsync(model.Id);

            if (order != null)
            {
                smoothboardDbContext.Orders.Remove(order);
                await smoothboardDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }

    }
}
