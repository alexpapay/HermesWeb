using System.Collections.Generic;
using OvpNgDatabase.Models.OvpNg;

namespace OvpNgDatabase.Interfaces
{
    public interface IAdminRepository
    {
        /// <summary>
        /// Get all objects models from database.
        /// </summary>
        /// <param name="objectModels">List of object models.</param>
        void GetAllObjectModels(List<ObjectModel> objectModels);

        /// <summary>
        /// Add object model to database.
        /// </summary>
        /// <param name="objectModel">Object model.</param>
        /// <param name="userName">Authorized user name.</param>
        void AddObject(ObjectModel objectModel, string userName);

        /// <summary>
        /// Get data for edit object model by his id.
        /// </summary>
        /// <param name="objectId">Editing object model id value.</param>
        /// <returns>Object model for edit view.</returns>
        ObjectModel GetDataForObjectEdit(int objectId);

        /// <summary>
        /// Post edited object model data to database.
        /// </summary>
        /// <param name="objectModel">Editing object model.</param>
        /// <param name="userName">Authorized user name.</param>
        void PostDataForObjectEdit(ObjectModel objectModel, string userName);

        /// <summary>
        /// Delete object model from database by id.
        /// </summary>
        /// <param name="objectModelId">Object model id value.</param>
        void DeleteObjectModel(int objectModelId);

        /// <summary>
        /// Get all object models from database.
        /// </summary>
        /// <param name="objectModels">List of objects.</param>
        void GetAllCompanies(List<Company> objectModels);

        /// <summary>
        /// Add company to database.
        /// </summary>
        /// <param name="company">Company.</param>
        /// <param name="userName">Authorized user name.</param>
        void AddCompany(Company company, string userName);

        /// <summary>
        /// Get data for edit company by they id.
        /// </summary>
        /// <param name="companyId">Editing company id value.</param>
        /// <returns>Company for edit view.</returns>
        Company GetDataForCompanyEdit(int companyId);

        /// <summary>
        /// Post edited company data to database.
        /// </summary>
        /// <param name="company">Editing company.</param>
        /// <param name="userName">Authorized user name.</param>
        void PostDataForCompanyEdit(Company company, string userName);

        /// <summary>
        /// Delete company from database by id.
        /// </summary>
        /// <param name="companyId">Company id value.</param>
        void DeleteCompany(int companyId);

        /// <summary>
        /// Get all company profiles from database.
        /// </summary>
        /// <param name="companyProfiles">List of companies.</param>
        void GetAllCompanyProfiles(List<CompanyProfile> companyProfiles);

        /// <summary>
        /// Add company profile to database.
        /// </summary>
        /// <param name="companyProfile">Company profile.</param>
        /// <param name="userName">Authorized user name.</param>
        void AddCompanyProfile(CompanyProfile companyProfile, string userName);

        /// <summary>
        /// Get data for edit company profile by they id.
        /// </summary>
        /// <param name="companyProfileId">Editing company profile id value.</param>
        /// <returns>Company for edit view.</returns>
        CompanyProfile GetDataForCompanyProfileEdit(int companyProfileId);

        /// <summary>
        /// Post edited company profile data to database.
        /// </summary>
        /// <param name="companyProfile">Editing company profile.</param>
        /// <param name="userName">Authorized user name.</param>
        void PostDataForCompanyProfileEdit(CompanyProfile companyProfile, string userName);

        /// <summary>
        /// Delete company profile from database by id.
        /// </summary>
        /// <param name="companyProfileId">Company profile id value.</param>
        void DeleteCompanyProfile(int companyProfileId);

        /// <summary>
        /// Get all construction types from database.
        /// </summary>
        /// <param name="constructionTypes">List of construction types.</param>
        void GetAllConstructionTypes(List<ConstructionType> constructionTypes);

        /// <summary>
        /// Add construction type to database.
        /// </summary>
        /// <param name="constructionType">Construction type.</param>
        /// <param name="userName">Authorized user name.</param>
        void AddConstructionType(ConstructionType constructionType, string userName);

        /// <summary>
        /// Get data for edit construction type by they id.
        /// </summary>
        /// <param name="constructionTypeId">Editing construction type id value.</param>
        /// <returns>Construction type for edit view.</returns>
        ConstructionType GetDataForConstructionTypeEdit(int constructionTypeId);

        /// <summary>
        /// Post edited construction type data to database.
        /// </summary>
        /// <param name="constructionType">Editing construction type.</param>
        /// <param name="userName">Authorized user name.</param>
        void PostDataForConstructionTypeEdit(ConstructionType constructionType, string userName);

        /// <summary>
        /// Get all stages from database.
        /// </summary>
        /// <param name="stages">List of stages.</param>
        void GetAllStages(List<Stage> stages);

        /// <summary>
        /// Add stage to database.
        /// </summary>
        /// <param name="stage">Stage.</param>
        /// <param name="userName">Authorized user name.</param>
        void AddStage(Stage stage, string userName);

        /// <summary>
        /// Get data for edit stage by they id.
        /// </summary>
        /// <param name="stageId">Editing stage id value.</param>
        /// <returns>Stage for edit view.</returns>
        Stage GetDataStageEdit(int stageId);

        /// <summary>
        /// Post edited stage data to database.
        /// </summary>
        /// <param name="stage">Stage company.</param>
        /// <param name="userName">Authorized user name.</param>
        void PostDataForStageEdit(Stage stage, string userName);

        /// <summary>
        /// Delete stage from database by id.
        /// </summary>
        /// <param name="stageId">Stage id value.</param>
        void DeleteStage(int stageId);
    }
}
