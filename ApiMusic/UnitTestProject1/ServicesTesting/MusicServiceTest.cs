using System;
using System.Collections.Generic;
using System.Text;
using UnitTest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.ServicesStub;
using Services.AlbumService;
using Services.ArtistService;
using Services.MusicService;
using Models;

namespace UnitTest
{
    [TestClass]
    public class MusicServiceTest
    {
        private SqlLifeFake _sqlLifeFake;

        [TestInitialize]
        public void Init()
        {
            _sqlLifeFake = new SqlLifeFake();
        }

        [TestMethod]
        public void Should_Insert_Music()
        {
            //ARRANGE
            var albums = AlbumStub.Albums;
            var artist = ArtistStub.Artist;
            var music = MusicStub.Music;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);
                MusicService musicService = new MusicService(context);

                //ACT
                var insertArtist = artistService.InsertArtistAsync(artist);
                albums[0].ArtistId = insertArtist.Result.Id;
                
                var albumInsert = albumService.InsertAlbumAsync(albums[0]);
                music.AlbumId = albumInsert.Result.Id;

                music.MusicArtists = new List<MusicArtist>();
                MusicArtist musicArtist = new MusicArtist
                {
                    ArtistId = insertArtist.Result.Id
                };

                music.MusicArtists.Add(musicArtist);

                var result = musicService.InsertMusicAsync(music);
                

                //ASSERT
                result.Should().NotBeNull();


            }
        }

        [TestMethod]
        public void Should_Delete_Music()
        {
            //ARRANGE
            var albums = AlbumStub.Albums;
            var artist = ArtistStub.Artist;
            var music = MusicStub.Music;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);
                MusicService musicService = new MusicService(context);

                //ACT
                var insertArtist = artistService.InsertArtistAsync(artist);
                albums[0].ArtistId = insertArtist.Result.Id;

                var albumInsert = albumService.InsertAlbumAsync(albums[0]);
                music.AlbumId = albumInsert.Result.Id;

                music.MusicArtists = new List<MusicArtist>();
                MusicArtist musicArtist = new MusicArtist
                {
                    ArtistId = insertArtist.Result.Id
                };

                music.MusicArtists.Add(musicArtist);
                   
                var deleteMusic = musicService.InsertMusicAsync(music);
                var result = musicService.DeleteMusicAsync(deleteMusic.Result.Id);

                //ASSERT
                result.Result.Should().BeFalse();

            }
        }

        [TestMethod]
        public void Should_Get_Music_By_id()
        {
            //ARRANGE
            var albums = AlbumStub.Albums;
            var artist = ArtistStub.Artist;
            var music = MusicStub.Music;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);
                MusicService musicService = new MusicService(context);

                //ACT
                var insertArtist = artistService.InsertArtistAsync(artist);
                albums[0].ArtistId = insertArtist.Result.Id;

                var albumInsert = albumService.InsertAlbumAsync(albums[0]);
                music.AlbumId = albumInsert.Result.Id;

                music.MusicArtists = new List<MusicArtist>();
                MusicArtist musicArtist = new MusicArtist
                {
                    ArtistId = insertArtist.Result.Id
                };

                music.MusicArtists.Add(musicArtist);

                var getMusic = musicService.InsertMusicAsync(music);
                var result = musicService.GetMusicAsync(getMusic.Result.Id);

                // ASSERT
                result.Result.Should().NotBeNull();
            }
        }

        [TestMethod]
        public void Should_Get_All_Music()
        {
            //ARRANGE
            var albums = AlbumStub.Albums;
            var artist = ArtistStub.Artist;
            var musics = MusicStub.Musics;
            var newInfoMusic = MusicStub.UpdateMusic;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);
                MusicService musicService = new MusicService(context);
                

              
                var insertArtist = artistService.InsertArtistAsync(artist);
                albums[0].ArtistId = insertArtist.Result.Id;

                var albumInsert = albumService.InsertAlbumAsync(albums[0]);
                musics[0].AlbumId = albumInsert.Result.Id;
                musics[1].AlbumId = albumInsert.Result.Id;

                MusicArtist musicArtist = new MusicArtist
                {
                    ArtistId = insertArtist.Result.Id
                };
               
                musics[0].MusicArtists = new List<MusicArtist>();
                musics[1].MusicArtists = new List<MusicArtist>();
                musics[0].MusicArtists.Add(musicArtist);
                musics[1].MusicArtists.Add(musicArtist);

                //ACT
                var first = musicService.InsertMusicAsync(musics[0]);
                var second = musicService.InsertMusicAsync(musics[1]);
                var result = musicService.GetMusicsAsync();

                // ASSERT
                result.Result.Should().HaveCount(2);
            }
        }

        [TestMethod]
        public void Should_Update_Music()
        {
            //ARRANGE
            var albums = AlbumStub.Albums;
            var artist = ArtistStub.Artist;
            var music = MusicStub.Music;
            var updateMusic = MusicStub.UpdateMusic;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);
                MusicService musicService = new MusicService(context);

                //ACT
                var insertArtist = artistService.InsertArtistAsync(artist);
                albums[0].ArtistId = insertArtist.Result.Id;

                var albumInsert = albumService.InsertAlbumAsync(albums[0]);
                music.AlbumId = albumInsert.Result.Id;

                music.MusicArtists = new List<MusicArtist>();
                MusicArtist musicArtist = new MusicArtist
                {
                    ArtistId = insertArtist.Result.Id
                };

                music.MusicArtists.Add(musicArtist);

                var musicInsert = musicService.InsertMusicAsync(music);
                var result = musicService
                    .UpdateMusicAsync(musicInsert.Result.Id, updateMusic);

                // ASSERT
                result.Result.Title.Should().Be(updateMusic.Title);
            }
        }
    }
}
