using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OvpNgDatabase.Models.OvpNg
{
    public class GeoDataDistrict
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Округ")]
        public string Name { get; set; }
    }
}