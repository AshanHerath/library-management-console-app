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


        public void RemoveBook(int bookId)
        {
            // book thitle to remove
            Book bookToRemove = _books.Find(b => b.BookId == bookId);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }

        }

        public void RemoveMembers(int memberId)
        {
            // book thitle to remove
            Member memberToRemove = _members.Find(b => b.MemberId == memberId);
            if (memberToRemove != null)
            {
                _members.Remove(memberToRemove);
            }

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

        public Member SearchMemberInfo(string nicNumber)
        {
            return _members.Find(m => m.MemberNic.Equals(nicNumber, StringComparison.OrdinalIgnoreCase));
        }
        public List<LendBook> ViewLendingInfo()
        {
            return _lendBooks;
        }

        public Book GetValidBook(string bookTitle)
        {
            Book? foundBook = SearchBookInfo(bookTitle);

            if (foundBook != null)
            {
                return foundBook;
            }
            else
            {
                return new Book();
            }
        }

        public Member GetValidMember(int memberId)
        {
            Member? foundMember = SearchMemberInfo(memberId);

            if (foundMember != null)
            {
                return foundMember;
            }
            else
            {
                return new Member();
            }
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
