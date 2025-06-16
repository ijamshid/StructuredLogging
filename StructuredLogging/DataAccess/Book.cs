namespace LoggingDemo.Models
{
    // Define the Book model with properties for Id, Title, Author, and YearPublished
    public class Book
    {
        public int Id { get; set; } // Unique identifier for the book
        public string Title { get; set; } // Title of the book
        public string Author { get; set; } // Author of the book
        public int YearPublished { get; set; } // Publication year
    }
}