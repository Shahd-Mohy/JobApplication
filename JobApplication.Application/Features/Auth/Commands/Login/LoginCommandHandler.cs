using JobApplication.Application.Common;
using JobApplication.Application.DTOs.Auth;
using JobApplication.Application.Interfaces;
using MediatR;

namespace JobApplication.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(IIdentityService identityService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _identityService = identityService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var checkedUser = await _identityService.CheckCredentialsAsync(
                request.LoginDto.Email, request.LoginDto.Password);

            if (!checkedUser.Succeeded)
                return Result<AuthResponseDto>.Failure(checkedUser.Errors);

            return Result<AuthResponseDto>.Success(BuildResponse(checkedUser.Value!));
        }

        private AuthResponseDto BuildResponse(AuthUserDto user)
        {
            var (token, expiresAtUtc) = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                ExpiresAtUtc = expiresAtUtc,
                User = user
            };
        }
    }
}
