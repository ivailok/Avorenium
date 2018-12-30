using System;
using Avorenium.Core.Domain.Entities.Data.Base;

namespace Avorenium.Core.Domain.Entities.Data.Dbo
{
    public class WordType : IEntity<int>, IEntityCreateTrackable, IEntityEditTrackable
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}