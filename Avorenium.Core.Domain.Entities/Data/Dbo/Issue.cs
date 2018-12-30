using System;
using System.Collections.Generic;
using Avorenium.Core.Domain.Entities.Data.Base;

namespace Avorenium.Core.Domain.Entities.Data.Dbo
{
    public class Issue : IEntity<int>, IEntityCreateTrackable, IEntityEditTrackable
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        
        public string ModifiedBy { get; set; }

        #region Navigation properties

        public ICollection<IssueWord> Words { get; set; }

        #endregion
    }
}