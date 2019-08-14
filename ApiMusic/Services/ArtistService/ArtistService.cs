using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistent;

namespace Services.ArtistService
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _dbContext;
        public ArtistService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistAsync()
        {
            List<Artist> artists = new List<Artist>();
            try
            {
                List<Artist> listArtist = await _dbContext.Artists.ToListAsync();

                artists = listArtist;
            }
            catch 
            {
                artists = null;
                
            }

            return artists;
        }

        public async Task<Artist> GetArtistAsync(Guid id)
        {
            Artist artist = new Artist();
            try
            {
                artist = await _dbContext.Artists
                    .Where(ar => ar.Id == id)
                    .SingleOrDefaultAsync();

            }
            catch (Exception)
            {

                artist = null;
            }

            return artist;
        }

        public async Task<ArtistDTO> InsertArtistAsync(Artist artist)
        {
            ArtistDTO newArtist = new ArtistDTO();
            try
            {
                artist.Id = Guid.NewGuid();
                await _dbContext.Artists.AddAsync(artist);

                var save = await _dbContext.SaveChangesAsync();
                if (save == 1)
                {
                    newArtist.NameArtist = artist.NameArtist;
                    newArtist.Country = artist.Country;
                    newArtist.Gender = artist.Gender;
                    newArtist.Id = artist.Id;
                }
                else
                {
                    newArtist = null;
                }

            }
            catch 
            {

                newArtist = null;
            }
            return newArtist;
        }

        public async Task<Artist> UpdateArtistAsync(Guid id, Artist artist)
        {
            Artist model = new Artist();
            try
            {
                Artist artistUpdate = await _dbContext.Artists.Where(ar => ar.Id == id).FirstOrDefaultAsync();

                if (artistUpdate != null)
                {
                    artistUpdate.NameArtist = artist.NameArtist;
                    artistUpdate.Gender = artist.Gender;
                    artistUpdate.Country = artist.Country;

                    var save = await _dbContext.SaveChangesAsync();

                    if(save == 1)
                    {
                        model = artistUpdate;
                    }
                }
                else
                {
                    model = null;
                }
            }
            catch 
            {

                model = null;
            }
            return model;
        }
    }
}
