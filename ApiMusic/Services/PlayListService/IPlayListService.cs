using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.PlayListService
{
    public interface IPlayListService
    {
        Task<PlayList> InsertPlayListAsync(PlayList playList);
        Task<PlayList> UpdatePlayListAsync(Guid id, PlayList playList);
        Task<bool> DeletePlayListAsync(Guid id);
        Task<PlayList> AddMusicAsync(PlayListMusicDTO playListMusic);
        Task<IEnumerable<PlayList>> GetAllPlayListAsync(Guid idUser);
        Task<PlayListInfoDTO> GetPlayList(Guid id);
    }
}
