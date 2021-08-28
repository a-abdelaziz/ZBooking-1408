using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZBooking.Core.Contracts;
using ZBooking.Core.Models;
using ZBooking.Core.ViewModels;
using ZBooking.DataAccess.InMemory;

namespace ZBooking.WebUI.Controllers
{
    public class VenueManagerController : Controller
    {
        IRepository<Venue> context;
        IRepository<VenueActivity> venueActivities;

        public VenueManagerController( IRepository<Venue> venueContext, IRepository<VenueActivity> venueActivityContext)
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

        public ActionResult Create()
        {
            VenueManagerViewModel viewModel = new VenueManagerViewModel();

            viewModel.Venue = new Venue();
            viewModel.VenueActivities = venueActivities.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Venue venue, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(venue);
            }
            else
            {
                if(file != null)
                {
                    venue.image = venue.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//VenueImages//") + venue.image);
                }
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
                VenueManagerViewModel viewModel = new VenueManagerViewModel();
                viewModel.Venue = venue;
                viewModel.VenueActivities = venueActivities.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit (Venue venue, string Id, HttpPostedFileBase file)
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
                if (file != null)
                {
                    venueToEdit.image = venueToEdit.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//VenueImages//") + venueToEdit.image);
                }

                venueToEdit.Name = venue.Name;
                venueToEdit.SubName = venue.SubName;
                venueToEdit.Description = venue.Description;
                venueToEdit.Activity = venue.Activity;
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