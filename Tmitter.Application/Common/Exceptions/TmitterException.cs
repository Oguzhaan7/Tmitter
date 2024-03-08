namespace Tmitter.Application.Common.Exceptions;

public abstract class TmitterException : Exception
{
    protected TmitterException(string title, string message) : base(title) => Title = title;

    public string Title { get; }
}