using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.src.Domain.Core;

namespace MediaPlayer.src.Domain.RepositoryInterface
{
    public interface IMediaRepository
    {
        void Play(int fileId);
        void Pause(int fileId);
        void Stop(int fileId);
        bool CreateNewFile(string fileName, string filePath, TimeSpan duration);
        MediaFile? CreateAudioFile(string fileName, string filePath, TimeSpan duration);
        MediaFile? CreateVideoFile(string fileName, string filePath, TimeSpan duration);
        bool DeleteFileById(int fileId);
        string GetAllFiles();
        MediaFile? GetFileById(int fileId);
    }
}