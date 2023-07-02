using MediaPlayer.src.Application;
using MediaPlayer.src.Business.Sevice;
using MediaPlayer.src.Domain.Core;
using MediaPlayer.src.Infrastructure.Repository;

internal class Program
{
    private static void Main()
    {
        // how client interact with application - via controllers
        var user = User.Instance;
        var userRepository = new UserRepository(user);
        var userService = new UserService(userRepository);
        var userController = new UserController(userService);
   
        var mediaRepository = new MediaRepository();
        var mediaService = new MediaService(mediaRepository);
        var mediaController = new MediaController(mediaService);

        var playListRepository = new PlayListRepository();
        var playListService = new PlayListService(playListRepository);
        var playListController = new PlayListController(playListService);

        /* command-line interface should be here. All the methods should be used from class controllers only */
        // Audio audio = new("Song 1", "song.mp3", new TimeSpan(0, 3, 10));
        // var audio1 = new Audio("song2", "song2.mp3", new TimeSpan(0, 2, 55));
        // Console.WriteLine(audio.FileName);
        // Console.WriteLine(audio.FilePath);
        // Console.WriteLine(audio.GetId);
        // Console.WriteLine(audio.Speed);
        // Console.WriteLine(audio.Duration);
        // var video = new Video("video1", "video.mov", new TimeSpan(0, 4, 5));
        // Console.WriteLine(video.Duration);
        // Console.WriteLine(video.Speed);
        var song1 = mediaController.CreateNewFile("Song 1", "song1.mp3", new TimeSpan(0, 3, 50), "audio");
        Console.WriteLine(song1?.GetType());
        Console.WriteLine(song1?.GetId);
        Console.WriteLine(song1?.Speed);
        Console.WriteLine(song1?.Duration);
        var video1 = mediaController.CreateNewFile("Video 1", "video1.mov", new TimeSpan(0, 5, 10), "video");
        Console.WriteLine(video1?.GetType());
        Console.WriteLine(video1?.GetId);
        Console.WriteLine(video1?.Speed);
        Console.WriteLine(video1?.Duration);

        // Console.WriteLine(userRepository.GetAllList(user.GetId));
        // var playlist1 = userRepository.AddNewList("Playlist 1", user.GetId);
        // Console.WriteLine(playlist1?.ListName);
        // var playlist2 = userRepository.AddNewList("Playlist 2", user.GetId);
        // Console.WriteLine(playlist1?.GetId);
        // Console.WriteLine(playlist2?.GetId);
        // var playlist2test = userRepository.AddNewList("Playlist 2 test", user.GetId);
        // if (playlist2 != null)
        // {
        //     user.AddNewList(playlist2);
        //     // userRepository.RemoveOneList(playlist2.GetId, user.GetId);
        // }
        // // userRepository.RemoveOneList(100, user.GetId);
        // Console.WriteLine(userRepository.GetAllList(user.GetId));
        // Console.WriteLine(playlist2test?.GetId);

        var playlist1 = userController.AddNewList("Playlist 1", user.GetId);
        var playlist2 = userController.AddNewList("Playlist 2", user.GetId);
        Console.WriteLine(userController.GetAllList(user.GetId));
        userController.RemoveOneList(3, user.GetId);
        Console.WriteLine(userController.GetAllList(user.GetId));

        if (playlist1 != null && song1 != null && video1 != null)
        {
            playListController.AddNewFile(playlist1, song1, user.GetId);
            playListController.AddNewFile(playlist1, video1, user.GetId);
            Console.WriteLine(playListController.GetAllFiles(playlist1));
            playListController.RemoveFile(playlist1, video1, user.GetId);
            Console.WriteLine(playListController.GetAllFiles(playlist1));
        }
    }
}