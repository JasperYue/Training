using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Client
{
    public class UserManagement
    {
        private string _IdHeader = "ID";
        private string _nameHeader = "Name";
        private string _genderHeader = "Gender";
        private string _mobleNumberHeader = "Moble Number";
        private Object _dataContext;
        private List<string> _header = null;

        public UserManagement(object obj)
        {
            _dataContext = obj;
            _header = new List<string>();
            Initialization();
        }

        public void PrintList()
        {
            PrintHeader();
            PrintHorizontalRule();
            PrintListContent();
        }

        #region Private Methods

        private void Initialization()
        {
            _header.Add(_IdHeader);
            _header.Add(_nameHeader);
            _header.Add(_genderHeader);
            _header.Add(_mobleNumberHeader);
        }

        private void PrintHeader()
        {
            Console.WriteLine();
            foreach (var s in _header)
            {
                Console.Write(s + "\t");
                if (s.Equals(_nameHeader))
                {
                    Console.Write("\t");
                }
            }
        }

        private void PrintListContent()
        {
            var dc = _dataContext as Training.Client.ViewModel.UserManagementViewModel;

            if (null != dc && null != dc.UserList)
            {
                foreach (var u in dc.UserList)
                {
                    Console.Write(u.UserID + "\t");
                    Console.Write(u.Name + "\t");
                    Console.Write((u.IsMale ? "Male" : "Female") + "\t");
                    Console.Write(u.MobileNumber + "\t");
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private void PrintHorizontalRule()
        {
            Console.WriteLine();
            Console.Write("------------------------------------------------------------");
            Console.WriteLine();
        }

        #endregion

    }
}
