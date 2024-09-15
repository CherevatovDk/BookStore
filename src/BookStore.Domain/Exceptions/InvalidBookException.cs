namespace BookStore.Exceptions;

public class InvalidBookException:BaseDomainException
{
    public InvalidBookException(){}

    public InvalidBookException(string error) => Error=error;

}