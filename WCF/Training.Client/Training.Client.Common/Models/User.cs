using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Client.Common.Models
{
    public class User
    {
        private long _userId;
        private string _firstName;
        private string _lastName;
        private bool _isMale;
        private string _mobleNumber;

        public long UserID
        {
            get
            {
                return _userId;
            }

            set
            {
                _userId = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public bool IsMale
        {
            get
            {
                return _isMale;
            }

            set
            {
                _isMale = value;
            }
        }

        public string MobleNumber
        {
            get
            {
                return _mobleNumber;
            }

            set
            {
                _mobleNumber = value;
            }
        }
    }
}
