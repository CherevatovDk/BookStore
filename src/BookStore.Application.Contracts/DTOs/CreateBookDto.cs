namespace BookStore.Models;

public class CreateBookDto
{
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public Genre Genre { get; set; }

}