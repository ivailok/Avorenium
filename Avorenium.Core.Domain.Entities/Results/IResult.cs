using System.Collections.Generic;
using Avorenium.Core.Domain.Entities.Enums;

namespace Avorenium.Core.Domain.Entities.Results
{
    public interface IResult
    {
        StatusEnum Status { get; }
    }

    public interface IResult<TError> : IResult
    {
        IEnumerable<TError> Errors { get; }
    }

    public interface IResult<TData, TError> : IResult<TError>
        where TData : class
    {   
        TData Data { get; }
    }
}