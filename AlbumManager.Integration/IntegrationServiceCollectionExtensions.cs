using AlbumManager.Domain.Contracts.Integration;
using AlbumManager.Domain.Contracts.Integration.Utils;
using AlbumManager.Integration.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumManager.Integration
{
    public static class IntegrationServiceCollectionExtensions
    {
        public static IServiceCollection AddIntegrationRepositories(this IServiceCollection services, string ApiBaseURL)
        {
            services.AddSingleton<IHttpClientWrapper>(new HttpClientWrapper(ApiBaseURL));
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            return services;
        }
    }
}
