using System.Collections.Generic;
using Avorenium.Core.Domain.Entities.Enums;

namespace Avorenium.Core.Domain.Entities.Results
{
    public interface IApplicationResult
    {
        StatusEnum Status { get; }
    }

    public interface IApplicationResult<TError> : IApplicationResult
    {
        IEnumerable<TError> ValidationErrors { get; }
    }

    public interface IApplicationResult<TData, TError> : IApplicationResult<TError>
        where TData : class
    {   
        TData Data { get; }
    }
}