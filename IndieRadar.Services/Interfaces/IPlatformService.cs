using System.Collections.Generic;
using System.Threading.Tasks;
using IndieRadar.Services.DTO;

namespace IndieRadar.Services.Interfaces
{
    public interface IPlatformService
    {
        Task<ICollection<PlatformDTO>> GetPlatformsAsync();
    }
}