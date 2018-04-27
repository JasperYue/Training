using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Training.Client.Models;
using Training.Client.UserService;
using System.ServiceModel;

namespace Training.Client.ViewModel
{
    public class UserManagementViewModel
    {
        private ICollection<User> _userList = null;
        private UserServiceClient _userService;

        public UserManagementViewModel()
        {
            _userService = new UserServiceClient();
        }

        public void Initialization()
        {
            _userList = new List<User>();

            IList<UserBusinessModel> userList = _userService.GetAllUsers();

            foreach(var user in userList)
            {
                _userList.Add(new User()
                {
                    UserID = user.UserId,
                    Name = user.LastName + user.FirstName,
                    IsMale = user.Gender == UserService.UserGenderEnum.FEMALE ? false : true,
                    MobileNumber = user.Mobile,
                });
            }
        }

        public void AddUser()
        {
            Console.Write("Please input first name : ");
            string firstName = Console.ReadLine();
            Console.Write("Please input last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Please input gender ( 0 - FEMALE, 1 - MALE) : ");
            string gender = Console.ReadLine();
            Console.Write("Please input mobile : ");
            string mobile = Console.ReadLine();

            //backend validation

            try
            {
                _userService.AddUser(new UserBusinessModel()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = "1".Equals(gender) ? UserGenderEnum.MALE : UserGenderEnum.FEMALE,
                    Mobile = mobile,
                });
            }
            catch (FaultException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[Error Message] : " + e.Message);
                Console.ResetColor();
            }
        }

        public ICollection<User> UserList
        {
            get
            {
                return _userList;
            }

            set
            {
                _userList = value;
            }
        }

    }
}
