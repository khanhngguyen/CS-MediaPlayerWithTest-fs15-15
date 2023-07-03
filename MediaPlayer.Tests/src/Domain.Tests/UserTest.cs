using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Tests.src.Domain.Tests
{
    public class UserTest
    {
        [Fact]
        public void CreateInstance_MultipleInstances_ReturnSingletonUser()
        {
            var user1 = User.Instance;
            var user2 = User.Instance;
            Assert.Equal(user1, user2);
        }

        [Fact]
        public void AddNewList_ValidList_AddSuccess()
        {
            var user = User.Instance;
            PlayList playlist = new("Pop songs", user.GetId);

            Assert.True(user.AddNewList(playlist));
            Assert.Equal($"All Playlists:\n{playlist.ListName}", user.GetAllList());
        }

        [Fact]
        public void AddNewList_ExistedList_AddFail()
        {
            var user = User.Instance;
            PlayList playlist = new("Pop songs", user.GetId);
            var stringWriter = new StringWriter();

            Assert.True(user.AddNewList(playlist));
            Assert.False(user.AddNewList(playlist));

            stringWriter.Write($"Playlist {playlist.ListName} already exists");
            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();
            
            Assert.Equal($"Playlist {playlist.ListName} already exists", output);
        }

        [Fact]
        public void GetAllList_ListIsEmpty_ReturnEmptyList()
        {
            var user = User.Instance;

            user.RemoveAllLists(); 

            Assert.Equal($"All Playlists:\n0 playlist to show", user.GetAllList());
        }

        [Fact]
        public void RemoveOneList_ValidList_RemoveSuccess()
        {
            var user = User.Instance;
            PlayList playlist = new("Pop songs", user.GetId);

            user.AddNewList(playlist);

            Assert.True(user.RemoveOneList(playlist));
        }

        [Fact]
        public void RemoveOneList_InValidList_RemoveFail()
        {
            var user = User.Instance;
            PlayList playlist = new("Pop songs", user.GetId);

            Assert.False(user.RemoveOneList(playlist));
        }

        [Fact]
        public void EmptyOneList_InValidList_EmptyFail()
        {
            var user = User.Instance;
            PlayList playlist = new("Pop songs", user.GetId);
            var stringWriter = new StringWriter();

            Assert.False(user.EmptyOneList(playlist));

            stringWriter.Write($"Can not empty, {playlist.ListName} is not found");
            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.Equal($"Can not empty, {playlist.ListName} is not found", output);
        }

        [Fact]
        public void GetListById_InvalidList_RetunNull()
        {
            var user = User.Instance;
            PlayList playlist = new("Pop songs", user.GetId);

            Assert.Null(user.GetListById(playlist.GetId));
        }

        [Fact]
        public void GetListById_ValidList_RetunFoundList()
        {
            var user = User.Instance;
            PlayList playlist = new("Pop songs", user.GetId);

            Assert.True(user.AddNewList(playlist));

            var listId = playlist.GetId;
            var found = user.GetListById(listId);

            Assert.NotNull(found);
            Assert.Equal(playlist, found);
        }

        [Fact]
        public void RemoveAllLists_AllScenarios_ReturnAccordingly()
        {
            var user = User.Instance;
            var stringWriter = new StringWriter();
            stringWriter.Write("0 playlist to remove");
            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.False(user.RemoveAllLists());
            Assert.Equal("0 playlist to remove", output);

            PlayList playlist = new("Pop songs", user.GetId);

            user.AddNewList(playlist);
            Assert.True(user.RemoveAllLists());
            Assert.Equal("All Playlists:\n0 playlist to show", user.GetAllList());
        }
    }
}