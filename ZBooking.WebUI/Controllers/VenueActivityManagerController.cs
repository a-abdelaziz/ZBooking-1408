using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZBooking.DataAccess.InMemory;
using ZBooking.Core.Models;

namespace ZBooking.WebUI.Controllers
{
    public class VenueActivityManagerController : Controller
    {
        InMemoryRepository<VenueActivity> context;

        public VenueActivityManagerController()
        {
            context = new InMemoryRepository<VenueActivity>();
        }
        // GET: VenueActivityManager
        public ActionResult Index()
        {
            List<VenueActivity> activities = context.Collection().ToList();
            return View(activities);
        }

        public ActionResult Create()
        {
            VenueActivity activity = new VenueActivity();
            return View(activity);
        }

        [HttpPost]
        public ActionResult Create(VenueActivity activity)
        {
            if (!ModelState.IsValid)
            {
                return View(activity);
            }
            else
            {
                context.Insert(activity);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
        {
            VenueActivity activity = context.Find(Id);

            if (activity == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(activity);
            }
        }

        [HttpPost]
        public ActionResult Edit(VenueActivity activity, string Id)
        {
            VenueActivity activityToEdit = context.Find(Id);

            if (activityToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(activity);
                }
                activityToEdit.Name = activity.Name;
                activityToEdit.Category = activity.Category;

                context.Commit();
                return RedirectToAction("Index");
            }

        }


        public ActionResult Delete(string Id)
        {
            VenueActivity activityToDelete = context.Find(Id);
            if (activityToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(activityToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            VenueActivity activityToDelete = context.Find(Id);
            if (activityToDelete == null)
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