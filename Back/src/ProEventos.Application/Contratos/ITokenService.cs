using ProEventos.Application.DTO;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDTO userUpdateDTO);
    }
}
