using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Domain.src.Core;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Infrastructure.src.Repository
{
    public class PlayListRepository : IPlayListRepository
    {
        public bool AddNewFile(PlayList playList, MediaFile file, int userId)
        {
            return playList.AddNewFile(file, userId);
        }

        public bool EmptyList(PlayList playList, int userId)
        {
            return playList.EmptyList(userId);
        }

        public bool RemoveFile(PlayList list, MediaFile file, int userId)
        {
            return list.RemoveFile(file, userId);
        }

        public string GetAllFiles(PlayList list)
        {
            return list.GetAllFiles();
        }
    }
}