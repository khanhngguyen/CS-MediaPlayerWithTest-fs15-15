using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MediaPlayer.Domain.src.Core;
using MediaPlayer.Infrastructure.src.Repository;

namespace MediaPlayer.Tests.src.Infrastructure.Tests
{
    public class PlayListRepositoryTest
    {
        private readonly PlayListRepository _playlistRepository = new();
        private readonly User _user = User.Instance;
        private readonly Audio _audio = new("Song 1", "song1.mp3", TimeSpan.FromMinutes(3));
        public PlayListRepositoryTest() {}

        [Fact]
        public void AddNewFile_ValidFile_AddSuccess()
        {
            PlayList playList = new("Playlist 1", _user.GetId);

            Assert.True(_playlistRepository.AddNewFile(playList, _audio, _user.GetId));
        }

        [Fact]
        public void AddNewFile_ExistedFile_AddFail()
        {
            PlayList playList = new("Playlist 1", _user.GetId);
            _playlistRepository.AddNewFile(playList, _audio, _user.GetId);

            Assert.False(_playlistRepository.AddNewFile(playList, _audio, _user.GetId));
        }

        [Fact]
        public void RemoveFile_ValidFile_RemoveSuccess()
        {
            PlayList playList = new("Playlist 1", _user.GetId);

            _playlistRepository.AddNewFile(playList, _audio, _user.GetId);

            Assert.True(_playlistRepository.RemoveFile(playList, _audio, _user.GetId));
        }

        [Fact]
        public void RemoveFile_InvalidFile_ReturnFalse()
        {
            PlayList playList = new("Playlist 1", _user.GetId);

            Assert.False(_playlistRepository.RemoveFile(playList, _audio, _user.GetId));
        }

        [Fact]
        public void EmptyList_AllScenario_ReturnAccordingText()
        {
            PlayList playList = new("Playlist 1", _user.GetId);

            _playlistRepository.AddNewFile(playList, _audio, _user.GetId);

            Assert.Equal($"All files in Playlist: {playList.ListName}\n{_audio.FileName}", _playlistRepository.GetAllFiles(playList));

            _playlistRepository.EmptyList(playList, _user.GetId);
            
            Assert.Equal($"0 files in Playlist {playList.ListName}", _playlistRepository.GetAllFiles(playList));
        }
    }
}