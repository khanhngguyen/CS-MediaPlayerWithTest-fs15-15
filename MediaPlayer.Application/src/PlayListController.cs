using MediaPlayer.Business.src.ServiceInterface;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Application.src
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
            if (userId < 0) throw new ArgumentException("user id is invalid");
            else return _playListService.AddNewFile(playlist, file, userId);
        }

        public bool EmptyList(PlayList playlist, int userId)
        {
            if (userId < 0) throw new ArgumentException("user id is invalid");
            else return _playListService.EmptyList(playlist, userId);
        }

        public bool RemoveFile(PlayList playlist, MediaFile file, int userId)
        {
            if (userId < 0) throw new ArgumentException("user id is invalid");
            else return _playListService.RemoveFile(playlist, file, userId);
        }

        public string GetAllFiles(PlayList playlist)
        {
            return playlist.GetAllFiles();
        }
    }
}