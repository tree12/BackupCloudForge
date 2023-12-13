using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ATom.CommonDB.DataObjects;
using BedarfsCheck.Data;
using Microsoft.AspNetCore.Mvc;

namespace BedarfsCheck.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        private static Group _groupFamily = new Group(GROUP_FAMILY, false) {Description = "Familienstand"};
        private static Group _groupWork = new Group(GROUP_WORK, false) {Description = "Berufliche Situation"};

        private static Group _groupSituation =
            new Group(GROUP_SITUATION, true) {Description = "Was bin ich (Mehrfachwahl möglich)"};

        private static Group _groupBelongings =
            new Group(GROUP_BELONGINGS, true, false) {Description = "Was besitze ich (Mehrfachwahl möglich)"};


        public const string GROUP_FAMILY = "family";
        public const string GROUP_WORK = "work";
        public const string GROUP_SITUATION = "situation";
        public const string GROUP_BELONGINGS = "belongings";

        public const string OPTION_FAMILY_SINGLE = "single";
        public const string OPTION_FAMILY_SINGLEWITHCHILD = "singlewithchild";
        public const string OPTION_FAMILY_COUPLE = "couple";
        public const string OPTION_FAMILY_COUPLEWITHCHILD = "couplewithchild";

        public const string OPTION_WORK_STUDY = "work_study";
        public const string OPTION_WORK_EMPLOYEE = "work_employee";
        public const string OPTION_WORK_BUSSINES = "work_bussines";
        public const string OPTION_WORK_RETIRED = "work_retired";

        public const string OPTION_SITUATON_RENTER = "situation_renter";
        public const string OPTION_SITUATON_LANDLORD = "situation_landlord";
        public const string OPTION_SITUATON_OWNER = "situation_owner";
        public const string OPTION_SITUATON_TRAVEL = "situation_travel";

        public const string OPTION_BELONGINGS_CAR = "belongings_car";
        public const string OPTION_BELONGINGS_DOG = "belongings_dog";
        public const string OPTION_BELONGINGS_BOAT = "belongings_boat";
        public const string OPTION_BELONGINGS_HORSE = "belongings_horse";
        public const string OPTION_BELONGINGS_OILTANK = "belongings_oiltank";

        public const string DATA_ITEMS = "items";

        private static Dictionary<string, Item> _items;

        static public Dictionary<string, Item> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new Dictionary<string, Item>();

                    AddItem(OPTION_FAMILY_SINGLE, _groupFamily, "Single");
                    AddItem(OPTION_FAMILY_SINGLEWITHCHILD, _groupFamily, "Single mit Kind");
                    AddItem(OPTION_FAMILY_COUPLE, _groupFamily, "Paar");
                    AddItem(OPTION_FAMILY_COUPLEWITHCHILD, _groupFamily, "Paar mit Kind");

                    AddItem(OPTION_WORK_STUDY, _groupWork, "Student");
                    AddItem(OPTION_WORK_EMPLOYEE, _groupWork, "Angestellter/Beamter");
                    AddItem(OPTION_WORK_BUSSINES, _groupWork, "Selbständig");
                    AddItem(OPTION_WORK_RETIRED, _groupWork, "im Ruhestand");

                    AddItem(OPTION_SITUATON_RENTER, _groupSituation, "Mieter");
                    AddItem(OPTION_SITUATON_OWNER, _groupSituation, "Eigentümer");
                    AddItem(OPTION_SITUATON_LANDLORD, _groupSituation, "Vermieter");
                    AddItem(OPTION_SITUATON_TRAVEL, _groupSituation, "Reisender");

                    AddItem(OPTION_BELONGINGS_CAR, _groupBelongings, "Fahrzeug");
                    AddItem(OPTION_BELONGINGS_DOG, _groupBelongings, "Hund");
                    AddItem(OPTION_BELONGINGS_BOAT, _groupBelongings, "Boot");
                    AddItem(OPTION_BELONGINGS_HORSE, _groupBelongings, "Pferd");
                    AddItem(OPTION_BELONGINGS_OILTANK, _groupBelongings, "Öltank");

                    void AddItem(string id, Group group, string description)
                    {
                        _items[id] = new Item(id, group) {Description = description};
                    }
                }
                ;
                return _items;
            }
        }

        /*
        private List<InsuranceData> _insuranceList = new List<InsuranceData>()
        {
            new InsuranceData("home_insurance")
            {
                Description = "Haushaltsversicherung",
                LevelDict = new Dictionary<string, int>()
                {
                    {OPTION_FAMILY_SINGLE, 3},
                    {OPTION_FAMILY_COUPLEWITHCHILD, 5}
                }
            },
            new InsuranceData("owner_home_insurance")
            {
                Description = "Eigenheim",
                LevelDict = new Dictionary<string, int>() {{OPTION_SITUATON_OWNER, 5}, {OPTION_SITUATON_LANDLORD, 5}}
            },
            new InsuranceData("owner_boat")
            {
                Description = "Bootsversicherung",
                LevelDict = new Dictionary<string, int>() {{OPTION_BELONGINGS_BOAT, 5}}
            },
        };
        */

        // GET api/values
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        } */

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public ActionResult Calculate([FromBody] Dictionary<string, Item> data)
        {
            List<InsuranceData> _insuranceList = InsuranceDB.LoadInsurances();

            foreach (var group in data.Values.Select(_ => _.Group).Distinct())
            {
                if (group.SelectionNeeded && !data.Values.Any(_ => _.Group.Name == group.Name && _.Selected))
                {
                    return PartialView("Error",
                        $"Sie müssen in der Gruppe '{group.Description}' mindestens eine Auswahl treffen.");
                }
            }

            foreach (InsuranceData insurance in _insuranceList)
            {
                insurance.CalcLevel(data.Values.ToList());
            }
            return PartialView("Result", _insuranceList);
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View(Items);
        }


        /*// POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }*/

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       

        public class Item
        {
            public Item(string name, Group @group)
            {
                Name = name;
                Group = @group;
            }

            public string Name { get; set; }
            public string Description { get; set; }
            public Group Group { get; set; }
            public bool Selected { get; set; }
        }

        public class Group
        {
            public Group(string name, bool multiselection, bool selectionNeeded = true)
            {
                Name = name;
                Multiselection = multiselection;
                SelectionNeeded = selectionNeeded;
            }

            public string Name { get; set; }
            public string Description { get; set; }
            public bool Multiselection { get; set; }
            public bool SelectionNeeded { get; set; }
        }

       

       
    }
}
