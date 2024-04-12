using CsharpKTApi.Mappers;
using CsharpKTApi.Settings;

namespace CsharpKTApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDevelopmentTeam(this IServiceCollection services, IConfiguration configuration)
        {
            // Example on how to "see" what each section contains, helpful for debug!
            //var teamSettingsSection = builder.Configuration.GetSection("TeamTypology");
            //var teamSettingsSection2 = builder.Configuration.GetSection("TeamTypology:Default");

            //Example on how to setup configuration "manually" or how to have configuration available during services setup
            //var teamSettings = new TeamTypologySettings();
            //builder.Configuration.Bind("TeamTypology", teamSettings);
            //builder.Services.AddSingleton(teamSettings);

            // Example on how to setup configuration using the IOptions/IOptionsSnapshot interface
            // You can read more about it here - https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0
            services.Configure<TeamTypologySettings>(configuration.GetSection("TeamTypology"));
            services.AddScoped<IDeveloperMapper, DeveloperMapper>();

            return services;
        }

        public static IServiceCollection AddKtApiVersioning(this IServiceCollection services)
        {
            services
                .AddApiVersioning(options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                })
                .AddMvc()
                .AddApiExplorer(options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            return services;
        }

    }
}
