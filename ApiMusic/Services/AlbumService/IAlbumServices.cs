using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.AlbumService
{
    public interface IAlbumServices
    {
        Task<AlbumDTO> InsertAlbum(AlbumDTO album);
        Task<AlbumDTO> UpdateAlbum(AlbumDTO album);
        Task<bool> DeleteAlbum(Guid id);
    }
}
