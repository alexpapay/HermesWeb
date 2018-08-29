using System.Security.Principal;
using OvpNgDatabase.Models.ViewModels;

namespace OvpNgDatabase.Interfaces
{
    public interface IStaticticRepository
    {
        /// <summary>
        /// Get statistic data.
        /// </summary>
        /// <param name="user">Authorized user.</param>
        /// <returns>Statistic view model data.</returns>
        StatisticViewModel GetStatisticData(IPrincipal user);
    }
}