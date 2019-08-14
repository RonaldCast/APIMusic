
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistent;

namespace Services.AlbumService
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _dbContext;
        public AlbumService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteAlbumAsync(Guid id)
        {
            bool response = false;
            try
            {
                var album = await _dbContext.Albums.Where(p => p.Id == id).SingleOrDefaultAsync();

                if (album != null )
                {
                    _dbContext.Albums.Remove(album);
                    var save = await _dbContext.SaveChangesAsync();
                    if (save == 1)
                    {
                        response = true;
                    }
                    else
                    {
                        response = false;
                    }
                }
            }
            catch
            {

                response = false;
            }

            return response;
        }

        public async Task<Album> GetAlbum(Guid id)
        {
            Album response = new Album();
            try
            {
                response = await _dbContext.Albums
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
   
            }
            catch
            {

                response = null;
            }

            return response;
        }

        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            List<Album> response = new List<Album>();
            try
            {
                response = await _dbContext.Albums.ToListAsync();
            }
            catch 
            {

                response = null;
            }

            return response;
        }

        public async Task<Album> InsertAlbumAsync(Album album)
        {
            Album response = new Album();
            try
            {
                album.Id = Guid.NewGuid();
                album.DatePublic = DateTimeOffset.Now;
                await _dbContext.Albums.AddAsync(album);
                var save = await _dbContext.SaveChangesAsync();
                if (save == 1)
                {
                    response = album;
                }
                else
                {
                    response = null;
                }
            }
            catch 
            {

                response = null;
            }
            return response;

        }

        public async  Task<Album> UpdateAlbumAsync(Guid id ,Album album)
        {
            Album response = new Album();

            try
            {
                response = await _dbContext.Albums
                    .Where(p => p.Id == id)
                    .SingleOrDefaultAsync();
                if (response != null)
                {
                    response.ArtistId = album.ArtistId;
                    response.Description = album.Description;
                    response.Title = album.Title;

                    var save = await _dbContext.SaveChangesAsync();
                    if(save != 1)
                    {
                        response = null;
                    }
                }
                
            }
            catch 
            {

                response = null;
            }

            return  response;
        }
    }
}
