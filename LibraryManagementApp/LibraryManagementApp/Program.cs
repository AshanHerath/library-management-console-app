using LibraryManagementApp;
using System.Collections.Generic;
using static LibraryManagementApp.Book;

namespace LibraryManagementApp
{
    internal class Program
    {
        private static Library library; // Initialize the library object

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

                    Book addBook = new Book();

                    // Get Book Title
                    Console.WriteLine("Enter Book Title: ");
                    addBook.BookName = Console.ReadLine();

                    // Get Book Author
                    Console.WriteLine("Enter Book Author: ");
                    addBook.BookAuthor = Console.ReadLine();

                    // Get Book Description
                    Console.WriteLine("Enter Book Description: ");
                    addBook.BookDescription = Console.ReadLine();

                    // Get Book ISBN
                    Console.WriteLine("Enter Book ISBN: ");
                    addBook.BookIsbn = Console.ReadLine();

                    // Check if there are any errors
                    if (addBook.CheckError() == 0)
                    {
                        // Create a new Book and add it to the library
                        Book newBook = new Book(addBook.BookName, addBook.BookDescription, addBook.BookAuthor, addBook.BookIsbn);
                        library.AddBook(newBook);
                        Console.WriteLine("succe fuly add");

                    }
                    else
                    {
                        Console.WriteLine("Error(s) occurred:");

                        foreach (string error in addBook.GetErrors())
                        {
                            Console.WriteLine($"Error: {error}");
                        }
                    }

                    BackToMenu("1 to Add Book or ");

                    break;

                case 2:
                    // Remove Book
                    Console.Clear();
                    recall = choice;

                    Book removeBook = new Book();

                    Console.WriteLine("Remove a Book:");
                    Console.WriteLine("------------------");

                    Console.Write("Enter Book Title to remove: ");

