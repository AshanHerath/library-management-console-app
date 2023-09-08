using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    internal class Member
    {

        private int _memberId;
        private string _memberName;
        private string _memberAddress;
        private string _memberNic;

        private string[] _errorMessages = new string[Enum.GetValues(typeof(MemberErrorField)).Length];

        public enum MemberErrorField
        {
            MemberIdError = 1,
            NameError = 2,
            AddressError = 3,
            NicError = 4,
        }

        public Member() { }

        public Member(string memberName, string memberAddress, string memberNic)
        {
            this._memberId = 0;
            this._memberName = memberName;
            this._memberAddress = memberAddress;
            this._memberNic = memberNic;
        }

        public int MemberId 
        {  
            get 
            { 
                return this._memberId; 
            } 
        }

        public string MemberName 
        { 
            get 
            { 
                return _memberName; 
            }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _memberName = value;
                    _errorMessages[(int)MemberErrorField.NameError] = null;
                }
                else
                {
                    _errorMessages[(int)MemberErrorField.NameError] = "Member name can't be null or empty.";
                }
            } 
        }

        public string MemberAddress 
        { 
            get
            {  
                return _memberAddress; 
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _memberAddress = value;
                    _errorMessages[(int)MemberErrorField.AddressError] = null;
                }
                else
                {
                    _errorMessages[(int)MemberErrorField.AddressError] = "Member Address can't be null or empty.";
                }
            }
        }

        public string MemberNic 
        { 
            get 
            { 
                return _memberNic;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _memberNic = value;
                    _errorMessages[(int)MemberErrorField.NicError] = null;
                }
                else
                {
                    _errorMessages[(int)MemberErrorField.NicError] = "Member NIC can't be null or empty.";
                }
            }
        }

        public string GetError(MemberErrorField field)
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
