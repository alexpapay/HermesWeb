using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OvpNgDatabase.Models.OvpNg
{
    public class GeoDataRegion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Регион")]
        public string Name { get; set; }

        [Required]
        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual GeoDataDistrict GeoDataDistrict { get; set; }
    }
}