using BonjoAPI.Entities;
using BonjoAPI.Others;
using BonjoAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BonjoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext dataContext;

        public UserService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public UserEntity Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = dataContext.Users.SingleOrDefault(x => x.Username == username);
            if (user == null)
                return null;

            if (!VerifiPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public UserEntity Create(UserEntity user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required!");

            if (dataContext.Users.Any(x => x.Username == user.Username))
                throw new Exception($"Username '{user.Username}' is already taken!");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            dataContext.Users.Add(user);
            dataContext.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            var user = dataContext.Users.Find(id);
            if (user != null)
            {
                dataContext.Users.Remove(user);
                dataContext.SaveChanges();
            }
        }

        public IEnumerable<UserEntity> GetAll() => dataContext.Users;

        public UserEntity GetById(int id) => dataContext.Users.Find(id);

        public void Update(UserEntity user, string password = null)
        {
            var updatedUser = dataContext.Users.Find(user.ID);
            if (updatedUser == null)
                throw new Exception("User not found");

            if (!string.IsNullOrWhiteSpace(user.Username) && user.Username != updatedUser.Username)
            {
                if (dataContext.Users.Any(x => x.Username == user.Username))
                    throw new Exception($"Username '{user.Username}' is already taken!");

                updatedUser.Username = user.Username;
            }

            if (!string.IsNullOrWhiteSpace(user.Firstname))
                updatedUser.Firstname = user.Firstname;

            if (!string.IsNullOrWhiteSpace(user.Lastname))
                updatedUser.Lastname = user.Lastname;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                updatedUser.PasswordHash = passwordHash;
                updatedUser.PasswordSalt = passwordSalt;
            }

            dataContext.Users.Update(updatedUser);
            dataContext.SaveChanges();
        }

        private static bool VerifiPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (passwordHash.Length != 64 || passwordSalt.Length != 128)
                throw new ArgumentException("Invalid length of password hash or/and password salt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i])
                        return false;
            }

            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}