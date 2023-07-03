using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Business.src.ServiceInterface
{
    public interface IPlayListService
    {
        bool AddNewFile(PlayList playlist, MediaFile file, int userId);
        bool RemoveFile(PlayList playlist, MediaFile file, int userId);
        bool EmptyList(PlayList playlist, int userId);
        string GetAllFiles(PlayList list);
    }
}