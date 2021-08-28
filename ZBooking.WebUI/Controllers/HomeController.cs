using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZBooking.Core.Contracts;
using ZBooking.Core.Models;

namespace ZBooking.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Venue> context;
        IRepository<VenueActivity> venueActivities;

        public HomeController(IRepository<Venue> venueContext, IRepository<VenueActivity> venueActivityContext)
        {
            context = venueContext;
            venueActivities = venueActivityContext;
        }
        // GET: VenueManager
        public ActionResult Index()
        {
            List<Venue> venues = context.Collection().ToList();
            return View(venues);
        }

        public ActionResult Details(string Id)
        {
            Venue venue = context.Find(Id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(venue);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}