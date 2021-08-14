using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZBooking.Core.Models;
using ZBooking.DataAccess.InMemory;

namespace ZBooking.WebUI.Controllers
{
    public class VenueManagerController : Controller
    {
        VenueRepository context;

        public VenueManagerController()
        {
            context = new VenueRepository();
        }
        // GET: VenueManager
        public ActionResult Index()
        {
            List<Venue> venues = context.Collection().ToList();
            return View(venues);
        }

        public ActionResult Create()
        {
            Venue venue = new Venue();
            return View(venue);
        }

        [HttpPost]
        public ActionResult Create(Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return View(venue);
            }
            else
            {
                context.Insert(venue);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
        {
            Venue venue = context.Find(Id);

            if(venue == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(venue);
            }
        }

        [HttpPost]
        public ActionResult Edit (Venue venue, string Id)
        {
            Venue venueToEdit = context.Find(Id);

            if (venueToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(venue);
                }
                venueToEdit.Name = venue.Name;
                venueToEdit.SubName = venue.SubName;
                venueToEdit.Description = venue.Description;
                venueToEdit.image = venue.image;
                venueToEdit.Longitude = venue.Longitude;
                venueToEdit.Latitude = venue.Latitude;
                venueToEdit.HourPrice = venue.HourPrice;
                venueToEdit.DayPrice = venue.DayPrice;

                context.Commit();
                return RedirectToAction("Index");
            }

        }


        public ActionResult Delete(string Id)
        {
            Venue venueToDelete = context.Find(Id);
            if(venueToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(venueToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Venue venueToDelete = context.Find(Id);
            if (venueToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}