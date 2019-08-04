using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Services.MusicService
{
    public class MusicService : IMusicService
    {
        public Task<bool> DeleteMusic(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MusicDTO> InsertMusic(MusicDTO music)
        {
            throw new NotImplementedException();
        }

        public Task<MusicArtistDTO> InsertMusicArtist(MusicArtistDTO musicArtist)
        {
            throw new NotImplementedException();
        }

        public Task<MusicDTO> UpdateMusic(MusicDTO music)
        {
            throw new NotImplementedException();
        }
    }
}
