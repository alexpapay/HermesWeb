using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OvpNgDatabase.Models.OvpNg
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Юридическое название")]
        public string BusinessName { get; set; }

        [DisplayName("Веб сайт")]
        public string Website { get; set; }

        [DisplayName("Профиль компании")]
        public int CompanyProfileId { get; set; }

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

        [NotMapped]
        public SelectList CompanyProfiles { get; set; }

        public Company()
        {
            OvpNgContext objectContext = new OvpNgContext();
            CompanyProfiles = new SelectList(objectContext.CompanyProfiles, "Id", "Name");
        }
    }
}