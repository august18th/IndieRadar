using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Model.Models;
using IndieRadar.Services.DTO;
using IndieRadar.Services.Interfaces;

namespace IndieRadar.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<GenreDTO>> GetGenresAsync()
        {
            var genres = await _genreRepository.GetItemsAsync();
            return _mapper.Map<ICollection<Genre>, ICollection<GenreDTO>>(genres);
        }
    }
}