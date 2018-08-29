using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OvpNgDatabase.Models.OvpNg
{
    public class GeoDataCity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Регион")]
        public string Name { get; set; }

        [Required]
        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        public virtual GeoDataRegion GeoDataRegion { get; set; }
    }
}