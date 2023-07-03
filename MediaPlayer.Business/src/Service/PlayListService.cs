using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Business.src.ServiceInterface;
using MediaPlayer.Domain.src.Core;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Business.src.Service
{
    public class PlayListService : IPlayListService
    {
        private readonly IPlayListRepository _playList;

        public PlayListService(IPlayListRepository playList)
        {
            _playList = playList;
        }
        public bool AddNewFile(PlayList playlist, MediaFile file, int userId)
        {
            return _playList.AddNewFile(playlist, file, userId);
        }

        public bool EmptyList(PlayList playlist, int userId)
        {
            return _playList.EmptyList(playlist, userId);
        }

        public bool RemoveFile(PlayList playlist, MediaFile file, int userId)
        {
            return _playList.RemoveFile(playlist, file, userId);
        }
        
        public string GetAllFiles(PlayList list)
        {
            return list.GetAllFiles();
        }
    }
}