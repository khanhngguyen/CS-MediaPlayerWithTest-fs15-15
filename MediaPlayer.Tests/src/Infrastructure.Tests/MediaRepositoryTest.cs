using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MediaPlayer.Infrastructure.src.Repository;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Tests.src.Infrastructure.Tests
{
    public class MediaRepositoryTest
    {
        public MediaRepositoryTest()
        {
            
        }

        [Fact]
        public void CreateNewFile_ValidData_ReturnMediaFile()
        {
            var mediaRepository = new MediaRepository();
            var song = mediaRepository.CreateAudioFile("Song 1","song1.mp3", TimeSpan.FromMinutes(3));
            var video = mediaRepository.CreateVideoFile("Video 1", "video1.mov", TimeSpan.FromMinutes(2));

            Assert.NotNull(song); 
            Assert.NotNull(video);
            Assert.IsType<Audio>(song);
            Assert.IsType<Video>(video);
            Assert.Equal("Song 1", song.FileName);
            Assert.Equal("song1.mp3", song.FilePath);
            Assert.Equal(TimeSpan.FromMinutes(3), song.Duration);
            Assert.Equal(1, song.Speed);
            Assert.Equal("Video 1", video.FileName);
            Assert.Equal("video1.mov", video.FilePath);
            Assert.Equal(TimeSpan.FromMinutes(2), video.Duration);
        }

        [Fact]
        public void DeleteFileById_ValidId_DeleteSuccess()
        {
            var mediaRepository = new MediaRepository();
            var song = mediaRepository.CreateAudioFile("Song 1","song1.mp3", TimeSpan.FromMinutes(3));

            Assert.NotNull(song);
            Assert.True(mediaRepository.DeleteFileById(song.GetId));
        }

        [Fact]
        public void DeleteFileById_InValidId_DeleteFail()
        {
            var mediaRepository = new MediaRepository();

            Assert.False(mediaRepository.DeleteFileById(0));
        }

        [Fact]
        public void GetAllFiles_AllScenario_ReturnCorrectly()
        {
            var mediaRepository = new MediaRepository();

            Assert.Equal("All files:\n0 files to show", mediaRepository.GetAllFiles());

            var song = mediaRepository.CreateAudioFile("Song 1","song1.mp3", TimeSpan.FromMinutes(3));

            Assert.NotNull(song);
            Assert.Equal($"All files:\n{song?.FileName}.", mediaRepository.GetAllFiles());
        }

        [Fact]
        public void GetFileById_ValidId_ReturnFile()
        {
            var mediaRepository = new MediaRepository();
            var song = mediaRepository.CreateAudioFile("Song 1","song1.mp3", TimeSpan.FromMinutes(3));

            Assert.NotNull(song);

            var songId = song.GetId;
            var found = mediaRepository.GetFileById(songId);

            Assert.NotNull(found);
            Assert.Equal(song, found);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(-1)]
        public void GetFileById_InValidId_ReturnNull(int id)
        {
            var mediaRepository = new MediaRepository();
    
            var found = mediaRepository.GetFileById(id);

            Assert.Null(found);
        }
    }
}