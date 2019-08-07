using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.MusicService
{
    public interface IMusicService
    {
        Task<Music> InsertMusicAsync(Music music);
        Task<bool> DeleteMusicAsync(Guid id);
        Task<Music> UpdateMusicAsync(Guid id, Music music);
        Task<Music> GetMusicAsync(Guid id);
        Task<IEnumerable<Music>> GetMusicsAsync();
    }
}
