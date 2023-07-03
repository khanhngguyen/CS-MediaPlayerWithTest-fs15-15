using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Tests.src.Domain.Tests
{
    public class VideoTest
    {
        [Fact]
        public void Constructor_ValidData_CreateNewVideo()
        {
            Video video = new("Video 1", "video1.mov", new TimeSpan(0, 5, 15));

            Assert.Equal("Video 1", video.FileName);
            Assert.Equal("video1.mov", video.FilePath);
            Assert.Equal(1, video.Speed);
            Assert.True(video.Duration.Equals(new TimeSpan(0, 5, 15)));
            Assert.IsType<Video>(video);
        }

        [Theory]
        [InlineData(0.25)]
        [InlineData(0.5)]
        [InlineData(1.5)]
        [InlineData(2)]
        public void ChangeSpeed_ValidSpeed_SpeedChanged(double speed)
        {
            Video video = new("Video 1", "video1.mov", new TimeSpan(0, 5, 15));

            video.ChangeSpeed(speed);

            Assert.Equal(video.Speed, speed);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(3.3)]
        public void ChangeSpeed_InvalidSpeed_UnchangedSpeed(double speed)
        {
            Video video = new("Video 1", "video1.mov", new TimeSpan(0, 5, 15));
            ArgumentException exception = Assert.Throws<ArgumentException>(() => video.ChangeSpeed(speed));

            Assert.Throws<ArgumentException>(() => video.ChangeSpeed(speed));
            Assert.Equal("Not a valid speed value", exception.Message);
            Assert.Equal(1, video.Speed);
        }
    }
}