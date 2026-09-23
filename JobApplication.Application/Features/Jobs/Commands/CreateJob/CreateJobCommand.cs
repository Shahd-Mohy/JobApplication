using JobApplication.Application.DTOs;
using MediatR;

namespace JobApplication.Application.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommand : IRequest<int>
    {
        public CreateJobDto CreateJobDto { get; }
        public string RecruiterId { get; }

        public CreateJobCommand(CreateJobDto createJobDto, string recruiterId)
        {
            CreateJobDto = createJobDto;
            RecruiterId = recruiterId;
        }
    }
}
