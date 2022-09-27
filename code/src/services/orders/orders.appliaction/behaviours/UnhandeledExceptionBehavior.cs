using MediatR;
using Microsoft.Extensions.Logging;

namespace orders.appliaction.behaviours
{
    public class UnhandeledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> logger;

        public UnhandeledExceptionBehavior(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName= typeof(TRequest).Name;

                logger.LogError(ex, "Application request: Unhandeled exception has happened for request {Name} {@Request}", requestName, request);

                throw;
            }
        }
    }
}
