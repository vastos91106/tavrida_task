using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.TavridaTask;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TavridaTaskDbContext>
{
    public TavridaTaskDbContext CreateDbContext(string[] args)
    {
        var connectionOption = TryGetConnectionString(args);

        if (string.IsNullOrEmpty(connectionOption))
        {
            throw new ArgumentException("connection string is not defined to pass DesignTimeDbContextFactory");
        }
        
        var builder = new DbContextOptionsBuilder<TavridaTaskDbContext>();

        builder.UseSqlServer(connectionOption);

        return new TavridaTaskDbContext(builder.Options);
    }

    private string? TryGetConnectionString(string[] args)
    {
        if (args == null)
        {
            return null;
        }

        if (args.Length == 0)
        {
            return null;
        }

        if (string.IsNullOrEmpty(args[0]))
        {
            return null;
        }

        return args[0];
    }
}