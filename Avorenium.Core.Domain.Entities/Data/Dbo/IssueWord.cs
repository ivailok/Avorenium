using System;
using Avorenium.Core.Domain.Entities.Data.Base;

namespace Avorenium.Core.Domain.Entities.Data.Dbo
{
    public class IssueWord : IEntityCreateTrackable, IEntityEditTrackable
    {
        public int IssueId { get; set; }

        public int WordId { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        #region Navigation properties
        
        public Issue Issue { get; set; }

        public Word Word { get; set; }

        #endregion
    }
}