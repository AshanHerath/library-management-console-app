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

        public Book(string bookId, string bookTitle, string bookDescription, string bookAuthor, string bookISBN) 
        {
            _bookId = 0;
            _bookTitle = bookTitle;
            _bookDescription = bookDescription;
            _bookAuthor = bookAuthor;
            _bookISBN = bookISBN;
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
                    Console.WriteLine("Book Title can't be null");
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
                    Console.WriteLine("Book Description can't be null");
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
                    Console.WriteLine("Book Author can't be null");
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
                    Console.WriteLine("Book ISBN can't be null");
                }
            }
        }

    }
}
