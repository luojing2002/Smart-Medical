using BookStore.Books;
using BookStore.DoctorInformation;
using BookStore.DoctorvVsit;
using BookStore.Patient;
using BookStore.Prescriptions;
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


    #endregion
    public DbSet<Book> Books { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medication> Medications { get; set; }


    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {

    }

    public DbSet<PatientPrescription> PatientPrescriptions { get; set; }

    public DbSet<BasicPatientInfo> BasicPatientInfos { get; set; }

    public DbSet<DoctorClinic> DoctorClinics { get; set; }

    public DbSet<DoctorAccount> DoctorAccounts { get; set; }

    public DbSet<DoctorDepartment> DoctorDepartments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

       
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();


        //书籍
        builder.Entity<Book>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "Books",
                BookStoreConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);            
        });
        builder.Entity<Prescription>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "Prescriptions",
                BookStoreConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });
        builder.Entity<Medication>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "Medications",
                BookStoreConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });
        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(BookStoreConsts.DbTablePrefix + "YourEntities", BookStoreConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        // PatientPrescription 配置
        builder.Entity<PatientPrescription>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "PatientPrescriptions", BookStoreConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            //长度限制、必填项等
            b.Property(x => x.MedicationName).IsRequired().HasMaxLength(128);
            b.Property(x => x.Specification).HasMaxLength(128);
            b.Property(x => x.DosageUnit).IsRequired().HasMaxLength(20);
            b.Property(x => x.Dosage).IsRequired();
            b.Property(x => x.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            b.Property(x => x.PrescriptionTemplateNumber).IsRequired().HasDefaultValue(0);

        });

        // BasicPatientInfo 配置
        builder.Entity<BasicPatientInfo>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "BasicPatientInfos", BookStoreConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.VisitId).IsRequired().HasMaxLength(20);
            b.Property(x => x.PatientName).IsRequired().HasMaxLength(50);
            b.Property(x => x.AgeUnit).HasMaxLength(10);
            b.Property(x => x.ContactPhone).HasMaxLength(20);
            b.Property(x => x.IdNumber).HasMaxLength(18);
            b.Property(x => x.VisitType).IsRequired().HasMaxLength(20);
            b.Property(x => x.VisitStatus).HasMaxLength(20);
        });

        // DoctorAccount 配置
        builder.Entity<DoctorAccount>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "DoctorAccounts", BookStoreConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.AccountId).IsRequired().HasMaxLength(20);
            b.Property(x => x.EmployeeId).IsRequired().HasMaxLength(10);
            b.Property(x => x.EmployeeName).IsRequired().HasMaxLength(20);
            b.Property(x => x.InstitutionName).IsRequired().HasMaxLength(50);
            b.Property(x => x.DepartmentName).HasMaxLength(30);
        });

        // DoctorClinic 配置
        builder.Entity<DoctorClinic>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "DoctorClinics", BookStoreConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.PatientId).IsRequired();
            b.Property(x => x.DoctorId).IsRequired();
            b.Property(x => x.VisitDateTime).IsRequired();
            b.Property(x => x.DepartmentName).IsRequired().HasMaxLength(50);
            b.Property(x => x.ChiefComplaint).HasMaxLength(500);
            b.Property(x => x.PreliminaryDiagnosis).HasMaxLength(1000);
            b.Property(x => x.VisitType).IsRequired().HasMaxLength(20);
            b.Property(x => x.Remarks).HasMaxLength(1000);
        });

        // DoctorDepartment 配置
        builder.Entity<DoctorDepartment>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "DoctorDepartments", BookStoreConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.DepartmentName).IsRequired().HasMaxLength(50);
            b.Property(x => x.DepartmentCategory).HasMaxLength(30);
            b.Property(x => x.Address).HasMaxLength(100);
            b.Property(x => x.DirectorName).HasMaxLength(20);
            b.Property(x => x.Type).HasMaxLength(20);
        });
    }


}
