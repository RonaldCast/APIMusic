using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ArtistService;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.ServicesStub;

namespace UnitTest
{
    [TestClass]
    public class ArtistServiceTest
    {
        private SqlLifeFake _sqlLifeFake;

     

        [TestInitialize]
        public void Init()
        {
            _sqlLifeFake = new SqlLifeFake();
        }

        [TestMethod]
        public void Should_Insert_Artist()
        {
            //ARRANGE
            var artist = ArtistStub.Artist;

            using(var context = _sqlLifeFake.GetDbContext())
            {
                ArtistService artistService = new ArtistService(context);

                //ACT
                var result = artistService.InsertArtistAsync(artist);

                //ASSERT
                result.Result.NameArtist.Should().Be(ArtistStub.Artist.NameArtist);
            }
        }

        [TestMethod]
        public void Should_Update_Artist()
        {
            //ARRANGE
            var artist = ArtistStub.Artist;
            var newInfoArtist = ArtistStub.UpdateArtist;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                //ACT
                ArtistService artistService = new ArtistService(context);
                var oldArtist = artistService.InsertArtistAsync(artist);
                var result = artistService
                    .UpdateArtistAsync(oldArtist.Result.Id, newInfoArtist);

                //ASSERT
                result.Result.Country.Should().Be(newInfoArtist.Country);

            }
        }

        [TestMethod]
        public void Should_Get_Artist_Be_Id()
        {
            //ARRAGEN
            var artist = ArtistStub.Artist;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                ArtistService artistService = new ArtistService(context);

                //ACT
                var newArtist = artistService.InsertArtistAsync(artist);
                var result = artistService.GetArtistAsync(newArtist.Result.Id);

                //ASSERT
                result.Result.NameArtist.Should().NotBeNullOrEmpty();
            }
        }

        [TestMethod]
        public  void Should_Get_All_Artists()
        {
            //  ARRANGE
            var artists = ArtistStub.ListArtist;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                ArtistService artistService = new ArtistService(context);

                var first = artistService.InsertArtistAsync(artists[0]);
                var second = artistService.InsertArtistAsync(artists[1]);
                var Thrid = artistService.InsertArtistAsync(artists[2]);
                var Fourth = artistService.InsertArtistAsync(artists[3]);

                var result = artistService.GetAllArtistAsync();

                result.Result.Should().HaveCount(4);
            }
        }
    }
}
