using static LibraryManagementApp.Book;

namespace LibraryManagementApp
{
    internal class Program
    {
        private static Library library = new Library(); // Initialize the library object

        static void Main(string[] args)
        {
            // Create a new Book instance
            Book book = new Book();

            // Get Book Title
            Console.WriteLine("Enter Book Title: ");
            book.BookName = Console.ReadLine();

            // Get Book Author
            Console.WriteLine("Enter Book Author: ");
            book.BookAuthor = Console.ReadLine();

            // Get Book Description
            Console.WriteLine("Enter Book Description: ");
            book.BookDescription = Console.ReadLine();

            // Get Book ISBN
            Console.WriteLine("Enter Book ISBN: ");
            book.BookIsbn = Console.ReadLine();

            // Check if there are any errors
            if (book.CheckError() == 1)
            {
                // Create a new Book and add it to the library
                Book newBook = new Book(book.BookName, book.BookDescription, book.BookAuthor, book.BookIsbn);

                // Add the newBook to the library
                library.AddBook(newBook);

                List<Book> allBooks = library.GetAllBooks();

                Console.WriteLine("Library Books:");
                Console.WriteLine("| Title    | Author              | Description         | ISBN            |");
                Console.WriteLine("---------------------------------------------------------------");
                foreach (var b in allBooks)
                {
                    Console.WriteLine($"| {b.BookName,-8} | {b.BookAuthor,-20} | {b.BookDescription,-20} | {b.BookIsbn,-17} ");
                }
            }
            else
            {
                Console.WriteLine("Error(s) occurred:");

                foreach (Book.BookErrorField field in Enum.GetValues(typeof(Book.BookErrorField)))
                {
                    string errorMessage = book.GetError(field);

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        int number = (int)field;
                        Console.WriteLine($"Error Code {number}: {errorMessage}");
                    }
                }
            }
        }
    }
}