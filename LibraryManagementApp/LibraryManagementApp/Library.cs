using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementApp
{
    internal class Library
    {
        // Private fields to store books, members, and lend books
        private List<Book> _books;
        private List<Member> _members;
        private List<LendBook> _lendBooks;

        // Constructor to initialize the Library with empty lists
        public Library()
        {
            _books = new List<Book>();
            _members = new List<Member>();
            _lendBooks = new List<LendBook>();
        }

        // Method to add a book to the library
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        // Method to get a list of all books in the library
        public List<Book> GetAllBooks()
        {
            return _books;
        }

        // Method to register a member in the library
        public void RegisterMember(Member member)
        {
            _members.Add(member);
        }

        // Method to remove a book from the library by book object
        public void RemoveBook(Book bookId)
        {
            _books.Remove(bookId);
        }

        // Method to remove a member from the library by member object
        public void RemoveMembers(Member memberId)
        {
            _members.Remove(memberId);
        }

        // Method to search for a book by ISBN
        public Book SearchBookInfo(string bookIsbn)
        {
            return _books.Find(b => b.BookIsbn.Equals(bookIsbn, StringComparison.OrdinalIgnoreCase));
        }

        // Method to search for a book by its ID
        public Book SearchBookInfo(int bookId)
        {
            return _books.Find(b => b.BookId == bookId);
        }

        // Method to get a list of all registered members
        public List<Member> GetAllMembers()
        {
            return _members;
        }

        // Method to search for a member by their ID
        public Member SearchMemberInfo(int memberId)
        {
            return _members.Find(m => m.MemberId == memberId);
        }

        // Method to lend a book to a member
        public void LendBookForMember(Book bookId, Member memberId, DateTime issueDate, DateTime returnDate)
        {
            bool bookIsAvailable = bookId.BookIsAvailable;

            if (bookId != null && memberId != null && bookIsAvailable)
            {
                // Create a new LendBook object to track the lending transaction
                LendBook lendBook = new LendBook(bookId, memberId, issueDate, returnDate);
                _lendBooks.Add(lendBook);
                bookId.BookIsAvailable = false;
                Console.WriteLine("");
                Console.WriteLine("The book has been successfully lent.");
            }
            else
            {
                Console.WriteLine("The book has already been Lended");
            }
        }

        // Method to return a book by its lending transaction ID
        public void ReturnBook(int lendBookId)
        {
            LendBook LendBookToReturn = _lendBooks.Find(t => t.LendBookId == lendBookId);

            if (LendBookToReturn != null)
            {
                Book returnBook = LendBookToReturn.LendBookName;
                returnBook.BookIsAvailable = true;
                _lendBooks.Remove(LendBookToReturn);
                Console.WriteLine("Book returned successfully.");
            }
            else
            {
                Console.WriteLine("Transaction ID is incorrect.");
            }
        }

        // Method to view all lending information
        public List<LendBook> ViewLendingInfo()
        {
            return _lendBooks;
        }

        // Method to display overdue books
        public List<LendBook> DisplayOverdueBooks()
        {
            DateTime currentDate = DateTime.Now;
            return _lendBooks.Where(t => t.ReturnDate < currentDate).ToList();
        }

        // Method to calculate the fine for an overdue book
        public float CalculateFine(LendBook lendBook)
        {
            DateTime dueDate = lendBook.ReturnDate.Date;
            DateTime currentDate = DateTime.Now.Date;
            TimeSpan overdueDuration = currentDate - dueDate;
            float fine = 0;

            if (overdueDuration.TotalDays <= 7)
            {
                fine = (float)overdueDuration.TotalDays * 50;
            }
            else
            {
                fine = 7 * 50 + (float)(overdueDuration.TotalDays - 7) * 100;
            }

            return fine;
        }

        // Method to get a valid book by its ID
        public Book? GetValidBook(int bookId)
        {
            Book? foundBook = SearchBookInfo(bookId);
            return foundBook;
        }

        // Method to get a valid member by their ID
        public Member? GetValidMember(int memberId)
        {
            Member? foundMember = SearchMemberInfo(memberId);
            return foundMember;
        }

        // Method to get the total count of books in the library
        public int GetBookCount()
        {
            return _books.Count;
        }

        // Method to get the total count of members registered in the library
        public int GetMemberCount()
        {
            return _members.Count;
        }

        // Method to get the total count of lend books
        public int GetLendBookCount()
        {
            return _lendBooks.Count;
        }
    }
}
