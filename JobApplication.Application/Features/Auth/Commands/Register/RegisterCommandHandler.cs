using JobApplication.Application.Common;
using JobApplication.Application.DTOs.Auth;
using JobApplication.Application.Interfaces;
using MediatR;

namespace JobApplication.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthResponseDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IIdentityService identityService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _identityService = identityService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<AuthResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var dto = request.RegisterDto;

            var created = await _identityService.CreateUserAsync(
                dto.FullName, dto.Email, dto.Password, dto.Role);

            if (!created.Succeeded)
                return Result<AuthResponseDto>.Failure(created.Errors);

            return Result<AuthResponseDto>.Success(BuildResponse(created.Value!));
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
