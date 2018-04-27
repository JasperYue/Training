using System.Collections.Generic;
using Training.Common.BusinessModel;
using Training.Common.ServiceInterface;
using Training.Service.BusinessLogic;

namespace Training.Service
{
    public class UserService : IUserService
    {
        #region Private Members

        private IUserBusinessLogic _userBusinessLogic = null;

        #endregion

        #region Constructor

        public UserService()
        {
            _userBusinessLogic = new UserBusinessLogic();
        }

        #endregion

        public void AddUser(UserBusinessModel userBL)
        {
            ValidationHelper.ValidateUser(userBL);
            ValidationHelper.ValidateUserGenderEnum(userBL.Gender);
            _userBusinessLogic.AddUser(userBL);
        }

        IList<UserBusinessModel> IUserService.GetAllUsers()
        {
            return _userBusinessLogic.GetAllUsers();
        }

        public void add()
        {
            
        }
    }
}
