using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Services.PlayListService
{
    public class PlayListService : IPlayListService
    {
        public Task<bool> DeletePlayList(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayListDTO> InsertPlayList(PlayListDTO playList)
        {
            throw new NotImplementedException();
        }

        public Task<PlayListMusicDTO> InsertPlayListMusic(PlayListMusicDTO playListMusic)
        {
            throw new NotImplementedException();
        }

        public Task<PlayListDTO> UpdatePlayList(PlayListDTO playList)
        {
            throw new NotImplementedException();
        }
    }
}
