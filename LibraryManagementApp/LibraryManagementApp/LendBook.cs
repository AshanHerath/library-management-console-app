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
        private DateTime _startDate;
        private DateTime _returnDate;

        private string[] _errorMessages = new string[Enum.GetValues(typeof(LendBookErrorField)).Length];

        public enum LendBookErrorField
        {
            LendBookIdError = 1,
            LendBookError = 2,
            MemberError = 3,
            ReturnDateError = 4,
        }

        public LendBook(Book book, Member member, DateTime returnDate)
        {
            this._lendBookId = LibrarySystem.GenerateLendBookId();
            this._book = book;
            this._member = member;
            this._startDate = DateTime.Now;
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
                    _errorMessages[(int)LendBookErrorField.LendBookError] = null;
                }
                else
                {
                    _errorMessages[(int)LendBookErrorField.LendBookError] = "Book can't be null or empty.";
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
                    _errorMessages[(int)LendBookErrorField.MemberError] = null;
                }
                else
                {
                    _errorMessages[(int)LendBookErrorField.MemberError] = "Member Address can't be null or empty.";
                }
            }
        }

        public DateTime ReturnDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                if (value != DateTime.MinValue && value > DateTime.Now)
                {
                    _startDate = value;
                    _errorMessages[(int)LendBookErrorField.ReturnDateError] = null;
                }
                else
                {
                    _errorMessages[(int)LendBookErrorField.ReturnDateError] = "Return date must be a valid future date.";
                }
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
        }


        public string GetError(LendBookErrorField field)
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
