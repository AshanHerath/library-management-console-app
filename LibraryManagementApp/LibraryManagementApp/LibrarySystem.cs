using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    internal class LibrarySystem
    {

        Library library;

        private static int nextBookId;
        private static int nextMemberId;
        private static int nextLendBookId;

        public LibrarySystem()
        {
            library = new Library();

            nextBookId = library.GetBookCount();
            nextMemberId = library.GetMemberCount();
            nextLendBookId = library.GetLendBookCount();

        }

        public static int GenerateBookId()
        {
            return nextBookId++;
        }

        public static int GenerateMemberId()
        {
            return nextMemberId++;
        }

        public static int GenerateLendBookId()
        {
            return nextLendBookId++;
        }

    }
}
