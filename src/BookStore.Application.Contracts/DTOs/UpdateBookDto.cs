namespace BookStore.Models;

public class UpdateBookDto : CreateBookDto
{
    public bool IsDeleted { get; set; }
}