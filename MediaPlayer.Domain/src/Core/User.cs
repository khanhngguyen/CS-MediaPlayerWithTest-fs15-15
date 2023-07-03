namespace MediaPlayer.Domain.src.Core
{
    public class User : BaseEntity
    {
        private readonly List<PlayList> _lists = new();
        private static readonly Lazy<User> lazyInstance = new(() => new User());

        public string Name { get; set; } = string.Empty;

        private User(){}

        public static User Instance => lazyInstance.Value;

        public bool AddNewList(PlayList list)
        {
            if (_lists.Contains(list))
            {
                Console.WriteLine($"Playlist {list.ListName} already exists");
                return false;
            }
            else 
            {
                _lists.Add(list);
                return true;
            }
        }

        public bool RemoveOneList(PlayList list)
        {
            return _lists.Remove(list);
        }

        public bool EmptyOneList(PlayList list)
        {
            if (_lists.Contains(list))
                return list.EmptyList(GetId);
            else
                {
                    Console.WriteLine($"Can not empty, {list.ListName} is not found");
                    return false;
                }
        }

        public string GetAllList()
        {
            string text = "All Playlists:";
            if (_lists.Count == 0)
            {
                text += "\n0 playlist to show";
            }
            else
            {
                foreach (PlayList list in _lists)
                {
                    text += $"\n{list.ListName}";
                }
            }
            return text;
        }

        public PlayList? GetListById(int listId)
        {
            var list = _lists.Find(l => l.GetId == listId);
            if (list != null) return list;
            else return null;
        }

        public bool RemoveAllLists()
        {
            if (_lists.Count == 0)
            {
                Console.WriteLine("0 playlist to remove");
                return false;
            }
            else 
            {
                _lists.Clear();
                return true;
            }
        }
    }
}