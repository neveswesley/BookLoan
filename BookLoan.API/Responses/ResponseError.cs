namespace BookLoan.API.Responses;

public class ResponseError
{
    public IList<string> ErrorMessage { get; set; }

    public ResponseError(IList<string> errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public ResponseError(string error)
    {
        ErrorMessage = new List<string>();
        ErrorMessage.Add(error);
    }
}