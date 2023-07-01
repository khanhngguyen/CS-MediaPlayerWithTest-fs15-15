using MediaPlayer.src.Application;
using MediaPlayer.src.Business.Sevice;
using MediaPlayer.src.Domain.Core;
using MediaPlayer.src.Infrastructure.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        // how client interact with application - via controllers
        var user = User.Instance;
        var userRepository = new UserRepository();
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
        var video1 = mediaController.CreateNewFile("Video1", "video1.mov", new TimeSpan(0, 5, 10), "video");
        Console.WriteLine(video1?.GetType());
        Console.WriteLine(video1?.GetId);
        Console.WriteLine(video1?.Speed);
        Console.WriteLine(video1?.Duration);
    }
}