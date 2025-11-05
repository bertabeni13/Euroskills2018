using Microsoft.EntityFrameworkCore;

namespace Euroskills2018.Razor.Data;

public static class SqlSeeder
{
    public static async Task SeedAsync(EuroskillsContext ctx)
    {
        // Ha már van adat, kilépünk
        if (await ctx.Versenyzok.AsNoTracking().AnyAsync())
            return;

        // Az adatok.sql tartalmának futtatása (bin mappából olvassa)
        var contentRoot = AppContext.BaseDirectory;
        var adatokPath = Path.Combine(contentRoot, "Data", "sql", "adatok.sql");
        if (!File.Exists(adatokPath))
            return;

        var sql = await File.ReadAllTextAsync(adatokPath);
        await ctx.Database.ExecuteSqlRawAsync(sql);
    }
}

