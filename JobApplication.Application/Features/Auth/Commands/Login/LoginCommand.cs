using JobApplication.Application.Common;
using JobApplication.Application.DTOs.Auth;
using MediatR;

namespace JobApplication.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<Result<AuthResponseDto>>
    {
        public LoginDto LoginDto { get; }

        public LoginCommand(LoginDto loginDto)
        {
            LoginDto = loginDto;
        }
    }
}
