using MediaPlayer.src.Business.ServiceInterface;
using MediaPlayer.src.Domain.Core;

namespace MediaPlayer.src.Application
{
    public class PlayListController
    {
        private readonly IPlayListService _playListService;

        public PlayListController(IPlayListService playListService)
        {
            _playListService = playListService;
        }

        public bool AddNewFile(PlayList playlist, MediaFile file, int userId)
        {
            return _playListService.AddNewFile(playlist, file, userId);
        }

        public bool EmptyList(PlayList playlist, int userId)
        {
            return _playListService.EmptyList(playlist, userId);
        }

        public bool RemoveFile(PlayList playlist, MediaFile file, int userId)
        {
            return _playListService.RemoveFile(playlist, file, userId);
        }

        public string GetAllFiles(PlayList playlist)
        {
            return playlist.GetAllFiles();
        }
    }
}