using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OvpNgDatabase.Models.OvpNg
{
    public class CompanyProfile
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

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
    }
}