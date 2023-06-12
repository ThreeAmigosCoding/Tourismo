using System;


namespace Tourismo.Core.Utility
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        DateTime CreatedAt { get; set; }

        bool IsActive { get; set; }
    }
}
