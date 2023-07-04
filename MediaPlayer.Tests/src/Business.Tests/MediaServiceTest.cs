using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using MediaPlayer.Business.src.ServiceInterface;
using MediaPlayer.Domain.src.RepositoryInterface;
using MediaPlayer.Domain.src.Core;
using MediaPlayer.Business.src.Service;

namespace MediaPlayer.Tests.src.Business.Tests
{
    public class MediaServiceTest
    {
        private readonly IMediaService _mediaService;
        private readonly Mock<IMediaRepository> _mockMediaRepository;

        public MediaServiceTest()
        {
            _mockMediaRepository = new();
            _mediaService = new MediaService(_mockMediaRepository.Object);
        }

        [Fact]
        public void CreateNewFile_ValidFile_CreateNewFileWithType()
        {
            _mockMediaRepository.Setup(x => x.CreateAudioFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
                .Returns((string name, string path, TimeSpan duration) => new Audio(name, path, duration));
            _mockMediaRepository.Setup(x => x.CreateVideoFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
                .Returns((string name, string path, TimeSpan duration) => new Video(name, path, duration));

            var song = _mediaService.CreateNewFile("Song 1", "song1.mp3", TimeSpan.FromMinutes(3), "audio");
            var video = _mediaService.CreateNewFile("Video 1", "video1.mp3", TimeSpan.FromMinutes(3), "video");

            Assert.NotNull(song);
            Assert.NotNull(video);
            _mockMediaRepository.Verify(x => x.CreateAudioFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()), Times.Once);
            _mockMediaRepository.Verify(x => x.CreateVideoFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()), Times.Once);
            Assert.IsType<Audio>(song);
            Assert.IsType<Video>(video);
        }

        [Fact]
        public void DeleteFileById_ValidId_DeleteSuccess()
        {
            _mockMediaRepository.Setup(x => x.CreateAudioFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
                .Returns((string name, string path, TimeSpan duration) => new Audio(name, path, duration));
            _mockMediaRepository.Setup(x => x.DeleteFileById(It.IsAny<int>()))
                .Returns((int id) => true);
            var song = _mediaService.CreateNewFile("Song 1", "song1.mp3", TimeSpan.FromMinutes(3), "audio");

            Assert.NotNull(song);
            Assert.True(_mediaService.DeleteFileById(song.GetId));
            _mockMediaRepository.Verify(x => x.DeleteFileById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void DeleteFileById_InValidId_DeleteFail()
        {
            _mockMediaRepository.Setup(x => x.DeleteFileById(It.IsAny<int>()))
                .Returns((int id) => false);

            Assert.False(_mediaService.DeleteFileById(6));
            _mockMediaRepository.Verify(x => x.DeleteFileById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetAllFiles_ValidFiles_ReturnAllFiles()
        {
            string text = string.Empty;
            _mockMediaRepository.Setup(x => x.GetAllFiles()).Returns(() => text);

            _mediaService.CreateNewFile("Song 1", "song1.mp3", TimeSpan.FromMinutes(3), "audio");
            _mediaService.CreateNewFile("Video 1", "video1.mp3", TimeSpan.FromMinutes(3), "video");
            text = "All files: \nSong 1.\nVideo 1.";
            
            Assert.Equal(text, _mediaService.GetAllFiles());
        }

        [Fact]
        public void GetAllFiles_EmptyFiles_ReturnNoFiles()
        {
            string text = string.Empty;
            _mockMediaRepository.Setup(x => x.GetAllFiles()).Returns(() => text);

            text = "All files:\n0 files to show";
            
            Assert.Equal(text, _mediaService.GetAllFiles());
        }

        [Fact]
        public void GetFileById_ValidId_ReturnFile()
        {
            _mockMediaRepository.Setup(x => x.CreateAudioFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
                .Returns((string name, string path, TimeSpan duration) => new Audio(name, path, duration));
            
            var song = _mediaService.CreateNewFile("Song 1", "song1.mp3", TimeSpan.FromMinutes(3), "audio");
            
            Assert.NotNull(song);

            var songId = song.GetId;
            _mockMediaRepository.Setup(x => x.GetFileById(It.IsAny<int>())).Returns((int id) => song);

            var found = _mediaService.GetFileById(songId);

            Assert.NotNull(found);
            Assert.Equal(song, found);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(100)]
        public void GetFileById_InvalidValidId_ReturnNull(int id)
        {
            _mockMediaRepository.Setup(x => x.GetFileById(It.IsAny<int>())).Returns((int id) => null);

            var found = _mediaService.GetFileById(id);

            Assert.Null(found);
        }
    }
}