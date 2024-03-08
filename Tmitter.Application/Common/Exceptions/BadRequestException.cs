namespace Tmitter.Application.Common.Exceptions;

public abstract class BadRequestException : TmitterException
{
    protected BadRequestException(string message) : base("Bad Request", message)
    {
    }
}