using MediatR;

namespace Project.Application.Responses
{
    public interface ITestAPIRequest : IRequest<TestAPIResponse>
    {
        
    }
    
    public interface ITestAPIRequest<TResponse> : IRequest<TestAPIResponse<TResponse>>
    {
        
    }
}