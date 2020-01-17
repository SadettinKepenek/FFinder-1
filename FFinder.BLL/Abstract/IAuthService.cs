using System.Threading.Tasks;
using FFinder.Core.DataTransferObjects.User;
using FFinder.Entity.Concrete;
using Microsoft.AspNetCore.Identity;

namespace FFinder.BLL.Abstract
{
    public interface IAuthService
    {

        public UserLoginResponseDto Login(UserLoginRequestDto dto);
        public Task Register(UserAddDto userAddModel, string password);
        public void Update(UserUpdateDto userUpdateModel, string password);
        public void Delete(string username);
        public UserDetailDto GetUser();
    }
}