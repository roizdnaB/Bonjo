using BonjoAPI.Entities;
using BonjoAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BonjoAPI.Services
{
    public class UserService : IUserService
    {
        
        public UserEntity Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserEntity Create(UserEntity user, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserEntity user, string password = null)
        {
            throw new NotImplementedException();
        }
    }
}