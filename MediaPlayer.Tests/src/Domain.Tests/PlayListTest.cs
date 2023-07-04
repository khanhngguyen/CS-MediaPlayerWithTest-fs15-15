using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Tests.src.Domain.Tests
{
    public class PlayListTest
    {
        public PlayListTest() {}
        
        [Fact]
        public void Constructor_ValidData_CreateNewPlayList()
        {
            var user = User.Instance;
            int userId = user.GetId;
            PlayList playlist = new("Pop songs", userId);

            Assert.Equal("Pop songs", playlist.ListName);
        }

        [Fact]
        public void AddNewFile_ValidFile_AddSuccess()
        {
            var user = User.Instance;
            int userId = user.GetId;
            PlayList playlist = new("Pop songs", userId);
            Audio song1 = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));

            Assert.True(playlist.AddNewFile(song1, userId));
        }

        [Fact]
        public void AddNewFile_InvalidUser_AddFail()
        {
            var user = User.Instance;
            int userId = user.GetId;
            PlayList playlist = new("Pop songs", userId);
            Audio song1 = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));
            var stringWriter = new StringWriter();
            stringWriter.Write("Invalid user");

            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.False(playlist.AddNewFile(song1, 10));
            Assert.Equal("Invalid user", output);
        }

        [Fact]
        public void RemoveFile_ValidFile_RemoveSuccess()
        {
            var user = User.Instance;
            int userId = user.GetId;
            PlayList playlist = new("Pop songs", userId);
            Audio song1 = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));

            Assert.True(playlist.AddNewFile(song1, userId));
            Assert.True(playlist.RemoveFile(song1, userId));
        }

        [Fact]
        public void RemoveFile_InValidFile_RemoveFail()
        {
            var user = User.Instance;
            int userId = user.GetId;
            PlayList playlist = new("Pop songs", userId);
            Audio song1 = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));
            
            Assert.False(playlist.RemoveFile(song1, userId));
        }

        [Fact]
        public void EmptyList_ValidUser_EmptySuccess()
        {
            var user = User.Instance;
            int userId = user.GetId;
            PlayList playlist = new("Pop songs", userId);
            Audio song1 = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));
            
            playlist.AddNewFile(song1, userId);
            Assert.True(playlist.EmptyList(userId));
            Assert.Equal($"0 files in Playlist {playlist.ListName}", playlist.GetAllFiles());
        }

        [Fact]
        public void EmptyList_InValidUser_EmptyFail()
        {
            var user = User.Instance;
            int userId = user.GetId;
            PlayList playlist = new("Pop songs", userId);
            var stringWriter = new StringWriter();
            stringWriter.Write("Invalid user");

            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();
            
            Assert.False(playlist.EmptyList(10));
            Assert.Equal("Invalid user", output);
        }

        [Fact]
        public void GetAllFiles_WithValidFiles_ReturnAllFiles()
        {
            var user = User.Instance;
            int userId = user.GetId;
            PlayList playlist = new("Pop songs", userId);
            Audio song1 = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));
            var stringWriter = new StringWriter();

            playlist.AddNewFile(song1, userId);

            stringWriter.Write($"All files in Playlist: {playlist.ListName}");
            stringWriter.Write($"\n{song1.FileName}");
            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.Equal("All files in Playlist: Pop songs\nSong 1", output);
        }
    }
}