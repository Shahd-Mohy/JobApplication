using JobApplication.Application.DTOs;
using JobApplication.Application.Interfaces;
using JobApplication.Domain.Entities;
using MediatR;

namespace JobApplication.Application.Features.Applications.Queries.GetMyApplications
{
    public class GetMyApplicationsQueryHandler : IRequestHandler<GetMyApplicationsQuery, IEnumerable<JobApplicationDto>>
    {
        private readonly IRepository<JobCandidateApplication> _jobApplicationRepository;

        public GetMyApplicationsQueryHandler(IRepository<JobCandidateApplication> jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }

        public Task<IEnumerable<JobApplicationDto>> Handle(GetMyApplicationsQuery request, CancellationToken cancellationToken)
        {
            var applications = _jobApplicationRepository.Get()
                .Where(a => a.Candidate.UserId == request.UserId)
                .OrderByDescending(a => a.AppliedAt)
                .Select(ToDto)
                .ToList()
                .AsEnumerable();

            return Task.FromResult(applications);
        }

        private static readonly System.Linq.Expressions.Expression<Func<JobCandidateApplication, JobApplicationDto>> ToDto = a => new JobApplicationDto
        {
            Id = a.Id,
            JobId = a.JobId,
            JobTitle = a.Job.Title,
            CandidateId = a.CandidateId,
            CandidateName = a.Candidate.Name,
            Status = a.JobApplicationStatus.ToString(),
            AppliedAt = a.AppliedAt,
            StatusUpdatedAt = a.StatusUpdatedAt,
            CancelledAt = a.CancelledAt,
            CvUrl = a.CvUrl
        };
    }
}
