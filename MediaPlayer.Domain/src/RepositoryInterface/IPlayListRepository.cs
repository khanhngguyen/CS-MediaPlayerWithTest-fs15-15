using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Domain.src.RepositoryInterface
{
    public interface IPlayListRepository
    {
        bool AddNewFile(PlayList playList, MediaFile file, int userId);
        bool RemoveFile(PlayList list, MediaFile file, int userId);
        bool EmptyList(PlayList playList, int userId);
        string GetAllFiles(PlayList list);
    }
}