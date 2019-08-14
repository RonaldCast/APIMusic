using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.ServicesStub;
using Services.AlbumService;
using Services.ArtistService;

namespace UnitTest
{
    [TestClass]
    public class AlbumServiceTest
    {
        private SqlLifeFake _sqlLifeFake;

        [TestInitialize]
        public void Init()
        {
            _sqlLifeFake = new SqlLifeFake();
        }


        [TestMethod]
        public void Should_Insert_Album()
        {
            //ARRAGEN
            var artist = ArtistStub.Artist;
            var album = AlbumStub.Album;

            using(var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);

                //ACT
                var artistInsert = artistService.InsertArtistAsync(artist);
                album.ArtistId = artistInsert.Result.Id;
                var albumInsert = albumService
                    .InsertAlbumAsync(album);

                //ASSERT
                albumInsert.Result.Title.Should().Be(album.Title);
                albumInsert.Result.Should().NotBeNull();
            }
        }


        [TestMethod]
        public void Should_Update_Album()
        {

            //ARRAGEN
            var artist = ArtistStub.Artist;
            var album = AlbumStub.Album;
            var updateAlbum = AlbumStub.UpdateAlbum;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);
                
                //ACT
                var artistInsert = artistService.InsertArtistAsync(artist);
                album.ArtistId = artistInsert.Result.Id;
                var albumInsert = albumService
                    .InsertAlbumAsync(album);
                updateAlbum.ArtistId = artistInsert.Result.Id;

                var result = albumService
                    .UpdateAlbumAsync(albumInsert.Result.Id, updateAlbum);
                //ASSERT
                result.Result.Title.Should().Be(updateAlbum.Title);
                result.Result.Should().NotBeNull();
            }
        }


        [TestMethod]
        public void Should_Get_All_Album()
        {
            //ARRANGE
            var albums = AlbumStub.Albums;
            var artist = ArtistStub.Artist;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);

                var insertArtist = artistService.InsertArtistAsync(artist);
                albums[0].ArtistId = insertArtist.Result.Id;
                albums[1].ArtistId = insertArtist.Result.Id;

                //ACT
                var fisrt = albumService.InsertAlbumAsync(albums[0]);
                var second = albumService.InsertAlbumAsync(albums[1]);
                var result = albumService.GetAlbumsAsync();

                //ASSERT
                result.Result.Should().HaveCount(2);


            }

        }


        [TestMethod]
        public void Should_Get_Album_By_Id()
        {
            //ARRAGEN
            var artist = ArtistStub.Artist;
            var album = AlbumStub.Album;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);

                //ACT
                var artistInsert = artistService.InsertArtistAsync(artist);
                album.ArtistId = artistInsert.Result.Id;
                var albumInsert = albumService
                    .InsertAlbumAsync(album);

                var result = albumService.GetAlbum(albumInsert.Result.Id);

                //ASSERT
                result.Result.Should().NotBeNull();
      
            }
        }

        [TestMethod]
        public void Should_Delete_Album()
        {
             //ARRAGEN
            var artist = ArtistStub.Artist;
            var album = AlbumStub.Album;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                AlbumService albumService = new AlbumService(context);
                ArtistService artistService = new ArtistService(context);

                //ACT
                var artistInsert = artistService.InsertArtistAsync(artist);
                album.ArtistId = artistInsert.Result.Id;
                var albumInsert = albumService
                    .InsertAlbumAsync(album);

                var result = albumService.DeleteAlbumAsync(albumInsert.Result.Id);

                //ASSERT
                result.Result.Should().BeTrue();
            }
        }
    }
}
