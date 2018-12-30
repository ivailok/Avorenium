namespace Avorenium.Core.Domain.Entities.Dto.Word
{
    public class WordCreateDto
    {
        public string Text { get; set; }

        public string Type { get; set; }

        public int? TypeId { get; set; }
    }
}