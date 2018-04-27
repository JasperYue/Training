using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Training.Common;
using Training.Common.BusinessModel;

namespace Training.Service
{
    public static class ValidationHelper
    {
        public static void ValidateUser(UserBusinessModel userBL)
        {
            string errorMessage = string.Empty;

            if (null == userBL)
            {
                errorMessage = "User is invalid.";
                throw new FaultException(errorMessage);
            }

            if (string.IsNullOrEmpty(userBL.FirstName))
            {
                errorMessage = "FirstName cannot be empty";
                throw new FaultException(errorMessage);
            }

            if (string.IsNullOrEmpty(userBL.LastName))
            {
                errorMessage = "LastName cannot be empty";
                throw new FaultException(errorMessage);
            }

            if (string.IsNullOrEmpty(userBL.Mobile))
            {
                errorMessage = "Mobile cannot be empty";
                throw new FaultException(errorMessage);
            }

        }

        public static void ValidateUserGenderEnum(UserGenderEnum userGenderEnum)
        {
            if (userGenderEnum != UserGenderEnum.FEMALE && userGenderEnum != UserGenderEnum.MALE)
            {
                string errorMessage = string.Format("Gender should be '{0}' or '{1}'.", UserGenderEnum.FEMALE, UserGenderEnum.MALE);
                throw new FaultException(errorMessage);
            }
        }
    }
}
