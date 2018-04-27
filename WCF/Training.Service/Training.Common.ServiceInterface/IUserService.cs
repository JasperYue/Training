using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Common.BusinessModel;

namespace Training.Common.ServiceInterface
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        void AddUser(UserBusinessModel userBL);

        [OperationContract]
        IList<UserBusinessModel> GetAllUsers();
    }
}
