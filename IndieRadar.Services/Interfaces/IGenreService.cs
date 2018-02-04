using System.Collections.Generic;
using System.Threading.Tasks;
using IndieRadar.Model.Models;
using IndieRadar.Services.DTO;

namespace IndieRadar.Services.Interfaces
{
    public interface IGenreService
    {
        Task<ICollection<GenreDTO>> GetGenresAsync();
    }
}