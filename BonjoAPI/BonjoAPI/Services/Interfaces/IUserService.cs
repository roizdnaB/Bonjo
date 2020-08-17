using BonjoAPI.Entities;
using System.Collections.Generic;

namespace BonjoAPI.Services.Interfaces
{
    public interface IUserService
    {
        UserEntity Authenticate(string username, string password);

        IEnumerable<UserEntity> GetAll();

        UserEntity GetById(int id);

        UserEntity Create(UserEntity user, string password);

        void Update(UserEntity user, string password = null);

        void Delete(int id);
    }
}