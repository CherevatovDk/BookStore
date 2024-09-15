using System;

namespace BookStore;

public abstract class BaseDomainException : Exception
{
    private string? message;

    public string? Error
    {
        get => message;
        set => message = value;
    }
}