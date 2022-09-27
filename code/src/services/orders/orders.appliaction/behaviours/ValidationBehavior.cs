using FluentValidation;
using MediatR;
using ValidationException = orders.appliaction.exceptions.ValidationException;

namespace orders.appliaction.behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                
                var validationResult = await Task.WhenAll(validators
                    .Select(validator => validator.ValidateAsync(context,cancellationToken)));

                var failures = validationResult
                    .SelectMany(r=> r.Errors)
                    .Where(f=>f!=null)
                    .ToList();

                if (failures.Count>0)
                {
                    throw new ValidationException(failures);
                }

            }

            return await next();
        }
    }
}
