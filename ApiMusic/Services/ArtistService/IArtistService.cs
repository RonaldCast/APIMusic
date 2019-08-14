using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.ArtistService
{
    public interface IArtistService
    {
        Task<ArtistDTO> InsertArtistAsync(Artist artist);
        Task<Artist> UpdateArtistAsync(Guid id,  Artist artist);
        Task<Artist> GetArtistAsync(Guid id);
        Task<IEnumerable<Artist>> GetAllArtistAsync();
    }
}
