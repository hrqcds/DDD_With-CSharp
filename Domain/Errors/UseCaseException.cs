namespace Domain.Errors;

public class UseCaseException : Exception
{
    public string ErrorDescription { get; set; } = null!;
    public int StatusCode { get; set; }

    public UseCaseException(string errorDescription, int statusCode)
    {
        ErrorDescription = errorDescription;
        StatusCode = statusCode;
    }
}
