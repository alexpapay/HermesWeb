using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OvpNgDatabase.DAL;
using OvpNgDatabase.Interfaces;
using OvpNgDatabase.Models;
using OvpNgDatabase.Models.OvpNg;

namespace OvpNgDatabase.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController()
        {
            _adminRepository = new AdminRepository(new OvpNgContext());
        }

        // GET: /Admin
        public ActionResult Index()
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            List<ObjectModel> objectModels = new List<ObjectModel>();

            _adminRepository.GetAllObjectModels(objectModels);
            
            return View("ObjectModel", objectModels);
        }

        // GET: /Admin/ObjectModel
        public ActionResult ObjectModel()
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            List<ObjectModel> objectModels = new List<ObjectModel>();

            _adminRepository.GetAllObjectModels(objectModels);

            return View(objectModels);
        }
        // POST: /Admin/AddObjectModel/
        [HttpPost]
        public ActionResult AddObjectModel(ObjectModel objectModel)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.AddObject(objectModel, User.Identity.Name);

            return RedirectToAction("ObjectModel");
        }
        // GET: /Admin/GetEditObjectModel/5
        [HttpGet]
        public ActionResult GetEditObjectModel(int id)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            ObjectModel objectModel = _adminRepository.GetDataForObjectEdit(id);

            return objectModel == null ? View("Error") : View("ObjectModelEdit", objectModel);
        }
        // POST: /Admin/PostEditObjectModel/
        [HttpPost]
        public ActionResult PostEditObjectModel(ObjectModel objectModel)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.PostDataForObjectEdit(objectModel, User.Identity.Name);

            return RedirectToAction("ObjectModel");
        }
        // POST: /Admin/DeleteObjectModel/
        [HttpPost]
        public ActionResult DeleteObjectModel(ObjectModel objectModel)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.DeleteObjectModel(objectModel.Id);

            return RedirectToAction("ObjectModel");
        }
        
        // GET: /Admin/Company
        public ActionResult Company()
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            List<Company> companies = new List<Company>();

            _adminRepository.GetAllCompanies(companies);

            return View(companies);
        }
        // POST: /Admin/AddCompany/
        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.AddCompany(company, User.Identity.Name);

            return RedirectToAction("Company");
        }
        // GET: /Admin/GetEditCompany/5
        [HttpGet]
        public ActionResult GetEditCompany(int id)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            Company company = _adminRepository.GetDataForCompanyEdit(id);
            
            return company == null ? View("Error") : View("CompanyEdit", company);
        }
        // POST: /Admin/PostEditCompany/
        [HttpPost]
        public ActionResult PostEditCompany(Company company)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.PostDataForCompanyEdit(company, User.Identity.Name);

            return RedirectToAction("Company");
        }
        // POST: /Admin/DeleteCompany/
        [HttpPost]
        public ActionResult DeleteCompany(Company company)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.DeleteCompany(company.Id);

            return RedirectToAction("Company");
        }

        // GET: /Admin/CompanyProfile
        public ActionResult CompanyProfile()
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            List<CompanyProfile> companyProfiles = new List<CompanyProfile>();

            _adminRepository.GetAllCompanyProfiles(companyProfiles);

            return View(companyProfiles);
        }
        // POST: /Admin/AddCompanyProfile/
        [HttpPost]
        public ActionResult AddCompanyProfile(CompanyProfile companyProfile)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.AddCompanyProfile(companyProfile, User.Identity.Name);

            return RedirectToAction("CompanyProfile");
        }
        // GET: /Admin/GetEditCompany/5
        [HttpGet]
        public ActionResult GetEditCompanyProfile(int id)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            CompanyProfile companyProfile = _adminRepository.GetDataForCompanyProfileEdit(id);

            return View("CompanyProfileEdit", companyProfile);
        }
        // POST: /Admin/PostEditCompanyProfile/
        [HttpPost]
        public ActionResult PostEditCompanyProfile(CompanyProfile companyProfile)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.PostDataForCompanyProfileEdit(companyProfile, User.Identity.Name);

            return RedirectToAction("CompanyProfile");
        }
        // POST: /Admin/DeleteCompany/
        [HttpPost]
        public ActionResult DeleteCompanyProfile(CompanyProfile companyProfile)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.DeleteCompanyProfile(companyProfile.Id);

            return RedirectToAction("CompanyProfile");
        }
        
        // GET: /Admin/ConstructionType
        public ActionResult ConstructionType()
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            List<ConstructionType> constructionTypes = new List<ConstructionType>();

            _adminRepository.GetAllConstructionTypes(constructionTypes);

            return View(constructionTypes);
        }
        // POST: /Admin/AddConstructionType/
        [HttpPost]
        public ActionResult AddConstructionType(ConstructionType constructionType)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.AddConstructionType(constructionType, User.Identity.Name);

            return RedirectToAction("ConstructionType");
        }
        // GET: /Admin/GetEditConstructionType/5
        [HttpGet]
        public ActionResult GetEditConstructionType(int id)
        {
            if (!User.IsInRole("admin"))
                return View("Error");
            
            ConstructionType constructionType = _adminRepository.GetDataForConstructionTypeEdit(id);

            return View("ConstructionTypeEdit", constructionType);
        }
        // POST: /Admin/PostEditConstructionType/
        [HttpPost]
        public ActionResult PostEditConstructionType(ConstructionType constructionType)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.PostDataForConstructionTypeEdit(constructionType, User.Identity.Name);

            return RedirectToAction("ConstructionType");
        }
        // POST: /Admin/DeleteConstructionType/
        [HttpPost]
        public ActionResult DeleteConstructionType(ConstructionType constructionType)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            using (OvpNgContext db = new OvpNgContext())
            {
                ConstructionType deletingConstructionType = new ConstructionType
                {
                    Id = constructionType.Id
                };

                db.ConstructionTypes.Attach(deletingConstructionType);
                db.ConstructionTypes.Remove(deletingConstructionType);

                db.SaveChanges();
            }
            return RedirectToAction("ConstructionType");
        }
        
        // GET: /Admin/Stage
        public ActionResult Stage()
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            List<Stage> stages = new List<Stage>();

            _adminRepository.GetAllStages(stages);

            return View(stages);
        }
        // POST: /Admin/AddStage/
        [HttpPost]
        public ActionResult AddStage(Stage stage)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.AddStage(stage, User.Identity.Name);

            return RedirectToAction("Stage");
        }
        // GET: /Admin/GetEditStage/5
        [HttpGet]
        public ActionResult GetEditStage(int id)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            Stage stage = _adminRepository.GetDataStageEdit(id);

            return View("StageEdit", stage);
        }
        // POST: /Admin/PostEditStage/
        [HttpPost]
        public ActionResult PostEditStage(Stage stage)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.PostDataForStageEdit(stage, User.Identity.Name);

            return RedirectToAction("Stage");
        }
        // POST: /Admin/DeleteStage/
        [HttpPost]
        public ActionResult DeleteStage(Stage stage)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            _adminRepository.DeleteStage(stage.Id);

            return RedirectToAction("Stage");
        }

        // TODO: Rework this controllers to pattern in future:
        // GET: /Admin/ThermalIsolation
        public ActionResult ThermalIsolation()
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            List<ThermalIsolation> thermalIsolations = new List<ThermalIsolation>();

            using (OvpNgContext db = new OvpNgContext())
            {
                thermalIsolations
                    .AddRange(db.ThermalIsolations);
            }

            return View(thermalIsolations);
        }

        // POST: /Admin/DeleteThermalIsolation/
        [HttpPost]
        public ActionResult DeleteThermalIsolation(ThermalIsolation thermalIsolation)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            using (OvpNgContext db = new OvpNgContext())
            {
                ThermalIsolation deletingThermalIsolation = new ThermalIsolation
                {
                    Id = thermalIsolation.Id
                };

                db.ThermalIsolations.Attach(deletingThermalIsolation);
                db.ThermalIsolations.Remove(deletingThermalIsolation);

                db.SaveChanges();
            }
            return RedirectToAction("ThermalIsolation");
        }

        // POST: /Admin/AddThermalIsolation/
        [HttpPost]
        public ActionResult AddThermalIsolation(ThermalIsolation thermalIsolation)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            using (OvpNgContext db = new OvpNgContext())
            {
                DateTime dateTimeNow = DateTime.Now;
                thermalIsolation.CreatedAt = dateTimeNow;
                thermalIsolation.LastEditAt = dateTimeNow;
                thermalIsolation.LastEditBy = User.Identity.Name;
                thermalIsolation.CreatedBy = User.Identity.Name;

                db.ThermalIsolations.Add(thermalIsolation);
                db.SaveChanges();
            }

            return RedirectToAction("ThermalIsolation");
        }


        // GET: /Admin/Anticorrosive
        public ActionResult Anticorrosive()
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            List<Anticorrosive> anticorrosives = new List<Anticorrosive>();

            using (OvpNgContext db = new OvpNgContext())
            {
                anticorrosives
                    .AddRange(db.Anticorrosives);
            }

            return View(anticorrosives);
        }

        // POST: /Admin/DeleteAnticorrosive/
        [HttpPost]
        public ActionResult DeleteAnticorrosive(Anticorrosive anticorrosive)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            using (OvpNgContext db = new OvpNgContext())
            {
                Anticorrosive deletingAnticorrosive = new Anticorrosive
                {
                    Id = anticorrosive.Id
                };

                db.Anticorrosives.Attach(deletingAnticorrosive);
                db.Anticorrosives.Remove(deletingAnticorrosive);

                db.SaveChanges();
            }
            return RedirectToAction("Anticorrosive");
        }

        // POST: /Admin/AddAnticorrosive/
        [HttpPost]
        public ActionResult AddAnticorrosive(Anticorrosive anticorrosive)
        {
            if (!User.IsInRole("admin"))
                return View("Error");

            using (OvpNgContext db = new OvpNgContext())
            {
                DateTime dateTimeNow = DateTime.Now;
                anticorrosive.CreatedAt = dateTimeNow;
                anticorrosive.LastEditAt = dateTimeNow;
                anticorrosive.LastEditBy = User.Identity.Name;
                anticorrosive.CreatedBy = User.Identity.Name;

                db.Anticorrosives.Add(anticorrosive);
                db.SaveChanges();
            }

            return RedirectToAction("Anticorrosive");
        }
    }
}