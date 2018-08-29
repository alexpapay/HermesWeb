using System.Web.Mvc;
using OvpNgDatabase.DAL;
using OvpNgDatabase.Interfaces;
using OvpNgDatabase.Models;
using OvpNgDatabase.Models.ViewModels;

namespace OvpNgDatabase.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStaticticRepository _staticticRepository;

        public StatisticsController()
        {
            _staticticRepository = new StaticticRepository(new OvpNgContext());
        }

        // GET: Statistics/
        public ActionResult Index()
        {
            StatisticViewModel statistic = _staticticRepository.GetStatisticData(User);

            ViewBag.Title = "Статистика";

            return View(statistic);
        }
    }
}