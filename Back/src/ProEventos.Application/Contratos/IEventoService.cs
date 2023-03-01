using ProEventos.Application.DTO;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDTO> AddEventos(EventoDTO model);
        Task<EventoDTO> UpdateEventos(int eventoId, EventoDTO model);
        Task<bool> DeleteEventos(int eventoId);
        Task<EventoDTO[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<EventoDTO[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDTO> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);

    }
}
