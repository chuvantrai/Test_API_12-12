using Project.Application.Responses;

namespace Project.Application.Responses
{
    public class TestAPIResponse
    {
        public TestAPIResponse()
        {
            
        }
        
        public TestAPIResponse(int status, bool success, params string[] errors)
        {
            Status = status;
            Success = success;
            Errors = errors?.Length > 0 ? errors : null;
        }

        public bool Success { get; set; }
        public int Status { get; set; }
        public string[]? Errors { get; set; }
    }
}

public class TestAPIResponse<T> : TestAPIResponse
{
    public T? Data { get; set; }
}