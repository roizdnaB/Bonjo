using BonjoAPI.Entities;
using System.Collections.Generic;

namespace BonjoAPI.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO Authenticate(string username, string password);

        IEnumerable<UserDTO> GetAll();

        UserDTO GetById(int id);

        UserDTO Create(UserDTO user, string password);

        void Update(UserDTO user, string password = null);

        void Delete(int id);
    }
}