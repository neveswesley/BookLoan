namespace BookLoan.API.ExceptionsBase;

public class NotFoundException : BookLoanException
{
    private readonly IList<string> _errors;

    public NotFoundException(string error)
    {
        _errors = new List<string> { error };
    }

    public NotFoundException(IList<string> errors)
    {
        _errors = errors;
    }

    public override IList<string> GetErrors()
    {
        return _errors;
    }
}