using System;
using System.Collections.Generic;
using Avorenium.Core.Domain.Entities.Enums;

namespace Avorenium.Core.Domain.Entities.Results
{
    public class SuccessResult<TError> : IResult<TError>
    {
        public SuccessResult(StatusEnum status)
        {
            Status = status;
        }

        public StatusEnum Status { get; private set; }

        public IEnumerable<TError> Errors => new List<TError>();
    }

    public class SuccessResult<TData, TError> : SuccessResult<TError>, IResult<TData, TError>
        where TData : class
    {
        public SuccessResult(StatusEnum status, TData data)
            : base(status)
        {
            Data = data;
        }
        
        public TData Data { get; private set; }
    }
}