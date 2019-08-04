using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.PlayListService
{
    public interface IPlayListService
    {
        Task<PlayListDTO> InsertPlayList(PlayListDTO playList);
        Task<PlayListDTO> UpdatePlayList(PlayListDTO playList);
        Task<bool> DeletePlayList(Guid id);
        Task<PlayListMusicDTO> InsertPlayListMusic(PlayListMusicDTO playListMusic);
    }
}
