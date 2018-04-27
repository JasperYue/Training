using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Common.BusinessModel;
using Training.Data.Providers;

namespace Training.Service.BusinessLogic
{
    public class UserBusinessLogic : IUserBusinessLogic
    {

        #region Private Members

        private IUserDataService _userDataService = null;

        #endregion

        #region Constructor

        //public UserBusinessLogic(IUserDataService userDataService)
        //{
        //    _userDataService = userDataService;
        //}

        public UserBusinessLogic()
        {
            _userDataService = new UserDataProvider();
        }

        #endregion

        public void AddUser(UserBusinessModel userBL)
        {
            var userList = GetAllUsers();

            if (0 == userList.Count)
            {
                userBL.UserId = 1;
            }
            else
            {
                userBL.UserId = userList.OrderByDescending(x => x.UserId).FirstOrDefault().UserId + 1;

            }
            _userDataService.AddUser(userBL.ToEntityModel());
        }

        public IList<UserBusinessModel> GetAllUsers()
        {
            IList<UserBusinessModel> userBL = new List<UserBusinessModel>();

            var userList = _userDataService.GetAllUsers();
            foreach (var user in userList)
            {
                userBL.Add(user.ToBusinessModel());
            }

            return userBL;
        }

    }
}
