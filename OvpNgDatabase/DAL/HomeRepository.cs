using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using OvpNgDatabase.Interfaces;
using OvpNgDatabase.Models;
using OvpNgDatabase.Models.OvpNg;

namespace OvpNgDatabase.DAL
{
    public class HomeRepository : IHomeRepository
    {
        private readonly OvpNgContext _db;

        public HomeRepository(OvpNgContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get data for mainpage table.
        /// </summary>
        /// <param name="user">Authorized user</param>
        /// <returns>List of object models.</returns>
        public List<ObjectModel> GetMainPageObjects(IPrincipal user)
        {
            List<ObjectModel> mainObjects = new List<ObjectModel>();

            List<ObjectModel> allObjects;
            if (user.IsInRole("admin") || user.IsInRole("user"))
                allObjects = _db.ObjectModels.Where(x => x.Id != 0 && (x.Id < 56 || x.Id > 62)).ToList();
            else
                // Demo objects:
                allObjects = _db.ObjectModels.Where(x => x.Id >= 56 && x.Id <= 62).ToList();

            foreach (var mainObject in allObjects)
            {
                mainObject.Stage = _db.Stages.FirstOrDefault(x => x.Id == mainObject.StageId);
                mainObject.GeoDataDistrict = _db.GeoDataDistricts.FirstOrDefault(x => x.Id == mainObject.GeoDistrictId);
                mainObject.ConstructionType = _db.ConstructionTypes.FirstOrDefault(x => x.Id == mainObject.ConstructionTypeId);
                mainObject.Owner = _db.Companies.FirstOrDefault(x => x.Id == mainObject.OwnerId);
                mainObject.Investor = _db.Companies.FirstOrDefault(x => x.Id == mainObject.InvestorId);
                mainObject.InvestorDepartment = _db.Companies.FirstOrDefault(x => x.Id == mainObject.InvestorDepartmentId);
                mainObject.Designer = _db.Companies.FirstOrDefault(x => x.Id == mainObject.DesignerId);
                mainObject.GeneralDesigner = _db.Companies.FirstOrDefault(x => x.Id == mainObject.GeneralDesignerId);
                mainObject.GeneralContractor = _db.Companies.FirstOrDefault(x => x.Id == mainObject.GeneralContractorId);
                mainObject.Contractor = _db.Companies.FirstOrDefault(x => x.Id == mainObject.ContractorId);
                mainObject.Constructor = _db.Companies.FirstOrDefault(x => x.Id == mainObject.ConstructorId);
                mainObject.NonDependentController = _db.Companies.FirstOrDefault(x => x.Id == mainObject.NonDependentControllerId);

                mainObjects.Add(mainObject);
            }

            return mainObjects;
        }

        /// <summary>
        /// Get data for object card display.
        /// </summary>
        /// <param name="objectId">Selected object id value.</param>
        /// <returns>Object model.</returns>
        public ObjectModel GetDataForObjectCard(int objectId)
        {
            ObjectModel mainObject = _db.ObjectModels.FirstOrDefault(x => x.Id == objectId);

            if (mainObject == null)
                return null;

            mainObject.GeoDataDistrict =
                _db.GeoDataDistricts.FirstOrDefault(x => x.Id == mainObject.GeoDistrictId);
            mainObject.Stage = _db.Stages.FirstOrDefault(x => x.Id == mainObject.StageId);
            mainObject.ConstructionType = _db.ConstructionTypes.FirstOrDefault(x => x.Id == mainObject.ConstructionTypeId);
            mainObject.Owner = _db.Companies.FirstOrDefault(x => x.Id == mainObject.OwnerId);
            mainObject.Investor = _db.Companies.FirstOrDefault(x => x.Id == mainObject.InvestorId);
            mainObject.InvestorDepartment =
                _db.Companies.FirstOrDefault(x => x.Id == mainObject.InvestorDepartmentId);
            mainObject.Designer = _db.Companies.FirstOrDefault(x => x.Id == mainObject.DesignerId);
            mainObject.GeneralDesigner = _db.Companies.FirstOrDefault(x => x.Id == mainObject.GeneralDesignerId);
            mainObject.GeneralContractor =
                _db.Companies.FirstOrDefault(x => x.Id == mainObject.GeneralContractorId);
            mainObject.Contractor = _db.Companies.FirstOrDefault(x => x.Id == mainObject.ContractorId);
            mainObject.Constructor = _db.Companies.FirstOrDefault(x => x.Id == mainObject.ConstructorId);
            mainObject.NonDependentController =
                _db.Companies.FirstOrDefault(x => x.Id == mainObject.NonDependentControllerId);


            return mainObject;
        }
    }
}