using JobApplication.Application.DTOs;
using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using JobApplication.Domain.Enums;
using MediatR;

namespace JobApplication.Application.Features.Jobs.Queries.GetOpenJobs
{
    public class GetOpenJobsQueryHandler : IRequestHandler<GetOpenJobsQuery, IEnumerable<JobDto>>
    {
        private readonly IRepository<Job> _jobRepository;

        public GetOpenJobsQueryHandler(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Task<IEnumerable<JobDto>> Handle(GetOpenJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = _jobRepository.Get()
                .Where(j => j.Status == JobStatus.Open)
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
