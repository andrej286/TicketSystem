using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.DTO;
using TicketEShop.Domain.Relations;
using TicketEShop.Repository;
using TicketEShop.Services.Interface;

namespace TicketEShop.Web.Controllers
{
    public class MovieTicketsController : Controller
    {
        private readonly IMovieTicketService _movieTicketService;

        public MovieTicketsController(IMovieTicketService movieTicketService)
        {
            _movieTicketService = movieTicketService;
        }

        // GET: MovieTickets
        public IActionResult Index()
        {
            var allMovieTickets = this._movieTicketService.GetAllMovieTickets(); 


            return View(allMovieTickets);
        }

        public IActionResult AddMovieTicketToCart(Guid? id)
        {
            var model = this._movieTicketService.GetShoppingCartInfo(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovieTicketToCart([Bind("SelectedMovieTicketId", "Quantity")] AddToShoppingCartDto item)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._movieTicketService.AddToShoppingCart(item, userId);

            if (result)
            {
                return RedirectToAction("Index", "MovieTickets");
            }

            return View();
        }


        // GET: MovieTickets/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieTicket = this._movieTicketService.GetDetailsForMovieTicket(id);
            if (movieTicket == null)
            {
                return NotFound();
            }

            return View(movieTicket);
        }

        // GET: MovieTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,MovieName,MovieImage,TicketPrice,WatchDate")] MovieTicket movieTicket)
        {
            if (ModelState.IsValid)
            {
                
                this._movieTicketService.CreateNewMovieTicket(movieTicket); 

                return RedirectToAction(nameof(Index));
            }
            return View(movieTicket);
        }

        // GET: MovieTickets/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieTicket = this._movieTicketService.GetDetailsForMovieTicket(id);

            if (movieTicket == null)
            {
                return NotFound();
            }
            return View(movieTicket);
        }

        // POST: MovieTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,MovieName,MovieImage,TicketPrice,WatchDate")] MovieTicket movieTicket)
        {
            if (id != movieTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   this._movieTicketService.UpdeteExistingMovieTicket(movieTicket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieTicketExists(movieTicket.Id))
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
            return View(movieTicket);
        }

        // GET: MovieTickets/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieTicket = _movieTicketService.GetDetailsForMovieTicket(id);

            if (movieTicket == null)
            {
                return NotFound();
            }

            return View(movieTicket);
        }

        // POST: MovieTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._movieTicketService.DeleteMovieTicket(id);

            return RedirectToAction(nameof(Index));
        }

        private bool MovieTicketExists(Guid id)
        {
            return this._movieTicketService.GetDetailsForMovieTicket(id) != null;
        }
    }
}
