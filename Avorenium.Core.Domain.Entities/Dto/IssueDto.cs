using System;
using System.Collections.Generic;
using Avorenium.Core.Domain.Entities.Dto.Word;

namespace Avorenium.Core.Domain.Entities.Dto
{
    public class IssueDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } 

        public DateTime CreatedOn { get; set; }

        public List<WordDto> Words { get; set; }
    }
}