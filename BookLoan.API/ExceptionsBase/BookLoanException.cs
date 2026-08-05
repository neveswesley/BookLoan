namespace BookLoan.API.ExceptionsBase;

public abstract class BookLoanException : Exception
{
    public abstract IList<string> GetErrors();
}