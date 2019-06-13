using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class UserLogic : BaseLogic
    {
        public List<UserModel> GetAllUsers()
        {
            return GetUser()
                .ToList();
        }
        public UserModel GetOneUser(string username)
        {
            return GetUser()
                .Where(u => username == u.userName)
                .SingleOrDefault();
        }
        public string GetPassword(string userName)
        {
            return DB.Users
                .Where(u => u.UserName == userName)
                .Select(u => u.Password)
                .SingleOrDefault();
        }
        private IQueryable<UserModel> GetUser()
        {
            return DB.Users
                .Select(u => new UserModel
                {
                    id = u.UserID,
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    userName = u.UserName,
                    phone = u.Phone,
                    email = u.Email,
                    birthDay = u.Birthday,
                    role = u.Role
                }).AsQueryable();
        }
    }
}
