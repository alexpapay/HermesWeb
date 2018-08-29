using System.Collections.Generic;
using System.Security.Principal;
using OvpNgDatabase.Models.OvpNg;

namespace OvpNgDatabase.Interfaces
{
    public interface IHomeRepository
    {
        /// <summary>
        /// Get data for mainpage table.
        /// </summary>
        /// <param name="user">Authorized user</param>
        /// <returns>List of object models.</returns>
        List<ObjectModel> GetMainPageObjects(IPrincipal user);

        /// <summary>
        /// Get data for object card display.
        /// </summary>
        /// <param name="objectId">Selected object id value.</param>
        /// <returns>Object model.</returns>
        ObjectModel GetDataForObjectCard(int objectId);
    }
}