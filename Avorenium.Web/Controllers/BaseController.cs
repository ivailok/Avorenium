using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Avorenium.Core.Domain.Entities.Results;
using Avorenium.Core.Domain.Entities.Constants;
using Avorenium.Core.Domain.Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Avorenium.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult HandleResult(IApplicationResult result)
        {
            switch (result.Status)
            {
                case StatusEnum.EntityUpdated:
                case StatusEnum.EntityDeleted:
                {
                    return NoContent();
                }
                case StatusEnum.InvalidRequest:
                {
                    return ValidationProblem(new ValidationProblemDetails(ModelState));
                }
                case StatusEnum.PermissionsAreRequired:
                {
                    return Forbid();
                }
                case StatusEnum.EntityNotFound:
                {
                    return NotFound();
                }
                case StatusEnum.DuplicatedEntityFound:
                {
                    return Conflict();
                }
                default:
                {
                    return HandleGeneralMappingError(ErrorConstants.ApplicationStatusToHttpStatusCodeMappingError);
                }
            }
        }

        protected IActionResult HandleResult<TError>(IApplicationResult<TError> result)
        {
            switch (result.Status)
            {
                case StatusEnum.EntityUpdated:
                case StatusEnum.EntityDeleted:
                {
                    return NoContent();
                }
                case StatusEnum.InvalidRequest:
                {
                    return ValidationProblem(new ValidationProblemDetails(ModelState));
                }
                case StatusEnum.PermissionsAreRequired:
                {
                    return Forbid();
                }
                case StatusEnum.EntityNotFound:
                {
                    return NotFound();
                }
                case StatusEnum.DuplicatedEntityFound:
                {
                    return Conflict();
                }
                case StatusEnum.ValidationFailed:
                {
                    var errors = result.ValidationErrors.Select(x => GetError((Enum)(object)x));

                    if (!errors.Any())
                    {
                        return HandleGeneralMappingError(ErrorConstants.ApplicationStatusToHttpStatusCodeMappingError);
                    }

                    return UnprocessableEntity(errors);
                }
                default:
                {
                    return HandleGeneralMappingError(ErrorConstants.ApplicationStatusToHttpStatusCodeMappingError);
                }
            }
        }

        protected IActionResult HandleResult<TData, TError>(IApplicationResult<TData, TError> result)
            where TData : class
        {
            switch (result.Status)
            {
                case StatusEnum.EntityRetrieved:
                {
                    if (result.Data == null)
                    {
                        return HandleGeneralMappingError(ErrorConstants.ApplicationStatusToResultDataMappingError);
                    }

                    return Ok(result.Data);
                }
                case StatusEnum.EntityCreated:
                {
                    if (result.Data == null)
                    {
                        return HandleGeneralMappingError(ErrorConstants.ApplicationStatusToResultDataMappingError);
                    }

                    return Created(string.Empty, result.Data);
                }
                case StatusEnum.EntityUpdated:
                case StatusEnum.EntityDeleted:
                {
                    return NoContent();
                }
                case StatusEnum.InvalidRequest:
                {
                    return ValidationProblem(new ValidationProblemDetails(ModelState));
                }
                case StatusEnum.PermissionsAreRequired:
                {
                    return Forbid();
                }
                case StatusEnum.EntityNotFound:
                {
                    return NotFound();
                }
                case StatusEnum.DuplicatedEntityFound:
                {
                    return Conflict();
                }
                case StatusEnum.ValidationFailed:
                {
                    var errors = result.ValidationErrors.Select(x => GetError((Enum)(object)x));

                    if (!errors.Any())
                    {
                        return HandleGeneralMappingError(ErrorConstants.ApplicationStatusToHttpStatusCodeMappingError);
                    }

                    return UnprocessableEntity(errors);
                }
                default:
                {
                    return HandleGeneralMappingError(ErrorConstants.ApplicationStatusToHttpStatusCodeMappingError);
                }
            }
        }
        
        private IActionResult HandleGeneralMappingError(string error)
        {
            return ValidationProblem(
                new ValidationProblemDetails(
                    new Dictionary<string, string[]>
                    {
                        [nameof(HandleResult)] = new string [] { error }
                    }));
        }

        private string GetError(Enum error)
        {
            var errorMessage = string.Empty;

            if (!ErrorConstants.Errors.TryGetValue(error, out errorMessage))
            {
                errorMessage = ErrorConstants.ApplicationValidationMappingError;
            }            

            return errorMessage;
        }
    }
}