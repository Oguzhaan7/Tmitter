namespace Tmitter.Application.Common.Exceptions;

public class ValidationException : TmitterException
{
    public ValidationException(List<string> errors) : base("Validation Failure",
        "One or more validation errors occured")
    {
        Errors = errors;
    }

    public List<string> Errors { get; set; }
}