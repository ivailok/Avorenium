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
        public List<string> SplitTerms(string text)
        {
            var separators = new char[] { ' ', ',', '?', '.', '!', ';', '`', '\'', '\"', ':', ']', '[' };
            var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return words.ToList();
        }

        public List<string> FilterMeaninglessWords(List<string> words)
        {
            var meaninglessWords = new string[] { "of", "in", "on", "of", "a", "at", "from", "to" };
            var filteredWords = words.Except(meaninglessWords);

            return filteredWords.ToList();
        }

        // public Dictionary<string, List<string>> GetSynonyms(List<string> words)
        // {
            
        // }
    }
}