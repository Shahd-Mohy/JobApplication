using JobApplication.Application.Common;
using MediatR;

namespace JobApplication.Application.Features.Applications.Commands.Apply
{
    public class ApplyCommand : IRequest<Result<int>>
    {
        public string UserId { get; }
        public int JobId { get; }
        public Stream Cv { get; }
        public string CvExtension { get; }

        public ApplyCommand(string userId, int jobId, Stream cv, string cvExtension)
        {
            UserId = userId;
            JobId = jobId;
            Cv = cv;
            CvExtension = cvExtension;
        }
    }
}
