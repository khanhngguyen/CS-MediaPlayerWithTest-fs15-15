using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.src.Business.ServiceInterface;
using MediaPlayer.src.Domain.Core;

namespace MediaPlayer.src.Application
{
    public class MediaController
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public MediaFile? CreateNewFile(string fileName, string filePath, TimeSpan duration, string type)
        {
            if (type == "audio" || type == "video") return _mediaService.CreateNewFile(fileName, filePath, duration, type);
            else throw new ArgumentException("type can only be \"audio\" or \"video\"");
            // else return _mediaService.CreateNewFile(fileName, filePath, duration, type);
        }

        public bool DeleteFileById(int id)
        {
            return _mediaService.DeleteFileById(id);
        }

        public string GetAllFiles()
        {
            return _mediaService.GetAllFiles();
        }

        public MediaFile? GetFileById(int id)
        {
            return _mediaService.GetFileById(id);
        }
    }
}