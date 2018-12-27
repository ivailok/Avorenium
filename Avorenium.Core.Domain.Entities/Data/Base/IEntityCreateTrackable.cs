using System;

namespace Avorenium.Core.Domain.Entities.Data.Base
{
    public interface IEntityCreateTrackable
    {
        DateTime CreatedOn { get; set; }

        string CreatedBy { get; set; }
    }
}