using System.Collections.Generic;
using System.Web.Mvc;
using OvpNgDatabase.DAL;
using OvpNgDatabase.Interfaces;
using OvpNgDatabase.Models;
using OvpNgDatabase.Models.OvpNg;

namespace OvpNgDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository _homeRepository;

        public HomeController()
        {
            _homeRepository = new HomeRepository(new OvpNgContext());
        }

        // GET: Index/
        public ActionResult Index()
        {
            List<ObjectModel> mainObjects = _homeRepository.GetMainPageObjects(User);

            ViewBag.Title = "Объекты";

            return View(mainObjects);
        }

        // GET: Index/ObjectCard/5
        public ActionResult ObjectCard(int? objectId)
        {
            if (objectId is null)
                return View("Error");

            ObjectModel mainObject = _homeRepository.GetDataForObjectCard(objectId.Value);

            if (mainObject is null)
                return View("Error");

            ViewBag.Title = mainObject.Subject;

            return View(mainObject);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Информация о вашем продукте";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Контакты";

            return View();
        }
    }
}