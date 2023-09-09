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
        private List<Book> _books;
        private List<Member> _members;
        private List<LendBook> _lendBooks;

        public Library() 
        {
            _books = new List<Book>();
            _members = new List<Member>();
            _lendBooks = new List<LendBook>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public void RegisterMember(Member member)
        {
            _members.Add(member);
        }


        public void RemoveBook(Book bookId)
        {
                _books.Remove(bookId);
        }

        public void RemoveMembers(Member memberId)
        {
                _members.Remove(memberId);
        }

        public Book SearchBookInfo(string bookTitle)
        {
            return _books.Find(b => b.BookName.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        }

        public Book SearchBookInfo(int bookId)
        {
            return _books.Find(b => b.BookId == bookId);
        }

        public List<Member> GetAllMembers()
        {
            return _members;
        }

        public Member SearchMemberInfo(int memberId)
        {
            return _members.Find(m => m.MemberId == memberId);
        }

        public List<LendBook> ViewLendingInfo()
        {
            return _lendBooks;
        }

        public Book? GetValidBook(int bookId)
        {
            Book? foundBook = SearchBookInfo(bookId);
            return foundBook;
        }

        public Member? GetValidMember(int memberId)
        {
            Member? foundMember = SearchMemberInfo(memberId);
            return foundMember;
        }

        public int GetBookCount()
        {
            return _books.Count;
        }

        public int GetMemberCount()
        {
            return _members.Count;
        }

        public int GetLendBookCount()
        {
            return _members.Count;
        }
    }
}
