using System;

namespace Avorenium.Core.Domain.Entities.Data.Base
{
    public interface IEntityEditTrackable
    {
        DateTime? ModifiedOn { get; set; }

        string ModifiedBy { get; set; }
    }
}