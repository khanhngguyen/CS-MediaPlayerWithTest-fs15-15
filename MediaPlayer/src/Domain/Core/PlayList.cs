namespace MediaPlayer.src.Domain.Core
{
    public class PlayList : BaseEntity
    {
        private readonly HashSet<MediaFile> _files = new();
        private readonly int _userId;

        public string ListName { get; set; }

        public PlayList(string name, int userId)
        {
            ListName = name;
            _userId = userId;
        }

        public bool AddNewFile(MediaFile file, int userId)
        {
            if (CheckUserId(userId))
            {
                return _files.Add(file);
            }
            else
            {
                Console.WriteLine("Invalid user");
                return false;
            }
        }

        public bool RemoveFile(MediaFile file, int userId)
        {
            if (CheckUserId(userId))
            {
                return _files.Remove(file);
            }
            else 
            {
                Console.WriteLine("Invalid user");
                return false;
            }
        }

        public bool EmptyList(int userId)
        {
            if (CheckUserId(userId))
            {
                _files.Clear();
                return true;
            }
            else 
            {
                Console.WriteLine("Invalid user");
                return false;
            }
        }

        public string GetAllFiles()
        {
            if (_files.Count == 0) return $"O files in Playlist {ListName}";
            else
            {
                string text = $"All files in Playlist: {ListName}";
                foreach (var file in _files)
                {
                    text += $"\n{file.FileName}";
                }
                return text;
            }
        }

        private bool CheckUserId(int userId)
        {
            if (userId == _userId) return true;
            return false;
        }
    }
}