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
        private Library _library = new Library();

        private List<string> _errors = new List<string>();


        public Member() { }

        public Member(string memberName, string memberAddress, string memberNic)
        {
            _memberId = LibrarySystem.GenerateMemberId();
            _memberName = memberName;
            _memberAddress = memberAddress;
            _memberNic = memberNic;
        }

        public int MemberId 
        {  
            get 
            { 
                return this._memberId; 
            } 
            set
            {
                if (_library.GetValidMember != null)
                {
                    this._memberId = value;
                }
                else
                {
                    _errors.Add("Member Id is not valid.");
                }

            }
        }

        public string MemberName 
        { 
            get 
            { 
                return this._memberName; 
            }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._memberName = value;
                }
                else
                {
                    _errors.Add("Member name can't be null or empty.");
                }
            } 
        }

        public string MemberAddress 
        { 
            get
            {  
                return this._memberAddress; 
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._memberAddress = value;
                }
                else
                {
                    _errors.Add("Member Address can't be null or empty.");
                }
            }
        }

        public string MemberNic 
        { 
            get 
            { 
                return this._memberNic;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._memberNic = value;
                }
                else
                {
                    _errors.Add("Member NIC can't be null or empty.");
                }
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
