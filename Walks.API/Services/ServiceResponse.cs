using Walks.API.Data;

namespace Walks.API.Services
{
	public class ServiceResponse<T>
	{
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public ValidStates? State { get; set; } = null;
        public string? Error { get; set; } = null;
        public List<string>? ErrorMessages { get; set; } = null;
    }
}

