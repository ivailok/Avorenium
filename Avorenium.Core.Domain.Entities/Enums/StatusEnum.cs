namespace Avorenium.Core.Domain.Entities.Enums
{
    public enum StatusEnum
    {
        Default = 0,
        
        EntityRetrieved = 1,
        
        EntityCreated = 2,
        
        EntityUpdated = 3,
        
        EntityDeleted = 4,

        InvalidRequest = 5,

        PermissionsAreRequired = 6,

        EntityNotFound = 7,

        DuplicatedEntityFound = 8,
        
        ValidationFailed = 9
    }
}