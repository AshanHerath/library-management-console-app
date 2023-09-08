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

        private string[] _errorMessages = new string[Enum.GetValues(typeof(BookErrorField)).Length];

        public enum BookErrorField
        {
            BookIdError = 1,
            TitleError = 2,
            DescriptionError = 3,
            AuthorError = 4,
            IsbnError = 5,
            IsAvailableError = 6,
        }

        public Book() { }

        public Book(string bookTitle, string bookDescription, string bookAuthor, string bookISBN)
        {
            _bookId = 0;
            _bookTitle = bookTitle;
            _bookDescription = bookDescription;
            _bookAuthor = bookAuthor;
            _bookISBN = bookISBN;
            _bookIsAvailable = true;
        }

        public int BookId
        {
            get { return _bookId; }
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
                    _errorMessages[(int)BookErrorField.TitleError] = null;
                }
                else
                {
                    _errorMessages[(int)BookErrorField.TitleError] = "Book Title can't be null or empty.";
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
                    _errorMessages[(int)BookErrorField.DescriptionError] = null;
                }
                else
                {
                    _errorMessages[(int)BookErrorField.DescriptionError] = "Book Description can't be null or empty.";
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
                    _errorMessages[(int)BookErrorField.AuthorError] = null;
                }
                else
                {
                    _errorMessages[(int)BookErrorField.AuthorError] = "Book Author can't be null or empty.";
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
                    _errorMessages[(int)BookErrorField.IsbnError] = null;
                }
                else
                {
                    _errorMessages[(int)BookErrorField.IsbnError] = "Book ISBN can't be null or empty.";
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

        public string GetError(BookErrorField field)
        {
            int index = (int)field;
            if (index >= 0 && index < _errorMessages.Length)
            {
                return _errorMessages[index];
            }
            else
            {
                return null; 
            }
        }

        public int CheckError()
        {
            foreach (var errorMessage in _errorMessages)
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
