using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Business.src.ServiceInterface
{
    public interface IMediaService
    {
        MediaFile? CreateNewFile(string fileName, string filePath, TimeSpan duration, string type);
        bool DeleteFileById(int id);
        string GetAllFiles();
        MediaFile? GetFileById(int id);
    }
}