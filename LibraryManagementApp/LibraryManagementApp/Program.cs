using LibraryManagementApp;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;
using static LibraryManagementApp.Book;

namespace LibraryManagementApp
{
    internal class Program
    {
        
        private static Library _library; // Initialize the Library object
        private static Program _program;

        // Initialize variables to keep track of recall and setChoose
        private static int recall;
        private static int setChoose = 0;

        static void Main(string[] args)
        {

            _library = new Library();
            _program = new Program();

            MenuChoose();
        }

        private static int ShowMenu()
        {
            //create menu
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
            Console.Write("                                             |  Enter your choice: ");

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

                    Book AddBook = new Book();

                    Console.WriteLine("                                          ------------------------------------");
                    Console.WriteLine("                                          |          Add a New Book          |");
                    Console.WriteLine("                                          ------------------------------------");

                    // Get Book Title
                    Console.Write("                                          | Enter Book Title: ");
                    AddBook.BookName = Console.ReadLine();

                    // Get Book Author
                    Console.Write("                                          | Enter Book Author: ");
                    AddBook.BookAuthor = Console.ReadLine();

                    // Get Book Description
                    Console.Write("                                          | Enter Book Description: ");
                    AddBook.BookDescription = Console.ReadLine();

                    // Get Book ISBN
                    Console.Write("                                          | Enter Book ISBN: ");
                    AddBook.BookIsbn = Console.ReadLine();
                    Console.WriteLine("                                          ------------------------------------");

                    // Check if there are any errors
                    if (AddBook.CheckError() == 0)
                    {
                        // Create a new Book and add it to the library
                        Book newBook = new Book(AddBook.BookName, AddBook.BookDescription, AddBook.BookAuthor, AddBook.BookIsbn);
                        _library.AddBook(newBook);
                        Console.WriteLine("");
                        Console.WriteLine("Book added successfully");

                    }
                    else
                    {
                        _program.ErrorMessageShow(AddBook.GetErrors());
                    }
                    Console.WriteLine("");
                    BackToMenu("1 to Add Book or ");

                    break;

                case 2:
                    // Remove Book
                    Console.Clear();
                    recall = choice;

                    Book removeBook = new Book();

                    Console.WriteLine("                                          ------------------------------------");
                    Console.WriteLine("                                          |            Remove a Book         |"); 
                    Console.WriteLine("                                          ------------------------------------");

                    Console.Write("                                          | Enter Book Title to remove: ");

                    if (int.TryParse(Console.ReadLine(), out int mbookIdToRemove))
                    {
                        Book bookToRemove = _library.GetValidBook(mbookIdToRemove);
                        // Check if there are any errors
                        if (bookToRemove != null)
                        {

                            _library.RemoveBook(bookToRemove);
                            Console.WriteLine("");
                            Console.WriteLine("Book removed successfully.");

                        }
                        else
                        {

                            _program.ErrorMessageShow("book id not found");

                        }
                    }
                    else
                    {
                        _program.ErrorMessageShow("Invalid input. Please enter a valid number.");
                    }
                    Console.WriteLine("");
                    BackToMenu("1 to Remove Book or ");

                    break;

                case 3:
                    // Register Member
                    Console.Clear();
                    recall = choice;

                    Member addMember = new Member();

                    Console.WriteLine("                                          ------------------------------------");
                    Console.WriteLine("                                          |       Register a New Member      |");
                    Console.WriteLine("                                          ------------------------------------");

                    Console.Write("                                          | Enter Member Name: ");
                    addMember.MemberName = Console.ReadLine();

                    Console.Write("                                          | Enter Member Address: ");
                    addMember.MemberAddress = Console.ReadLine();

                    Console.Write("                                          | Enter Member NIC: ");
                    addMember.MemberNic = Console.ReadLine();
                    Console.WriteLine("                                          ------------------------------------");

                    // Check if there are any errors
                    if (addMember.CheckError() == 0)
                    {
                        Member newMember = new Member(addMember.MemberName, addMember.MemberAddress, addMember.MemberNic);
                        _library.RegisterMember(newMember);
                        Console.WriteLine("");
                        Console.WriteLine("Member registered successfully.");
                    }
                    else
                    {
                        _program.ErrorMessageShow(addMember.GetErrors());
                    }
                    Console.WriteLine("");
                    BackToMenu("1 to Register New Member or ");
                    break;


                case 4:
                    // Remove Member
                    Console.Clear();
                    recall = choice;

                    Member removeMember = new Member();

                    Console.WriteLine("                                          ------------------------------------");
                    Console.WriteLine("                                          |       Remove a Member            |"); 
                    Console.WriteLine("                                          ------------------------------------");


                    Console.Write("                                          | Enter Member ID to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int memberIdToRemove))
                    {
                        Member memberToRemove = _library.GetValidMember(memberIdToRemove);

                        // Check if there are any errors
                        if (memberToRemove != null)
                        {
                            _library.RemoveMembers(memberToRemove);
                            Console.WriteLine("");
                            Console.WriteLine("Member removed successfully.");
                        }
                        else
                        {
                            _program.ErrorMessageShow("Member id not found.");
                        }
                    }
                    else
                    {
                        _program.ErrorMessageShow("Invalid input. Please enter a valid number.");
                    }
                    Console.WriteLine("");
                    BackToMenu("1 to Remove Member or ");
                    break;

                case 5:

                    // Search Book Information
                    Console.Clear();
                    recall = choice;
                    Console.WriteLine("");
                    Console.WriteLine("Enter number 1 to search the book by book ID and number 2 to search the book by ISBN number.");
                    Console.WriteLine("");
                    if (int.TryParse(Console.ReadLine(), out int select))
                    {
                        if (select == 1)
                        {
                            Console.WriteLine("                                          ------------------------------------");
                            Console.WriteLine("                                          |        Search for a Book         |");
                            Console.WriteLine("                                          ------------------------------------");

                            Console.Write("                                          | Enter Book ID to search: ");
                            string bookIdToSearch = Console.ReadLine();
                            Console.WriteLine("                                          ------------------------------------");

                            if (int.TryParse(bookIdToSearch, out int bookId))
                            {
                                Book foundBook = _library.GetValidBook(bookId);

                                if (foundBook != null)
                                {

                                    Book searchedBook = _library.SearchBookInfo(bookId);
                                    Console.Clear();
                                    Console.WriteLine("");
                                    Console.WriteLine("Book Information:");
                                    Console.WriteLine("--------------------------------------------------");
                                    Console.WriteLine($"| Book ID:     | {searchedBook.BookId,-30} |");
                                    Console.WriteLine($"| Title:       | {searchedBook.BookName,-30} |");
                                    Console.WriteLine($"| Author:      | {searchedBook.BookAuthor,-30} |");
                                    Console.WriteLine($"| Description: | {searchedBook.BookDescription,-30} |");
                                    Console.WriteLine($"| ISBN Number: | {searchedBook.BookIsbn,-30} |");
                                    Console.WriteLine($"| Availability:| {(searchedBook.BookIsAvailable ? "Available" : "Not available"),-30} |");
                                    Console.WriteLine("--------------------------------------------------");


                                }
                                else
                                {
                                    _program.ErrorMessageShow($"Book with ID '{bookId}' not found.");
                                }
                            }
                            else
                            {
                                _program.ErrorMessageShow("Invalid Book ID.");
                            }
                        }
                        else if (select == 2)
                        {
                            Console.WriteLine("                                          ------------------------------------");
                            Console.WriteLine("                                          |        Search for a Book         |");
                            Console.WriteLine("                                          ------------------------------------");

                            Console.Write("                                          | Enter Book ISBN Number to search: ");
                            string bookIsbnToSearch = Console.ReadLine();
                            Console.WriteLine("                                          ------------------------------------");

                            Book searchedBook = _library.SearchBookInfo(bookIsbnToSearch);

                            if (searchedBook != null)
                            {


                                Console.Clear();
                                Console.WriteLine("");
                                Console.WriteLine("Book Information:");
                                Console.WriteLine("--------------------------------------------------");
                                Console.WriteLine($"| Book ID:     | {searchedBook.BookId,-30} |");
                                Console.WriteLine($"| Title:       | {searchedBook.BookName,-30} |");
                                Console.WriteLine($"| Author:      | {searchedBook.BookAuthor,-30} |");
                                Console.WriteLine($"| Description: | {searchedBook.BookDescription,-30} |");
                                Console.WriteLine($"| ISBN Number: | {searchedBook.BookIsbn,-30} |");
                                Console.WriteLine($"| Availability:| {(searchedBook.BookIsAvailable ? "Available" : "Not available"),-30} |");
                                Console.WriteLine("--------------------------------------------------");


                            }
                            else
                            {
                                _program.ErrorMessageShow($"Book with ID '{bookIsbnToSearch}' not found.");
                            }
                        }
                        else
                        {
                            _program.ErrorMessageShow("Invalid Select.");
                        }
                    }

                    
                    Console.WriteLine("");
                    BackToMenu("1 to Search Book Information or ");
                    break;

                case 6:
                    // Search Member Information
                    Console.Clear();
                    recall = choice;

                    Console.WriteLine("                                          ------------------------------------");
                    Console.WriteLine("                                          |     Enter Member ID to search    |");
                    Console.WriteLine("                                          ------------------------------------");

                    Console.Write("                                          | Enter Member ID to search: ");
                    string memberIdToSearch = Console.ReadLine();
                    Console.WriteLine("                                          ------------------------------------");

                    if (int.TryParse(memberIdToSearch, out int memberId))
                    {
                        Member foundMember = _library.GetValidMember(memberId);

                        if (foundMember != null)
                        {

                            Member searchedMember = _library.SearchMemberInfo(memberId);
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("Member Information:");
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine($"| Member ID:   | {searchedMember.MemberId,-30} |");
                            Console.WriteLine($"| Name:        | {searchedMember.MemberName,-30} |");
                            Console.WriteLine($"| Address:     | {searchedMember.MemberAddress,-30} |");
                            Console.WriteLine($"| NIC Number:  | {searchedMember.MemberNic,-30} |");
                            Console.WriteLine("--------------------------------------------------");

                        }
                        else
                        {
                            _program.ErrorMessageShow("Member not found.");
                        }
                    }
                    else
                    {
                        _program.ErrorMessageShow("Invalid Member ID.");
                    }
                    Console.WriteLine("");
                    BackToMenu("1 to Search Member Information or ");
                    break;


                case 7:
                    // List All Books
                    Console.Clear();
                    recall = choice;
                    List<Book> allBooks = _library.GetAllBooks();

                    Console.WriteLine("             ------------------------------------------------------------------------------------------------");
                    Console.WriteLine("             |                                       List of all books                                      |");
                    Console.WriteLine("             ------------------------------------------------------------------------------------------------");
                    Console.WriteLine("             | Book ID  | Title                | Author               |     ISBN          |  Availability   |");
                    Console.WriteLine("             ------------------------------------------------------------------------------------------------");

                    foreach (var book in allBooks)
                    {
                        Console.WriteLine($"             | {book.BookId,8} | {book.BookName,-20} | {book.BookAuthor,-20} | {book.BookIsbn,-17} | {(book.BookIsAvailable ? "Available" : "Not available"),-15} |");
                    }

                    Console.WriteLine("             ------------------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    BackToMenu("");
                    break;



                case 8:
                    // List All Members
                    Console.Clear();
                    recall = choice;
                    List<Member> allMembers = _library.GetAllMembers();

                    Console.WriteLine("                   ---------------------------------------------------------------------------------------");
                    Console.WriteLine("                   |                                      List of all members                            |");
                    Console.WriteLine("                   ---------------------------------------------------------------------------------------");
                    Console.WriteLine("                   | Member ID   | Name                      |   Address             |  NIC              |");
                    Console.WriteLine("                   ---------------------------------------------------------------------------------------");

                    foreach (var member in allMembers)
                    {
                        Console.WriteLine($"                   | {member.MemberId,11} | {member.MemberName,-25} | {member.MemberAddress,-21} | {member.MemberNic,-17} |");
                    }

                    Console.WriteLine("                   ---------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    BackToMenu("");
                    break;

                case 9:
                    // Lend Book
                    Console.Clear();
                    recall = choice;

                    LendBook addLendBook = new LendBook();

                   Console.WriteLine("                                          ----------------------------------------------");
                    Console.WriteLine("                                          |                   Lend Book                |");
                    Console.WriteLine("                                          ----------------------------------------------");

                    Console.Write("                                          | Enter Member ID: ");

                    if (int.TryParse(Console.ReadLine(), out int memberIdToLend))
                    {
                        Member validMember = _library.GetValidMember(memberIdToLend);

                        if (validMember != null)
                        {
                            Console.Write("                                          | Enter Book Id to lend: ");

                            if (int.TryParse(Console.ReadLine(), out int lendBookId))
                            {
                                Book validBook = _library.GetValidBook(lendBookId);

                                if (validBook != null)
                                {

                                    Console.Write("                                          | Enter issue date (yyyy-MM-dd): ");
                                    if (DateTime.TryParse(Console.ReadLine(), out DateTime issueDate))
                                    {

                                        Console.Write("                                          | Enter return date (yyyy-MM-dd): ");

                                        if (DateTime.TryParse(Console.ReadLine(), out DateTime returnDate))
                                        {

                                            _library.LendBookForMember(validBook, validMember, issueDate, returnDate);

                                        }
                                        else
                                        {
                                            _program.ErrorMessageShow("Invalid date format. Please use yyyy-MM-dd format.");
                                        }
                                    }
                                    else
                                    {
                                        _program.ErrorMessageShow("Invalid date format. Please use yyyy-MM-dd format.");
                                    }

                                }
                                else
                                {
                                    _program.ErrorMessageShow("Book not found in the library.");
                                }
                            }
                            else
                            {
                                _program.ErrorMessageShow("Invalid Book ID. Please enter a valid integer.");
                            }
                        }
                        else
                        {
                            _program.ErrorMessageShow("Invalid Member ID. Please enter a valid integer.");
                        }
                        Console.WriteLine("");
                        BackToMenu("1 to Lend Book or ");
                        break;
                    }
                    Console.WriteLine("");
                    BackToMenu("1 to Lend Book or ");
                    break;


                case 10:
                    // Return Book
                    Console.Clear();
                    recall = choice;

                    Console.WriteLine("                                          ------------------------------------");
                    Console.WriteLine("                                          |            Return Book           |");
                    Console.WriteLine("                                          ------------------------------------");

                    Console.Write("                                          | Enter Transaction ID to return: ");

                    if (int.TryParse(Console.ReadLine(), out int lendBookIdToReturn))
                    {
                        _library.ReturnBook(lendBookIdToReturn);
                    }
                    else
                    {
                        _program.ErrorMessageShow("Invalid input.");
                    }
                    Console.WriteLine("");
                    BackToMenu("1 to Return Book or ");
                    break;


                case 11:
                    // View Lending Information
                    Console.Clear();
                    recall = choice;
                    List<LendBook> lendBooks = _library.ViewLendingInfo();
                    Console.WriteLine("                           ----------------------------------------------------------------------------------");
                    Console.WriteLine("                           |                                Lending Information                             |");
                    Console.WriteLine("                           ----------------------------------------------------------------------------------");
                    Console.WriteLine("                           | Transaction ID | Book Title     | Member Name    | Start Date   | Return Date  |");
                    Console.WriteLine("                           ----------------------------------------------------------------------------------");

                    foreach (LendBook lendBook in lendBooks)
                    {
                        Console.WriteLine($"                           | {lendBook.LendBookId,15} | {lendBook.LendBookName.BookName,14} | {lendBook.MemberOfLend.MemberName,13} | {lendBook.IssueDate.ToString("yyyy-MM-dd"),12} | {lendBook.ReturnDate.ToString("yyyy-MM-dd"),12} |");
                    }

                    Console.WriteLine("                           ----------------------------------------------------------------------------------");
                    BackToMenu("");
                    break;


                case 12:
                    // Display Overdue Books
                    Console.Clear();
                    recall = choice;
                    List<LendBook> overdueBooks = _library.DisplayOverdueBooks();

                    Console.WriteLine("                           ---------------------------------------------------------------------------------------");
                    Console.WriteLine("                           |                                    Overdue Books                                    |");
                    Console.WriteLine("                           ---------------------------------------------------------------------------------------");
                    Console.WriteLine("                           | Transaction ID | Book Title          | Member Name        | Due Date    | Fine      |");
                    Console.WriteLine("                           ---------------------------------------------------------------------------------------");

                    foreach (LendBook lendBook in overdueBooks)
                    {
                        float fine = _library.CalculateFine(lendBook);
                        Console.WriteLine($"                           | {lendBook.LendBookId,14} | {lendBook.LendBookName.BookName,-19} | {lendBook.MemberOfLend.MemberName,-18} | {lendBook.ReturnDate.ToString("yyyy-MM-dd"),-11} | Rs. {fine,-5} |");
                    }

                    Console.WriteLine("                           ---------------------------------------------------------------------------------------");
                    BackToMenu("");
                    break;


                case 13:
                    // Quit
                    Environment.Exit(0);
                    break;


                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    setChoose = 1;
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
                    _program.ErrorMessageShow("Invalid input. Please enter a valid number.");
                }
            }
        }

        private void ErrorMessageShow(string error)
        {
            Console.Clear();
            Console.WriteLine("Error(s) occurred:");
            Console.WriteLine(error);
        }

        private void ErrorMessageShow(string[] errors)
        {
            Console.Clear();
            Console.WriteLine("Error(s) occurred:");
            foreach (string error in errors)
            {
                Console.WriteLine($"Error: {error}");
            }
        }
    }
}
