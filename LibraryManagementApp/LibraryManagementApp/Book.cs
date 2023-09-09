using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    internal class Book
    {
        private int _bookId;
        private string _bookTitle;
        private string _bookDescription;
        private string _bookAuthor;
        private string _bookISBN;
        private bool _bookIsAvailable;
        private Library _library = new Library();

        private List<string> _errors = new List<string>();

        public Book() { }

        public Book(string bookTitle, string bookDescription, string bookAuthor, string bookISBN)
        {
            this._bookId = LibrarySystem.GenerateBookId();
            this._bookTitle = bookTitle;
            this._bookDescription = bookDescription;
            this._bookAuthor = bookAuthor;
            this._bookISBN = bookISBN;
            this._bookIsAvailable = true;
        }

        public int BookId
        {
            get { return _bookId; }
            set 
            {
                if (_library.GetValidBook != null)
                {
                    this._bookId = value;
                }
                else
                {
                    _errors.Add("Book Id is not valid.");
                }
                
            }
        }

        public string BookName
        {
            get
            {
                return _bookTitle;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _bookTitle = value;
                }
                else
                {
                    _errors.Add("Book Title can't be null or empty.");
                }
            }
        }

        public string BookDescription
        {
            get
            {
                return _bookDescription;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _bookDescription = value;
                }
                else
                {
                    _errors.Add("Book Description can't be null or empty.");
                }
            }
        }

        public string BookAuthor
        {
            get { return _bookAuthor; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _bookAuthor = value;
                }
                else
                {
                    _errors.Add("Book Author can't be null or empty.");
                }
            }
        }

        public string BookIsbn
        {
            get { return _bookISBN; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _bookISBN = value;
                }
                else
                {
                    _errors.Add("Book ISBN can't be null or empty.");
                }
            }
        }

        public bool BookIsAvailable
        {
            get { return _bookIsAvailable; }
            set
            {
                _bookIsAvailable = value;
            }
        }

        public int CheckError()
        {
            return _errors.Count;
        }

        public string[] GetErrors()
        {
            return _errors.ToArray();
        }
    }
}
