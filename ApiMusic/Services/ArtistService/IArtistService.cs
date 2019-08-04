using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.ArtistService
{
    public interface IArtistService
    {
        Task<ArtistDTO> InsertArtist(ArtistDTO artist);
        Task<ArtistDTO> UpdateArtist(ArtistDTO artist);
    }
}
