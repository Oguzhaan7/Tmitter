using MapsterMapper;
using MediatR;
using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Application.Common.Utils;
using Tmitter.Domain;

namespace Tmitter.Application.Users.Commands.CreateUser;

public record CreateUserCommand(CreateUserRequest UserRequest) : IRequest<Result>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var isExists = await _userRepository
            .GetAsync(user =>
                user.Username.Equals(request.UserRequest.Username) || user.Email.Equals(request.UserRequest.Email));

        if (isExists is not null)
            return Result.Failure(400, "Username or email already exists");

        var user = _mapper.Map<User>(request.UserRequest);

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return Result.Success(201, "User registered successfully");
    }
}