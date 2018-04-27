using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Training.Common.BusinessModel
{
    [DataContract]
    public class UserBusinessModel
    {
        #region Constructor

        public UserBusinessModel()
        {
        }

        #endregion

        #region Public properties

        [DataMember]
        public long UserId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public UserGenderEnum Gender { get; set; }
        [DataMember]
        public string Mobile { get; set; }

        #endregion
    }
}
