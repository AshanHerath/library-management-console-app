using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryManagementApp.Member;

namespace LibraryManagementApp
{
    internal class LendBook
    {

        private int _lendBookId;
        private Book _book;
        private Member _member;
        private DateTime _issueDate;
        private DateTime _returnDate;

        private List<string> _errors = new List<string>();

        public LendBook() { }

        public LendBook(Book book, Member member, DateTime issueDate, DateTime returnDate)
        {
            this._lendBookId = LibrarySystem.GenerateLendBookId();
            this._book = book;
            this._member = member;
            this._issueDate = issueDate;
            this._returnDate = returnDate;
        }

        public int LendBookId
        {
            get
            {
                return this._lendBookId;
            }
        }

        public Book LendBookName
        {
            get
            {
                return _book;
            }
            set
            {
                if (value != null)
                {
                    _book = value;
                }
                else
                {
                    _errors.Add("Book can't be null or empty.");
                }
            }
        }

        public Member MemberOfLend
        {
            get
            {
                return _member;
            }
            set
            {
                if (value != null)
                {
                    _member = value;
                }
                else
                {
                    _errors.Add("Member Address can't be null or empty.");
                }
            }
        }

        public DateTime ReturnDate
        {
            get
            {
                return _returnDate;
            }
            //set
            //{
            //    if (value != DateTime.MinValue && value > DateTime.Now)
            //    {
            //        _returnDate = value;
            //    }
            //    else
            //    {
            //        _errors.Add("Return date must be a valid future date.");

            //    }
            //}
        }

        public DateTime IssueDate
        {
            get
            {
                return _issueDate;
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
