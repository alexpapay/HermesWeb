using System.Collections.Generic;
using OvpNgDatabase.Models.OvpNg;

namespace OvpNgDatabase.Models.ViewModels
{
    public class StatisticViewModel
    {
        public List<CompanyDataViewModel> Investors { get; set; }

        public List<CompanyDataViewModel> Designers { get; set; }

        public List<CompanyDataViewModel> Contractors { get; set; }

        public List<ObjectModel> ObjectModels { get; set; }

        public StatisticViewModel()
        {
            Investors = new List<CompanyDataViewModel>();
            Designers = new List<CompanyDataViewModel>();
            Contractors = new List<CompanyDataViewModel>();
            ObjectModels = new List<ObjectModel>();
        }
    }

    public class CompanyDataViewModel
    {
        public string Name { get; set; }

        public int ObjectsCount { get; set; }
    }
}