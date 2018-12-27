using Avorenium.Core.Domain.Entities.Enums;

namespace Avorenium.Core.Domain.Entities.Results
{
    public class Result : IResult
    {
        public Result(StatusEnum status)
        {
            Status = status;
        }

        public StatusEnum Status { get; private set; }
    }
}