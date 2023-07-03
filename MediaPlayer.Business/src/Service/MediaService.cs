using MediaPlayer.Business.src.ServiceInterface;
using MediaPlayer.Domain.src.Core;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Business.src.Service
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository; 
        }

        public MediaFile? CreateNewFile(string fileName, string filePath, TimeSpan duration, string type)
        {
            if (type == "audio")
            {
                return _mediaRepository.CreateAudioFile(fileName, filePath, duration);
            }
            else return _mediaRepository.CreateVideoFile(fileName, filePath, duration);
        }

        public bool DeleteFileById(int id)
        {
            return _mediaRepository.DeleteFileById(id);
        }

        public string GetAllFiles()
        {
            return _mediaRepository.GetAllFiles();
        }

        public MediaFile? GetFileById(int id)
        {
            return _mediaRepository.GetFileById(id);
        }
    }
}