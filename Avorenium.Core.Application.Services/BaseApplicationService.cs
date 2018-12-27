using Avorenium.Core.Domain.Entities.Enums;
using Avorenium.Core.Domain.Entities.Results;

namespace Avorenium.Core.Application.Services
{
    public class BaseApplicationService
    {
        protected bool IsInvalidRequest<TRequest, TData, TError>(TRequest request, out IApplicationResult<TData, TError> result)
            where TRequest : class
            where TData : class
        {
            result = null;

            if (request == null)
            {
                result = new ApplicationResult<TData, TError>(StatusEnum.InvalidRequest);
            }

            return request == null;
        }


        protected bool IsInvalidRequest<TRequest, TError>(TRequest request, out IApplicationResult<TError> result)
            where TRequest : class
        {
            result = null;

            if (request == null)
            {
                result = new ApplicationResult<TError>(StatusEnum.InvalidRequest);
            }

            return request == null;
        }

        protected bool IsInvalidRequest<TRequest>(TRequest request, out IApplicationResult result)
            where TRequest : class
        {
            result = null;

            if (request == null)
            {
                result = new ApplicationResult(StatusEnum.InvalidRequest);
            }

            return request == null;
        }
    }
}