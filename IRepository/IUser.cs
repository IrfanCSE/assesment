using primetechmvc.DTO;

namespace primetechmvc.IRepository
{
    public interface IUser
    {
         public Task<LoginResponse> LoginUser(UserModel obj);
    }
}