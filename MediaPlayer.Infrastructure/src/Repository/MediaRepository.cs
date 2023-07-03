using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Domain.src.Core;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Infrastructure.src.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly Dictionary<int, MediaFile> _files = new();

        public bool CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {
            throw new NotImplementedException();
        }

        public MediaFile? CreateAudioFile(string fileName, string filePath, TimeSpan duration)
        {
            Audio file = new(fileName, filePath, duration);
            if (_files.ContainsKey(file.GetId))
            {
                Console.WriteLine("File already existed");
                return null;
            }
            else 
            {
                _files.Add(file.GetId, file);
                return file;
            }
        }

        public MediaFile? CreateVideoFile(string fileName, string filePath, TimeSpan duration)
        {
            Video file = new(fileName, filePath, duration);
            if (_files.ContainsKey(file.GetId))
            {
                Console.WriteLine("File already existed");
                return null;
            }
            else 
            {
                _files.Add(file.GetId, file);
                return file;
            }
        }

        public bool DeleteFileById(int fileId)
        {
            return _files.Remove(fileId);
        }

        public string GetAllFiles()
        {
            string text = "All files:";
            foreach (var (key, value) in _files)
            {
                text += $"\n{value.FileName}.";
            }
            return text;
        }

        public MediaFile? GetFileById(int fileId)
        {
            if (_files.ContainsKey(fileId)) return _files[fileId];
            else return null;
        }

        public void Pause(int fileId)
        {
            var file = GetFileById(fileId);
            file?.Pause();
        }

        public void Play(int fileId)
        {
            var file = GetFileById(fileId);
            file?.Play();
        }

        public void Stop(int fileId)
        {
            var file = GetFileById(fileId);
            file?.Stop();
        }
    }
}