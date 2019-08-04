
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Services.AlbumService
{
    public class AlbumService : IAlbumServices
    {
        public Task<bool> DeleteAlbum(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumDTO> InsertAlbum(AlbumDTO album)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumDTO> UpdateAlbum(AlbumDTO album)
        {
            throw new NotImplementedException();
        }
    }
}
