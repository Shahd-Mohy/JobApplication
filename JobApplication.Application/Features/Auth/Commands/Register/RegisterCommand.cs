using JobApplication.Application.Common;
using JobApplication.Application.DTOs.Auth;
using MediatR;

namespace JobApplication.Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<Result<AuthResponseDto>>
    {
        public RegisterDto RegisterDto { get; }

        public RegisterCommand(RegisterDto registerDto)
        {
            RegisterDto = registerDto;
        }
    }
}
