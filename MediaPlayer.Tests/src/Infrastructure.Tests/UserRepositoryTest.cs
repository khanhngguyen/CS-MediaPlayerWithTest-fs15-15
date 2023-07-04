using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MediaPlayer.Domain.src.Core;
using MediaPlayer.Infrastructure.src.Repository;

namespace MediaPlayer.Tests.src.Infrastructure.Tests
{
    public class UserRepositoryTest
    {
        private readonly User _user = User.Instance;
        private readonly UserRepository _userRepository;
        // private readonly PlayList _playlist;

        public UserRepositoryTest()
        {
            _userRepository = new(_user);
            _user.RemoveAllLists();
            // _playlist = new("Playlist 1", _user.GetId);
        }

        [Fact]
        public void AddNewList_ValidList_AddSuccess()
        {
            var playlist = _userRepository.AddNewList("Playlist 1", _user.GetId);

            Assert.NotNull(playlist);
            Assert.Equal("Playlist 1", playlist.ListName);
        }

        [Fact]
        public void RemoveOneListValidList_RemoveSuccess()
        {
            var playlist = _userRepository.AddNewList("Playlist 1", _user.GetId);

            Assert.NotNull(playlist);
            Assert.True(_userRepository.RemoveOneList(playlist.GetId, _user.GetId));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(15)]
        public void RemoveOneList_InValidList_RemoveFail(int id)
        {
            Assert.False(_userRepository.RemoveOneList(id, _user.GetId));
        }

        [Fact]
        public void RemoveAllLists_ValidLists_RemoveSuccess()
        {
            _userRepository.AddNewList("Playlist 1", _user.GetId);

            Assert.True(_userRepository.RemoveAllLists(_user.GetId));
        }

        [Fact]
        public void RemoveAllLists_EmptyList_RemoveFail()
        {
            var stringWriter = new StringWriter();
            stringWriter.Write("0 playlist to remove");
            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.False(_userRepository.RemoveAllLists(_user.GetId));
            Assert.Equal("0 playlist to remove", output);
        }

        [Fact]
        public void EmptyOneList_ValidList_EmptySuccess()
        {
            var playlist = _userRepository.AddNewList("Playlist 1", _user.GetId);
            
            Assert.NotNull(playlist);
            Assert.True(_userRepository.EmptyOneList(playlist.GetId, _user.GetId));
        }

        [Fact]
        public void EmptyOneList_InValidList_EmptySuccess()
        {
            var stringWriter = new StringWriter();
            stringWriter.Write("Can not empty, playlist is not found");
            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();
            
            Assert.False(_userRepository.EmptyOneList(10, _user.GetId));
            Assert.Equal("Can not empty, playlist is not found", output);
        }

        [Fact]
        public void GetAllList_AllScenario_ReturnAccordingText()
        {
            Assert.Equal("All Playlists:\n0 playlist to show", _userRepository.GetAllList(_user.GetId));

            _userRepository.AddNewList("Playlist 1", _user.GetId);

            Assert.Equal("All Playlists:\nPlaylist 1", _userRepository.GetAllList(_user.GetId));
        }

        // [Fact]
        // public void GetAllList_ValidPlaylist_ReturnAccordingText()
        // {
        //     _userRepository.AddNewList("Playlist 1", _user.GetId);

        //     Assert.Equal("All Playlists:\nPlaylist 1", _userRepository.GetAllList(_user.GetId));
        // }

        [Fact]
        public void GetListById_ValidId_ReturnPlaylist()
        {
            var playlist = _userRepository.AddNewList("Playlist 1", _user.GetId);

            Assert.NotNull(playlist);
            var found = _userRepository.GetListById(playlist.GetId, _user.GetId);

            Assert.NotNull(found);
            Assert.Equal(playlist, found);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(20)]
        public void GetListById_InValidId_ReturnNull(int id)
        {
            var found = _userRepository.GetListById(id, _user.GetId);

            Assert.Null(found);
        }
    }
}