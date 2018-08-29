using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using OvpNgDatabase.Interfaces;
using OvpNgDatabase.Models;
using OvpNgDatabase.Models.OvpNg;
using OvpNgDatabase.Models.ViewModels;

namespace OvpNgDatabase.DAL
{
    public class StaticticRepository :IStaticticRepository
    {
        private readonly OvpNgContext _db;

        public StaticticRepository(OvpNgContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get statistic data.
        /// </summary>
        /// <param name="user">Authorized user.</param>
        /// <returns>Statistic view model data.</returns>
        public StatisticViewModel GetStatisticData(IPrincipal user)
        {
            StatisticViewModel statistic = new StatisticViewModel();

            List<ObjectModel> allObjects;
            List<Company> currentCompanies;

            if (user.IsInRole("admin") || user.IsInRole("user"))
            {
                allObjects = _db.ObjectModels.Where(x => x.Id != 0 && (x.Id < 56 || x.Id > 62)).ToList();
                currentCompanies = _db.Companies.Where(x => x.Id != 32).ToList();
            }
            else
            {
                allObjects = _db.ObjectModels.Where(x => x.Id >= 56 && x.Id <= 62).ToList();
                currentCompanies = _db.Companies.Where(x => x.Id == 32).ToList();
            }

            foreach (Company company in currentCompanies)
            {
                List<ObjectModel> dataInvestors = allObjects.Where(x => x.Investor.Id == company.Id).ToList();
                if (dataInvestors.Count != 0)
                    statistic.Investors.Add(new CompanyDataViewModel
                    {
                        Name = company.Name,
                        ObjectsCount = dataInvestors.Count
                    });

                List<ObjectModel> dataDesigners = allObjects.Where(x => x.Designer.Id == company.Id).ToList();
                if (dataDesigners.Count != 0)
                    statistic.Designers.Add(new CompanyDataViewModel
                    {
                        Name = company.Name,
                        ObjectsCount = dataDesigners.Count
                    });

                List<ObjectModel> dataContractors = allObjects.Where(x => x.Contractor.Id == company.Id).ToList();
                if (dataContractors.Count != 0)
                    statistic.Contractors.Add(new CompanyDataViewModel
                    {
                        Name = company.Name,
                        ObjectsCount = dataContractors.Count
                    });
            }

            statistic.ObjectModels.AddRange(allObjects);

            return statistic;
        }
    }
}