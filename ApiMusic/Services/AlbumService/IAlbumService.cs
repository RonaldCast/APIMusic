using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.AlbumService
{
    public interface IAlbumService
    {
        Task<Album> InsertAlbumAsync(Album album);
        Task<Album> UpdateAlbumAsync(Guid id, Album album);
        Task<IEnumerable<Album>> GetAlbumsAsync();
        Task<Album> GetAlbum(Guid id);
        Task<bool> DeleteAlbumAsync(Guid id);

    }
}
