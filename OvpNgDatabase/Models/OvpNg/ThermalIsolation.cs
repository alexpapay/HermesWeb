using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OvpNgDatabase.Models.OvpNg
{
    public class ThermalIsolation
    {
        [Key]
        public int? Id { get; set; }

        [DisplayName("ТИП Закупка")]
        public string Purchase { get; set; }

        [DisplayName("Наличие")]
        public bool IsAvailable { get; set; }

        [DisplayName("Приоритетности")]
        public int Priority { get; set; }

        [DisplayName("Объем")]
        public double Volume { get; set; }

        [DisplayName("Площадь")]
        public double Square { get; set; }

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