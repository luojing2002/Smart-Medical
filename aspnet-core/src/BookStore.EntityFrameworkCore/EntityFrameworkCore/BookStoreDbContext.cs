using BookStore;
using BookStore.Books;
using BookStore.Pharmacy;
using BookStore.Medical;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace BookStore.EntityFrameworkCore;


[ConnectionStringName("Default")]
public class BookStoreDbContext :
    AbpDbContext<BookStoreDbContext>

{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Drug> Drugs { get; set; }
    public DbSet<Sick> Medicals { get; set; }


    #endregion

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

       
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();




        builder.Entity<Book>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "Books",
                BookStoreConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        builder.Entity<Drug>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "Drugs", BookStoreConsts.DbSchema);
            b.ConfigureByConvention(); 
            b.Property(x => x.DrugName).IsRequired().HasMaxLength(128);
            b.Property(x => x.DrugType).IsRequired().HasMaxLength(32);
            b.Property(x => x.FeeName).IsRequired().HasMaxLength(32);
            b.Property(x => x.DosageForm).IsRequired().HasMaxLength(32);
            b.Property(x => x.Specification).IsRequired().HasMaxLength(64);
            b.Property(x => x.Effect).IsRequired().HasMaxLength(256);
            b.Property(x => x.Category).IsRequired();
            b.Property(x => x.PurchasePrice).HasColumnType("decimal(18,2)");
            b.Property(x => x.SalePrice).HasColumnType("decimal(18,2)");
        });

        builder.Entity<Sick>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "Medicals", BookStoreConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Status).IsRequired().HasMaxLength(32);
            b.Property(x => x.InpatientNumber).IsRequired().HasMaxLength(32);
            b.Property(x => x.Name).IsRequired().HasMaxLength(32);
            b.Property(x => x.DischargeDepartment).IsRequired().HasMaxLength(64);
            b.Property(x => x.Gender).IsRequired().HasMaxLength(8);
            b.Property(x => x.DischargeTime).IsRequired();
            b.Property(x => x.AdmissionDiagnosis).IsRequired().HasMaxLength(128);
            b.Property(x => x.DischargeDiagnosis).IsRequired().HasMaxLength(128);
        });

       
        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(BookStoreConsts.DbTablePrefix + "YourEntities", BookStoreConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }


}
