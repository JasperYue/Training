using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data.Entities;

namespace Training.Data.Providers
{
    public interface IUserDataService
    {
        void AddUser(UserEntity user);

        IList<UserEntity> GetAllUsers();
    }
}
