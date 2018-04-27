using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Common.BusinessModel;

namespace Training.Service.BusinessLogic
{
    public interface IUserBusinessLogic
    {
        void AddUser(UserBusinessModel userBL);

        IList<UserBusinessModel> GetAllUsers();
    }
}
