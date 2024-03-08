using MapsterMapper;
using MediatR;
using Tmitter.Application.Common.Authentication;
using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Application.Common.Utils;
using Tmitter.Domain;

namespace Tmitter.Application.Users.Commands.CreateUser;

public record CreateUserCommand(CreateUserRequest UserRequest) : IRequest<Result>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IAuthentication _authentication;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthentication authentication)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _authentication = authentication;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var isExists = await _userRepository
            .GetAsync(user =>
                user.Username.Equals(request.UserRequest.Username) || user.Email.Equals(request.UserRequest.Email));

        if (isExists is not null)
            return Result.Failure(400, "Username or email already exists");

        var user = _mapper.Map<User>(request.UserRequest);

        user.ProfilePicture = "default.png";
        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        user.Password = _authentication.HashPassword(request.UserRequest.Password);

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return Result.Success(201, "User registered successfully");
    }
}