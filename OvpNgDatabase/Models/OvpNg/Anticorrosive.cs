using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OvpNgDatabase.Models.OvpNg
{
    public class Anticorrosive
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("ТИП Закупка")]
        public string Purchase { get; set; }

        [DisplayName("Лакокраска")]
        public bool IsPaintAndVarnish { get; set; }

        [DisplayName("Внутренние трубы")]
        public bool IsTubesInside { get; set; }

        [DisplayName("Наружние трубы")]
        public bool IsTubesOutside { get; set; }

        [Required]
        [DisplayName("Создано")]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        [DisplayName("Редактировано")]
        public DateTime LastEditAt { get; set; }

        [Required]
        public string LastEditBy { get; set; }
    }
}