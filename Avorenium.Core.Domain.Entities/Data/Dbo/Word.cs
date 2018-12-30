using System;
using Avorenium.Core.Domain.Entities.Data.Base;
using Avorenium.Core.Domain.Entities.Enums;

namespace Avorenium.Core.Domain.Entities.Data.Dbo
{
    public class Word : IEntity<int>, IEntityCreateTrackable, IEntityEditTrackable
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int TypeId { get;set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        #region Navigation properties

        public WordType Type { get;set; }

        #endregion
    }
}