using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Tests.src.Domain.Tests
{
    public class AudioTest
    {
        [Fact]
        public void Constructor_ValidData_CreateNewAudio()
        {
            Audio audio = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));

            Assert.Equal("Song 1", audio.FileName);
            Assert.Equal("song1.mp3", audio.FilePath);
            Assert.Equal(1, audio.Speed);
            Assert.True(audio.Duration.Equals(new TimeSpan(0, 3, 10)));
            Assert.IsType<Audio>(audio);
        }

        [Fact]
        public void Play_Valid_MediaFilePlay()
        {
            Audio audio = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));
            audio.Play();
            var stringWriter = new StringWriter();
            stringWriter.Write("Playing...");

            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.Equal("Playing...", output);
        }

        [Fact]
        public void Pause_Valid_MediaFilePlay()
        {
            Audio audio = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));
            audio.Pause();
            var stringWriter = new StringWriter();
            stringWriter.Write("Paused.");

            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.Equal("Paused.", output);
        }

        [Fact]
        public void Stop_Valid_MediaFilePlay()
        {
            Audio audio = new("Song 1", "song1.mp3", new TimeSpan(0, 3, 10));
            audio.Stop();
            var stringWriter = new StringWriter();
            stringWriter.Write("Stopped.");

            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.Equal("Stopped.", output);
            Assert.True(audio.CurrentPosition.Equals(new TimeSpan(0)));
        }
    }
}