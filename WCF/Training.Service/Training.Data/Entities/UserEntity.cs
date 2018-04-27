using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data.Entities
{
    public class UserEntity
    {
        #region Private Members

        private long _userId;
        private string _firstName;
        private string _lastName;
        private string _gender;
        private string _mobile;

        #endregion

        #region Public Properties

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }

        #endregion
    }
}
