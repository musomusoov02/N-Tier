using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.DataAccess.Persistence;

public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<DatabaseContext>();

        if (context.Database.IsNpgsql()) await context.Database.MigrateAsync();
    }
}

