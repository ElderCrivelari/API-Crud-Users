using CRUDUsersAPI.Data;
using CRUDUsersAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CRUDUsersAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel Add(UserModel userAdd)
        {
            _dbContext.Users.Add(userAdd);
            _dbContext.SaveChanges();



            return userAdd;
        }

        public bool Delete(int id)
        {
            UserModel userDatabase = GetById(id);
            if (userDatabase == null) throw new Exception("Database Error : User not found");

            _dbContext.Users.Remove(userDatabase);
            _dbContext.SaveChanges();

            return true;
        }

        public List<UserModel> GetAll()
        {
            return  _dbContext.Users.ToList();
        }

        public UserModel GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public UserModel Update(UserModel userUpd, int id)
        {
            UserModel userDatabase =  GetById(id);
            if (userDatabase == null) throw new Exception("Database Error : User not found");

            userDatabase.Name = userUpd.Name;
            userDatabase.Email = userUpd.Email;
            userDatabase.Password = userUpd.Password;

            _dbContext.Update(userDatabase);
            _dbContext.SaveChanges();
            return userDatabase;

        }
    }
}
