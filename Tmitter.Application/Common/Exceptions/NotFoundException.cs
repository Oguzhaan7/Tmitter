namespace Tmitter.Application.Common.Exceptions;

public abstract class NotFoundException : TmitterException
{
    protected NotFoundException(string message) : base("Not Found", message)
    {
    }
}