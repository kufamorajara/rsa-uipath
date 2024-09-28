using System.Diagnostics.Contracts;

namespace Errors;

public class InitError : Exception
{
    public InitError(string Message)
    {
        message = message;
    }

    string message = string.Empty;
    public override string Message => message;
}
