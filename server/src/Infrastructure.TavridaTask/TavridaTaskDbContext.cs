using Core.TavridaTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.TavridaTask;

public class TavridaTaskDbContext : DbContext
{
    public TavridaTaskDbContext(DbContextOptions<TavridaTaskDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyBranch> CompanyBranches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(builder =>
            {
                builder.Property(company => company.Id).UseIdentityColumn();
                builder.Property(company => company.Name).IsRequired();

                modelBuilder.Entity<Company>()
                    .HasMany(e => e.CompanyBranches)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.CompanyId)
                    .HasPrincipalKey(e => e.Id);
            }
        );

        modelBuilder.Entity<CompanyBranch>(builder =>
        {
            builder.Property(branch => branch.Id).UseIdentityColumn();
            builder.Property(branch => branch.Name).IsRequired();
        });
    }
}