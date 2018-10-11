using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using OfficeStock.Entity;
using System.Data.Entity;
using OfficeStock.Common.Enums;

namespace OfficeStock.Dal.Contexts
{
    public class AssociationDbContext : DbContext
    {
        public AssociationDbContext() : base("OfficeStockConStr")
        {
            Database.SetInitializer<AssociationDbContext>(new DropCreateDatabaseIfModelChanges<AssociationDbContext>());
            //Database.SetInitializer<AssociationDbContext>(new CreateDatabaseIfNotExists<AssociationDbContext>());
            
        }

        public DbSet<FixedAsset> FixedAssets { get; set; }
      //  public DbSet<FixedAssetType> FixedAssetTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FixedAsset>().ToTable("FixedAssets");
            modelBuilder.Entity<Barcode>().ToTable("Barcodes");
            modelBuilder.Entity<Group>().ToTable("Groups");
            modelBuilder.Entity<Location>().ToTable("Locations");
            base.OnModelCreating(modelBuilder);
        }
    }
}

    
