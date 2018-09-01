using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OvpNgDatabase.Models.OvpNg;

namespace OvpNgDatabase.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class OvpNgContext : DbContext
    {
        public OvpNgContext() : base("HermesDb")
        {
            
        }

        public DbSet<Anticorrosive> Anticorrosives { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<ConstructionType> ConstructionTypes { get; set; }
        public DbSet<GeoDataDistrict> GeoDataDistricts { get; set; }
        public DbSet<GeoDataRegion> GeoDataRegions { get; set; }
        public DbSet<GeoDataCity> GeoDataCities { get; set; }
        public DbSet<ObjectModel> ObjectModels { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<ThermalIsolation> ThermalIsolations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // TODO: Rework this for correct deleting:
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}