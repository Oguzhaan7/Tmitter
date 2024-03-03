using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tmitter.Application.Common.Authentication;
using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Infrastructure.Authentication;
using Tmitter.Infrastructure.Persistance;
using Tmitter.Infrastructure.Persistance.Repositories;

namespace Tmitter.Infrastructure;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistance(configuration);

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IAuthentication, Authentication.Authentication>();

        services
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                ClockSkew = TimeSpan.Zero
            });
        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<TmitterDbContext>(options =>
                options.UseNpgsql(configuration.GetSection("AppDatabase").Value));

        var tmitterContext = services.BuildServiceProvider().GetService<TmitterDbContext>();

        if (tmitterContext.Database.GetPendingMigrations().Any())
            tmitterContext.Database.Migrate();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // services.AddScoped<IUserRepository, UserRepository>();
        // services.AddScoped<IPostRepository, PostRepository>();
        // services.AddScoped<INotificationRepository, NotificationRepository>();
        // services.AddScoped<IMessageRepository, MessageRepository>();
        // services.AddScoped<ILikeRepository, LikeRepository>();
        // services.AddScoped<IHashtagRepository, HashtagRepository>();
        // services.AddScoped<ICommentRepository, CommentRepository>();

        return services;
    }
}