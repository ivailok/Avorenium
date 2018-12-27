using System;
using System.Collections.Generic;
using System.Linq;
using Avorenium.Core.Domain.Entities.Enums;

namespace Avorenium.Core.Domain.Entities.Results
{
    public class ValidationResult<TError> : IApplicationResult<TError>
    {
        public ValidationResult(StatusEnum status, TError error)
        {
            Status = status;
            ValidationErrors = new List<TError> { error };
        }

        public ValidationResult(StatusEnum status, IEnumerable<TError> errors)
        {
            Status = status;
            ValidationErrors = new List<TError>(errors);
        }

        public ValidationResult(IApplicationResult<TError> errorResult)
        {
            Status = errorResult.Status;
            ValidationErrors = errorResult.ValidationErrors;
        }

        public StatusEnum Status { get; private set; }

        public IEnumerable<TError> ValidationErrors { get; private set; }
    }

    public class ErrorResult<TData, TError> : ValidationResult<TError>, IApplicationResult<TData, TError>
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

        public ErrorResult(IApplicationResult<TData, TError> errorResult)
            : base(errorResult)
        {
        }

        public TData Data => null;
    }
}