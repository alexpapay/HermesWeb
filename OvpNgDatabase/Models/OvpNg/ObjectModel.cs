using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OvpNgDatabase.Models.OvpNg
{
    public class ObjectModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название")]
        public string ObjectName { get; set; }

        [DisplayName("Входит в")]
        public int? SubObjectId { get; set; }

        [DisplayName("Предмет")]
        public string Subject { get; set; }

        [Required]
        [DisplayName("% готовности")]
        public int CompletionRate { get; set; }

        [Required]
        [DisplayName("Вид строительства")]
        public int ConstructionTypeId { get; set; }

        [Required]
        [DisplayName("Стадия МН")]
        public int StageId { get; set; }
        
        [DisplayName("Область")]
        public string RegionName { get; set; }

        [DisplayName("Идентификатор региона")]
        public string Identifier { get; set; }

        [Required]
        [DisplayName("Округ")]
        public int GeoDistrictId { get; set; }

        [DisplayName("Начало объекта")]
        public DateTime ObjectStart { get; set; }

        [DisplayName("Конец объекта")]
        public DateTime ObjectFinish { get; set; }
        
        [DisplayName("Начало строительства")]
        public DateTime ConstructionStart { get; set; }

        [DisplayName("Конец строительства")]
        public DateTime ConstructionFinish { get; set; }

        [DisplayName("Начало проектирования")]
        public DateTime DesignStart { get; set; }

        [DisplayName("Конец проектирования")]
        public DateTime DesignFinish { get; set; }

        [DisplayName("Сметы")]
        public bool IsHaveCalculations { get; set; }
        
        [DisplayName("Владелец")]
        public int OwnerId { get; set; }

        [DisplayName("Инвестор")]
        public int InvestorId { get; set; }

        [DisplayName("Подразделение инвестора")]
        public int InvestorDepartmentId { get; set; }

        [DisplayName("Генподрядчик проекта")]
        public int GeneralContractorId { get; set; }

        [DisplayName("Генпроектировщик")]
        public int GeneralDesignerId { get; set; }

        [DisplayName("Проектировщик")]
        public int DesignerId { get; set; }

        [DisplayName("Конструктор")]
        public int ConstructorId { get; set; }

        [DisplayName("Независимый контроль")]
        public int NonDependentControllerId { get; set; }

        [DisplayName("Подрядчик")]
        public int ContractorId { get; set; }

        [Required]
        [DisplayName("Дата создания")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [DisplayName("Создано")]
        public string CreatedBy { get; set; }

        [Required]
        [DisplayName("Дата редактирования")]
        public DateTime LastEditAt { get; set; }

        [Required]
        [DisplayName("Редактировано")]
        public string LastEditBy { get; set; }

        [ForeignKey("StageId")]
        public virtual Stage Stage { get; set; }

        [ForeignKey("ConstructionTypeId")]
        public virtual ConstructionType ConstructionType { get; set; }

        //[ForeignKey("GeoDistrictId")]
        [NotMapped]
        public virtual GeoDataDistrict GeoDataDistrict { get; set; }
        
        [ForeignKey("OwnerId")]
        public virtual Company Owner { get; set; }
        
        [ForeignKey("InvestorId")]
        public virtual Company Investor { get; set; }

        [ForeignKey("InvestorDepartmentId")]
        public virtual Company InvestorDepartment { get; set; }

        [ForeignKey("GeneralContractorId")]
        public virtual Company GeneralContractor { get; set; }

        [ForeignKey("GeneralDesignerId")]
        public virtual Company GeneralDesigner { get; set; }

        [ForeignKey("DesignerId")]
        public virtual Company Designer { get; set; }

        [ForeignKey("ConstructorId")]
        public virtual Company Constructor { get; set; }

        [ForeignKey("NonDependentControllerId")]
        public virtual Company NonDependentController { get; set; }

        [ForeignKey("ContractorId")]
        public virtual Company Contractor { get; set; }

        [NotMapped]
        public SelectList Companies { get; set; }

        [NotMapped]
        public SelectList Stages { get; set; }

        [NotMapped]
        public SelectList ConstructionTypes { get; set; }

        [NotMapped]
        public SelectList GeoDataDistricts { get; set; }

        [NotMapped]
        public List<Company> CompaniesList { get; set; }

        [NotMapped]
        public List<Stage> StagesList { get; set; }

        [NotMapped]
        public List<ConstructionType> ConstructionTypesList { get; set; }

        [NotMapped]
        public List<GeoDataDistrict> GeoDataDistrictList { get; set; }

        public ObjectModel()
        {
            OvpNgContext objectContext = new OvpNgContext();
            Companies = new SelectList(objectContext.Companies, "Id", "Name");
            Stages = new SelectList(objectContext.Stages, "Id", "Name");
            ConstructionTypes = new SelectList(objectContext.ConstructionTypes, "Id", "Name");
            GeoDataDistricts = new SelectList(objectContext.GeoDataDistricts, "Id", "Name");

            DateTime currentTime = DateTime.Now;

            ObjectStart = currentTime;
            ObjectFinish = currentTime;
            ConstructionStart = currentTime;
            ConstructionFinish = currentTime;
            DesignStart = currentTime;
            DesignFinish = currentTime;
        }
    }
}