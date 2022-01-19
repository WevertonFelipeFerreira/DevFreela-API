﻿using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.API.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
