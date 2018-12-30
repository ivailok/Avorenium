using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avorenium.Core.Domain.Entities.Dto;
using Avorenium.Core.Domain.Interfaces;

namespace Avorenium.Core.Domain.Services
{
    public class TermsDomainService : ITermsDomainService
    {
        public List<string> GetFilteredTerms(string text, List<string> separators, List<string> filterTerms)
        {
            var splittedTerms = text.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var filteredTerms = splittedTerms.Except(filterTerms);

            return filteredTerms.ToList();
        }
    }
}