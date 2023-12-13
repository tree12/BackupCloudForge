using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ATom.CommonDB.DB;
using BedarfsCheck.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BedarfsCheck.Controllers
{
    [Route("api/[controller]")]    
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<InsuranceData> insuranceList = InsuranceDB.LoadInsurances();
            return View("Index",insuranceList);
        }

        [HttpPost]
        [ActionName("CreateInsurance")]
        public IActionResult CreateInsurance([FromForm] InsuranceData insurance)
        {
            //InsuranceData insurance = new InsuranceData() {Name_PK = name_PK, Description = description};
            insurance.Name_PK = Regex.Replace(insurance.Name_PK, "[^a-zA-Z0-9]", "");
            DBBaseObject<InsuranceData> insuranceDB = new DBBaseObject<InsuranceData>(Global.Connection);            
            insuranceDB.Insert(insurance);            
            return RedirectToAction("Index");
        }

        // GET: /<controller>/
        [HttpGet("CreateDB")]               
        public IActionResult CreateDB()
        {
            DBBaseObject<InsuranceData> insuranceDB = new DBBaseObject<InsuranceData>(Global.Connection);
            if (!insuranceDB.TableExists()) insuranceDB.CreateTable();
            DBBaseObject<InsuranceLevelData> insuranceLevelDB = new DBBaseObject<InsuranceLevelData>(Global.Connection);
            if (!insuranceLevelDB.TableExists()) insuranceLevelDB.CreateTable();
            return View("Index");
        }
    }
}
