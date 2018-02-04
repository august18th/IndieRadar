using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Model.Models;
using IndieRadar.Services.DTO;
using IndieRadar.Services.Interfaces;

namespace IndieRadar.Services.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformService(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<PlatformDTO>> GetPlatformsAsync()
        {
            var platforms = _mapper.Map<ICollection<Platform>, ICollection<PlatformDTO>>
                (await _platformRepository.GetItemsAsync());
            return platforms;
        }
    }
}