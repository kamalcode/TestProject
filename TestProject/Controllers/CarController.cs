using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.DataAccessLayer;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
      
        public ActionResult Index(string currentFilter, string searchTerm)
        {
            ViewBag.CurrentFilter = searchTerm;
            IList<Car> listCars = null;
            try
            {
                if(!string.IsNullOrWhiteSpace(searchTerm))
                {
                    listCars = unitOfWork.CarRepository.Get(d => d.Brand == searchTerm, d => d.OrderByDescending(x => x.ID)).ToList();
                }
                else
                {
                    listCars = unitOfWork.CarRepository.Get(null,d => d.OrderByDescending(x => x.ID),"").ToList();
                }
            }
            catch(DataException ex)
            {
                LoggerService.Error(ex.StackTrace);
            }
            return View(listCars);
        }

        
        public ActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Brand, Model, Price, Year,New")]Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var un = User.Identity.Name;
                    car.CreatedBy = un;
                    unitOfWork.CarRepository.Insert(car);
                    unitOfWork.Save();
                    LoggerService.Info(string.Format("Created new car record by user:{0}", un));
                }
            }
            catch (DataException ex)
            {
                LoggerService.Error(ex.StackTrace);
            }
            return Json(new { status = "success"});
        }

        public ActionResult Edit(int Id)
        {
            var car = unitOfWork.CarRepository.GetByID(Id);
            return PartialView("_EditCarPartial", car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Brand, Model, Price, Year,New")]Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var un = User.Identity.Name;
                    car.CreatedBy = un;
                    unitOfWork.CarRepository.Update(car);
                    unitOfWork.Save();
                    LoggerService.Info(string.Format("Edit by user:{0}", un));
                }
            }
            catch (DataException ex)
            {
                LoggerService.Error(ex.StackTrace);
            }
            return Json(new { status = "success edit" });
        }
    }
}