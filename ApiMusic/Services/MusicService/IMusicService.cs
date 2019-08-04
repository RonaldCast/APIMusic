using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.MusicService
{
    public interface IMusicService
    {
        Task<MusicDTO> InsertMusic(MusicDTO music);
        Task<bool> DeleteMusic(Guid id);
        Task<MusicDTO> UpdateMusic(MusicDTO music);
        Task<MusicArtistDTO> InsertMusicArtist(MusicArtistDTO musicArtist);
        
    }
}
