using LibraryManagementApp;
using static LibraryManagementApp.Book;

namespace LibraryManagementApp
{
    internal class Program
    {
        private static Library library = new Library(); // Initialize the library object

        private static int recall;
        private static int setChoose = 0;

        static void Main(string[] args)
        {
            library = new Library();
            MenuChoose();
        }

        private static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("                                         ==========================================");
            Console.WriteLine("                                         |         Library Management System       |");
            Console.WriteLine("                                         ==========================================");
            Console.WriteLine("                                         | 1. Add Book                             |");
            Console.WriteLine("                                         | 2. Remove Book                          |");
            Console.WriteLine("                                         | 3. Register Member                      |");
            Console.WriteLine("                                         | 4. Remove Member                        |");
            Console.WriteLine("                                         | 5. Search Book Information              |");
            Console.WriteLine("                                         | 6. Search Member Information            |");
            Console.WriteLine("                                         | 7. List All Books                       |");
            Console.WriteLine("                                         | 8. List All Members                     |");
            Console.WriteLine("                                         | 9. Lend Book                            |");
            Console.WriteLine("                                         | 10. Return Book                         |");
            Console.WriteLine("                                         | 11. View Lending Information            |");
            Console.WriteLine("                                         | 12. Display Overdue Books               |");
            Console.WriteLine("                                         | 13. Quit                                |");
            Console.WriteLine("                                         |=========================================|");
            Console.Write("                                                                                       ");
            Console.Write("                                                                          |  Enter your choice: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
                return ShowMenu();
            }
        }


        private static void MenuChoose()
        {
            int choice;

            if (setChoose == 0)
            {
                choice = ShowMenu();
            }
            else
            {
                choice = recall;
            }


            switch (choice)
            {

                case 1:

                    Console.Clear();
                    recall = choice;

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
                    if (book.CheckError() == 0)
                    {
                        // Create a new Book and add it to the library
                        Book newBook = new Book(book.BookName, book.BookDescription, book.BookAuthor, book.BookIsbn);
                        Console.WriteLine("succe fuly add");
                        
                    }
                    else
                    {
                        Console.WriteLine("Error(s) occurred:");

                        foreach (string error in book.GetErrors())
                        {
                            Console.WriteLine($"Error: {error}");
                        }
                    }

                    break;

                case 2:
                    // Remove Book
                    Console.Clear();
                    recall = choice;



                    break;

            }
        }
    }
}


//// Add the newBook to the library
//library.AddBook(newBook);

//List<Book> allBooks = library.GetAllBooks();

//Console.WriteLine("Library Books:");
//Console.WriteLine("| Title    | Author              | Description         | ISBN            |");
//Console.WriteLine("---------------------------------------------------------------");
//foreach (var b in allBooks)
//{
//    Console.WriteLine($"| {b.BookName,-8} | {b.BookAuthor,-20} | {b.BookDescription,-20} | {b.BookIsbn,-17} ");
//}
