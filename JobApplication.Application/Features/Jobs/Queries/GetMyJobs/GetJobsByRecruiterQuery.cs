using JobApplication.Application.DTOs;
using MediatR;

namespace JobApplication.Application.Features.Jobs.Queries.GetMyJobs
{
    public class GetJobsByRecruiterQuery : IRequest<IEnumerable<JobDto>>
    {
        public string RecruiterId { get; }

        public GetJobsByRecruiterQuery(string recruiterId)
        {
            RecruiterId = recruiterId;
        }
    }
}
