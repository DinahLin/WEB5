using Assignment2.EntityModels;
using Assignment2.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Assignment2.Models.TrackAddViewModel;

namespace Assignment2.Controllers
{
    public class TracksController : Controller
    {
        private Manager m = new Manager();
        // GET: Track
        public ActionResult Index()
        {
            var c = m.TrackGetAll();
            return View(c);
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            var obj = m.TrackGetById(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
        [HttpPost]
        public ActionResult Create(TrackAddViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
                return View(newItem);
            try
            {
                // Process the input
                var addedItem = m.TrackAdd(newItem);
                // If the item was not added, return the user to the Create page
                // otherwise redirect them to the Details page.
                if (addedItem == null)
                    return View(newItem);
                else
                    return RedirectToAction("Details", new { id = addedItem.TrackId });
            }
            catch
            {
                return View(newItem);
            }
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Track/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Track/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Pop()
        {
            return View(m.TrackGetAllPop());

        }
        

        public ActionResult Longest()
        {         
           
            return View(m.TrackGetAllTop100Longest());
        }

        public ActionResult Purple()
        {
          
            return View(m.TrackGetAllDeepPurple());
        }

    }
}
