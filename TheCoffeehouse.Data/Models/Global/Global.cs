using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheCoffeehouse.Data.Models.Domains;
using TheCoffeehouse.Data.Models.Repositories;
using TheCoffeehouse.Data.Models.Uow;

namespace TheCoffeehouse.Data.Models.Global
{
    public class Global
    {
        public static void ConfigureIoC(IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<DbContext, TheCoffeeHouseContext>()
                .AddScoped<IAppUsersRepository, AppUsersRepository>()
                .AddScoped<IProductsRepository, ProductsRepository>()
                .AddScoped<IPostsRepository, PostsRepository>()
                .AddScoped<AppUsersDomains>()
                .AddScoped<PostsDomains>()
                .AddScoped<ProductsDomains>();
        }
    }
}
