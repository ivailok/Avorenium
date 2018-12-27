using System;
using System.Collections.Generic;

namespace Avorenium.Core.Domain.Entities.Constants
{
    public static class ErrorConstants
    {
        public static string ApplicationStatusToHttpStatusCodeMappingError => "Invalid application status to http status code mapping.";


        public static string ApplicationStatusToResultDataMappingError => "Invalid application status to result data mapping.";

        public static string ApplicationValidationMappingError => "Invalid validation error mapping.";

        public static Dictionary<Enum, string> Errors
        {
            get
            {
                return new Dictionary<Enum, string>()
                {
                };
            }
        }
    }
}