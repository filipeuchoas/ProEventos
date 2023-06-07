using ProEventos.Application.DTO;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDTO> AddEventos(int userId, EventoDTO model);
        Task<EventoDTO> UpdateEventos(int userId, int eventoId, EventoDTO model);
        Task<bool> DeleteEventos(int userId, int eventoId);
        Task<EventoDTO[]> GetAllEventosAsync(int userId, bool includePalestrantes = false);
        Task<EventoDTO[]> GetAllEventosByTemaAsync(int userId, string tema, bool includePalestrantes = false);
        Task<EventoDTO> GetEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false);

    }
}
