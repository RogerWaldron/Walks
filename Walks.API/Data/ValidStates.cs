using System;
namespace Walks.API.Data
{
	public enum ValidStates
	{
        NotFound = 0,
        Duplicate = 1,
        Repository = 2,
        SoftDeleted = 3,
        HardDeleted = 4,
        Created = 5,
        Updated = 6,
        OK = 7,
        Error = 8,
        Exists = 9,
    }
}

