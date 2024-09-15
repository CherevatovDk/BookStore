using System;
using BookStore.Exceptions;
using BookStore.Guards;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using static BookStore.BookStoreConstants.Common;
using static BookStore.BookStoreConstants.Book;

namespace BookStore.Models;

public class Book : AuditedAggregateRoot<Guid>
{
    public bool IsDeleted { get; private set; }

    internal Book(string title, decimal price, int quantity, string imageUrl, string description, Genre genre)
    {
        Guard.ForStringLength<InvalidBookException>(title, MinNameLength, MaxNameLength, nameof(Title));
        Guard.AgainstOutOfRange<InvalidBookException>(price, MinPriceValue, MaxPriceValue, nameof(Price));
        Guard.AgainstOutOfRange<InvalidBookException>(quantity, MinQuantityValue, MaxQuantityValue, nameof(Quantity));
        Guard.ForValidUrl<InvalidBookException>(imageUrl, nameof(ImageUrl));
        Guard.ForStringLength<InvalidBookException>(description, MinDescriptionLength, MaxDescriptionLength, nameof(Description));
        
        Title = title;
        Price = price;
        Quantity = quantity;
        ImageUrl = imageUrl;
        Description = description;
        Genre = genre;
        IsDeleted = false;
    }

    public string Title { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public string ImageUrl { get; private set; }
    public string Description { get; private set; }
    public Genre Genre { get; private set; }

    public void Update(string title, decimal price, int quantity, string imageUrl, string description, Genre genre)
    {
        Guard.ForStringLength<InvalidBookException>(title, MinNameLength, MaxNameLength, nameof(Title));
        Guard.AgainstOutOfRange<InvalidBookException>(price, MinPriceValue, MaxPriceValue, nameof(Price));
        Guard.AgainstOutOfRange<InvalidBookException>(quantity, MinQuantityValue, MaxQuantityValue, nameof(Quantity));
        Guard.ForValidUrl<InvalidBookException>(imageUrl, nameof(ImageUrl));
        Guard.ForStringLength<InvalidBookException>(description, MinDescriptionLength, MaxDescriptionLength, nameof(Description));
        
        Title = title;
        Price = price;
        Quantity = quantity;
        ImageUrl = imageUrl;
        Description = description;
        Genre = genre;
    }

    public void Delete()
    {
        if (IsDeleted)
        {
            throw new InvalidBookException("Book is already deleted.");
        }
        IsDeleted = true;
    }

    public void Restore()
    {
        if (!IsDeleted)
        {
            throw new InvalidBookException("Book is not deleted.");
        }
        IsDeleted = false;
    }

    public void UpdateQuantity(int quantity)
    {
        Guard.AgainstOutOfRange<InvalidBookException>(quantity, MinQuantityValue, MaxQuantityValue, nameof(Quantity));
        Quantity = quantity;
    }
}
