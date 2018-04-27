using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Common;
using Training.Common.BusinessModel;
using Training.Data.Entities;

namespace Training.Service.BusinessLogic
{
    public static class UserExtension
    {
        public static UserBusinessModel ToBusinessModel(this UserEntity userEntity)
        {
            if (null == userEntity)
            {
                return null;
            }

            UserBusinessModel userBusinessModel = new UserBusinessModel();
            userBusinessModel.UserId = userEntity.UserId;
            userBusinessModel.FirstName = userEntity.FirstName;
            userBusinessModel.LastName = userEntity.LastName;
            userBusinessModel.Mobile = userEntity.Mobile;

            if (UserGenderEnum.FEMALE.ToString().Equals(userEntity.Gender, StringComparison.CurrentCultureIgnoreCase))
            {
                userBusinessModel.Gender = UserGenderEnum.FEMALE;
            }
            else
            {
                userBusinessModel.Gender = UserGenderEnum.MALE;
            }

            return userBusinessModel;
        }

        public static UserEntity ToEntityModel(this UserBusinessModel userBL)
        {

            if (null == userBL)
            {
                return null;
            }

            return new UserEntity()
            {
                UserId = userBL.UserId,
                FirstName = userBL.FirstName,
                LastName = userBL.LastName,
                Gender = userBL.Gender.ToString(),
                Mobile = userBL.Mobile
            };
        }

    }
}
