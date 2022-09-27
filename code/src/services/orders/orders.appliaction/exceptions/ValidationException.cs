using FluentValidation.Results;

namespace orders.appliaction.exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; private set; }
        public ValidationException():base("One or more validation failures have occured.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(x=>x.PropertyName, e=>e.ErrorMessage)
                .ToDictionary(failureGroup=>failureGroup.Key, failureGroup=>failureGroup.ToArray());
        }

    }
}
