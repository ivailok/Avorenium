using System.Collections.Generic;
using Avorenium.Core.Domain.Entities.Enums;

namespace Avorenium.Core.Domain.Entities.Results
{
    public class ApplicationResult : IApplicationResult
    {
        public ApplicationResult(StatusEnum status)
        {
            Status = status;
        }

        public StatusEnum Status { get; private set; }
    }

    public class ApplicationResult<TError> : ApplicationResult, IApplicationResult<TError>
    {
        public ApplicationResult(StatusEnum status)
            : base(status)
        {
        }

        public IEnumerable<TError> ValidationErrors => new List<TError>();
    }

    public class ApplicationResult<TData, TError> : ApplicationResult<TError>, IApplicationResult<TData, TError>
        where TData : class
    {
        public ApplicationResult(StatusEnum status)
            : base(status)
        {
        }

        public TData Data => null;
    }
}