                    if (int.TryParse(Console.ReadLine(), out int mbookIdToRemove))
                    {
                        Book bookToRemove = library.GetValidBook(mbookIdToRemove);
                        // Check if there are any errors
                        if (bookToRemove != null)
                        {

                            library.RemoveBook(bookToRemove);
                            Console.WriteLine("Book removed successfully.");

                        }
                        else
                        {
                            Console.WriteLine("Error(s) occurred:");

                            Console.WriteLine("book id not found");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }

                    BackToMenu("1 to Remove Book or ");

                    break;

                case 3:
                    // Register Member
                    Console.Clear();
                    recall = choice;

                    Member addMember = new Member();

                    Console.WriteLine("Register a New Member:");
                    Console.WriteLine("-----------------------");

                    Console.Write("Enter Member Name: ");
                    addMember.MemberName = Console.ReadLine();

                    Console.Write("Enter Member Address: ");
                    addMember.MemberAddress = Console.ReadLine();

                    Console.Write("Enter Member NIC: ");
                    addMember.MemberNic = Console.ReadLine();

                    // Check if there are any errors
                    if (addMember.CheckError() == 0)
                    {
                        Member newMember = new Member(addMember.MemberName, addMember.MemberAddress, addMember.MemberNic);
                        library.RegisterMember(newMember);
                        Console.Clear();
                        Console.WriteLine("Member registered successfully.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error(s) occurred:");

                        foreach (string error in addMember.GetErrors())
                        {
                            Console.WriteLine($"Error: {error}");
                        }
                    }
                    BackToMenu("1 to Register New Member or ");
                    break;


                case 4:
                    // Remove Member
                    Console.Clear();
                    recall = choice;

                    Member removeMember = new Member();

                    Console.WriteLine("Remove a Member:");
                    Console.WriteLine("-----------------");

                    Console.Write("Enter Member ID to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int memberIdToRemove))
                    {
                        Member memberToRemove = library.GetValidMember(memberIdToRemove);

                        // Check if there are any errors
                        if (memberToRemove !=  null)
                        {
                            library.RemoveMembers(memberToRemove);
                            Console.WriteLine("Member removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Member id not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    BackToMenu("1 to Remove Member or ");
                    break;

                case 5:

                    // Search Book Information
                    Console.Clear();
                    recall = choice;

                    Console.WriteLine("Search for a Book:");
                    Console.WriteLine("------------------");

                    Console.Write("Enter Book ID to search: ");
                    string bookIdToSearch = Console.ReadLine();

                    if (int.TryParse(bookIdToSearch, out int bookId))
                    {
                        Book foundBook = library.GetValidBook(bookId);

                        if (foundBook != null)
                        {

                            Book searchedBook = library.SearchBookInfo(bookId);

                            Console.WriteLine("Book Information:");
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine($"| Book ID: {searchedBook.BookId,6} |");
                            Console.WriteLine($"| Title: {searchedBook.BookName,40} |");
                            Console.WriteLine($"| Author: {searchedBook.BookAuthor,38} |");
                            Console.WriteLine($"| Description: {searchedBook.BookIsbn,-34} |");
                            Console.WriteLine($"| Availability: {(searchedBook.BookIsAvailable ? "Available" : "Not available"),-15} |");
                            Console.WriteLine("--------------------------------------------------");

                        }
                        else
                        {
                            Console.WriteLine($"Book with ID '{bookId}' not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Book ID.");
                    }

                    BackToMenu("1 to Search Book Information or ");
                    break;

                case 6:
                    // Search Member Information
                    Console.Clear();
                    recall = choice;
                    Console.Write("Enter Member ID to search: ");
                    String memberIdToSearch = Console.ReadLine();

                    if (int.TryParse(memberIdToSearch, out int memberId))
                    {
                        Member foundMember = library.GetValidMember(memberId);

                        if (foundMember != null)
                        {

                            Member searchedMember = library.SearchMemberInfo(memberId);

                            Console.WriteLine("Member Information:");
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine($"| Member ID: {searchedMember.MemberId,6} |");
                            Console.WriteLine($"| Name: {searchedMember.MemberName,40} |");
                            Console.WriteLine($"| Address: {searchedMember.MemberAddress,38} |");
                            Console.WriteLine($"| NIC Number: {searchedMember.MemberNic,-34} |");
                            Console.WriteLine("--------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Member not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Member ID.");
                    }
                    BackToMenu("1 to Search Member Information or ");
                    break;


                case 7:
                    // List All Books
                    Console.Clear();
                    recall = choice;
                    List<Book> allBooks = library.GetAllBooks();

                    Console.WriteLine("List of all books:");
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.WriteLine("| Book ID  | Title                | Author               |     ISBN          |  Availability   |");
                    Console.WriteLine("------------------------------------------------------------------------------------------------");

                    foreach (var book in allBooks)
                    {
                        Console.WriteLine($"| {book.BookId,8} | {book.BookName,-20} | {book.BookAuthor,-20} | {book.BookIsbn,-17} | {(book.BookIsAvailable ? "Available" : "Not available"),-15} |");
                    }

                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    BackToMenu("");
                    break;



                case 8:
                    // List All Members
                    Console.Clear();
                    recall = choice;
                    List<Member> allMembers = library.GetAllMembers();

                    Console.WriteLine("List of all members:");
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    Console.WriteLine("| Member ID   | Name                      |   Address             |  NIC               |");
                    Console.WriteLine("---------------------------------------------------------------------------------------");

                    foreach (var member in allMembers)
                    {
                        Console.WriteLine($"| {member.MemberId,10} | {member.MemberName,-25} | {member.MemberAddress,-25} | {member.MemberNic,-25} |");
                    }

                    Console.WriteLine("--------------------------------------------");
                    BackToMenu("");
                    break;


            }
        }
        // back to menu
        private static void BackToMenu(string message)
        {
            while (true)
            {
                Console.WriteLine("Press " + message + "0 to return to the main menu...");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number) && (number == 0 || number == 1))
                {
                    setChoose = number;
                    MenuChoose();
                    break; // Exit the loop if valid input is provided
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
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
