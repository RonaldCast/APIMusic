using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistent;

namespace Services.PlayListService
{
    public class PlayListService : IPlayListService
    {
        private readonly ApplicationDbContext _dbContext;

        public PlayListService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PlayList> AddMusicAsync(PlayListMusicDTO playListMusic)
        {
            PlayList response = new PlayList();

            try
            {
                PlayList play = await _dbContext.PlayLists
                    .Where(p => p.Id == playListMusic.Id)
                    .SingleOrDefaultAsync();
                List<Music> musics = await _dbContext.Musics.ToListAsync();

                List<Music> listMusic = (from music in musics
                                         join m in playListMusic.Music
                                         on music.Id equals m
                                         select new Music
                                         {
                                             Id = music.Id,
                                             Title = music.Title,
                                             Duration = music.Duration,
                                             DatePublic = music.DatePublic,
                                             AlbumId = music.AlbumId
                                         }).ToList();

                PlayList ppo = new PlayList();
                ppo.PlayListMusics = new List<PlayListMusic>();
                foreach ( Music m in listMusic)
                {
                   
                    PlayListMusic playList = new PlayListMusic();
                    playList.Music = m;
                    playList.PlayList = play;

                    ppo.PlayListMusics.Add(playList);
                }

                play.PlayListMusics = ppo.PlayListMusics;
                var save = await _dbContext.SaveChangesAsync();
                if (save >= 1)
                {
                    response = play;
                }
                else
                {
                    response = null;
                }
                
            }
            catch (Exception ex)
            {
                response = null;
                
            }

            return response;
        }

        public async Task<bool> DeletePlayListAsync(Guid id)
        {
            bool response = false;
            try
            {
                PlayList playList = await _dbContext.PlayLists
                    .Where(p => p.Id == id)
                    .SingleOrDefaultAsync();
                if (playList != null)
                {
                    _dbContext.Remove(playList);
                    var save = await _dbContext.SaveChangesAsync();
                    if (save >=1)
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

        public async Task<IEnumerable<PlayList>> GetAllPlayListAsync(Guid idUser)
        {
            List<PlayList> response = new List<PlayList>();
            try
            {
                response = await _dbContext.PlayLists
                    .Where(p => p.UserId == idUser).ToListAsync();
             
            }
            catch 
            {

                response = null;
            }

            return response;
        }
    
        public async Task<PlayListInfoDTO> GetPlayList(Guid id)
        {
            PlayListInfoDTO response = new PlayListInfoDTO();
            try
            {
                 PlayList playList = await _dbContext.PlayLists
                    .Include(p => p.PlayListMusics)
                    .Where(p => p.Id == id).SingleOrDefaultAsync();

   
                
                if (playList != null)
                {

                    List<Music> musics = await _dbContext.Musics.ToListAsync();

                    List<Music> musicsPlayList = (from music in musics
                                                  join play in playList.PlayListMusics
                                                  on music.Id equals play.MusicId
                                                  select new Music
                                                  {
                                                      Id = music.Id,
                                                      Title = music.Title,
                                                      Duration = music.Duration,
                                                      AlbumId = music.AlbumId
                                                  }).ToList();
                    response.Title = playList.Title;
                    response.Description = playList.Description;
                    response.musics = musicsPlayList;
                    
                }
            }
            catch 
            {
                response = null;
                
            }

            return response;
        }

        public async Task<PlayList> InsertPlayListAsync(PlayList playList)
        {
            PlayList response = new PlayList();

            try
            {
                User user = await _dbContext.Users
                    .Where(p => p.Id == playList.UserId).SingleOrDefaultAsync();
                playList.User = user;

                await _dbContext.PlayLists.AddAsync(playList);

                var save = await _dbContext.SaveChangesAsync();
                if (save == 1)
                {
                    response = playList;
                }
            }
            catch
            {

                response = null;
            }
            return response;
        }

        public async Task<PlayList> UpdatePlayListAsync(Guid id, PlayList playList)
        {
            PlayList response = new PlayList();
            try
            {
                response = await _dbContext.PlayLists
                    .Where(p => p.Id == id).SingleOrDefaultAsync();
                if (response != null)
                {
                    response.Title = playList.Title;
                    response.Description = playList.Description;

                    var save = await _dbContext.SaveChangesAsync();
                    if (save != 1)
                    {
                        response = null;
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
