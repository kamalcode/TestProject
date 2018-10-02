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
        private readonly UnitOfWork _unitOfWork = null;

        public CarController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index(string currentFilter, string searchTerm)
        {
            ViewBag.CurrentFilter = searchTerm;
            IList<Car> listCars = null;
            var un = User.Identity.Name;
            try
            {

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    listCars = _unitOfWork.CarRepository.Get(d => ((d.Model.Contains(searchTerm) || d.Brand.Contains(searchTerm)) && d.CreatedBy == un), d => d.OrderByDescending(x => x.ID)).ToList();
                }
                else
                {
                    listCars = _unitOfWork.CarRepository.Get(d=>d.CreatedBy==un,d => d.OrderByDescending(x => x.ID),"").ToList();
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
                    _unitOfWork.CarRepository.Insert(car);
                    _unitOfWork.Save();
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
            var car = _unitOfWork.CarRepository.GetByID(Id);
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
                    _unitOfWork.CarRepository.Update(car);
                    _unitOfWork.Save();
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