using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Client.Models
{
    public class User
    {
        private long _userId;
        private string _name;
        private bool _isMale;
        private string _mobileNumber;

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

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
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

        public string MobileNumber
        {
            get
            {
                return _mobileNumber;
            }

            set
            {
                _mobileNumber = value;
            }
        }

    }
}
