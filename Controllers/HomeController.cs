using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restauranter.Models;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestContext _context;
        public HomeController(RestContext context)
        {
            _context = context;
        }
 

        [HttpGet]
        [Route("")]    
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("home")]       
        public IActionResult Home()
        {
            List<Review> AllReviews = _context.reviews.OrderByDescending(d => d.Visit_Date).ToList();
            ViewBag.allreviews = AllReviews;
            return View();
        }
        [HttpPost]
        [Route("add")]
        public IActionResult NewReview(Review review)
        {
            Review addReview = new Review 
            {
                Reviewer = review.Reviewer,
                Restaurant = review.Restaurant,
                Stars = review.Stars,
                Reviews = review.Reviews,
                Visit_Date = review.Visit_Date,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
            };
            TryValidateModel(addReview);
            if(ModelState.IsValid)
            {
                _context.Add(addReview);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }
    }
}
