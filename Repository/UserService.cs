using Microsoft.EntityFrameworkCore;
using primetechmvc.DbContexts;
using primetechmvc.DTO;
using primetechmvc.IRepository;
using StoreProcedure;

namespace primetechmvc.Repository
{
    public class UserService : IUser
    {
        private readonly Context _context;
        public UserService(Context context)
        {
            _context = context;
        }

        // Some optimization could be done:
        // use index on the name column to improve the performance of the query.
        // Use more secure way of storing and comparing password like bcrypt or scrypt.
        // Add more validation checks like check if the obj, obj.username and obj.password are not null or empty before querying the database.
        public async Task<LoginResponse> LoginUser(UserModel obj)
        {
            var user = await _context.Users.Where(x => x.Name == obj.username && x.Password == obj.password && x.IsActive == true).FirstOrDefaultAsync();

            if (user == null)
                return new LoginResponse { Message = "Invalid User!" };

            // Generating token with JwtBearer
            obj.Id = user.Id;
            var token = Token.CreateJWT(obj);

            return new LoginResponse
            {
                UserId = user.Id,
                UserName = user.Name,
                Message = "Login Success",
                Token = token
            };
        }
    }
}