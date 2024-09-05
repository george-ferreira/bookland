using Microsoft.EntityFrameworkCore;

namespace bookland.Extensions
{
    public static class MigrationsExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app) 
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using LivroContext context = scope.ServiceProvider.GetRequiredService<LivroContext>();

            context.Database.Migrate();
        }
    }
}
