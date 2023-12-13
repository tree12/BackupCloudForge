using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BedarfsCheck.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BedarfsCheck.Controllers
{
    [Route("api/[controller]")]
    public class InsuranceController : Controller
    {
        // GET: Insurance
        public ActionResult Index()
        {
            List<InsuranceData> insuranceList = InsuranceDB.LoadInsurances();
            return View("Index", insuranceList);
        }

        // GET: Insurance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Insurance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insurance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("edit")]
        [ActionName("Edit")]
        public ActionResult Edit([FromQuery] string name_PK)
        {
            InsuranceData insurance = InsuranceDB.LoadInsurance(name_PK);
            return View("Edit",insurance);
        }

        [HttpPost("Save")]
        [ActionName("Save")]
        public ActionResult Save([FromBody] InsuranceData insurance)
        {
            InsuranceDB.SaveInsurance(insurance);
            return Redirect("/api/insurance/Edit?name_pk="+insurance.Name_PK);
        }

        // POST: Insurance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string name_PK, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Insurance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Insurance/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}