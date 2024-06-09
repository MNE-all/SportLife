using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SportLife.Context;

namespace SportLife.Services.Tests;

public static class DbConnection
{
    private static SportLifeContext Context { get; set; }
    public static SportLifeContext Get() => Context;
    static DbConnection()
    {
        var options = new DbContextOptionsBuilder<SportLifeContext>().UseSqlite("Data Source=SportLifeTests.db").Options;
        Context = new SportLifeContext(options);

    }
}