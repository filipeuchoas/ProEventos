using Microsoft.AspNetCore.Identity;
using ProEventos.Application.DTO;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IAccountService
    {
        Task<bool> UserExist(string username);
        Task<UserUpdateDTO> GetUserByUserNameAsync(string username);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDTO, string password);
        Task<UserDTO> CreateAccountAsync(UserDTO userDTO);
        Task<UserUpdateDTO> UpdateAccountAsync(UserUpdateDTO userUpdateDTO);
    }
}
