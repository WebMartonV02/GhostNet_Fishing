using GhostNetFishing.GhostNetAndPersons;
using GhostNetFishing.GhostNets;
using GhostNetFishing.GhostNetStatuses;
using GhostNetFishing.Persons;
using GhostNetFishing.PersonTypes;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace GhostNetFishing.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class GhostNetFishingDbContext :
    AbpDbContext<GhostNetFishingDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    public DbSet<GhostNet> GhostNets { get; set; }
    public DbSet<GhostNetStatus> GhostNetStatuses { get; set; }
    public DbSet<GhostNetAndPerson> GhostNetAndPersons { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonType> PersonTypes { get; set; }

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
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public GhostNetFishingDbContext(DbContextOptions<GhostNetFishingDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        builder.Entity<GhostNet>(b =>
        {
            b.ToTable(GhostNetFishingConsts.DbTablePrefix + nameof(GhostNet), GhostNetFishingConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasMany(x => x.GhostNetAndPerson).WithOne(x => x.GhostNet).HasForeignKey(x => x.GhostNetId);
            b.HasOne(x => x.GhostNetStatus).WithMany(x => x.GhostNets).HasForeignKey(x => x.GhostNetStatusId);
        });

        builder.Entity<GhostNetStatus>(b =>
        {
            b.ToTable(GhostNetFishingConsts.DbTablePrefix + nameof(GhostNetStatus), GhostNetFishingConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasMany(x => x.GhostNets).WithOne(x => x.GhostNetStatus).HasForeignKey(x => x.GhostNetStatusId);
        });

        builder.Entity<GhostNetAndPerson>(b =>
        {
            b.ToTable(GhostNetFishingConsts.DbTablePrefix + nameof(GhostNetAndPerson), GhostNetFishingConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne(x => x.Person).WithMany(x => x.GhostNetAndPerson).HasForeignKey(x => x.PersonId);
            b.HasOne(x => x.GhostNet).WithMany(x => x.GhostNetAndPerson).HasForeignKey(x => x.GhostNetId);
        });

        builder.Entity<Person>(b =>
        {
            b.ToTable(GhostNetFishingConsts.DbTablePrefix + nameof(Person), GhostNetFishingConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne(x => x.PersonType).WithMany(x => x.Persons).HasForeignKey(x => x.PersonTypeId);
            b.HasMany(x => x.GhostNetAndPerson).WithOne(x => x.Person).HasForeignKey(x => x.PersonId);
        });

        builder.Entity<PersonType>(b =>
        {
            b.ToTable(GhostNetFishingConsts.DbTablePrefix + nameof(PersonType), GhostNetFishingConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasMany(x => x.Persons).WithOne(x => x.PersonType).HasForeignKey(x => x.PersonTypeId);
        });
    }
}
