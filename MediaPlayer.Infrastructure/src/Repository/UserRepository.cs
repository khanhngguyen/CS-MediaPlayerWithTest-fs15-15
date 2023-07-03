using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Domain.src.Core;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Infrastructure.src.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Dictionary<int, User> _users = new();

        public UserRepository(User user)
        {
            _users.Add(user.GetId, user);
        }

        public PlayList? AddNewList(string name, int userId)
        {
            User user = _users[userId];
            PlayList list = new(name, userId);
            if (user.AddNewList(list)) return list;
            else return null;
        }

        public bool RemoveOneList(int listId, int userId)
        {
            User user = _users[userId];
            var playlist = user.GetListById(listId);
            if (playlist != null) return user.RemoveOneList(playlist);
            else 
            {
                Console.WriteLine("Can not remove, user does not have playlist to remove");
                return false;
            }
        }

        public bool RemoveAllLists(int userId)
        {
            User user = _users[userId];
            return user.RemoveAllLists();
        }

        public bool EmptyOneList(int listId, int userId)
        {
            User user = _users[userId];
            var playlist = user.GetListById(listId);
            if (playlist != null) return user.EmptyOneList(playlist);
            else 
            {
                Console.WriteLine("Can not empty, playlist is not found");
                return false;
            }
        }

        public string GetAllList(int userId)
        {
            return _users[userId].GetAllList();
        }

        public PlayList? GetListById(int listId, int userId)
        {
            User user = _users[userId];
            return user.GetListById(listId);
        }
    }
}