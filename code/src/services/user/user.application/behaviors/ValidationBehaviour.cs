using FluentValidation;
using MediatR;
using ValidationException = user.application.exceptions.ValidationException;

namespace user.application.behaviors
{
    public class ValidationBehaviour<TRequest,TRespons> : IPipelineBehavior<TRequest, TRespons> where TRequest : IRequest<TRespons>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TRespons> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TRespons> next)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(validators
                    .Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationResult
                    .SelectMany(r=>r.Errors)
                    .Where(x=>x!=null)
                    .ToList();

               if (failures.Any())
               {
                    throw new ValidationException(failures);
               }

            }

            return await next();
        }
    }
}
