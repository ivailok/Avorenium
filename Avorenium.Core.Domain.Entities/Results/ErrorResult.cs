using System;
using System.Collections.Generic;
using System.Linq;
using Avorenium.Core.Domain.Entities.Enums;

namespace Avorenium.Core.Domain.Entities.Results
{
    public class ErrorResult<TError> : IResult<TError>
    {
        public ErrorResult(StatusEnum status, TError error)
        {
            Status = status;
            Errors = new List<TError> { error };
        }

        public ErrorResult(StatusEnum status, IEnumerable<TError> errors)
        {
            Status = status;
            Errors = new List<TError>(errors);
        }

        public ErrorResult(IResult<TError> errorResult)
        {
            Status = errorResult.Status;
            Errors = errorResult.Errors;
        }

        public StatusEnum Status { get; private set; }

        public IEnumerable<TError> Errors { get; private set; }
    }

    public class ErrorResult<TData, TError> : ErrorResult<TError>, IResult<TData, TError>
        where TData : class
    {
        public ErrorResult(StatusEnum status, TError error)
            : base(status, error)
        {
        }

        public ErrorResult(StatusEnum status, IEnumerable<TError> errors)
            : base(status, errors)
        {
        }

        public ErrorResult(IResult<TData, TError> errorResult)
            : base(errorResult)
        {
        }

        public TData Data => null;
    }
}