// using Microsoft.EntityFrameworkCore;
// using primetechmvc.DbContexts;

// public static class DBStartup
// {
//     public static void DbDevelopment(this IServiceCollection services, IConfiguration Configuration)
//     {
//         var data = Configuration.GetConnectionString("Development");
//         services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Development")), ServiceLifetime.Transient);
//     }
// }
