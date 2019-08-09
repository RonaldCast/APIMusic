using System;
using System.Collections.Generic;
using System.Text;
using UnitTest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        }

        /*[TestMethod]
        public void Should_Delete_Music()
        {

        }

        [TestMethod]
        public void Should_Get_Music_By_id()
        {

        }

        [TestMethod]
        public void Should_Get_All_Music()
        {

        }
        [TestMethod]
        public void Should_Update_Music()
        {

        } */
    }
}
