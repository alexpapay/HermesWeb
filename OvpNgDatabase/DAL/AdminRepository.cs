using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using OvpNgDatabase.Interfaces;
using OvpNgDatabase.Models;
using OvpNgDatabase.Models.OvpNg;

namespace OvpNgDatabase.DAL
{
    public class AdminRepository : IAdminRepository
    {
        private readonly OvpNgContext _db;

        public AdminRepository(OvpNgContext db)
        {
            _db = db;
        }

        #region ObjectModel
        /// <summary>
        /// Get all object models from database.
        /// </summary>
        /// <param name="objectModels">List of objects.</param>
        public void GetAllObjectModels(List<ObjectModel> objectModels)
        {
            try
            {
                objectModels.AddRange(_db.ObjectModels);
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Add object model to database.
        /// </summary>
        /// <param name="objectModel">Object model.</param>
        /// <param name="userName">Authorized user name.</param>
        public void AddObject(ObjectModel objectModel, string userName)
        {
            try
            {
                DateTime dateTimeNow = DateTime.Now;
                objectModel.CreatedAt = dateTimeNow;
                objectModel.LastEditAt = dateTimeNow;
                objectModel.LastEditBy = userName;
                objectModel.CreatedBy = userName;

                _db.ObjectModels.Add(objectModel);
                _db.SaveChanges();
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Get data for edit object model by his id.
        /// </summary>
        /// <param name="objectId">Editing object model id value.</param>
        /// <returns>Object model for edit view.</returns>
        public ObjectModel GetDataForObjectEdit(int objectId)
        {
            ObjectModel objectModel = _db.ObjectModels.FirstOrDefault(x => x.Id == objectId);

            if (objectModel == null)
                return null;

            objectModel.CompaniesList = _db.Companies.ToList();
            objectModel.StagesList = _db.Stages.ToList();
            objectModel.ConstructionTypesList = _db.ConstructionTypes.ToList();
            objectModel.GeoDataDistrictList = _db.GeoDataDistricts.ToList();
            objectModel.Companies = new SelectList(_db.Companies, "Id", "Name");
            objectModel.Stages = new SelectList(_db.Stages, "Id", "Name");
            objectModel.ConstructionTypes = new SelectList(_db.ConstructionTypes, "Id", "Name");

            return objectModel;
        }

        /// <summary>
        /// Post edited object model data to database.
        /// </summary>
        /// <param name="objectModel">Editing object model.</param>
        /// <param name="userName">Authorized user name.</param>
        public void PostDataForObjectEdit(ObjectModel objectModel, string userName)
        {
            try
            {
                ObjectModel updatedObjectModel = new ObjectModel
                {
                    Id = objectModel.Id
                };

                _db.ObjectModels.Attach(updatedObjectModel);

                updatedObjectModel.ObjectName = objectModel.ObjectName;
                updatedObjectModel.SubObjectId = objectModel.SubObjectId;
                updatedObjectModel.Subject = objectModel.Subject;
                updatedObjectModel.CompletionRate = objectModel.CompletionRate;
                updatedObjectModel.ConstructionTypeId = objectModel.ConstructionTypeId;
                updatedObjectModel.StageId = objectModel.StageId;
                updatedObjectModel.RegionName = objectModel.RegionName;
                updatedObjectModel.Identifier = objectModel.Identifier;
                updatedObjectModel.GeoDistrictId = objectModel.GeoDistrictId;
                updatedObjectModel.ObjectStart = objectModel.ObjectStart;
                updatedObjectModel.ConstructionFinish = objectModel.ObjectFinish;
                updatedObjectModel.ConstructionFinish = objectModel.ConstructionStart;
                updatedObjectModel.ConstructionFinish = objectModel.ConstructionFinish;
                updatedObjectModel.ConstructionFinish = objectModel.DesignStart;
                updatedObjectModel.ConstructionFinish = objectModel.DesignFinish;
                updatedObjectModel.IsHaveCalculations = objectModel.IsHaveCalculations;
                updatedObjectModel.OwnerId = objectModel.OwnerId;
                updatedObjectModel.InvestorId = objectModel.InvestorId;
                updatedObjectModel.InvestorDepartmentId = objectModel.InvestorDepartmentId;
                updatedObjectModel.GeneralContractorId = objectModel.GeneralContractorId;
                updatedObjectModel.GeneralDesignerId = objectModel.GeneralDesignerId;
                updatedObjectModel.DesignerId = objectModel.DesignerId;
                updatedObjectModel.ConstructorId = objectModel.ConstructorId;
                updatedObjectModel.NonDependentControllerId = objectModel.NonDependentControllerId;
                updatedObjectModel.ContractorId = objectModel.ContractorId;
                updatedObjectModel.CreatedAt = objectModel.CreatedAt;
                updatedObjectModel.CreatedBy = objectModel.CreatedBy;
                updatedObjectModel.LastEditAt = DateTime.Now;
                updatedObjectModel.LastEditBy = userName;

                _db.Entry(updatedObjectModel).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Delete object model from database by id.
        /// </summary>
        /// <param name="objectModelId">Object model id value.</param>
        public void DeleteObjectModel(int objectModelId)
        {
            ObjectModel deletingObjectModel = new ObjectModel
            {
                Id = objectModelId
            };

            _db.ObjectModels.Attach(deletingObjectModel);
            _db.ObjectModels.Remove(deletingObjectModel);

            _db.SaveChanges();
        }
        #endregion

        #region Company
        /// <summary>
        /// Get all companies from database.
        /// </summary>
        /// <param name="objectModels">List of companies.</param>
        public void GetAllCompanies(List<Company> objectModels)
        {
            try
            {
                objectModels.AddRange(_db.Companies);
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Add company to database.
        /// </summary>
        /// <param name="company">Company.</param>
        /// <param name="userName">Authorized user name.</param>
        public void AddCompany(Company company, string userName)
        {
            try
            {
                DateTime dateTimeNow = DateTime.Now;
                company.CreatedAt = dateTimeNow;
                company.LastEditAt = dateTimeNow;
                company.LastEditBy = userName;
                company.CreatedBy = userName;

                _db.Companies.Add(company);
                _db.SaveChanges();
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Get data for edit company by they id.
        /// </summary>
        /// <param name="companyId">Editing company id value.</param>
        /// <returns>Company for edit view.</returns>
        public Company GetDataForCompanyEdit(int companyId)
        {
            Company company = _db.Companies.FirstOrDefault(x => x.Id == companyId);

            if (company == null)
                return null;

            company.CompanyProfiles = new SelectList(_db.CompanyProfiles, "Id", "Name", company.CompanyProfileId);

            return company;
        }

        /// <summary>
        /// Post edited company data to database.
        /// </summary>
        /// <param name="company">Editing company.</param>
        /// <param name="userName">Authorized user name.</param>
        public void PostDataForCompanyEdit(Company company, string userName)
        {
            try
            {
                Company updatedCompany = new Company
                {
                    Id = company.Id
                };

                _db.Companies.Attach(updatedCompany);

                updatedCompany.Name = company.Name;
                updatedCompany.BusinessName = company.BusinessName;
                updatedCompany.CompanyProfileId = company.CompanyProfileId;
                updatedCompany.LastEditAt = DateTime.Now;
                updatedCompany.LastEditBy = userName;
                _db.Entry(updatedCompany).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Delete company from database by id.
        /// </summary>
        /// <param name="companyId">Company id value.</param>
        public void DeleteCompany(int companyId)
        {
            Company deletingCompany = new Company()
            {
                Id = companyId
            };

            _db.Companies.Attach(deletingCompany);
            _db.Companies.Remove(deletingCompany);

            _db.SaveChanges();
        }
        #endregion

        #region CompanyProfile
        /// <summary>
        /// Get all company profiles from database.
        /// </summary>
        /// <param name="companyProfiles">List of companies.</param>
        public void GetAllCompanyProfiles(List<CompanyProfile> companyProfiles)
        {
            try
            {
                companyProfiles.AddRange(_db.CompanyProfiles);
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Add company profile to database.
        /// </summary>
        /// <param name="companyProfile">Company profile.</param>
        /// <param name="userName">Authorized user name.</param>
        public void AddCompanyProfile(CompanyProfile companyProfile, string userName)
        {
            try
            {
                DateTime dateTimeNow = DateTime.Now;

                companyProfile.CreatedAt = dateTimeNow;
                companyProfile.LastEditAt = dateTimeNow;
                companyProfile.LastEditBy = userName;
                companyProfile.CreatedBy = userName;

                _db.CompanyProfiles.Add(companyProfile);
                _db.SaveChanges();
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Get data for edit company profile by they id.
        /// </summary>
        /// <param name="companyProfileId">Editing company profile id value.</param>
        /// <returns>Company profile for edit view.</returns>
        public CompanyProfile GetDataForCompanyProfileEdit(int companyProfileId)
        {
            CompanyProfile company = _db.CompanyProfiles.FirstOrDefault(x => x.Id == companyProfileId);
            
            return company;
        }

        /// <summary>
        /// Post edited company profile data to database.
        /// </summary>
        /// <param name="companyProfile">Editing company profile.</param>
        /// <param name="userName">Authorized user name.</param>
        public void PostDataForCompanyProfileEdit(CompanyProfile companyProfile, string userName)
        {
            try
            {
                CompanyProfile updatedCompanyProfile = new CompanyProfile
                {
                    Id = companyProfile.Id
                };

                _db.CompanyProfiles.Attach(updatedCompanyProfile);

                updatedCompanyProfile.Name = companyProfile.Name;
                updatedCompanyProfile.LastEditAt = DateTime.Now;
                updatedCompanyProfile.LastEditBy = userName;

                _db.Entry(updatedCompanyProfile).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Delete company profile from database by id.
        /// </summary>
        /// <param name="companyProfileId">Company profile id value.</param>
        public void DeleteCompanyProfile(int companyProfileId)
        {
            CompanyProfile deletingCompanyProfile = new CompanyProfile()
            {
                Id = companyProfileId
            };

            _db.CompanyProfiles.Attach(deletingCompanyProfile);
            _db.CompanyProfiles.Remove(deletingCompanyProfile);

            _db.SaveChanges();
        }
        #endregion
        
        #region ConstructionType
        /// <summary>
        /// Get all construction types from database.
        /// </summary>
        /// <param name="constructionTypes">List of construction types.</param>
        public void GetAllConstructionTypes(List<ConstructionType> constructionTypes)
        {
            try
            {
                constructionTypes.AddRange(_db.ConstructionTypes);
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Add construction type to database.
        /// </summary>
        /// <param name="constructionType">Construction type.</param>
        /// <param name="userName">Authorized user name.</param>
        public void AddConstructionType(ConstructionType constructionType, string userName)
        {
            try
            {
                DateTime dateTimeNow = DateTime.Now;

                constructionType.CreatedAt = dateTimeNow;
                constructionType.LastEditAt = dateTimeNow;
                constructionType.LastEditBy = userName;
                constructionType.CreatedBy = userName;

                _db.ConstructionTypes.Add(constructionType);
                _db.SaveChanges();
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Get data for edit construction type by they id.
        /// </summary>
        /// <param name="constructionTypeId">Editing construction type id value.</param>
        /// <returns>Construction type for edit view.</returns>
        public ConstructionType GetDataForConstructionTypeEdit(int constructionTypeId)
        {
            ConstructionType company = _db.ConstructionTypes.FirstOrDefault(x => x.Id == constructionTypeId);

            return company;
        }

        /// <summary>
        /// Post edited construction type data to database.
        /// </summary>
        /// <param name="constructionType">Editing construction type.</param>
        /// <param name="userName">Authorized user name.</param>
        public void PostDataForConstructionTypeEdit(ConstructionType constructionType, string userName)
        {
            try
            {
                ConstructionType updatedConstructionType = new ConstructionType
                {
                    Id = constructionType.Id
                };

                _db.ConstructionTypes.Attach(updatedConstructionType);

                updatedConstructionType.Name = constructionType.Name;
                updatedConstructionType.LastEditAt = DateTime.Now;
                updatedConstructionType.LastEditBy = userName;

                _db.Entry(updatedConstructionType).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Delete construction type from database by id.
        /// </summary>
        /// <param name="constructionTypeId">Construction type id value.</param>
        public void DeleteConstructionType(int constructionTypeId)
        {
            ConstructionType deletingConstructionType = new ConstructionType
            {
                Id = constructionTypeId
            };

            _db.ConstructionTypes.Attach(deletingConstructionType);
            _db.ConstructionTypes.Remove(deletingConstructionType);

            _db.SaveChanges();
        }
        #endregion

        #region Stage
        /// <summary>
        /// Get all stages from database.
        /// </summary>
        /// <param name="stages">List of stages.</param>
        public void GetAllStages(List<Stage> stages)
        {
            try
            {
                stages.AddRange(_db.Stages);
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Add stage to database.
        /// </summary>
        /// <param name="stage">Stage.</param>
        /// <param name="userName">Authorized user name.</param>
        public void AddStage(Stage stage, string userName)
        {
            try
            {
                DateTime dateTimeNow = DateTime.Now;

                stage.CreatedAt = dateTimeNow;
                stage.LastEditAt = dateTimeNow;
                stage.LastEditBy = userName;
                stage.CreatedBy = userName;

                _db.Stages.Add(stage);
                _db.SaveChanges();
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Get data for edit stage by they id.
        /// </summary>
        /// <param name="stageId">Editing stage id value.</param>
        /// <returns>Stage for edit view.</returns>
        public Stage GetDataStageEdit(int stageId)
        {
            Stage stage = _db.Stages.FirstOrDefault(x => x.Id == stageId);
            
            return stage;
        }

        /// <summary>
        /// Post edited stage data to database.
        /// </summary>
        /// <param name="stage">Stage company.</param>
        /// <param name="userName">Authorized user name.</param>
        public void PostDataForStageEdit(Stage stage, string userName)
        {
            try
            {
                Stage updatedStage = new Stage
                {
                    Id = stage.Id
                };

                _db.Stages.Attach(updatedStage);

                updatedStage.Name = stage.Name;
                updatedStage.LastEditAt = DateTime.Now;
                updatedStage.LastEditBy = userName;

                _db.Entry(updatedStage).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                // TODO: Add logging here
            }
        }

        /// <summary>
        /// Delete stage from database by id.
        /// </summary>
        /// <param name="stageId">Stage id value.</param>
        public void DeleteStage(int stageId)
        {
            Stage deletingStage = new Stage()
            {
                Id = stageId
            };

            _db.Stages.Attach(deletingStage);
            _db.Stages.Remove(deletingStage);

            _db.SaveChanges();
        }
        #endregion
    }
}