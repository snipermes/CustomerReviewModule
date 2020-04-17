using System;
using System.Linq;
using CustomerReviewModule.Core;
using CustomerReviewModule.Core.Services;
using CustomerReviewModule.Data.Repositories;
using CustomerReviewModule.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Core.Settings;


namespace CustomerReviewModule.Web
{
    public class Module : IModule
    {
        public ManifestModuleInfo ModuleInfo { get; set; }

        public void Initialize(IServiceCollection serviceCollection)
        {
            // database initialization
            var configuration = serviceCollection.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("VirtoCommerce.CustomerReviewModule") ?? configuration.GetConnectionString("VirtoCommerce");
            serviceCollection.AddDbContext<CustomerReviewModuleDbContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddSingleton<Func<ICustomerReviewRepository>>(provider => () => provider.CreateScope().ServiceProvider.GetRequiredService<ICustomerReviewRepository>());
            serviceCollection.AddTransient<ICustomerReviewRepository, CustomerReviewRepository>();
            serviceCollection.AddTransient<ICustomerReviewSearchService, CustomerReviewSearchService>();
            serviceCollection.AddTransient<ICustomerReviewService, CustomerReviewService>();

        }

        public void PostInitialize(IApplicationBuilder appBuilder)
        {
            // register settings
            var settingsRegistrar = appBuilder.ApplicationServices.GetRequiredService<ISettingsRegistrar>();
            settingsRegistrar.RegisterSettings(ModuleConstants.Settings.AllSettings, ModuleInfo.Id);

            // register permissions
            var permissionsProvider = appBuilder.ApplicationServices.GetRequiredService<IPermissionsRegistrar>();
            permissionsProvider.RegisterPermissions(ModuleConstants.Security.Permissions.AllPermissions.Select(x =>
                new Permission()
                {
                    GroupName = "CustomerReviewModule",
                    ModuleId = ModuleInfo.Id,
                    Name = x
                }).ToArray());


            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<CustomerReviewModuleDbContext>();
                //dbContext.Database.MigrateIfNotApplied(MigrationName.GetUpdateV2MigrationNameByOwnerName(ModuleInfo.Id, ""));
                dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();

            }
        }

        public void Uninstall()
        {
            // do nothing in here
        }

    }

}
