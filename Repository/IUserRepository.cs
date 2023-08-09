using CRUDUsersAPI.Models;

namespace CRUDUsersAPI.Repository
{
    public interface IUserRepository
    {
        public UserModel GetById(int id);
        public List<UserModel> GetAll();
        public UserModel Add(UserModel userAdd);
        public UserModel Update(UserModel userUpd,int id);
        public bool Delete(int id);
    }
}
