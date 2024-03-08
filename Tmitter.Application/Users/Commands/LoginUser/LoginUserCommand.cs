using MapsterMapper;
using MediatR;
using Tmitter.Application.Common.Authentication;
using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Application.Common.Utils;
using Tmitter.Application.Users.Common;

namespace Tmitter.Application.Users.Commands.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<Result<UserResponse>>;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<UserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IAuthentication _authentication;

    public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthentication authentication)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _authentication = authentication;
    }

    public async Task<Result<UserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        string hashedPassword = _authentication.HashPassword(request.Password);

        var user = await _userRepository
            .GetAsync(user => user.Email.Equals(request.Email)
                              && user.Password.Equals(hashedPassword));

        if (user is null)
            return Result<UserResponse>.Failure(404, "Email or password is incorrect");

        var mappedUser = _mapper.Map<UserResponse>(user);
        mappedUser.Token = _authentication.GenerateToken(user);

        return Result<UserResponse>.Success(mappedUser, 200, "");
    }
}