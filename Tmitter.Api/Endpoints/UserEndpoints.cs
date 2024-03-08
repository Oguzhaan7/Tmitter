using Carter;
using MediatR;
using Tmitter.Application.Common.Utils;
using Tmitter.Application.Users.Commands.CreateUser;
using Tmitter.Application.Users.Commands.LoginUser;

namespace Tmitter.Api.Endpoints;

public class UserEndpoints : CarterModule
{
    public UserEndpoints() : base("/users")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/create", async (CreateUserRequest request, ISender sender) =>
        {
            var result = await sender.Send(new CreateUserCommand(request));

            if (result.Succeeded)
                return Results.Ok(result);

            return Results.BadRequest(result);
        });

        app.MapPost("/login", async (LoginUserCommand user, ISender sender) =>
        {
            var result = await sender.Send(user);

            if (result.Succeeded)
                return Results.Ok(result);

            return Results.NotFound(result);
        });
    }
}