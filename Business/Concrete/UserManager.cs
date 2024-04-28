using Business.Abstract;
using Core.Utilities.Hashing;
using DataAccess.Abstract;
using Enitities.Concrete;
using Enitities.Dtos;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(RegisterAuthDto authDto)
        {
            byte[] passwordHash, paswordSalt;
            HashingHelper.CreatePassword(authDto.Password, out passwordHash, out paswordSalt);

            User user =new User();
            user.Id = 0;
            user.Email= authDto.Email;
            user.Name= authDto.Name;
            user.PasswordHash= passwordHash;
            user.PasswordSalt= paswordSalt;
            user.ImageUrl= authDto.ImageUrl;

            _userDal.Add(user);
        }

        public User GetByEmail(string email)
        {
           var result =_userDal.Get(p=>p.Email==email);
            return result;  
        }

        public List<User> GetList()
        {
            return _userDal.GetAll();
        }
    }
}
