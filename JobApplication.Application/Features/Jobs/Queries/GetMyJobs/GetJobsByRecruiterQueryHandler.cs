using JobApplication.Application.DTOs;
using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using MediatR;

namespace JobApplication.Application.Features.Jobs.Queries.GetMyJobs
{
    public class GetJobsByRecruiterQueryHandler : IRequestHandler<GetJobsByRecruiterQuery, IEnumerable<JobDto>>
    {
        private readonly IRepository<Job> _jobRepository;

        public GetJobsByRecruiterQueryHandler(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Task<IEnumerable<JobDto>> Handle(GetJobsByRecruiterQuery request, CancellationToken cancellationToken)
        {
            var jobs = _jobRepository.Get()
                .Where(j => j.RecruiterId == request.RecruiterId)
                .OrderByDescending(j => j.Id)
                .ToList()
                .Select(ToDto);

            return Task.FromResult(jobs);
        }

        private static JobDto ToDto(Job job) => new()
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            Status = job.Status.ToString(),
            ClosedAt = job.ClosedAt
        };
    }
}
