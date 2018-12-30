using System;

namespace Avorenium.Core.Domain.Entities.Dto.Word
{
    public class WordDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get;set; }
    }
}