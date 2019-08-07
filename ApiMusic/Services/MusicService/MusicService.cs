using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistent;

namespace Services.MusicService
{
    public class MusicService : IMusicService
    {

        private readonly ApplicationDbContext _dbContext;
        public MusicService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteMusicAsync(Guid id)
        {
            bool response = false;
            try
            {
                Music music = await _dbContext.Musics.Where(p => p.Id == id).SingleOrDefaultAsync();

                if (music != null)
                {
                     _dbContext.Remove(music);
                    var save = await _dbContext.SaveChangesAsync();

                    if (save == 1)
                    {
                        response = true;
                    }

                }

            }   
            catch 
            {

                response = false;
            }

            return response; 


        }

        public async Task<Music> GetMusicAsync(Guid id)
        {
            Music response = new Music();
            try
            {
                response = await _dbContext.Musics
                    .Where(p => p.Id == id)
                    .SingleOrDefaultAsync();

            }
            catch 
            {
                response = null;
                
            }

            return response; 
        }

        public async Task<IEnumerable<Music>> GetMusicsAsync()
        {
            List<Music> musics = new List<Music>();
            try
            {
                musics = await _dbContext.Musics.ToListAsync();
            }
            catch 
            {

                musics = null;
            }
            return musics;

        }

        public async Task<Music> InsertMusicAsync(Music music)
        {
            Music response = new Music();
            try
            {
                music.DatePublic = DateTimeOffset.Now;

                List<Artist> artists = await _dbContext.Artists.ToListAsync();

                List<Artist> artistMusic = 
                    (from artist in artists
                     join artistM in music.MusicArtists
                     on artist.Id equals artistM.ArtistId
                     select new Artist {
                                       Id  = artist.Id,
                                       NameArtist = artist.NameArtist,
                                       Country = artist.Country,
                                       Gender = artist.Gender
                     }).ToList();

                if(artistMusic.Count != 0)
                {
                    music.MusicArtists = new List<MusicArtist>();
                   foreach (Artist art in artistMusic)
                    {
                        MusicArtist musicArtist = new MusicArtist();
                        musicArtist.Artist = art;
                        musicArtist.Music = music;
                        music.MusicArtists.Add(musicArtist);
                    }

                    await _dbContext.Musics.AddAsync(music);

                    var save = await _dbContext.SaveChangesAsync();
                    if (save != 1)
                    {
                        response = music;
                    }
                }
                                           
            }
            catch
            {

                response = null;
            }

            return response;
        }

        public async Task<Music> UpdateMusicAsync(Guid id, Music music)
        {
            Music response = new Music();
            try
            {

                List<Artist> artists = await _dbContext.Artists.ToListAsync();
                response = await _dbContext.Musics.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (response != null)
                {
                    response.Duration = music.Duration;
                    response.Title = music.Title;

                   var save = await _dbContext.SaveChangesAsync();
                   if (save != 1)
                   {
                      response = music;
                   }
                    
                }
            }
            catch
            {

                response = null;
            }

            return response;
        }
    }
}
