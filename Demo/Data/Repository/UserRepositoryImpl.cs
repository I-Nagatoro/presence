using Demo.Data.Exceptions;
using Demo.Data.LocalData;
using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Data.Repository
{
    public class UserRepositoryImpl
    {
        private List<UserLocalEnity> _users;

        public UserRepositoryImpl()
        {
            _users = LocalStaticData.users;
        }

        public IEnumerable<UserLocalEnity> GetAllUsers => _users;

        public bool RemoveUserById(int userId)
        {
            var user = _users.FirstOrDefault(u => u.ID == userId);
            if (user == null) throw new UserNotFoundException(userId);

            _users.Remove(user);
            return true;
        }

        public UserLocalEnity? UpdateUser(UserLocalEnity user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Guid == user.Guid);
            if (existingUser == null) throw new UserNotFoundException(user.ID);

            existingUser.FIO = user.FIO;
            existingUser.GroupID = user.GroupID;

            return existingUser;
        }
    }
}
